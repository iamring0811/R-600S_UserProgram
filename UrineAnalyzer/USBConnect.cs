using FTD2XX_NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;


namespace UrineAnalyzer
{


    public static class USBConnect
    {
        static UInt32 ftdiDeviceCount = 0;                                                      //FTDI 연결 기기 수
        static FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;                                  //FTDI 연결 상태 확인 변수
        static FTDI myFtdiDevice = new FTDI();                                                  //FTDI 기기 변수
        static FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[10];    //FTDI 기기목록 수(배열 : 최대 연결 기기 수)
        static UInt32 numBytesWritten = 0;
        static UInt32 numBytesAvailable = 0;
        static UInt32 numBytesRead = 0;
        static string targetpath = Application.StartupPath + @"\Data.accdb";
        static string inStream = "";
        static Boolean dataFlag = false;//220414
        public delegate void StatusHandler();
        public static event StatusHandler Status_cmd;
        public delegate void DataHandler();
        public static event DataHandler result_cmd;
        public delegate void PFHandler();
        public static event PFHandler Pf_cmd;
        public delegate void ConnectHandler();
        public static event ConnectHandler connect_cmd;

        static BackgroundWorker worker = new BackgroundWorker();
        static readonly System.Timers.Timer timer = new System.Timers.Timer();
        public static AutoResetEvent event_1 = new AutoResetEvent(true);
        static object obj = new object();

        public static string _status;
        public static string SN;
        static UInt64 dataCount = 0;
        static uint locId = 0;
        static uint eventType;
        public static uint cnt = 0;

        public static void USBStart()
        {
            //            Thread Autoconnect = new Thread(new ThreadStart(AutoConnect));
            //            Autoconnect.Start();
            AutoConnect();
            Console.WriteLine("USBStart");
        }

        public static void AutoConnect()
        {
            // 타이머 생성 및 시작
            worker.DoWork += new DoWorkEventHandler(worker_Dowork);
            //            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            //timer.Interval = 750;//1 * 1875; // 1000ms/38400bps*120000
            //220414 Start
            if (!Data.chk_Pf)
            {
                timer.Interval = 3000;
            }
            else
            {
                timer.Interval = 750;
            }
            //220414 End
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }


        public static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (Data.datas.Count == 0)
                {
                    if (Data.DelayCnt == 1)
                    {
                        Data.DelayCnt = 0;
                        DataConn.GetDataCommit();
                        DataHandler handler = result_cmd;
                        handler?.Invoke();

                    }
                    else if (Data.DelayCnt > 0)
                    {
                        Data.DelayCnt--;
                    }
                    //                   if (myFtdiDevice.IsOpen == false)
                    //                   {
                    ftStatus = myFtdiDevice.GetEventType(ref eventType);
                    //                   if (ftdiDeviceCount == 0)
                    if (ftStatus != FTDI.FT_STATUS.FT_OK)
                    {
                        inStream = "";
                        try
                        {
                            ftStatus = myFtdiDevice.Close();
                        }
                        catch
                        {
                            ftStatus = myFtdiDevice.ResetDevice();
                        }
                        ConnectDevice();
                        return;
                    }
                    if (myFtdiDevice.IsOpen == false)
                    {
                        StatusSet(Data.iDisconnected);
                        ConnectDevice();
                        return;
                    }
                    //                    }
                }
                //               lock (obj)
                //             {
                if (!worker.IsBusy)
                {
                    worker.RunWorkerAsync();
                    if (Data.datas.Count > 0)
                    {
                        while (Data.datas.Count > 0)
                        {
                            DataHandler handler = result_cmd;
                            handler?.Invoke();
                        }
                    }
                    //220414 Start
                    else if (!Data.chk_Pf)
                    {
                        Data.chk_Pf = true;
                        SendData('q'); //220413
                    }
                    //220414 End
                    else
                    {
                        StatusSet($"{Data.iConnected} : " + SN);
                    }
                }
                //               }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void StatusSet(string cmd)
        {
            Data.StatusData = cmd;
            //            Status_cmd = Status_cmd;
            Status_cmd?.Invoke();

        }

        static void worker_Dowork(object sender, DoWorkEventArgs e)
        {
            lock (obj)
            {
                myFtdiDevice.GetRxBytesAvailable(ref numBytesAvailable);
                if (numBytesAvailable < 1) return;
                byte[] bytes = new byte[numBytesAvailable];
                ftStatus = myFtdiDevice.Read(bytes, numBytesAvailable, ref numBytesRead);
                if (numBytesAvailable == numBytesRead)
                {
                    StatusSet(Data.iReceivingData);
                    string readData = Encoding.Default.GetString(bytes);
                    cnt += numBytesRead;
                    Console.Write("inStream:" + readData);
                    inStream += readData;
                    readData = "";
                    string[] dataSplit = inStream.Split('\n');
                    inStream = "";

                    foreach (string data in dataSplit)
                    {
                        if (data.Length > 0)
                        {
                            if (data.Length == 261)
                            {
                                Data.datas.Enqueue(data);
                                if (Data.DelayCnt < 15) Data.DelayCnt = 2;  //220414
                                dataCount++;
                            }
                            else if (data.Length > 4980)
                            {
                                ReadData(data);
                            }
                            else
                            {
                                inStream = data;
                            }
                        }

                    }
                }
            }
        }



        public static void ConnectDevice()
        {
            ftStatus = myFtdiDevice.GetNumberOfDevices(ref ftdiDeviceCount);
            if (ftStatus == FTDI.FT_STATUS.FT_OK || ftdiDeviceCount > 0)
            {
            }
            else
            {
                StatusSet(Data.iDisconnected);
                Pf_cmd?.Invoke(); //220413
            }
            if (ftdiDeviceCount > 0)
            {
                // Allocate storage for device info list

                ftStatus = myFtdiDevice.GetDeviceList(ftdiDeviceList);
                int i = 0;
                for (i = 0; i < ftdiDeviceCount; i++)
                {
                    ftStatus = myFtdiDevice.OpenByLocation(locId == 0 ? ftdiDeviceList[i].LocId : locId);
                    switch (Data.Get_BaudRate)
                    {
                        case 0:
                            ftStatus = myFtdiDevice.SetBaudRate(9600);
                            break;
                        case 1:
                            ftStatus = myFtdiDevice.SetBaudRate(38400);
                            break;
                        case 2:
                            ftStatus = myFtdiDevice.SetBaudRate(115200);
                            break;
                    }

                    ftStatus = myFtdiDevice.SetDataCharacteristics(FTDI.FT_DATA_BITS.FT_BITS_8, FTDI.FT_STOP_BITS.FT_STOP_BITS_1, FTDI.FT_PARITY.FT_PARITY_NONE);
                    ftStatus = myFtdiDevice.SetFlowControl(FTDI.FT_FLOW_CONTROL.FT_FLOW_NONE, 0x00, 0x00);
                    ftStatus = myFtdiDevice.SetTimeouts(1000, 0);
                    SendData(0x51);
                    Thread.Sleep(100);
                    /*
                    if (ftStatus == FTDI.FT_STATUS.FT_OK)
                    {
                        Console.WriteLine("Data send complete");
                    }
                    else
                    {
                        StatusSet(Data.iDisconnected);
                        myFtdiDevice.Close();
                        return;
                    }
                    */
                    do
                    {
                        ftStatus = myFtdiDevice.GetRxBytesAvailable(ref numBytesAvailable);
                        if (ftStatus != FTDI.FT_STATUS.FT_OK)
                        {
                        }
                        Thread.Sleep(10);
                        //220414 Start
                    } while (numBytesAvailable < 1);
                    if (numBytesAvailable > 0) break;
                    //220414 End
                }

                //220414 Start
                if (!dataFlag)
                {
                    byte[] bytes = new byte[numBytesAvailable];
                    ftStatus = myFtdiDevice.Read(bytes, numBytesAvailable, ref numBytesRead);
                    string readData = Encoding.Default.GetString(bytes);
                    Console.WriteLine("readData:" + readData);
                    //ftStatus = myFtdiDevice.Read(out readData, numBytesAvailable, ref numBytesRead);\
                    if (readData.EndsWith("\n"))
                    {
                        locId = ftdiDeviceList[i].LocId;
                        ReadData(readData);
                        readData = "";
                    }
                }
                //220414 End
            }
            else if (ftdiDeviceCount == 0 || ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                StatusSet(Data.iDisconnected);
                //220413 Start
                if (!Data.chk_Pf && cnt == 0)
                {
                    cnt = 1;
                    Console.WriteLine("USBConncet");
                    Pf_cmd?.Invoke();
                }
                //220413 End
            }
        }


        public static void SendData(int senddata)
        {
            string dataToWrite = "*" + (char)(senddata) + "\n";
            ftStatus = myFtdiDevice.Write(dataToWrite, dataToWrite.Length, ref numBytesWritten);
            Console.WriteLine("DataSend:" + (char)senddata);
        }

        public static void ReadData(string cmd)
        {
            char C = cmd[1];

            try
            {
                if (C.Equals('Q'))
                {
                    //220414 Start
                    dataFlag = true;
                    SN = cmd.Remove(0, 2);
                    StatusSet($"{Data.iConnected} : " + SN);
                    //                    Thread.Sleep(1500);//220413
                    //220414 End7
                }
                else if (C.Equals('q'))
                {
                    string cmd_ = cmd.Remove(0, 2);
                    string cmd_Arb = cmd_.Substring(0, 1660);
                    string cmd_Si = cmd_.Substring(1660, 1660);
                    string cmd_Conv = cmd_.Substring(3320);
                    string unit;
                    string sql;
                    Dictionary<string, string> Grademap = new Dictionary<string, string>();
                    sql = @" SELECT * FROM DB_Table";
                    DataTable itemtable = DataConn.GetDataSet(sql, targetpath).Tables[0];

                    for (int i = 1; i < 10; i++)
                    {
                        Grademap.Add($"Grade{i}", "");
                    }

                    for (int i = 0; i < 20; i++)
                    {
                        int s = 83 * i;
                        int s1 = s + 11;

                        unit = cmd_Arb.Substring(s + 3, 8);
                        if (unit != "        ") unit = unit.Trim();

                        if (i < 13) sql = $"INSERT INTO DB_PrintForm VALUES('{itemtable.Rows[i][1]}', '{unit}'";
                        else sql = $"INSERT INTO DB_PrintForm VALUES(' ', '{unit}'";

                        for (int j = 1; j < 10; j++)
                        {
                            Grademap[$"Grade{i}"] = cmd_Arb.Substring(s1 + 8 * (j - 1), 8);
                            if (Grademap[$"Grade{i}"] != "        ") Grademap[$"Grade{i}"] = Grademap[$"Grade{i}"].Trim();
                            sql += $",'{Grademap[$"Grade{i}"]}'";
                        }

                        sql += $", 'Arb')";
                        DataConn.Getdata(sql);
                        //                        Console.WriteLine(sql);

                    }
                    for (int i = 0; i < 20; i++)
                    {
                        int s = 83 * i;
                        int s1 = s + 11;

                        unit = cmd_Si.Substring(s + 3, 8);
                        if (unit != "        ") unit = unit.Trim();

                        if (i < 13) sql = $"INSERT INTO DB_PrintForm VALUES('{itemtable.Rows[i][1]}', '{unit}'";
                        else sql = $"INSERT INTO DB_PrintForm VALUES(' ', '{unit}'";

                        for (int j = 1; j < 10; j++)
                        {
                            Grademap[$"Grade{i}"] = cmd_Si.Substring(s1 + 8 * (j - 1), 8);
                            if (Grademap[$"Grade{i}"] != "        ") Grademap[$"Grade{i}"] = Grademap[$"Grade{i}"].Trim();
                            sql += $",'{Grademap[$"Grade{i}"]}'";
                        }

                        sql += $", 'Si')";
                        DataConn.Getdata(sql);
                        //                        Console.WriteLine(sql);
                    }
                    for (int i = 0; i < 20; i++)
                    {
                        int s = 83 * i;
                        int s1 = s + 11;

                        unit = cmd_Conv.Substring(s + 3, 8);
                        if (unit != "        ") unit = unit.Trim();

                        if (i < 13) sql = $"INSERT INTO DB_PrintForm VALUES('{itemtable.Rows[i][1]}', '{unit}'";
                        else sql = $"INSERT INTO DB_PrintForm VALUES(' ', '{unit}'";

                        for (int j = 1; j < 10; j++)
                        {
                            Grademap[$"Grade{i}"] = cmd_Conv.Substring(s1 + 8 * (j - 1), 8);
                            if (Grademap[$"Grade{i}"] != "        ") Grademap[$"Grade{i}"] = Grademap[$"Grade{i}"].Trim();
                            sql += $",'{Grademap[$"Grade{i}"]}'";
                        }
                        sql += $", 'Conv')";
                        DataConn.Getdata(sql);
                    }
                    cnt = 0;
                    timer.Interval = 750;//220414
                    connect_cmd?.Invoke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}



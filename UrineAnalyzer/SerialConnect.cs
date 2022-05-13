using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace UrineAnalyzer
{
    static class SerialConnect
    {
        public static SerialPort port;
        static BackgroundWorker worker = new BackgroundWorker();

        public delegate void StatusHandler();
        public static event StatusHandler Status_cmd;
        public delegate void DataHandler();
        public static event DataHandler result_cmd;
        public delegate void PFHandler();       //220413
        public static event PFHandler Pf_cmd;       //220413
        public delegate void ConnectHandler();  //220413
        public static event ConnectHandler connect_cmd; //220413

        private static string inStream = "";
        //   public static string _status = "";
        public static string SN;
        static string targetpath = Application.StartupPath + @"\Data.accdb";
        // static uint delayCnt = 0;
        static bool connectCheck = false;

        static readonly System.Timers.Timer timer = new System.Timers.Timer();
        static readonly System.Timers.Timer timer1 = new System.Timers.Timer(); //220413
        public static uint DelayCnt = 0;

        public static void SerialStart()
        {
            port = new SerialPort(Data.portName);
            switch (Data.Get_BaudRate)
            {
                case 0:
                    port.BaudRate = 9600;
                    break;
                case 1:
                    port.BaudRate = 38400;
                    break;
                case 2:
                    port.BaudRate = 115200;
                    break;
            }
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.Parity = Parity.None;
            port.Handshake = Handshake.None;
            port.ReadTimeout = 1000;
            port.WriteTimeout = 1000;
            Thread thread = new Thread(ConnectionCheck);
            thread.Start();
            //ConnectionCheck();
            Thread.Sleep(1000);
            if (!connectCheck)
            {
                port.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                port.Close();
                Console.WriteLine($"{port.PortName} {Data.iDisconnected}");
                StatusSet(Data.iDisconnected);
                //220413 Start
                if (!Data.chk_Pf)
                {
                    Pf_cmd?.Invoke();
                    timer1.Interval = 2000;
                    timer1.Elapsed += new ElapsedEventHandler(StartConnect);
                    timer1.Start();
                }
            }
        }
        static int cnt = 0;
        public static void StartConnect(object sender, ElapsedEventArgs e)
        {

            port = new SerialPort(Data.portName);
            switch (Data.Get_BaudRate)
            {
                case 0:
                    port.BaudRate = 9600;
                    break;
                case 1:
                    port.BaudRate = 38400;
                    break;
                case 2:
                    port.BaudRate = 115200;
                    break;
            }
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.Parity = Parity.None;
            port.Handshake = Handshake.None;
            port.ReadTimeout = 1000;
            port.WriteTimeout = 1000;
            ConnectionCheck();
            Thread.Sleep(1000);
            if (!connectCheck)
            {
                port.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                port.Close();
                Console.WriteLine($"{port.PortName} {Data.iDisconnected}");
            }
            else
            {
                timer1.Stop();
               // connect_cmd?.Invoke();
            }
            Console.WriteLine($"cnt {cnt++}");
        }
        //220413 End
        public static void ConnectionCheck()
        {
            try
            {
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                port.Open();
                port.WriteLine("*Q\n");
            }
            catch
            {
                port.Close();
                connectCheck = false;
                Console.WriteLine(Data.iDisconnected);
                StatusSet(Data.iDisconnected);
            }
        }

        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (Data.datas.Count > 0 && !worker.IsBusy)
                {
                    worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void worker_Dowork(object sender, DoWorkEventArgs e)
        {
            DataHandler handler = result_cmd;
            handler?.Invoke();
        }

        public static void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            connectCheck = true;
            StatusSet(Data.iReceivingData);
            inStream += port.ReadExisting();
            //Console.WriteLine($"{inStream}");
            string[] dataSplit = inStream.Split('\n');
            inStream = "";
            foreach (string data1 in dataSplit)
            {
                if (data1.Length > 0)
                {
                    if (data1.Length == 261)
                    {
                        //                        Console.WriteLine($"{data.Length} : {data}");
                        Data.datas.Enqueue(data1);
                    }
                    else if (data1 == dataSplit.Last())
                    {
                        inStream = data1;
                    }
                    else
                    {
                        //                        Console.WriteLine($"{data.Length} : {data}");
                        ReadData(data1);
                    }
                }
                else
                {
                    StatusSet($"{Data.iConnected} : {SN}");
                }
            }
        }

        public static void StatusSet(string cmd)
        {
            Data.StatusData = cmd;
            StatusHandler handler = Status_cmd;
            handler?.Invoke();
        }

        public static void ReadData(string cmd)
        {
            char C = cmd[1];
            try
            {
                if (C.Equals('Q'))
                {
                    SN = cmd.Remove(0, 2);
                    //                    StatusSet(Data.lConnect + SN);
                    worker.DoWork += new DoWorkEventHandler(worker_Dowork);

                    timer.Interval = 1000;
                    timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                    timer.Start();
                    Console.WriteLine(port.PortName + Data.iStart);

                    if (!Data.chk_Pf) port.WriteLine("*q\n");
                }
                else if (C.Equals('q'))
                {
                    Console.WriteLine("PrintForm Start");
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
                    connect_cmd?.Invoke();
                }
            }
            catch
            {
            }
        }
    }
}

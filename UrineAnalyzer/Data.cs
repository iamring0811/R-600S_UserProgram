using System;
using System.Collections.Concurrent;
using System.Data;
using System.Drawing;

namespace UrineAnalyzer
{
    public static class Data
    {
        public static readonly string Version = "V1.00.EN.01-220408";

        public static DataTable ListItem = DataConn.GetDataTable("DB_ListItem");
        public static DataTable ListResult = DataConn.GetDataTable("DB_ListResult");
        public static DataTable PadColor = DataConn.GetDataTable("DB_PadColor");
        public static DataTable Patient = DataConn.GetDataTable("DB_Patient");
        public static DataTable PrintForm = DataConn.GetDataTable("DB_PrintForm");
        public static DataTable QCResult = DataConn.GetDataTable("DB_QCResult");
        public static DataTable Result = DataConn.GetDataTable("DB_Result");
        public static DataTable Set = DataConn.GetDataTable("DB_Set");
        public static string Get_Lang = Set.Rows[0]["Lang"].ToString();
        public static DataTable Table = DataConn.GetDataTable("DB_Table");
        public static DataTable User = DataConn.GetDataTable("DB_User");
        //public static DataTable Lang = DataConn.GetDataTable($"DB_Lang WHERE Sort = '{Get_Lang}' ORDER BY SEQ", false, "[Translation]");
        public static DataTable Lang = DataConn.GetDataTable($"DB_Lang WHERE Sort = '{Get_Lang}' ORDER BY SEQ");
        public static DataTable FullLang = DataConn.GetDataTable($"DB_Lang ORDER BY SEQ");

        public static DataRow ListItemRow = ListItem.NewRow();
        public static DataRow ListResultRow = ListResult.NewRow();
        public static DataRow PadColorRow = PadColor.NewRow();
        public static DataRow PatientRow = Patient.NewRow();
        public static DataRow PrintFormRow = PrintForm.NewRow();
        public static DataRow QCResultRow = QCResult.NewRow();
        public static DataRow ResultRow = Result.NewRow();
        public static DataRow SetRow = Set.NewRow();
        public static DataRow TableRow = Table.NewRow();
        public static DataRow UserRow = User.NewRow();
        public static DataRow LangRow = Lang.NewRow();
        public static DataRow FullLangRow = FullLang.NewRow();

        public static readonly Color SysColor = Color.FromArgb(154, 179, 198);
        public static readonly Color PinkColor = Color.FromArgb(255, 193, 214);

        public static bool chk_Pf = (PrintForm.Rows.Count == 0 ? false : true); //220413

        public static Color Get_Neg_back = Color.FromArgb((int) Set.Rows[0]["Neg_Back_R"], (int) Set.Rows[0]["Neg_Back_G"], (int) Set.Rows[0]["Neg_Back_B"]);
        public static Color Get_Neg_fore = Color.FromArgb((int)Set.Rows[0]["Neg_Fore_R"], (int)Set.Rows[0]["Neg_Fore_G"], (int)Set.Rows[0]["Neg_Fore_B"]);
        public static Color Get_Pos_back = Color.FromArgb((int)Set.Rows[0]["Pos_Back_R"], (int)Set.Rows[0]["Pos_Back_G"], (int)Set.Rows[0]["Pos_Back_B"]);
        public static Color Get_Pos_fore = Color.FromArgb((int)Set.Rows[0]["Pos_Fore_R"], (int)Set.Rows[0]["Pos_Fore_G"], (int)Set.Rows[0]["Pos_Fore_B"]);

        public static int Get_Unit = (int)(Set.Rows[0]["Unit"]);
        public static int Get_BaudRate = (int)Set.Rows[0]["BaudRate"];
        public static bool Get_SetStart = ((int)Set.Rows[0]["BaudRate"] < 0 ? true : false);     //220414

        public static uint DelayCnt = 0;

        public static readonly bool USB = false;
        public static readonly bool Serial = true;

        public static bool Get_SerialType = ((int)Set.Rows[0]["Serial"] == 1 ? Serial: USB);
        

        public static readonly int Unit_Arb = 0;
        public static readonly int Unit_Conv = 1;
        public static readonly int Unit_SI = 2;

        public static readonly string aUrineAnalyzer    = Lang.Rows[0]["Translation"].ToString();           //A.Main Urine Analyzer
        public static readonly string bPatient           = Lang.Rows[1]["Translation"].ToString();           //B.Patient   Patient
        public static readonly string bPatientID        = Lang.Rows[2]["Translation"].ToString();           //B-A Patient ID
        public static readonly string bName             = Lang.Rows[3]["Translation"].ToString();           //B-B Name
        public static readonly string bBirthday         = Lang.Rows[4]["Translation"].ToString();           //B-C Birthday
        public static readonly string bSex              = Lang.Rows[5]["Translation"].ToString();           //B-D Sex
        public static readonly string bMale             = Lang.Rows[6]["Translation"].ToString();           //B-E Male
        public static readonly string bFemale       = Lang.Rows[7]["Translation"].ToString();           //B-F FeMale
        public static readonly string bWorning      = Lang.Rows[8]["Translation"].ToString();            //B-G Existing information has been updated.
        public static readonly string cResult           = Lang.Rows[9]["Translation"].ToString();           //C.Result
        public static readonly string cPatientID        = Lang.Rows[10]["Translation"].ToString();           //C-A Patient ID
        public static readonly string cName             = Lang.Rows[11]["Translation"].ToString();           //C-B Name
        public static readonly string cBirthday         = Lang.Rows[12]["Translation"].ToString();           //C-C Birthday
        public static readonly string cSex              = Lang.Rows[13]["Translation"].ToString();          //C-D Sex
        public static readonly string cSEQ              = Lang.Rows[14]["Translation"].ToString();          //C-E SEQ
        public static readonly string cColor            = Lang.Rows[15]["Translation"].ToString();          //C-F Color
        public static readonly string cturbidity        = Lang.Rows[16]["Translation"].ToString();          //C-G Turbidity
        public static readonly string cTestDate         = Lang.Rows[17]["Translation"].ToString();          //C-H Test Date
        public static readonly string cTestTime         = Lang.Rows[18]["Translation"].ToString();          //C-I Test Time
        public static readonly string cStrip            = Lang.Rows[19]["Translation"].ToString();          //C-J Strip
        public static readonly string cOperator         = Lang.Rows[20]["Translation"].ToString();          //C-K Operator
        public static readonly string cItem             = Lang.Rows[21]["Translation"].ToString();          //C-L Item
        public static readonly string cUnit             = Lang.Rows[22]["Translation"].ToString();          //C-M Unit
        public static readonly string cGrade            = Lang.Rows[23]["Translation"].ToString();          //C-N Grade
        public static readonly string cLotNo            = Lang.Rows[24]["Translation"].ToString();          //C-O Lot No.
        public static readonly string cSolution         = Lang.Rows[25]["Translation"].ToString();          //C-P Solution
        public static readonly string cTest             = Lang.Rows[26]["Translation"].ToString();          //C-Q Test
        public static readonly string cMale         = Lang.Rows[27]["Translation"].ToString();          // C-R Male
        public static readonly string cFemale       = Lang.Rows[28]["Translation"].ToString();          //C-S Female
        public static readonly string cGraph        = Lang.Rows[29]["Translation"].ToString();          //C-T Graph
        public static readonly string cList         = Lang.Rows[30]["Translation"].ToString();          //C-U List
        public static readonly string cNegative     = Lang.Rows[31]["Translation"].ToString();          //C-V Negative
        public static readonly string cPositive     = Lang.Rows[32]["Translation"].ToString();          //C-W Positive
        public static readonly string cView          = Lang.Rows[33]["Translation"].ToString();          //C-X View
        public static readonly string cNostrip      = Lang.Rows[34]["Translation"].ToString();          //C-Y NO STRIP
        public static readonly string dSetting          = Lang.Rows[35]["Translation"].ToString();          //D.Setting
        public static readonly string dResultMark       = Lang.Rows[36]["Translation"].ToString();          //D-A Result Mark
        public static readonly string dNeg              = Lang.Rows[37]["Translation"].ToString();          //D-B Neg.
        public static readonly string dPos              = Lang.Rows[38]["Translation"].ToString();          //D-C Pos.
        public static readonly string dForeColor        = Lang.Rows[39]["Translation"].ToString();          //D-D Fore color
        public static readonly string dBackColor        = Lang.Rows[40]["Translation"].ToString();          //D-E Back color
        public static readonly string dUnit             = Lang.Rows[41]["Translation"].ToString();          //D-F Unit
        public static readonly string dArb              = Lang.Rows[42]["Translation"].ToString();          //D-G Arb
        public static readonly string dConv             = Lang.Rows[43]["Translation"].ToString();          //D-H Conv.
        public static readonly string dSI               = Lang.Rows[44]["Translation"].ToString();          //D-I S.I.
        public static readonly string dInterface        = Lang.Rows[45]["Translation"].ToString();          //D-J Interface
        public static readonly string dRS232            = Lang.Rows[46]["Translation"].ToString();          //D-K RS-232
        public static readonly string dBaudrate         = Lang.Rows[47]["Translation"].ToString();          //D-L Baud rate
        public static readonly string dLanguage         = Lang.Rows[48]["Translation"].ToString();          //D-M Language
        public static readonly string dSEQ              = Lang.Rows[49]["Translation"].ToString();          //D-N SEQ
        public static readonly string dEnglish          = Lang.Rows[50]["Translation"].ToString();          //D-O English
        public static readonly string dScan             = Lang.Rows[51]["Translation"].ToString();          //D-P Scan
        public static readonly string dUSB          = Lang.Rows[52]["Translation"].ToString();          //D-Q USB
        public static readonly string dTranslation  = Lang.Rows[53]["Translation"].ToString();          //D-R Translation
        public static readonly string dComplete     = Lang.Rows[54]["Translation"].ToString();          //D-S The Settings have been applied.
        public static readonly string dWarning          = Lang.Rows[55]["Translation"].ToString();          //D-T Warning
        public static readonly string dWarningError1 = Lang.Rows[56]["Translation"].ToString();          //D-U Changed setting without save will not be applied.
        public static readonly string dWarningError2 = Lang.Rows[57]["Translation"].ToString();          //D-V Will you continue?
        public static readonly string eSearch           = Lang.Rows[58]["Translation"].ToString();          //E.Search 
        public static readonly string ePatientID        = Lang.Rows[59]["Translation"].ToString();          //E-A Patient ID
        public static readonly string eName             = Lang.Rows[60]["Translation"].ToString();          //E-B Name
        public static readonly string eStartDate        = Lang.Rows[61]["Translation"].ToString();          //E-C Start Date
        public static readonly string eEndDate          = Lang.Rows[62]["Translation"].ToString();          //E-D End Date
        public static readonly string eBirthday         = Lang.Rows[63]["Translation"].ToString();          //E-E Birthday
        public static readonly string eSex              = Lang.Rows[64]["Translation"].ToString();          //E-F Sex
        public static readonly string fListSetting      = Lang.Rows[65]["Translation"].ToString();          //F.List setting  List setting
        public static readonly string fComplete         = Lang.Rows[66]["Translation"].ToString();          //F-A The setting is complete.
        public static readonly string gLogin            = Lang.Rows[67]["Translation"].ToString();          //G.Login Login
        public static readonly string gUserID           = Lang.Rows[68]["Translation"].ToString();          //G-A User ID
        public static readonly string gPassword         = Lang.Rows[69]["Translation"].ToString();          //G-B Password
        public static readonly string gManagement       = Lang.Rows[70]["Translation"].ToString();          //G-C Management
        public static readonly string gWrongError1      = Lang.Rows[71]["Translation"].ToString();          //G-D User ID and password do not match or
        public static readonly string gWrongError2      = Lang.Rows[72]["Translation"].ToString();          //G-E you do not have an account yet
        public static readonly string hManagement           = Lang.Rows[73]["Translation"].ToString();          //H.Management
        public static readonly string hRegistration     = Lang.Rows[74]["Translation"].ToString();          //H-A Registration
        public static readonly string hUserID           = Lang.Rows[75]["Translation"].ToString();          //H-B User ID
        public static readonly string hPassword         = Lang.Rows[76]["Translation"].ToString();          //H-C Password
        public static readonly string hConfirmPassword  = Lang.Rows[77]["Translation"].ToString();          //H-D Confirm password
        public static readonly string hName             = Lang.Rows[78]["Translation"].ToString();          //H-E Name
        public static readonly string hBirthday         = Lang.Rows[79]["Translation"].ToString();          //H-F Birthday
        public static readonly string hSave             = Lang.Rows[80]["Translation"].ToString();          //H-G Save
        public static readonly string hCancel           = Lang.Rows[81]["Translation"].ToString();          //H-I Cancel
        public static readonly string hDelete           = Lang.Rows[82]["Translation"].ToString();          //H-J Delete
        public static readonly string hWrongError1       = Lang.Rows[83]["Translation"].ToString();          //H-K Password and confirm password do not match
        public static readonly string hID                       = Lang.Rows[84]["Translation"].ToString();          //H-L ID
        public static readonly string hWrongError2      = Lang.Rows[85]["Translation"].ToString();          //H-M Are you sure you want to delete
        public static readonly string hDeleteWarning = Lang.Rows[86]["Translation"].ToString();          //H-N Delete Warning
        public static readonly string iStatusBar        = Lang.Rows[87]["Translation"].ToString();          //I.Status bar    Status bar
        public static readonly string iConnected        = Lang.Rows[88]["Translation"].ToString();          //I-A Connected
        public static readonly string iReceivingData    = Lang.Rows[89]["Translation"].ToString();          //I-B Receiving data
        public static readonly string iDisconnected     = Lang.Rows[90]["Translation"].ToString();          //I-C Disconnected
        public static readonly string iUserID           = Lang.Rows[91]["Translation"].ToString();          //I-D User ID
        public static readonly string iDBError          = Lang.Rows[92]["Translation"].ToString();          //I-E DB Error
        public static readonly string iData             = Lang.Rows[93]["Translation"].ToString();          //I-F Data
        public static readonly string iStart            = Lang.Rows[94]["Translation"].ToString();          //I-G Start
        public static readonly string jLogout       = Lang.Rows[95]["Translation"].ToString();          //J.Logout
        public static readonly string kClose        = Lang.Rows[96]["Translation"].ToString();          //K.Close 
        public static readonly string lColor        = Lang.Rows[97]["Translation"].ToString();          //L.Color 
        public static readonly string lNone         = Lang.Rows[98]["Translation"].ToString();          //L-A None
        public static readonly string lYellow       = Lang.Rows[99]["Translation"].ToString();          //L-B Yellow
        public static readonly string lDKYellow     = Lang.Rows[100]["Translation"].ToString();          //L-C DK Yellow
        public static readonly string lStraw        = Lang.Rows[101]["Translation"].ToString();          //L-D Straw
        public static readonly string lAmber        = Lang.Rows[102]["Translation"].ToString();          //L-E Amber
        public static readonly string lRed          = Lang.Rows[103]["Translation"].ToString();          //L-F Red
        public static readonly string lOrange      = Lang.Rows[104]["Translation"].ToString();          //L-G Orange
        public static readonly string lGreen        = Lang.Rows[105]["Translation"].ToString();          //L-H Green
        public static readonly string lOther        = Lang.Rows[106]["Translation"].ToString();          //L-I Other
        public static readonly string mTurbidity = Lang.Rows[107]["Translation"].ToString();          //M.Turbidity
        public static readonly string mClear       = Lang.Rows[108]["Translation"].ToString();          //M-A Clear
        public static readonly string mSLCloudy = Lang.Rows[109]["Translation"].ToString();          //M-B SL Cloudy
        public static readonly string mCloudy     = Lang.Rows[110]["Translation"].ToString();          //M-C Cloudy
        public static readonly string mTurbid       = Lang.Rows[111]["Translation"].ToString();          //M-D Turbid



        


        public static string StatusData;
        public static readonly string portName = Set.Rows[0]["PortName"].ToString();

        public static ConcurrentQueue<string> datas   = new ConcurrentQueue<string>();


        public static string QueueData
        {
            get
            {
                try
                {
                    string data;
                    bool success;
                    success = Data.datas.TryDequeue(out data);
                    if (success) return data;
                    else return "";
                }
                catch
                {
                    return "";
                }
            }
        }

        static Data()
        {
            ListItem.TableName = "DB_ListItem";
            ListResult.TableName = "DB_ListResult";
            PadColor.TableName = "DB_PadColor";
            Patient.TableName = "DB_Patient";
            PrintForm.TableName = "DB_PrintForm";
            QCResult.TableName = "DB_QCResult";
            Result.TableName = "DB_Result";
            Set.TableName = "DB_Set";
            Table.TableName = "DB_Table";
            User.TableName = "DB_User";
            Lang.TableName = "DB_Lang";
            Console.WriteLine($"SerialType = {Get_SerialType}");
        }
    }
}

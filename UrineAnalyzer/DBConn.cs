using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrineAnalyzer
{
    public static class DataConn
    {

        private static OleDbConnection conn;
        private static Boolean m_bConn = false;
        public static Mutex mutex = new Mutex();
        private static string loginID;
        private static string DB_path = Application.StartupPath + @"\Data.accdb";
        private static string connstr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + DB_path;
        private static OleDbConnection connection = new OleDbConnection(connstr);
        private static OleDbCommand command = connection.CreateCommand();
        private static OleDbTransaction transaction;
        public static string LoginID
        {
            get
            {
                return loginID;
            }
            set
            {
                loginID = value;
            }
        }
        public static Boolean isConn
        {
            get { return m_bConn; }
        }

        public static DataSet GetDataSet(string sql, string DB_path)
        {

            conn = new System.Data.OleDb.OleDbConnection(connstr);
            if (!m_bConn)
            {
                OpenDB();
                m_bConn = true;
                //            Console.WriteLine(sql);
            }
            DataSet ds = new DataSet();
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            adp.Fill(ds);
            CloseDB();
            return ds;
            //adp.Dispose();
        }
        public static DataSet GetDataSet(string sql)
        {

            conn = new System.Data.OleDb.OleDbConnection(connstr);
            if (!m_bConn)
            {
                OpenDB();
                m_bConn = true;
                //            Console.WriteLine(sql);
            }
            DataSet ds = new DataSet();
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            adp.Fill(ds);
            CloseDB();
            return ds;
            //adp.Dispose();
        }
        public static void DeleteData(DataTable dt)
        {
            string sql;
            sql = $"Delete FROM {dt.TableName}";
            Getdata(sql);
        }

        //220408 Start
        public static void DeleteData(DataTable dt, DataRow dr)
        {
            string sql;
            sql = $"Delete FROM {dt.TableName} WHERE ";
            int i = 0;
            for (i = 0; i < dr.Table.Columns.Count - 2; i++)
            {

                if (dr[i].GetType().Equals(typeof(string)))
                {
                    sql += $"{dr.Table.Columns[i].ColumnName} = '{dr[i].ToString()}' AND ";

                }
                else if (dr[i].GetType().Equals(typeof(int)))
                {
                    sql += $"{dr.Table.Columns[i].ColumnName} = {dr[i].ToString()} AND ";
                }
            }
            if (dr[i].GetType().Equals(typeof(string)))
            {
                sql += $"{dr.Table.Columns[i].ColumnName} = '{dr[i].ToString()}'";

            }
            else if (dr[i].GetType().Equals(typeof(int)))
            {
                sql += $"{dr.Table.Columns[i].ColumnName} = {dr[i].ToString()}";
            }
            //Console.WriteLine(sql);
            dt.Rows.Remove(dr);
            //            Getdata(sql);
            GetDataTransaction(sql);
        }
        //220408 End
        //220406 End
        public static DataTable GetDataTable(string tableName, bool distinct = false, string column = "*")
        {
            string sql;
            if (distinct == false)
            {
                sql = $"SELECT {column} FROM {tableName}";
            }
            else
            {
                sql = $"SELECT DISTINCT {column} FROM {tableName}";
            }
            //Console.WriteLine(sql);
            conn = new OleDbConnection(connstr);
            if (!m_bConn)
            {
                OpenDB();
                m_bConn = true;
            }
            DataTable dt = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            adp.Fill(dt);
            CloseDB(); 
            dt.TableName = tableName.Split(' ')[0];
            //dt.TableName = tableName;
            return dt;
        }

        public static void InsertData(DataTable dt, DataRow dr)
        {
            string sql = $"INSERT INTO {dt.TableName} VALUES(";

            //            Console.WriteLine($"ItemArray.Length = {dr.ItemArray.Length}");

            for (int i = 0; i < dr.ItemArray.Length - 1; i++)
            {
                if (dr[i].GetType().Equals(typeof(string)))
                {
                    sql += $"'{dr[i].ToString()}', ";
                }
                else if (dr[i].GetType().Equals(typeof(int)))
                {
                    sql += $"{dr[i].ToString()}, ";
                }
            }
            if (dr[dr.ItemArray.Length - 1].GetType().Equals(typeof(string)))
            {
                sql += $"'{dr[dr.ItemArray.Length - 1].ToString()}')";
            }
            else if (dr[dr.ItemArray.Length - 1].GetType().Equals(typeof(int)))
            {
                sql += $"{dr[dr.ItemArray.Length - 1].ToString()})";
            }
            //            Console.WriteLine("Insert sql:" + sql);

            dt.Rows.Add(dr);
            //AddDataTable(dt, dr);
            //Getdata(sql); 
            GetDataTransaction(sql);
        }
        public static void UpdateData(int seq, string datetime, DataTable dt, DataRow dr)
        {
            string sql = $"UPDATE {dt.TableName} SET ";
            if (dr[0].GetType().Equals(typeof(string)))//UID
            {
                sql += $"{dt.Columns[0].ColumnName} = '{dr[0].ToString()}', ";
            }
            else if (dr[0].GetType().Equals(typeof(int)))
            {
                sql += $"{dt.Columns[0].ColumnName} = {dr[0].ToString()}, ";
            }

            for (int i = 3; i < dr.ItemArray.Length - 1; i++)
            {
                if (dr[i].GetType().Equals(typeof(string)))
                {
                    sql += $"{dt.Columns[i].ColumnName} = '{dr[i].ToString()}', ";
                }
                else if (dr[i].GetType().Equals(typeof(int)))
                {
                    sql += $"{dt.Columns[i].ColumnName} = {dr[i].ToString()}, ";
                }
            }
            if (dr[dr.ItemArray.Length - 1].GetType().Equals(typeof(string)))
            {
                sql += $"{dt.Columns[dr.ItemArray.Length - 1].ColumnName} = '{dr[dr.ItemArray.Length - 1].ToString()}'";
            }
            else if (dr[dr.ItemArray.Length - 1].GetType().Equals(typeof(int)))
            {
                sql += $"{dt.Columns[dr.ItemArray.Length - 1].ColumnName} = {dr[dr.ItemArray.Length - 1].ToString()}";
            }
            sql += $" WHERE SEQ = {seq} AND TestDate = '{datetime}'";
                        //Console.WriteLine(sql);
            Getdata(sql);
            //            dt.Rows.Add(dr);
            AddDataTable(dt, dr);
        }
        public static void UpdateData(string patientID, DataTable dt, DataRow dr)
        {
            string sql = $"UPDATE {dt.TableName} SET ";

            for (int i = 1; i < dr.ItemArray.Length - 1; i++)
            {
                if (dr[i].GetType().Equals(typeof(string)))
                {
                    sql += $"{dt.Columns[i].ColumnName} = '{dr[i].ToString()}', ";
                }
                else if (dr[i].GetType().Equals(typeof(int)))
                {
                    sql += $"{dt.Columns[i].ColumnName} = {dr[i].ToString()}, ";
                }
            }
            if (dr[dr.ItemArray.Length - 1].GetType().Equals(typeof(string)))
            {
                sql += $"{dt.Columns[dr.ItemArray.Length - 1].ColumnName} = '{dr[dr.ItemArray.Length - 1].ToString()}'";
            }
            else if (dr[dr.ItemArray.Length - 1].GetType().Equals(typeof(int)))
            {
                sql += $"{dt.Columns[dr.ItemArray.Length - 1].ColumnName} = {dr[dr.ItemArray.Length - 1].ToString()}";
            }
            sql += $" WHERE PatientID = '{patientID}'";
            //            Console.WriteLine(sql);
            Getdata(sql);
            //            dt.Rows.Add(dr);
            AddDataTable(dt, dr);
        }
        public static void UpdateData(DataTable dt, DataRow dr)
        {
            string sql = $"UPDATE {dt.TableName} SET ";

            for (int i = 1; i < dr.ItemArray.Length - 1; i++)
            {
                if (dr[i].GetType().Equals(typeof(string)))
                {
                    sql += $"{dt.Columns[i].ColumnName} = '{dr[i].ToString()}', ";
                }
                else if (dr[i].GetType().Equals(typeof(int)))
                {
                    sql += $"{dt.Columns[i].ColumnName} = {dr[i].ToString()}, ";
                }
            }
            if (dr[dr.ItemArray.Length - 1].GetType().Equals(typeof(string)))
            {
                sql += $"{dt.Columns[dr.ItemArray.Length - 1].ColumnName} = '{dr[dr.ItemArray.Length - 1].ToString()}'";
            }
            else if (dr[dr.ItemArray.Length - 1].GetType().Equals(typeof(int)))
            {
                sql += $"{dt.Columns[dr.ItemArray.Length - 1].ColumnName} = {dr[dr.ItemArray.Length - 1].ToString()}";
            }
            //            Console.WriteLine(sql);
            Getdata(sql);
            //            dt.Rows.Add(dr);
            AddDataTable(dt, dr);
        }
        public static void UpdateData(DataTable dt, DataRow dr, string SEQ, string sort)
        {
            string sql = $"UPDATE {dt.TableName} SET ";

            sql += $"[{dt.Columns[2].ColumnName}] = '{dr[2].ToString()}' ";
            /*for (int i = 1; i < dr.ItemArray.Length - 1; i++)
            {
                if (dr[i].GetType().Equals(typeof(string)))
                {
                    sql += $"[{dt.Columns[i].ColumnName}] = '{dr[i].ToString()}' ";
                }
                else if (dr[i].GetType().Equals(typeof(int)))
                {
                    sql += $"[{dt.Columns[i].ColumnName}] = {dr[i].ToString()} ";
                }
            }*/
            sql += $" WHERE SEQ = '{SEQ}' AND Sort = '{sort}'";
            //            Console.WriteLine(sql);
            Getdata(sql);
            //            dt.Rows.Add(dr);
            //            AddDataTable(dt, dr);
        }
        public static void AddDataTable(DataTable dt, DataRow dr)
        {
            try
            {
                dt.ImportRow(dr);
                Console.WriteLine(dt.TableName + dr[1].ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        static object obj = new object();
        public static void Getdata(string insert_query)
        {
            //            try
            //            {
            lock (obj)
            {
                //            Console.WriteLine(insert_query);
                //mutex.WaitOne();
                conn = new OleDbConnection(connstr);
                OleDbCommand cmd = new OleDbCommand(insert_query, conn);
                cmd.CommandType = CommandType.Text;
                OpenDB();
                OleDbDataReader reader = cmd.ExecuteReader();
                //                while (reader.Read())
                //                {
                //                }

                //                OleDbDataAdapter adp = new OleDbDataAdapter();
                //                adp.InsertCommand = new OleDbCommand(insert_query, conn);
                //                adp.InsertCommand.ExecuteNonQuery();
                CloseDB();
                //mutex.ReleaseMutex();
                //            }
                //            catch(Exception e)
                //            {
                //                Console.WriteLine(e.ToString());
                //            }
            }
            
//            GetDataTransaction(insert_query); 


        }
        public static void OpenDataTransaction()
        {
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
            }
            catch
            {
                Console.WriteLine("Already Connected.");
            }
        }

        public static void GetDataTransaction(string insert_query)
        {
            OpenDataTransaction();


            command.Connection = connection;
            command.Transaction = transaction;
            command.CommandText = insert_query;
            command.ExecuteNonQuery();
        }
        public static void GetDataCommit()
        { 
            try
            {
                transaction.Commit();
                Console.WriteLine("Both records are written to database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                Console.WriteLine("  Message: {0}", ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                    Console.WriteLine("  Message: {0}", ex2.Message);
                }
            }
            connection.Close();
        }



        public static Boolean OpenDB()
        {
            Boolean bConn = false;
            try
            {
                conn.Open();
                bConn = true;
            }
            catch
            {
                bConn = false;
            }
            m_bConn = bConn;
            return bConn;
        }

        public static Boolean CloseDB()
        {
            Boolean bClose = false;
            try
            {
                conn.Close();
                bClose = true;
                m_bConn = false;
            }
            catch
            {
                bClose = false;
            }
            return bClose;
        }

        public static bool DataCheck(string sql)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                if (!m_bConn)
                {
                    OpenDB();
                    m_bConn = true;
                }
                OleDbDataReader oleReader = cmd.ExecuteReader(CommandBehavior.Default);
                //OleDbDataReader oleReader = cmd.ExecuteReader();
                bool res;
                res = oleReader.Read();
                oleReader.Close();
                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public static bool IDCheck(string UID, DataTable dt)
        {
            string filterExpression = $"PatientID = '{UID}'";
            bool res = false;
            DataRow[] dr = dt.Select(filterExpression);
            if (dr.Length > 0) res = true;
            return res;
        }
        public static bool Logincheck(string UID, string PW)
        {
            try
            {
                string password = EncryptionHelper.EncryptionSHA256(PW);

                string sql = "SELECT * FROM DB_User WHERE StrComp(id,'" + UID + "',0)=0 AND pw = '" + password + "'";
                //            Console.WriteLine(sql);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                OpenDB();
                
                OleDbDataReader oleReader = cmd.ExecuteReader(CommandBehavior.Default);
                //OleDbDataReader oleReader = cmd.ExecuteReader();
                bool res;
                res = oleReader.Read();
                oleReader.Close();
                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public static bool Admincheck()
        {
            try
            {
                conn = new System.Data.OleDb.OleDbConnection(connstr);

                OpenDB();//220406_3
                string sql = @"SELECT * FROM DB_User WHERE ID = 'Admin'";
                //MessageBox.Show(sql);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                //            if (!m_bConn) OpenDB();
                OleDbDataReader oleReader = cmd.ExecuteReader(CommandBehavior.Default);
                //OleDbDataReader oleReader = cmd.ExecuteReader();
                bool res;
                res = oleReader.Read();
                cmd.Dispose();
                oleReader.Close();
                //MessageBox.Show(res.ToString());
                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public static OleDbConnection GetConObj()
        {
            return conn;
        }

        public static Boolean IsConn()
        {
            return m_bConn;
        }
    }

    public static class EncryptionHelper
    {
        public static string EncryptionSHA256(string message)
        {
            //입력받은 문자열을 바이트배열로 변환
            byte[] array = Encoding.Default.GetBytes(message);
            byte[] hashValue;
            string result = string.Empty;

            //바이트배열을 암호화된 32byte 해쉬값으로 생성
            using (SHA256 mySHA256 = SHA256.Create())
            {
                hashValue = mySHA256.ComputeHash(array);
            }
            //32byte 해쉬값을 16진수로변환하여 64자리로 만듬
            for (int i = 0; i < hashValue.Length; i++)
            {
                result += hashValue[i].ToString("x2");
            }
            return result;
        }
    }
}

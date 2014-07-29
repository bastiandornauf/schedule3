using System;
using System.Collections.Generic;
using System.Text;


using MySql.Data.MySqlClient;
using MySql.Data;
using HPSchedule.Properties;

namespace HPSchedule
{
    /// <summary>
    /// Database wrappt alle Datenbankzugriffe.
    /// Verwendung von MySQL
    /// </summary>
    class Database
    {                
        MySqlConnection connect;
        MySqlCommand cmd;
        MySqlDataReader rd;
        string connectionString;
        LogFile log;



        public Database()
        {
            bool useRemote = false; //TODO: change to true for remote access
            connectionString = CreateConnectionString(useRemote);
            connect = new MySqlConnection(connectionString);
            cmd = new MySqlCommand("", connect);                        
            log = new LogFile("log_db");
            log.AppendDateToFilename = true;
        }

        /// <summary>
        /// Stellt den SQL-Befehls-String ein
        /// </summary>
        /// <param name="value">SQL-Befehl</param>
        /// 
        

        public void SetCommand( string value )
        {
            cmd.CommandText = value;

        }
        public MySqlCommand Command
        {
            get { return cmd; }
        }
        public void Close()
        {
            if( rd != null )
                if (!rd.IsClosed)
                    rd.Close();
            if( connect != null )
                if (connect.State != System.Data.ConnectionState.Closed)
                    connect.Close();

            
        }
        public MySqlConnection Connection
        {
            get { return connect; }
        }

        /// <summary>
        /// returns the result of the set command as dataTable
        /// </summary>
        /// <returns>DataTable with results</returns>
        public System.Data.DataTable Table()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            
            Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            connect.Close();
            
            return dt;
        }

        public void ExecuteReader()
        {
            
            Open();
            rd = cmd.ExecuteReader();
        }
        public void Execute()
        {
            Open();
            cmd.ExecuteNonQuery();
        }

        public int ExecuteWithResult() {
            Open();
            return cmd.ExecuteNonQuery();
        }
        public bool Read()
        {
            return rd.Read();
        }
        public int Insert(string table, string spalten, string werte) {
            int rowsAffected;

            cmd.CommandText = "INSERT INTO " + table + " (" + spalten + ") VALUES (" + werte + ");";

            try
            {
                Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (MySqlException exc)
            {
                log.Error(exc.Message + ": >>" + cmd.CommandText + "<<");
                rowsAffected = -1;
            }
            finally
            {
                if (connect != null)
                    connect.Close();
            }
            return rowsAffected;
        }
        public int GetId(string table)
        {
            int result = -1;
            cmd.CommandText = "SELECT LAST_INSERT_ID() FROM " + table + ";";
            
            try
            {
                Open();
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    if (!rd.IsDBNull(0))
                    {
                        result = rd.GetInt32("last_insert_id()");
                    }
                }
            }
            catch (MySqlException exc)
            {
                log.Error(exc.Message + ": >>" + cmd.CommandText + "<<");
            }
            finally
            {
                if (connect != null)
                    connect.Close();
            }
            return result;
        }
        public int Count(string table, string where)
        {
            return GetNumeric(table, "COUNT(*) AS total","total", where);
        }
        internal int GetNumeric(string table, string field, string whereClause)
        {
            return GetNumeric(table, field, field, whereClause);
        }
        internal int GetNumeric(string table, string field,string resultField, string whereClause)
        {
            cmd.CommandText = "SELECT " + field + " FROM " + table + " WHERE " + whereClause + ";";
            int result = 0;
            try
            {
                Open();
                // Kommando ausführen
                rd = cmd.ExecuteReader();
                // Zeilen vorhanden?
                if (rd.HasRows)
                {
                    rd.Read();
                    if (!rd.IsDBNull(0))
                    {
                        result = rd.GetInt32(resultField);
                    }
                    else
                        result = -1;
                }
            }
            catch (MySqlException exc)
            {
                log.Error(exc.Message + ": >>" + cmd.CommandText + "<<");
            }
            finally
            {
                if( connect != null )
                    connect.Close();
            }
            return result;
        }
        public int DeleteFromTable(string table, long id)
        {
            int rowsAffected;
            cmd.CommandText = String.Format("DELETE FROM {0} WHERE id={1};", table, id);

            try
            {
               Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (MySqlException exc)
            {
                log.Error(exc.Message + ": >>" + cmd.CommandText + "<<");
                rowsAffected = -1;
            }
            finally
            {
                if (connect != null)
                    connect.Close();
            }
            return rowsAffected;
        }

        #region Reader-Funktionen
        #region Konstanten, Defaultwerte, ...
        const int defaultInt = 0;
        const long defaultLong = 0;
        const string defaultString = "";
        DateTime defaultDateTime = DateTime.MinValue;
        const bool defaultBool = false;
        const double defaultDouble = 0;
        #endregion


        public bool ReaderHasRows
        {
            get
            {
                if (rd != null)
                    return rd.HasRows;
                else
                    return false;
            }
        }

        public bool IsNull(int index)
        {
            if (rd != null)
                return rd.IsDBNull(index);
            else
                throw new Exception("Reader nicht bereit");
        }

        public bool IsNull(string field)
        {
            if (rd != null)
                return IsNull(rd.GetOrdinal(field));
            else
                throw new Exception("Reader nicht bereit");
        }

        #region GetInt
        public int GetInt(int index, int defaultValue) 
        {
            if( rd == null)
                throw new Exception("Reader ist nicht bereit.");

            if( rd.IsDBNull( index ) )            
                return defaultValue;
            else
                return rd.GetInt32( index );
        }
        public int GetInt(string field, int defaultValue)
        {
            int index = rd.GetOrdinal( field );
            return GetInt( index, defaultValue );
        }
        public int GetInt(string field) {
            return GetInt(field, defaultInt );
        }
        public int GetInt(int index)
        {
            return GetInt(index, defaultInt);
        }
        #endregion

        #region GetLong
        public long GetLong(int index, long defaultValue) 
        {
            if( rd == null)
                throw new Exception("Reader ist nicht bereit.");

            if( rd.IsDBNull( index ) )            
                return defaultValue;
            else
                return rd.GetInt64( index );
        }
        public long GetLong(string field, long defaultValue)
        {
            int index = rd.GetOrdinal( field );
            return GetLong( index, defaultValue );
        }
        public long GetLong(string field) {
            return GetLong(field, defaultInt );
        }
        public long GetLong(int index)
        {
            return GetLong(index, defaultLong);
        }
        #endregion

        #region GetString
        public string GetString(int index, string defaultValue) 
        {
            if( rd == null)
                throw new Exception("Reader ist nicht bereit.");

            if( rd.IsDBNull( index ) )            
                return defaultValue;
            else
                return rd.GetString( index );
        }
        public string GetString(string field, string defaultValue)
        {
            int index = rd.GetOrdinal( field );
            return GetString( index, defaultValue );
        }
        public string GetString(string field) {
            return GetString(field, defaultString);
        }
        public string GetString(int index)
        {
            return GetString(index, defaultString);
        }
        #endregion

        #region GetDateTime
        public DateTime GetDateTime(int index, DateTime defaultValue) 
        {
            if( rd == null)
                throw new Exception("Reader ist nicht bereit.");

            if( rd.IsDBNull( index ) )            
                return defaultValue;
            else
                return rd.GetDateTime( index );
        }
        public DateTime GetDateTime(string field, DateTime defaultValue)
        {
            int index = rd.GetOrdinal( field );
            return GetDateTime( index, defaultValue );
        }
        public DateTime GetDateTime(string field) {
            return GetDateTime(field, defaultDateTime );
        }
        public DateTime GetDateTime(int index)
        {
            return GetDateTime(index, defaultDateTime);
        }
        #endregion       

        #region GetBool
        public bool GetBool(int index, bool defaultValue)
        {
            if (rd == null)
                throw new Exception("Reader ist nicht bereit.");

            if (rd.IsDBNull(index))
                return defaultValue;
            else
                return rd.GetBoolean(index);
        }
        public bool GetBool(string field, bool defaultValue)
        {
            int index = rd.GetOrdinal(field);
            return GetBool(index, defaultValue);
        }
        public bool GetBool(string field)
        {
            return GetBool(field, defaultBool);
        }
        public bool GetBool(int index)
        {
            return GetBool(index, defaultBool);
        }
        #endregion

        #region GetDouble
        public double GetDouble(int index, double defaultValue)
        {
            if (rd == null)
                throw new Exception("Reader ist nicht bereit.");

            if (rd.IsDBNull(index))
                return defaultValue;
            else
                return rd.GetDouble(index);
        }
        public double GetDouble(string field, double defaultValue)
        {
            int index = rd.GetOrdinal(field);
            return GetDouble(index, defaultValue);
        }
        public double GetDouble(string field)
        {
            return GetDouble(field, defaultDouble);
        }
        public double GetDouble(int index)
        {
            return GetDouble(index, defaultDouble);
        }
        #endregion


#endregion  


#region sqlHelper
        public void ReportError(string s)
        {
            log.Error(cmd.CommandText + " --- " + s);
#if DEBUG
            throw new Exception("Database reports Error: "+ s );
#endif        
        }


        public static string CreateConnectionString()
        {
            return CreateConnectionString(false);
        }

        public static string CreateConnectionString(bool useRemoteServer)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            Settings config = new Settings();

            builder.Server = useRemoteServer?config.dbRemoteServer:config.dbLocalServer;
            builder.UserID = useRemoteServer ? config.dbRemoteUser : config.dbLocalUser;
            builder.Password = useRemoteServer ? config.dbRemotePassword : config.dbLocalPassword;
            builder.Database = useRemoteServer ? config.dbRemoteDatabase : config.dbLocalDatabase;
            builder.CharacterSet = "utf8";


            return builder.ConnectionString;
        }
        public static string QuoteMarks(string s)
        {
            return "'" + s + "'";
        }
        public static string formatDatetimeQuoted(DateTime d)
        {
            return QuoteMarks(formatDatetime(d));
        }
        public static string formatDatetime(DateTime d)
        {
            string s = String.Format("{0:u}", d);
            s = s.Remove(s.Length - 1);
            return s;
        }
        public void MySqlSetUTF8()
        {
            MySqlConnection conn = new MySqlConnection(CreateConnectionString());
            string sqlCmd = "SET NAMES UTF8;";
            MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException exc)
            {
                log.Error(exc.Message);
            }
            finally
            {
                // Reader und Verbindung schließen
                if (conn != null)
                    conn.Close();
            }
        }

        #endregion


        public void Open() {
            if( connect.State == System.Data.ConnectionState.Closed )
                connect.Open();
        }
        
    }
}

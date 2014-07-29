using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Windows.Forms;

namespace ImportGebueh2Sql
{
    public class SqlHelper
    {
        MySqlConnection connect;
        MySqlCommand cmd;
        MySqlDataReader rd;
        string connectionString;
        LogFile log;

        public SqlHelper(LogFile l)
        {
            connectionString = CreateConnectionString();
            connect = new MySqlConnection(connectionString);
            cmd = new MySqlCommand("", connect);
            log = l;
        }

        public int Insert(string table, string spalten, string werte)
        {
            int rowsAffected;

            cmd.CommandText = "SET FOREIGN_KEY_CHECKS = 0; INSERT INTO " + table + " (" + spalten + ") VALUES (" + werte + ");";

            try
            {
                connect.Open();
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
            if (cmd != null && cmd.LastInsertedId>0 )
            {
                return (int)cmd.LastInsertedId;
            }
            
            
            int result = -1;
            cmd.CommandText = "SELECT LAST_INSERT_ID() FROM " + table + ";";

            try
            {
                connect.Open();
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

        internal int GetNumeric(string table, string field, string whereClause)
        {
            cmd.CommandText = "SELECT " + field + " FROM " + table + " WHERE " + whereClause + ";";
            int result = 0;
            try
            {
                connect.Open();
                // Kommando ausführen
                rd = cmd.ExecuteReader();
                // Zeilen vorhanden?
                if (rd.HasRows)
                {
                    rd.Read();
                    if (!rd.IsDBNull(0))
                    {
                        result = rd.GetInt32(field);
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
                if (connect != null)
                    connect.Close();
            }
            return result;
        }

        #region sqlHelper
        public static string CreateConnectionString()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            
            builder.Server = Properties.Settings.Default.server;
            //builder.Server = "localhost";
            builder.UserID = Properties.Settings.Default.user;
            builder.Password = Properties.Settings.Default.password;
            builder.Database = Properties.Settings.Default.database;
            builder.CharacterSet = "utf8";


            return builder.ConnectionString;
        }
        public static string QuoteMarks(string s)
        {
            return "'" + s.Trim() + "'";
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
        public static void MySqlSetUTF8()
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
                MessageBox.Show(exc.Message);
            }
            finally
            {
                // Reader und Verbindung schließen
                if (conn != null)
                    conn.Close();
            }
        }

        #endregion

    }
}

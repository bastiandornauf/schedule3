using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ImportGebueh2Sql
{
    public class LogFile
    {
        private string logFormat;
        private string errorTime;
        private string fileName;
        private bool appendDateToFilename;

        public LogFile(string file)
        {
            setTime();
            fileName = file;
            appendDateToFilename = false;

            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            errorTime = sYear + sMonth + sDay;
        }
        private void setTime()
        {
            logFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
        }
        private void WriteToFile(string txt)
        {
            setTime();
            StreamWriter sw = new StreamWriter(fileName + (appendDateToFilename ? errorTime : ""), true);
            sw.WriteLine(txt);
            sw.Flush();
            sw.Close();
        }

        public void Error(string errMsg)
        {
            WriteToFile(logFormat + " ERROR " + errMsg);
        }
        public void Msg(string msg)
        {
            WriteToFile(logFormat + " MSG   " + msg);
        }
    }
}

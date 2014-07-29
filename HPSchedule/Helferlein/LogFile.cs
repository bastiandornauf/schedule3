using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HPSchedule
{
    public class LogFile
    {
        private string logFormat;
        private string errorTime;
        private string fileName;
        private bool appendDateToFilename;
        private string ext;
        private string path;

        public LogFile(string file)
        {
            setTime();
            fileName = file;
            appendDateToFilename = false;
            ext = "txt";
            path = Environment.CurrentDirectory;


            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            errorTime = sYear + sMonth + sDay;
        }

        public string Extension
        {
            set { ext = value; }
            get { return ext; }
        }
        private string Filename()
        {            
            string fn = fileName + (appendDateToFilename ? errorTime : "");
            fn = Path.ChangeExtension(fn, ext);
            fn = Path.Combine(path, fn);
            return fn;
        }
        
        public bool AppendDateToFilename
        {
            set { appendDateToFilename = value; }
        }

        private void setTime()
        {
            logFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
        }
        private void WriteToFile(string txt)
        {
            setTime();
            StreamWriter sw = new StreamWriter( Filename() , true);
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

using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule.Datenobjekte
{
    public class Options
    {
        public Options()
        {

        }

        #region Datenbank
        public string mySqlLocalServer;
        public string mySqlLocalUser;
        public string mySqlLocalPassword;
        public string mySqlLocalDatabase;

        public bool useRemoteDatabase;
        public string mySqlRemoteServer;
        public string mySqlRemoteUser;
        public string mySqlRemotePassword;
        public string mySqlRemoteDatabase;
        #endregion

        #region Praxis
        #endregion


    }
}

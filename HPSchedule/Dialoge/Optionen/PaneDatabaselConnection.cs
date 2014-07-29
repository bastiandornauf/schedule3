using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HPSchedule.Dialoge.Optionen
{
    public partial class PanelDatabaseConnection : OptionControl
    {
        public PanelDatabaseConnection()
        {
            InitializeComponent();
        }

        public override void SaveData()
        {
            global::HPSchedule.Properties.Settings cfg = new global::HPSchedule.Properties.Settings();

            cfg.dbLocalServer = tbServer.Text;
            cfg.dbLocalUser = tbUser.Text;
            cfg.dbLocalPassword = tbPassword.Text;
            cfg.dbLocalDatabase = tbDatabase.Text;

            cfg.Save();
        }

        public override void LoadData()
        {
            global::HPSchedule.Properties.Settings cfg = new global::HPSchedule.Properties.Settings();

            tbServer.Text = cfg.dbLocalServer;
            tbUser.Text = cfg.dbLocalUser;
            tbPassword.Text = cfg.dbLocalPassword;
            tbDatabase.Text = cfg.dbLocalDatabase;
        }


    }
}

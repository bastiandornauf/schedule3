using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HPSchedule.Dialoge.Optionen
{
    public partial class PanelDayView : OptionControl
    {
        public PanelDayView()
        {
            InitializeComponent();
            // aus debug-grpnden:
            numericCellHeight.Enabled = false;
        }

        public override void SaveData()
        {
            global::HPSchedule.Properties.Settings cfg = new global::HPSchedule.Properties.Settings();

            if( cbDaysToShow.SelectedIndex >= 0 )
                cfg.showDaysInDayview = 5+cbDaysToShow.SelectedIndex;

            cfg.KalendarZeilenhöhe = (int)numericCellHeight.Value;

            cfg.Save();   
        }

        public override  void LoadData()
        {
            global::HPSchedule.Properties.Settings cfg = new global::HPSchedule.Properties.Settings();

            if( cfg.showDaysInDayview >= 5 && cfg.showDaysInDayview <= 7)
                cbDaysToShow.SelectedIndex = cfg.showDaysInDayview-5;

            numericCellHeight.Value = cfg.KalendarZeilenhöhe;
        }
    }
}

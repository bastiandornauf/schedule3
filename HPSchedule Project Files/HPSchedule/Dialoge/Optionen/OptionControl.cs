using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace HPSchedule.Dialoge.Optionen
{
    public abstract class OptionControl : UserControl
    {
        public abstract void SaveData();
        public abstract void LoadData();
    }
}

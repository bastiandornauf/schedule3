using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace HPSchedule.Dialoge
{
    public partial class AskDateTime : KryptonForm
    {
        private DateTime _value = new DateTime();

        public DateTime Value { 
            get { return _value; } 
            set { _value = value; } 
        }

        public AskDateTime()
        {
            InitializeComponent();
            if (Value != DateTime.MinValue)
                dateTimePicker1.Value = Value;
            else
                dateTimePicker1.Value = DateTime.Now;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _value = dateTimePicker1.Value;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _value = DateTime.MinValue;
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }



    }
}

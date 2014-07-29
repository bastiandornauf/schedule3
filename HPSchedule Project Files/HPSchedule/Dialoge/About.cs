using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HPSchedule.Dialoge
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            //labelVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); 
            labelVersion.Text = Application.ProductVersion;

            linkLabel1.Links.Add(0, 23, "http://www.bastian-dornauf.de/schedule/");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }


    }
}
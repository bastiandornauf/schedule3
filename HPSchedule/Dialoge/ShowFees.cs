using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HPSchedule.Dialoge
{
    public partial class ShowFees : Form
    {
        List<string> content;
        private bool stayOpen = true;

        public bool StayOpen
        {
            get { return stayOpen; }
            set { stayOpen = value; }
        }

        public ShowFees( List<string> values )
        {
            this.FormClosing += new FormClosingEventHandler(ShowFees_FormClosing);
            
            InitializeComponent();
            content = new List<string>();
            foreach (string s in values)
                content.Add(s);
        }

        void ShowFees_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = stayOpen;
        }


        private void ShowFees_Load(object sender, EventArgs e)
        {

        }

        public void UpdateContent(List<string> values)
        {
            content.Clear();
            foreach (string s in values)
                content.Add(s);
            UpdateListView();
        }

        public void UpdateListView() 
        {
            listView1.Items.Clear();
            
            if( content.Count %2 != 0 )
                throw new Exception("Ungerade Anzahl Werte angegeben");
            if (content.Count == 0)
                return;

            for(int iter = 0; iter<content.Count; iter+=2 ) 
            {
                ListViewItem li;
                li = listView1.Items.Add( content[iter] );
                li.SubItems.Add( content[iter+1] );
            }
        }
    }
}
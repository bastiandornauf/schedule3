using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HPSchedule.Datenobjekte;

namespace HPSchedule.Dialoge
{
    public partial class TreatedWithEditor : Form
    {
        private Treatment treatment;
        private Accounting accounting;

        private List<Healer> healer;
        private List<Room> rooms;


        public TreatedWithEditor(Treatment t, Accounting ac)
        {
            InitializeComponent();
            InitializeControls();

            if (t != null)
                treatment = t;
            else
                treatment = new Treatment();
                //throw new ArgumentException("kein gültiges Objekt des Typs Treatment übergeben (sondern null)");

            if (ac != null)
                accounting = ac;
            else
                throw new ArgumentException("kein gültiges Objekt des Typs Accounting übergeben  (sondern null)");

            healer = new List<Healer>();
            DoDatabaseMagic.LoadHealerToList(ref healer);
            rooms = new List<Room>();
            DoDatabaseMagic.LoadRoomToList(ref rooms);

            UpdateControls();


        }

        private void InitializeControls()
        {
            clbGroups.CheckOnClick = true;
            clbItems.CheckOnClick = true;
        }

        private void UpdateControls()
        {
            UpdateTextBox();
            UpdateGroupBox();
            UpdateItemBox();

            cbRoom.Items.Clear();            
            int selectedRoom=-1;
            foreach(Room r in rooms)
            {
                cbRoom.Items.Add(r.ToString());
                if (r.Id == treatment.RoomId)
                    selectedRoom = cbRoom.Items.Count - 1;
            }
            cbRoom.SelectedIndex = selectedRoom;            

            cbHealer.Items.Clear();
            int selectedHealer=-1;
            foreach (Healer h in healer)
            {
                cbHealer.Items.Add(h.ToString());
                if (h.Id == treatment.HealerId)
                    selectedHealer = cbHealer.Items.Count - 1;
            }
            cbHealer.SelectedIndex = selectedHealer;

        }

        private void UpdateTextBox()
        {
            tbDiagnosis.Text = treatment.Diagnosis;
        }

        private void UpdateItemBox()
        {
            foreach (Group g in accounting.Groups)
            {
                // wenn in TreatedWith-Liste, dann mit mit Häkchen
                clbGroups.Items.Add(g, treatment.Contains(g));
            }
        }

        private void UpdateGroupBox()
        {
            foreach (InvoiceItem i in accounting.Items)
            {
                // wenn in TreatedWith-Liste, dann mit mit Häkchen
                clbItems.Items.Add(i, treatment.Contains(i));
            }
        }

        private void clbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void clbItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bOK_Click(object sender, EventArgs e)
        {
            UpdateTreatment();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateTreatment()
        {
            treatment.items.Clear();

            foreach ( Group g in clbGroups.CheckedItems)
            {
                TreatedWith tw = new TreatedWith();
                tw.GroupId = g.Id;

                treatment.items.Add(tw);
            }

            foreach (InvoiceItem i in clbItems.CheckedItems)
            {
                TreatedWith tw = new TreatedWith();
                tw.ItemId = i.Id;

                treatment.items.Add(tw);
            }

            treatment.Diagnosis = tbDiagnosis.Text;
            if (cbRoom.SelectedIndex >= 0)
                treatment.RoomId = rooms[cbRoom.SelectedIndex].Id;
            if (cbHealer.SelectedIndex >= 0)
                treatment.HealerId = healer[cbHealer.SelectedIndex].Id;


        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
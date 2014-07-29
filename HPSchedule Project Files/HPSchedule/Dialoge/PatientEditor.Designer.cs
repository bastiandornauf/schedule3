namespace HPSchedule
{
    partial class PatientEditor
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientEditor));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.contextMenuInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mmSwitchDeath = new System.Windows.Forms.ToolStripMenuItem();
            this.label13 = new System.Windows.Forms.Label();
            this.cbTitle = new System.Windows.Forms.ComboBox();
            this.labelDeath = new System.Windows.Forms.Label();
            this.pickerDeathDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pickerBirthDate = new System.Windows.Forms.DateTimePicker();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLastname = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.tbFirstname = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbMethodOfPayment = new System.Windows.Forms.ComboBox();
            this.cbInsurance = new System.Windows.Forms.ComboBox();
            this.tbTreatmentCount = new System.Windows.Forms.TextBox();
            this.tbLatestTreatment = new System.Windows.Forms.TextBox();
            this.tbFirstTreatment = new System.Windows.Forms.TextBox();
            this.tbHealer = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbPublicComments = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbComments = new System.Windows.Forms.TextBox();
            this.labelNotes = new System.Windows.Forms.Label();
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxContacts = new System.Windows.Forms.ListBox();
            this.contextMenuStripContacts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiContextNew = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiContextEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiContextDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.label12 = new System.Windows.Forms.Label();
            this.listBoxAddress = new System.Windows.Forms.ListBox();
            this.contextMenuStripAddress = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiAddressNew = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiAddressEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiAddressDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiAddressSetDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.label11 = new System.Windows.Forms.Label();
            this.labelPatientId = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.contextMenuInfo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStripContacts.SuspendLayout();
            this.contextMenuStripAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.ContextMenuStrip = this.contextMenuInfo;
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cbTitle);
            this.groupBox1.Controls.Add(this.labelDeath);
            this.groupBox1.Controls.Add(this.pickerDeathDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.pickerBirthDate);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbLastname);
            this.groupBox1.Controls.Add(this.nameLabel);
            this.groupBox1.Controls.Add(this.tbFirstname);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(333, 258);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Allgemeine Informationen";
            // 
            // contextMenuInfo
            // 
            this.contextMenuInfo.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmSwitchDeath});
            this.contextMenuInfo.Name = "contextMenuInfo";
            this.contextMenuInfo.Size = new System.Drawing.Size(172, 28);
            // 
            // mmSwitchDeath
            // 
            this.mmSwitchDeath.Name = "mmSwitchDeath";
            this.mmSwitchDeath.Size = new System.Drawing.Size(171, 24);
            this.mmSwitchDeath.Text = "Tod eintragen";
            this.mmSwitchDeath.Click += new System.EventHandler(this.mmSwitchDeath_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(95, 218);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 17);
            this.label13.TabIndex = 13;
            // 
            // cbTitle
            // 
            this.cbTitle.FormattingEnabled = true;
            this.cbTitle.Items.AddRange(new object[] {
            "Herr",
            "Frau",
            "Herr Dr.",
            "Frau Dr."});
            this.cbTitle.Location = new System.Drawing.Point(95, 119);
            this.cbTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbTitle.Name = "cbTitle";
            this.cbTitle.Size = new System.Drawing.Size(229, 24);
            this.cbTitle.TabIndex = 6;
            // 
            // labelDeath
            // 
            this.labelDeath.AutoSize = true;
            this.labelDeath.Location = new System.Drawing.Point(9, 218);
            this.labelDeath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDeath.Name = "labelDeath";
            this.labelDeath.Size = new System.Drawing.Size(78, 17);
            this.labelDeath.TabIndex = 12;
            this.labelDeath.Text = "Verstorben";
            // 
            // pickerDeathDate
            // 
            this.pickerDeathDate.Enabled = false;
            this.pickerDeathDate.Location = new System.Drawing.Point(95, 213);
            this.pickerDeathDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pickerDeathDate.Name = "pickerDeathDate";
            this.pickerDeathDate.Size = new System.Drawing.Size(229, 22);
            this.pickerDeathDate.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 154);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Geschlecht";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 186);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Geburt";
            // 
            // pickerBirthDate
            // 
            this.pickerBirthDate.Location = new System.Drawing.Point(95, 181);
            this.pickerBirthDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pickerBirthDate.Name = "pickerBirthDate";
            this.pickerBirthDate.Size = new System.Drawing.Size(229, 22);
            this.pickerBirthDate.TabIndex = 11;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(196, 151);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(78, 21);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "weiblich";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(99, 151);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 21);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.Text = "männlich";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Titel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nachname";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vorname";
            // 
            // tbLastname
            // 
            this.tbLastname.AcceptsReturn = true;
            this.tbLastname.Location = new System.Drawing.Point(95, 86);
            this.tbLastname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbLastname.Name = "tbLastname";
            this.tbLastname.Size = new System.Drawing.Size(229, 22);
            this.tbLastname.TabIndex = 4;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(9, 25);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(46, 17);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "label1";
            // 
            // tbFirstname
            // 
            this.tbFirstname.Location = new System.Drawing.Point(95, 53);
            this.tbFirstname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbFirstname.Name = "tbFirstname";
            this.tbFirstname.Size = new System.Drawing.Size(229, 22);
            this.tbFirstname.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbMethodOfPayment);
            this.groupBox3.Controls.Add(this.cbInsurance);
            this.groupBox3.Controls.Add(this.tbTreatmentCount);
            this.groupBox3.Controls.Add(this.tbLatestTreatment);
            this.groupBox3.Controls.Add(this.tbFirstTreatment);
            this.groupBox3.Controls.Add(this.tbHealer);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(357, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(428, 258);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Behandlung und Abrechnung";
            // 
            // cbMethodOfPayment
            // 
            this.cbMethodOfPayment.FormattingEnabled = true;
            this.cbMethodOfPayment.Location = new System.Drawing.Point(160, 86);
            this.cbMethodOfPayment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbMethodOfPayment.Name = "cbMethodOfPayment";
            this.cbMethodOfPayment.Size = new System.Drawing.Size(259, 24);
            this.cbMethodOfPayment.TabIndex = 5;
            // 
            // cbInsurance
            // 
            this.cbInsurance.FormattingEnabled = true;
            this.cbInsurance.Location = new System.Drawing.Point(160, 52);
            this.cbInsurance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbInsurance.Name = "cbInsurance";
            this.cbInsurance.Size = new System.Drawing.Size(259, 24);
            this.cbInsurance.TabIndex = 3;
            // 
            // tbTreatmentCount
            // 
            this.tbTreatmentCount.Location = new System.Drawing.Point(160, 197);
            this.tbTreatmentCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbTreatmentCount.Name = "tbTreatmentCount";
            this.tbTreatmentCount.ReadOnly = true;
            this.tbTreatmentCount.Size = new System.Drawing.Size(259, 22);
            this.tbTreatmentCount.TabIndex = 11;
            // 
            // tbLatestTreatment
            // 
            this.tbLatestTreatment.Location = new System.Drawing.Point(160, 165);
            this.tbLatestTreatment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbLatestTreatment.Name = "tbLatestTreatment";
            this.tbLatestTreatment.ReadOnly = true;
            this.tbLatestTreatment.Size = new System.Drawing.Size(259, 22);
            this.tbLatestTreatment.TabIndex = 9;
            // 
            // tbFirstTreatment
            // 
            this.tbFirstTreatment.Location = new System.Drawing.Point(160, 133);
            this.tbFirstTreatment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbFirstTreatment.Name = "tbFirstTreatment";
            this.tbFirstTreatment.ReadOnly = true;
            this.tbFirstTreatment.Size = new System.Drawing.Size(259, 22);
            this.tbFirstTreatment.TabIndex = 7;
            // 
            // tbHealer
            // 
            this.tbHealer.Location = new System.Drawing.Point(160, 21);
            this.tbHealer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbHealer.Name = "tbHealer";
            this.tbHealer.ReadOnly = true;
            this.tbHealer.Size = new System.Drawing.Size(259, 22);
            this.tbHealer.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 225);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(182, 17);
            this.label16.TabIndex = 12;
            this.label16.Text = "(nicht abgerechnet/gesamt)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 201);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(147, 17);
            this.label15.TabIndex = 10;
            this.label15.Text = "Anzahl Behandlungen";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 137);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 17);
            this.label14.TabIndex = 6;
            this.label14.Text = "Erste Behandlung";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 169);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 17);
            this.label10.TabIndex = 8;
            this.label10.Text = "Letzte Behandlung";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 89);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 17);
            this.label9.TabIndex = 4;
            this.label9.Text = "Zahlungsweise";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 57);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Abrechnungsart";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 25);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Behandler";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbPublicComments);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.tbComments);
            this.groupBox4.Controls.Add(this.labelNotes);
            this.groupBox4.Location = new System.Drawing.Point(357, 281);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(428, 318);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Notizen";
            // 
            // tbPublicComments
            // 
            this.tbPublicComments.Location = new System.Drawing.Point(12, 186);
            this.tbPublicComments.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPublicComments.Multiline = true;
            this.tbPublicComments.Name = "tbPublicComments";
            this.tbPublicComments.Size = new System.Drawing.Size(407, 116);
            this.tbPublicComments.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 166);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Bemerkung";
            // 
            // tbComments
            // 
            this.tbComments.Location = new System.Drawing.Point(12, 49);
            this.tbComments.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbComments.Multiline = true;
            this.tbComments.Name = "tbComments";
            this.tbComments.Size = new System.Drawing.Size(407, 116);
            this.tbComments.TabIndex = 2;
            // 
            // labelNotes
            // 
            this.labelNotes.AutoSize = true;
            this.labelNotes.Location = new System.Drawing.Point(12, 30);
            this.labelNotes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Size = new System.Drawing.Size(56, 17);
            this.labelNotes.TabIndex = 0;
            this.labelNotes.Text = "Notizen";
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(684, 606);
            this.bOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(100, 28);
            this.bOK.TabIndex = 5;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(576, 606);
            this.bCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(100, 28);
            this.bCancel.TabIndex = 4;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxContacts);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.listBoxAddress);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(16, 281);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(333, 318);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kontakinformation";
            // 
            // listBoxContacts
            // 
            this.listBoxContacts.ContextMenuStrip = this.contextMenuStripContacts;
            this.listBoxContacts.FormattingEnabled = true;
            this.listBoxContacts.ItemHeight = 16;
            this.listBoxContacts.Location = new System.Drawing.Point(12, 186);
            this.listBoxContacts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxContacts.Name = "listBoxContacts";
            this.listBoxContacts.Size = new System.Drawing.Size(312, 116);
            this.listBoxContacts.TabIndex = 0;
            // 
            // contextMenuStripContacts
            // 
            this.contextMenuStripContacts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiContextNew,
            this.cmiContextEdit,
            this.cmiContextDelete});
            this.contextMenuStripContacts.Name = "contextMenuStripContacts";
            this.contextMenuStripContacts.Size = new System.Drawing.Size(151, 76);
            // 
            // cmiContextNew
            // 
            this.cmiContextNew.Name = "cmiContextNew";
            this.cmiContextNew.Size = new System.Drawing.Size(150, 24);
            this.cmiContextNew.Text = "Neu";
            this.cmiContextNew.Click += new System.EventHandler(this.cmiContextNew_Click);
            // 
            // cmiContextEdit
            // 
            this.cmiContextEdit.Name = "cmiContextEdit";
            this.cmiContextEdit.Size = new System.Drawing.Size(150, 24);
            this.cmiContextEdit.Text = "Bearbeiten";
            this.cmiContextEdit.Click += new System.EventHandler(this.cmiContextEdit_Click);
            // 
            // cmiContextDelete
            // 
            this.cmiContextDelete.Name = "cmiContextDelete";
            this.cmiContextDelete.Size = new System.Drawing.Size(150, 24);
            this.cmiContextDelete.Text = "Löschen";
            this.cmiContextDelete.Click += new System.EventHandler(this.cmiContextDelete_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 166);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(147, 17);
            this.label12.TabIndex = 3;
            this.label12.Text = "Telefon, Fax, eMail, ...";
            // 
            // listBoxAddress
            // 
            this.listBoxAddress.ContextMenuStrip = this.contextMenuStripAddress;
            this.listBoxAddress.FormattingEnabled = true;
            this.listBoxAddress.ItemHeight = 16;
            this.listBoxAddress.Location = new System.Drawing.Point(9, 41);
            this.listBoxAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxAddress.Name = "listBoxAddress";
            this.listBoxAddress.Size = new System.Drawing.Size(315, 116);
            this.listBoxAddress.TabIndex = 2;
            // 
            // contextMenuStripAddress
            // 
            this.contextMenuStripAddress.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiAddressNew,
            this.cmiAddressEdit,
            this.cmiAddressDelete,
            this.cmiAddressSetDefault});
            this.contextMenuStripAddress.Name = "contextMenuStripAddress";
            this.contextMenuStripAddress.Size = new System.Drawing.Size(224, 100);
            // 
            // cmiAddressNew
            // 
            this.cmiAddressNew.Name = "cmiAddressNew";
            this.cmiAddressNew.Size = new System.Drawing.Size(223, 24);
            this.cmiAddressNew.Text = "Neu";
            this.cmiAddressNew.Click += new System.EventHandler(this.cmiAddressNew_Click);
            // 
            // cmiAddressEdit
            // 
            this.cmiAddressEdit.Name = "cmiAddressEdit";
            this.cmiAddressEdit.Size = new System.Drawing.Size(223, 24);
            this.cmiAddressEdit.Text = "Bearbeiten";
            this.cmiAddressEdit.Click += new System.EventHandler(this.cmiAddressEdit_Click);
            // 
            // cmiAddressDelete
            // 
            this.cmiAddressDelete.Name = "cmiAddressDelete";
            this.cmiAddressDelete.Size = new System.Drawing.Size(223, 24);
            this.cmiAddressDelete.Text = "Löschen";
            this.cmiAddressDelete.Click += new System.EventHandler(this.cmiAddressDelete_Click);
            // 
            // cmiAddressSetDefault
            // 
            this.cmiAddressSetDefault.Name = "cmiAddressSetDefault";
            this.cmiAddressSetDefault.Size = new System.Drawing.Size(223, 24);
            this.cmiAddressSetDefault.Text = "Als Rechnungsadresse";
            this.cmiAddressSetDefault.Click += new System.EventHandler(this.cmiAddressSetDefault_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 20);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Adresse";
            // 
            // labelPatientId
            // 
            this.labelPatientId.Location = new System.Drawing.Point(704, 4);
            this.labelPatientId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPatientId.Name = "labelPatientId";
            this.labelPatientId.Size = new System.Drawing.Size(80, 16);
            this.labelPatientId.TabIndex = 6;
            this.labelPatientId.Text = "label14";
            this.labelPatientId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PatientEditor
            // 
            this.AcceptButton = this.bOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(801, 646);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.labelPatientId);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PatientEditor";
            this.Text = "Patient";
            this.Load += new System.EventHandler(this.PatientEditor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuInfo.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStripContacts.ResumeLayout(false);
            this.contextMenuStripAddress.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbLastname;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox tbFirstname;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker pickerBirthDate;
        private System.Windows.Forms.Label labelDeath;
        private System.Windows.Forms.DateTimePicker pickerDeathDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox listBoxContacts;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox listBoxAddress;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAddress;
        private System.Windows.Forms.ToolStripMenuItem cmiAddressNew;
        private System.Windows.Forms.ToolStripMenuItem cmiAddressEdit;
        private System.Windows.Forms.ToolStripMenuItem cmiAddressDelete;
        private System.Windows.Forms.ToolStripMenuItem cmiAddressSetDefault;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripContacts;
        private System.Windows.Forms.ToolStripMenuItem cmiContextNew;
        private System.Windows.Forms.ToolStripMenuItem cmiContextEdit;
        private System.Windows.Forms.ToolStripMenuItem cmiContextDelete;
        private System.Windows.Forms.Label labelNotes;
        private System.Windows.Forms.TextBox tbComments;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPublicComments;
        private System.Windows.Forms.ComboBox cbTitle;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ContextMenuStrip contextMenuInfo;
        private System.Windows.Forms.ToolStripMenuItem mmSwitchDeath;
        private System.Windows.Forms.Label labelPatientId;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbTreatmentCount;
        private System.Windows.Forms.TextBox tbLatestTreatment;
        private System.Windows.Forms.TextBox tbFirstTreatment;
        private System.Windows.Forms.TextBox tbHealer;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbMethodOfPayment;
        private System.Windows.Forms.ComboBox cbInsurance;
    }
}
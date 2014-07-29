namespace HPSchedule.Dialoge
{
    partial class TreatmentEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreatmentEditor));
            this.label1 = new System.Windows.Forms.Label();
            this.tbPatient = new System.Windows.Forms.TextBox();
            this.bSearchPatient = new System.Windows.Forms.Button();
            this.Behandlung = new System.Windows.Forms.GroupBox();
            this.bEdit = new System.Windows.Forms.Button();
            this.bCopyTreatment = new System.Windows.Forms.Button();
            this.bNewTreatment = new System.Windows.Forms.Button();
            this.lbTreatmentInfo = new System.Windows.Forms.ListBox();
            this.cbTreatmentLastFive = new System.Windows.Forms.ComboBox();
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Behandlung.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient";
            // 
            // tbPatient
            // 
            this.tbPatient.Location = new System.Drawing.Point(74, 10);
            this.tbPatient.Name = "tbPatient";
            this.tbPatient.ReadOnly = true;
            this.tbPatient.Size = new System.Drawing.Size(206, 20);
            this.tbPatient.TabIndex = 1;
            // 
            // bSearchPatient
            // 
            this.bSearchPatient.Location = new System.Drawing.Point(286, 8);
            this.bSearchPatient.Name = "bSearchPatient";
            this.bSearchPatient.Size = new System.Drawing.Size(28, 23);
            this.bSearchPatient.TabIndex = 2;
            this.bSearchPatient.Text = "...";
            this.bSearchPatient.UseVisualStyleBackColor = true;
            this.bSearchPatient.Click += new System.EventHandler(this.bSearchPatient_Click);
            // 
            // Behandlung
            // 
            this.Behandlung.Controls.Add(this.bEdit);
            this.Behandlung.Controls.Add(this.bCopyTreatment);
            this.Behandlung.Controls.Add(this.bNewTreatment);
            this.Behandlung.Controls.Add(this.lbTreatmentInfo);
            this.Behandlung.Controls.Add(this.cbTreatmentLastFive);
            this.Behandlung.Location = new System.Drawing.Point(12, 67);
            this.Behandlung.Name = "Behandlung";
            this.Behandlung.Size = new System.Drawing.Size(404, 260);
            this.Behandlung.TabIndex = 7;
            this.Behandlung.TabStop = false;
            this.Behandlung.Text = "Behandlung";
            // 
            // bEdit
            // 
            this.bEdit.Location = new System.Drawing.Point(147, 226);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(75, 23);
            this.bEdit.TabIndex = 4;
            this.bEdit.Text = "Bearbeiten";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // bCopyTreatment
            // 
            this.bCopyTreatment.Location = new System.Drawing.Point(228, 226);
            this.bCopyTreatment.Name = "bCopyTreatment";
            this.bCopyTreatment.Size = new System.Drawing.Size(89, 23);
            this.bCopyTreatment.TabIndex = 3;
            this.bCopyTreatment.Text = "Neu (als Kopie)";
            this.bCopyTreatment.UseVisualStyleBackColor = true;
            this.bCopyTreatment.Click += new System.EventHandler(this.bCopyTreatment_Click);
            // 
            // bNewTreatment
            // 
            this.bNewTreatment.Location = new System.Drawing.Point(323, 225);
            this.bNewTreatment.Name = "bNewTreatment";
            this.bNewTreatment.Size = new System.Drawing.Size(75, 23);
            this.bNewTreatment.TabIndex = 2;
            this.bNewTreatment.Text = "Neu";
            this.bNewTreatment.UseVisualStyleBackColor = true;
            this.bNewTreatment.Click += new System.EventHandler(this.bNewTreatment_Click);
            // 
            // lbTreatmentInfo
            // 
            this.lbTreatmentInfo.FormattingEnabled = true;
            this.lbTreatmentInfo.Location = new System.Drawing.Point(6, 46);
            this.lbTreatmentInfo.Name = "lbTreatmentInfo";
            this.lbTreatmentInfo.Size = new System.Drawing.Size(392, 173);
            this.lbTreatmentInfo.TabIndex = 1;
            // 
            // cbTreatmentLastFive
            // 
            this.cbTreatmentLastFive.FormattingEnabled = true;
            this.cbTreatmentLastFive.Location = new System.Drawing.Point(6, 19);
            this.cbTreatmentLastFive.Name = "cbTreatmentLastFive";
            this.cbTreatmentLastFive.Size = new System.Drawing.Size(392, 21);
            this.cbTreatmentLastFive.TabIndex = 0;
            this.cbTreatmentLastFive.SelectedIndexChanged += new System.EventHandler(this.cbTreatmentLastFive_SelectedIndexChanged);
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(341, 333);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 23);
            this.bOK.TabIndex = 8;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(260, 333);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 9;
            this.bCancel.Text = "Abbrechen";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Termin:";
            // 
            // TreatmentEditor
            // 
            this.AcceptButton = this.bOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(428, 362);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.Behandlung);
            this.Controls.Add(this.bSearchPatient);
            this.Controls.Add(this.tbPatient);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TreatmentEditor";
            this.Text = "Termin";
            this.Load += new System.EventHandler(this.TreatmentEditor_Load);
            this.Behandlung.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPatient;
        private System.Windows.Forms.Button bSearchPatient;
        private System.Windows.Forms.GroupBox Behandlung;
        private System.Windows.Forms.Button bNewTreatment;
        private System.Windows.Forms.ListBox lbTreatmentInfo;
        private System.Windows.Forms.ComboBox cbTreatmentLastFive;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bCopyTreatment;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
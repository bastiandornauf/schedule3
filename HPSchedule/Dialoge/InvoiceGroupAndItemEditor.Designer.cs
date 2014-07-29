namespace HPSchedule
{
    partial class InvoiceGroupAndItemEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceGroupAndItemEditor));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabItems = new System.Windows.Forms.TabPage();
            this.listViewItems = new System.Windows.Forms.ListView();
            this.columnNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFee = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnItemId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mmItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mmItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mmItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tabGroups = new System.Windows.Forms.TabPage();
            this.listViewGroups = new System.Windows.Forms.ListView();
            this.columnLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnItems = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnGroupFee = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnGroupId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmGroups = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mmGroupNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mmGroupEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mmGroupDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tabInsurances = new System.Windows.Forms.TabPage();
            this.listBoxInsurances = new System.Windows.Forms.ListBox();
            this.cmInsurance = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mmInsuranceNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mmInsuranceEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mmInsuranceDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.bOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxShowFeesBasedOnInsurance = new System.Windows.Forms.ComboBox();
            this.bApply = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabItems.SuspendLayout();
            this.cmItems.SuspendLayout();
            this.tabGroups.SuspendLayout();
            this.cmGroups.SuspendLayout();
            this.tabInsurances.SuspendLayout();
            this.cmInsurance.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabItems);
            this.tabControl1.Controls.Add(this.tabGroups);
            this.tabControl1.Controls.Add(this.tabInsurances);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(528, 352);
            this.tabControl1.TabIndex = 0;
            // 
            // tabItems
            // 
            this.tabItems.Controls.Add(this.listViewItems);
            this.tabItems.Location = new System.Drawing.Point(4, 22);
            this.tabItems.Name = "tabItems";
            this.tabItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabItems.Size = new System.Drawing.Size(520, 326);
            this.tabItems.TabIndex = 0;
            this.tabItems.Text = "Artikel";
            this.tabItems.UseVisualStyleBackColor = true;
            // 
            // listViewItems
            // 
            this.listViewItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNumber,
            this.columnDesc,
            this.columnFee,
            this.columnItemId});
            this.listViewItems.ContextMenuStrip = this.cmItems;
            this.listViewItems.FullRowSelect = true;
            this.listViewItems.GridLines = true;
            this.listViewItems.Location = new System.Drawing.Point(6, 6);
            this.listViewItems.MultiSelect = false;
            this.listViewItems.Name = "listViewItems";
            this.listViewItems.Size = new System.Drawing.Size(508, 314);
            this.listViewItems.TabIndex = 0;
            this.listViewItems.UseCompatibleStateImageBehavior = false;
            this.listViewItems.View = System.Windows.Forms.View.Details;
            // 
            // columnNumber
            // 
            this.columnNumber.Text = "Nummer";
            this.columnNumber.Width = 62;
            // 
            // columnDesc
            // 
            this.columnDesc.Text = "Beschreibung";
            this.columnDesc.Width = 310;
            // 
            // columnFee
            // 
            this.columnFee.Text = "Betrag";
            this.columnFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnFee.Width = 84;
            // 
            // columnItemId
            // 
            this.columnItemId.Text = "ID";
            this.columnItemId.Width = 30;
            // 
            // cmItems
            // 
            this.cmItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmItemNew,
            this.mmItemEdit,
            this.mmItemDelete});
            this.cmItems.Name = "cmInsurance";
            this.cmItems.Size = new System.Drawing.Size(138, 70);
            // 
            // mmItemNew
            // 
            this.mmItemNew.Name = "mmItemNew";
            this.mmItemNew.Size = new System.Drawing.Size(137, 22);
            this.mmItemNew.Text = "Neu";
            this.mmItemNew.Click += new System.EventHandler(this.mmItemNew_Click);
            // 
            // mmItemEdit
            // 
            this.mmItemEdit.Name = "mmItemEdit";
            this.mmItemEdit.Size = new System.Drawing.Size(137, 22);
            this.mmItemEdit.Text = "Bearbeiten";
            this.mmItemEdit.Click += new System.EventHandler(this.mmItemEdit_Click);
            // 
            // mmItemDelete
            // 
            this.mmItemDelete.Name = "mmItemDelete";
            this.mmItemDelete.Size = new System.Drawing.Size(137, 22);
            this.mmItemDelete.Text = "Löschen";
            this.mmItemDelete.Click += new System.EventHandler(this.mmItemDelete_Click);
            // 
            // tabGroups
            // 
            this.tabGroups.Controls.Add(this.listViewGroups);
            this.tabGroups.Location = new System.Drawing.Point(4, 22);
            this.tabGroups.Name = "tabGroups";
            this.tabGroups.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroups.Size = new System.Drawing.Size(520, 326);
            this.tabGroups.TabIndex = 1;
            this.tabGroups.Text = "Gruppen";
            this.tabGroups.UseVisualStyleBackColor = true;
            // 
            // listViewGroups
            // 
            this.listViewGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnLabel,
            this.columnItems,
            this.columnGroupFee,
            this.columnGroupId});
            this.listViewGroups.ContextMenuStrip = this.cmGroups;
            this.listViewGroups.FullRowSelect = true;
            this.listViewGroups.GridLines = true;
            this.listViewGroups.Location = new System.Drawing.Point(6, 6);
            this.listViewGroups.MultiSelect = false;
            this.listViewGroups.Name = "listViewGroups";
            this.listViewGroups.Size = new System.Drawing.Size(508, 314);
            this.listViewGroups.TabIndex = 0;
            this.listViewGroups.UseCompatibleStateImageBehavior = false;
            this.listViewGroups.View = System.Windows.Forms.View.Details;
            // 
            // columnLabel
            // 
            this.columnLabel.Text = "Label";
            this.columnLabel.Width = 153;
            // 
            // columnItems
            // 
            this.columnItems.Text = "Artikel-ID";
            this.columnItems.Width = 206;
            // 
            // columnGroupFee
            // 
            this.columnGroupFee.Text = "Betrag";
            this.columnGroupFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnGroupFee.Width = 86;
            // 
            // columnGroupId
            // 
            this.columnGroupId.Text = "ID";
            this.columnGroupId.Width = 34;
            // 
            // cmGroups
            // 
            this.cmGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmGroupNew,
            this.mmGroupEdit,
            this.mmGroupDelete});
            this.cmGroups.Name = "cmInsurance";
            this.cmGroups.Size = new System.Drawing.Size(138, 70);
            // 
            // mmGroupNew
            // 
            this.mmGroupNew.Name = "mmGroupNew";
            this.mmGroupNew.Size = new System.Drawing.Size(137, 22);
            this.mmGroupNew.Text = "Neu";
            this.mmGroupNew.Click += new System.EventHandler(this.mmGroupNew_Click);
            // 
            // mmGroupEdit
            // 
            this.mmGroupEdit.Name = "mmGroupEdit";
            this.mmGroupEdit.Size = new System.Drawing.Size(137, 22);
            this.mmGroupEdit.Text = "Bearbeiten";
            this.mmGroupEdit.Click += new System.EventHandler(this.mmGroupEdit_Click);
            // 
            // mmGroupDelete
            // 
            this.mmGroupDelete.Name = "mmGroupDelete";
            this.mmGroupDelete.Size = new System.Drawing.Size(137, 22);
            this.mmGroupDelete.Text = "Löschen";
            this.mmGroupDelete.Click += new System.EventHandler(this.mmGroupDelete_Click);
            // 
            // tabInsurances
            // 
            this.tabInsurances.Controls.Add(this.listBoxInsurances);
            this.tabInsurances.Location = new System.Drawing.Point(4, 22);
            this.tabInsurances.Name = "tabInsurances";
            this.tabInsurances.Padding = new System.Windows.Forms.Padding(3);
            this.tabInsurances.Size = new System.Drawing.Size(520, 326);
            this.tabInsurances.TabIndex = 2;
            this.tabInsurances.Text = "Abrechnung";
            this.tabInsurances.UseVisualStyleBackColor = true;
            // 
            // listBoxInsurances
            // 
            this.listBoxInsurances.ContextMenuStrip = this.cmInsurance;
            this.listBoxInsurances.FormattingEnabled = true;
            this.listBoxInsurances.Location = new System.Drawing.Point(6, 6);
            this.listBoxInsurances.Name = "listBoxInsurances";
            this.listBoxInsurances.Size = new System.Drawing.Size(508, 316);
            this.listBoxInsurances.TabIndex = 0;
            // 
            // cmInsurance
            // 
            this.cmInsurance.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmInsuranceNew,
            this.mmInsuranceEdit,
            this.mmInsuranceDelete});
            this.cmInsurance.Name = "cmInsurance";
            this.cmInsurance.Size = new System.Drawing.Size(138, 70);
            // 
            // mmInsuranceNew
            // 
            this.mmInsuranceNew.Name = "mmInsuranceNew";
            this.mmInsuranceNew.Size = new System.Drawing.Size(137, 22);
            this.mmInsuranceNew.Text = "Neu";
            this.mmInsuranceNew.Click += new System.EventHandler(this.mmInsuranceNew_Click);
            // 
            // mmInsuranceEdit
            // 
            this.mmInsuranceEdit.Name = "mmInsuranceEdit";
            this.mmInsuranceEdit.Size = new System.Drawing.Size(137, 22);
            this.mmInsuranceEdit.Text = "Bearbeiten";
            this.mmInsuranceEdit.Click += new System.EventHandler(this.mmInsuranceEdit_Click);
            // 
            // mmInsuranceDelete
            // 
            this.mmInsuranceDelete.Name = "mmInsuranceDelete";
            this.mmInsuranceDelete.Size = new System.Drawing.Size(137, 22);
            this.mmInsuranceDelete.Text = "Löschen";
            this.mmInsuranceDelete.Click += new System.EventHandler(this.mmInsuranceDelete_Click);
            // 
            // bOK
            // 
            this.bOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOK.Location = new System.Drawing.Point(465, 370);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 23);
            this.bOK.TabIndex = 1;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 375);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Abrechnungsart:";
            // 
            // comboBoxShowFeesBasedOnInsurance
            // 
            this.comboBoxShowFeesBasedOnInsurance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxShowFeesBasedOnInsurance.FormattingEnabled = true;
            this.comboBoxShowFeesBasedOnInsurance.Location = new System.Drawing.Point(104, 372);
            this.comboBoxShowFeesBasedOnInsurance.Name = "comboBoxShowFeesBasedOnInsurance";
            this.comboBoxShowFeesBasedOnInsurance.Size = new System.Drawing.Size(146, 21);
            this.comboBoxShowFeesBasedOnInsurance.TabIndex = 7;
            this.comboBoxShowFeesBasedOnInsurance.SelectedIndexChanged += new System.EventHandler(this.comboBoxShowFeesBasedOnInsurance_SelectedIndexChanged);
            // 
            // bApply
            // 
            this.bApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bApply.Location = new System.Drawing.Point(377, 369);
            this.bApply.Name = "bApply";
            this.bApply.Size = new System.Drawing.Size(82, 23);
            this.bApply.TabIndex = 8;
            this.bApply.Text = "Übernehmen";
            this.bApply.UseVisualStyleBackColor = true;
            this.bApply.Click += new System.EventHandler(this.bApply_Click);
            // 
            // InvoiceGroupAndItemEditor
            // 
            this.AcceptButton = this.bOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 419);
            this.Controls.Add(this.bApply);
            this.Controls.Add(this.comboBoxShowFeesBasedOnInsurance);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InvoiceGroupAndItemEditor";
            this.Text = "Artikel und Gruppen verwalten";
            this.tabControl1.ResumeLayout(false);
            this.tabItems.ResumeLayout(false);
            this.cmItems.ResumeLayout(false);
            this.tabGroups.ResumeLayout(false);
            this.cmGroups.ResumeLayout(false);
            this.tabInsurances.ResumeLayout(false);
            this.cmInsurance.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabItems;
        private System.Windows.Forms.TabPage tabGroups;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.ListView listViewItems;
        private System.Windows.Forms.ListView listViewGroups;
        private System.Windows.Forms.TabPage tabInsurances;
        private System.Windows.Forms.ColumnHeader columnNumber;
        private System.Windows.Forms.ColumnHeader columnDesc;
        private System.Windows.Forms.ColumnHeader columnFee;
        private System.Windows.Forms.ColumnHeader columnLabel;
        private System.Windows.Forms.ColumnHeader columnItems;
        private System.Windows.Forms.ColumnHeader columnGroupFee;
        private System.Windows.Forms.ListBox listBoxInsurances;
        private System.Windows.Forms.ContextMenuStrip cmInsurance;
        private System.Windows.Forms.ToolStripMenuItem mmInsuranceNew;
        private System.Windows.Forms.ToolStripMenuItem mmInsuranceEdit;
        private System.Windows.Forms.ToolStripMenuItem mmInsuranceDelete;
        private System.Windows.Forms.ContextMenuStrip cmGroups;
        private System.Windows.Forms.ToolStripMenuItem mmGroupNew;
        private System.Windows.Forms.ToolStripMenuItem mmGroupEdit;
        private System.Windows.Forms.ToolStripMenuItem mmGroupDelete;
        private System.Windows.Forms.ContextMenuStrip cmItems;
        private System.Windows.Forms.ToolStripMenuItem mmItemNew;
        private System.Windows.Forms.ToolStripMenuItem mmItemEdit;
        private System.Windows.Forms.ToolStripMenuItem mmItemDelete;
        private System.Windows.Forms.ColumnHeader columnGroupId;
        private System.Windows.Forms.ColumnHeader columnItemId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxShowFeesBasedOnInsurance;
        private System.Windows.Forms.Button bApply;
    }
}
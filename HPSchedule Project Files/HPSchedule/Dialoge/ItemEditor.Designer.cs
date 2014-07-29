namespace HPSchedule.Dialoge
{
    partial class ItemEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemEditor));
            this.label1 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewFees = new System.Windows.Forms.ListView();
            this.columnInsurance = new System.Windows.Forms.ColumnHeader();
            this.columnFee = new System.Windows.Forms.ColumnHeader();
            this.cmFeeList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mmEditFee = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bOK = new System.Windows.Forms.Button();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmFeeList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Beschreibung";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(91, 10);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(327, 20);
            this.tbDescription.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nummer";
            // 
            // listViewFees
            // 
            this.listViewFees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFees.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnInsurance,
            this.columnFee});
            this.listViewFees.ContextMenuStrip = this.cmFeeList;
            this.listViewFees.FullRowSelect = true;
            this.listViewFees.GridLines = true;
            this.listViewFees.Location = new System.Drawing.Point(16, 97);
            this.listViewFees.MultiSelect = false;
            this.listViewFees.Name = "listViewFees";
            this.listViewFees.Size = new System.Drawing.Size(402, 128);
            this.listViewFees.TabIndex = 6;
            this.listViewFees.UseCompatibleStateImageBehavior = false;
            this.listViewFees.View = System.Windows.Forms.View.Details;
            this.listViewFees.SelectedIndexChanged += new System.EventHandler(this.listViewFees_SelectedIndexChanged);
            // 
            // columnInsurance
            // 
            this.columnInsurance.Text = "Abrechnungsart";
            this.columnInsurance.Width = 277;
            // 
            // columnFee
            // 
            this.columnFee.Text = "Preis";
            this.columnFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnFee.Width = 114;
            // 
            // cmFeeList
            // 
            this.cmFeeList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmEditFee});
            this.cmFeeList.Name = "cmFeeList";
            this.cmFeeList.Size = new System.Drawing.Size(138, 26);
            // 
            // mmEditFee
            // 
            this.mmEditFee.Name = "mmEditFee";
            this.mmEditFee.Size = new System.Drawing.Size(137, 22);
            this.mmEditFee.Text = "Bearbeiten";
            this.mmEditFee.Click += new System.EventHandler(this.mmEditFee_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "(0.0 wenn kein GebüH-Artikel)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Preise";
            // 
            // bOK
            // 
            this.bOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOK.Location = new System.Drawing.Point(342, 231);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 23);
            this.bOK.TabIndex = 7;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(91, 36);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(100, 20);
            this.tbNumber.TabIndex = 3;
            this.tbNumber.TextChanged += new System.EventHandler(this.tbNumber_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ItemEditor
            // 
            this.AcceptButton = this.bOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 266);
            this.Controls.Add(this.tbNumber);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listViewFees);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ItemEditor";
            this.Text = "Artikel";
            this.cmFeeList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listViewFees;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnInsurance;
        private System.Windows.Forms.ColumnHeader columnFee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ContextMenuStrip cmFeeList;
        private System.Windows.Forms.ToolStripMenuItem mmEditFee;
    }
}
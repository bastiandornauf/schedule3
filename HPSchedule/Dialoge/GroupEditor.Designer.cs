namespace HPSchedule.Dialoge
{
    partial class GroupEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupEditor));
            this.listViewItems = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewGroup = new System.Windows.Forms.ListView();
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLabel = new System.Windows.Forms.TextBox();
            this.cbShowFees = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zurGruppeHinzufuegenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ausDerGruppeEntfernenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewItems
            // 
            this.listViewItems.AllowDrop = true;
            this.listViewItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewItems.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewItems.Location = new System.Drawing.Point(12, 68);
            this.listViewItems.Name = "listViewItems";
            this.listViewItems.Size = new System.Drawing.Size(514, 152);
            this.listViewItems.TabIndex = 3;
            this.listViewItems.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "alle Artikel";
            // 
            // listViewGroup
            // 
            this.listViewGroup.AllowDrop = true;
            this.listViewGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewGroup.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewGroup.Location = new System.Drawing.Point(12, 237);
            this.listViewGroup.Name = "listViewGroup";
            this.listViewGroup.Size = new System.Drawing.Size(514, 141);
            this.listViewGroup.TabIndex = 5;
            this.listViewGroup.UseCompatibleStateImageBehavior = false;
            // 
            // bOK
            // 
            this.bOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOK.Location = new System.Drawing.Point(451, 403);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 23);
            this.bOK.TabIndex = 7;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(370, 402);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 8;
            this.bCancel.Text = "Abbrechen";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Artikel in der Gruppe";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Gewünschte Artikel per Drag&&Drop verschieben.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Label";
            // 
            // tbLabel
            // 
            this.tbLabel.Location = new System.Drawing.Point(48, 10);
            this.tbLabel.Name = "tbLabel";
            this.tbLabel.Size = new System.Drawing.Size(193, 20);
            this.tbLabel.TabIndex = 1;
            // 
            // cbShowFees
            // 
            this.cbShowFees.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbShowFees.AutoSize = true;
            this.cbShowFees.Location = new System.Drawing.Point(421, 13);
            this.cbShowFees.Name = "cbShowFees";
            this.cbShowFees.Size = new System.Drawing.Size(101, 17);
            this.cbShowFees.TabIndex = 9;
            this.cbShowFees.Text = "Preise anzeigen";
            this.cbShowFees.UseVisualStyleBackColor = true;
            this.cbShowFees.CheckedChanged += new System.EventHandler(this.cbShowFees_CheckedChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zurGruppeHinzufuegenToolStripMenuItem,
            this.ausDerGruppeEntfernenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(228, 80);
            // 
            // zurGruppeHinzufügenToolStripMenuItem
            // 
            this.zurGruppeHinzufuegenToolStripMenuItem.Image = global::HPSchedule.Properties.Resources.NewDoc;
            this.zurGruppeHinzufuegenToolStripMenuItem.Name = "zurGruppeHinzufügenToolStripMenuItem";
            this.zurGruppeHinzufuegenToolStripMenuItem.Size = new System.Drawing.Size(227, 38);
            this.zurGruppeHinzufuegenToolStripMenuItem.Text = "Zur Gruppe hinzufügen";
            this.zurGruppeHinzufuegenToolStripMenuItem.Click += new System.EventHandler(this.zurGruppeHinzufügenToolStripMenuItem_Click);
            // 
            // ausDerGruppeEntfernenToolStripMenuItem
            // 
            this.ausDerGruppeEntfernenToolStripMenuItem.Image = global::HPSchedule.Properties.Resources.Stop;
            this.ausDerGruppeEntfernenToolStripMenuItem.Name = "ausDerGruppeEntfernenToolStripMenuItem";
            this.ausDerGruppeEntfernenToolStripMenuItem.Size = new System.Drawing.Size(227, 38);
            this.ausDerGruppeEntfernenToolStripMenuItem.Text = "Aus der Gruppe entfernen";
            this.ausDerGruppeEntfernenToolStripMenuItem.Click += new System.EventHandler(this.ausDerGruppeEntfernenToolStripMenuItem_Click);
            // 
            // GroupEditor
            // 
            this.AcceptButton = this.bOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(538, 438);
            this.Controls.Add(this.cbShowFees);
            this.Controls.Add(this.tbLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.listViewGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewItems);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GroupEditor";
            this.Text = "Gruppe";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewGroup;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLabel;
        private System.Windows.Forms.CheckBox cbShowFees;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem zurGruppeHinzufuegenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ausDerGruppeEntfernenToolStripMenuItem;
    }
}
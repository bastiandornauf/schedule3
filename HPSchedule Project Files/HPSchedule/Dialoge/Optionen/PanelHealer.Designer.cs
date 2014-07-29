namespace HPSchedule.Dialoge.Optionen
{
    partial class PanelHealer
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.farbeFestlegenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.namenBearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.entfernenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(387, 238);
            this.listBox1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripMenuItem,
            this.bearbeitenToolStripMenuItem,
            this.entfernenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 140);
            // 
            // neuToolStripMenuItem
            // 
            this.neuToolStripMenuItem.Image = global::HPSchedule.Properties.Resources.doctor;
            this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(153, 38);
            this.neuToolStripMenuItem.Text = "Neu";
            this.neuToolStripMenuItem.Click += new System.EventHandler(this.neuToolStripMenuItem_Click);
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.farbeFestlegenToolStripMenuItem,
            this.namenBearbeitenToolStripMenuItem});
            this.bearbeitenToolStripMenuItem.Image = global::HPSchedule.Properties.Resources.Edit;
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(153, 38);
            this.bearbeitenToolStripMenuItem.Text = "Bearbeiten";
            // 
            // farbeFestlegenToolStripMenuItem
            // 
            this.farbeFestlegenToolStripMenuItem.Name = "farbeFestlegenToolStripMenuItem";
            this.farbeFestlegenToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.farbeFestlegenToolStripMenuItem.Text = "Farbe festlegen";
            this.farbeFestlegenToolStripMenuItem.Click += new System.EventHandler(this.farbeFestlegenToolStripMenuItem_Click);
            // 
            // namenBearbeitenToolStripMenuItem
            // 
            this.namenBearbeitenToolStripMenuItem.Name = "namenBearbeitenToolStripMenuItem";
            this.namenBearbeitenToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.namenBearbeitenToolStripMenuItem.Text = "Namen bearbeiten";
            this.namenBearbeitenToolStripMenuItem.Click += new System.EventHandler(this.namenBearbeitenToolStripMenuItem_Click);
            // 
            // entfernenToolStripMenuItem
            // 
            this.entfernenToolStripMenuItem.Image = global::HPSchedule.Properties.Resources.Delete;
            this.entfernenToolStripMenuItem.Name = "entfernenToolStripMenuItem";
            this.entfernenToolStripMenuItem.Size = new System.Drawing.Size(168, 38);
            this.entfernenToolStripMenuItem.Text = "Entfernen";
            this.entfernenToolStripMenuItem.Click += new System.EventHandler(this.entfernenToolStripMenuItem_Click);
            // 
            // PanelHealer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBox1);
            this.Name = "PanelHealer";
            this.Size = new System.Drawing.Size(387, 249);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem farbeFestlegenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem namenBearbeitenToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem entfernenToolStripMenuItem;
    }
}

namespace HPSchedule.Dialoge
{
    partial class InvoicePrintingDlg
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
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.settingsDgv = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.invoiceDgv = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.auswahlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aktualisierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceDgv)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            this.kryptonSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.settingsDgv);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.invoiceDgv);
            this.kryptonSplitContainer1.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighInternalProfile;
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(661, 423);
            this.kryptonSplitContainer1.SplitterDistance = 99;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // settingsDgv
            // 
            this.settingsDgv.AllowUserToAddRows = false;
            this.settingsDgv.AllowUserToDeleteRows = false;
            this.settingsDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.settingsDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsDgv.Location = new System.Drawing.Point(0, 0);
            this.settingsDgv.Name = "settingsDgv";
            this.settingsDgv.RowTemplate.Height = 24;
            this.settingsDgv.Size = new System.Drawing.Size(661, 99);
            this.settingsDgv.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.settingsDgv.TabIndex = 0;
            // 
            // invoiceDgv
            // 
            this.invoiceDgv.AllowUserToAddRows = false;
            this.invoiceDgv.AllowUserToDeleteRows = false;
            this.invoiceDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.invoiceDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.invoiceDgv.Location = new System.Drawing.Point(0, 0);
            this.invoiceDgv.Name = "invoiceDgv";
            this.invoiceDgv.RowTemplate.Height = 24;
            this.invoiceDgv.Size = new System.Drawing.Size(661, 319);
            this.invoiceDgv.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.invoiceDgv.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.auswahlToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(661, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // auswahlToolStripMenuItem
            // 
            this.auswahlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aktualisierenToolStripMenuItem,
            this.alleToolStripMenuItem,
            this.keineToolStripMenuItem});
            this.auswahlToolStripMenuItem.Name = "auswahlToolStripMenuItem";
            this.auswahlToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.auswahlToolStripMenuItem.Text = "Auswahl";
            // 
            // aktualisierenToolStripMenuItem
            // 
            this.aktualisierenToolStripMenuItem.Name = "aktualisierenToolStripMenuItem";
            this.aktualisierenToolStripMenuItem.Size = new System.Drawing.Size(161, 24);
            this.aktualisierenToolStripMenuItem.Text = "aktualisieren";
            this.aktualisierenToolStripMenuItem.Click += new System.EventHandler(this.aktualisierenToolStripMenuItem_Click);
            // 
            // alleToolStripMenuItem
            // 
            this.alleToolStripMenuItem.Name = "alleToolStripMenuItem";
            this.alleToolStripMenuItem.Size = new System.Drawing.Size(161, 24);
            this.alleToolStripMenuItem.Text = "alle";
            this.alleToolStripMenuItem.Click += new System.EventHandler(this.alleToolStripMenuItem_Click);
            // 
            // keineToolStripMenuItem
            // 
            this.keineToolStripMenuItem.Name = "keineToolStripMenuItem";
            this.keineToolStripMenuItem.Size = new System.Drawing.Size(161, 24);
            this.keineToolStripMenuItem.Text = "keine";
            this.keineToolStripMenuItem.Click += new System.EventHandler(this.keineToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(661, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.kryptonSplitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(661, 423);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 28);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(661, 473);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // InvoicePrintingDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 501);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "InvoicePrintingDlg";
            this.Text = "Rechnungen erstellen";
            this.Load += new System.EventHandler(this.InvoicePrintingDlg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.settingsDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceDgv)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView invoiceDgv;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView settingsDgv;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem auswahlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aktualisierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keineToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
    }
}
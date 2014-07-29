namespace HPSchedule.Dialoge
{
    partial class AffirmApointmentsForm
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
            this.dataGridView = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bestätigenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alleMarkierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alleMarkierungenLöschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ohneBestätigungAbbrechenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bestätigungDurchführenUndBeendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 28);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(826, 245);
            this.dataGridView.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dataGridView.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bestätigenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(826, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bestätigenToolStripMenuItem
            // 
            this.bestätigenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alleMarkierenToolStripMenuItem,
            this.alleMarkierungenLöschenToolStripMenuItem,
            this.toolStripSeparator1,
            this.ohneBestätigungAbbrechenToolStripMenuItem,
            this.bestätigungDurchführenUndBeendenToolStripMenuItem});
            this.bestätigenToolStripMenuItem.Name = "bestätigenToolStripMenuItem";
            this.bestätigenToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.bestätigenToolStripMenuItem.Text = "Bestätigen?";
            // 
            // alleMarkierenToolStripMenuItem
            // 
            this.alleMarkierenToolStripMenuItem.Name = "alleMarkierenToolStripMenuItem";
            this.alleMarkierenToolStripMenuItem.Size = new System.Drawing.Size(268, 24);
            this.alleMarkierenToolStripMenuItem.Text = "Alle markieren";
            this.alleMarkierenToolStripMenuItem.Click += new System.EventHandler(this.alleMarkierenToolStripMenuItem_Click);
            // 
            // alleMarkierungenLöschenToolStripMenuItem
            // 
            this.alleMarkierungenLöschenToolStripMenuItem.Name = "alleMarkierungenLöschenToolStripMenuItem";
            this.alleMarkierungenLöschenToolStripMenuItem.Size = new System.Drawing.Size(268, 24);
            this.alleMarkierungenLöschenToolStripMenuItem.Text = "Alle Markierungen löschen";
            this.alleMarkierungenLöschenToolStripMenuItem.Click += new System.EventHandler(this.alleMarkierungenLöschenToolStripMenuItem_Click);
            // 
            // ohneBestätigungAbbrechenToolStripMenuItem
            // 
            this.ohneBestätigungAbbrechenToolStripMenuItem.Name = "ohneBestätigungAbbrechenToolStripMenuItem";
            this.ohneBestätigungAbbrechenToolStripMenuItem.Size = new System.Drawing.Size(268, 24);
            this.ohneBestätigungAbbrechenToolStripMenuItem.Text = "ohne Bestätigung abbrechen";
            this.ohneBestätigungAbbrechenToolStripMenuItem.Click += new System.EventHandler(this.ohneBestätigungAbbrechenToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(265, 6);
            // 
            // bestätigungDurchführenUndBeendenToolStripMenuItem
            // 
            this.bestätigungDurchführenUndBeendenToolStripMenuItem.Name = "bestätigungDurchführenUndBeendenToolStripMenuItem";
            this.bestätigungDurchführenUndBeendenToolStripMenuItem.Size = new System.Drawing.Size(331, 24);
            this.bestätigungDurchführenUndBeendenToolStripMenuItem.Text = "Bestätigung durchführen und beenden";
            this.bestätigungDurchführenUndBeendenToolStripMenuItem.Click += new System.EventHandler(this.bestätigungDurchführenUndBeendenToolStripMenuItem_Click);
            // 
            // AffirmApointmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 273);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AffirmApointmentsForm";
            this.Text = "Termine bestätigen";
            this.Load += new System.EventHandler(this.AffirmApointmentsForm_Load_1);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AffirmApointmentsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bestätigenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alleMarkierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alleMarkierungenLöschenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ohneBestätigungAbbrechenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bestätigungDurchführenUndBeendenToolStripMenuItem;
    }
}
namespace HPSchedule.Dialoge.Optionen
{
    partial class PanelDayView
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbDaysToShow = new System.Windows.Forms.ComboBox();
            this.numericCellHeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericCellHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Anzeige";
            // 
            // cbDaysToShow
            // 
            this.cbDaysToShow.FormattingEnabled = true;
            this.cbDaysToShow.Items.AddRange(new object[] {
            "Montag bis Freitag",
            "Montag bis Samstag",
            "Montag bis Sonntag"});
            this.cbDaysToShow.Location = new System.Drawing.Point(70, 1);
            this.cbDaysToShow.Name = "cbDaysToShow";
            this.cbDaysToShow.Size = new System.Drawing.Size(217, 21);
            this.cbDaysToShow.TabIndex = 1;
            // 
            // numericCellHeight
            // 
            this.numericCellHeight.Location = new System.Drawing.Point(70, 28);
            this.numericCellHeight.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericCellHeight.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericCellHeight.Name = "numericCellHeight";
            this.numericCellHeight.Size = new System.Drawing.Size(63, 20);
            this.numericCellHeight.TabIndex = 2;
            this.numericCellHeight.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Zeilenhöhe";
            // 
            // PanelDayView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericCellHeight);
            this.Controls.Add(this.cbDaysToShow);
            this.Controls.Add(this.label1);
            this.Name = "PanelDayView";
            this.Size = new System.Drawing.Size(287, 189);
            ((System.ComponentModel.ISupportInitialize)(this.numericCellHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDaysToShow;
        private System.Windows.Forms.NumericUpDown numericCellHeight;
        private System.Windows.Forms.Label label2;
    }
}

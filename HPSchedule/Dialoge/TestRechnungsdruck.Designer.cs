namespace HPSchedule.Dialoge
{
    partial class TestRechnungsdruck
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
            this.kryptonRichTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.SuspendLayout();
            // 
            // kryptonRichTextBox1
            // 
            this.kryptonRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonRichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.kryptonRichTextBox1.Name = "kryptonRichTextBox1";
            this.kryptonRichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.kryptonRichTextBox1.Size = new System.Drawing.Size(732, 532);
            this.kryptonRichTextBox1.TabIndex = 0;
            this.kryptonRichTextBox1.Text = "kryptonRichTextBox1";
            // 
            // TestRechnungsdruck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 532);
            this.Controls.Add(this.kryptonRichTextBox1);
            this.Name = "TestRechnungsdruck";
            this.Text = "TestRechnungsdruck";
            this.Load += new System.EventHandler(this.TestRechnungsdruck_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox kryptonRichTextBox1;
    }
}
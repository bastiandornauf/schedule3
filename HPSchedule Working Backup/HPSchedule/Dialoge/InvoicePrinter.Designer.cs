namespace HPSchedule.Dialoge
{
    partial class InvoicePrinter
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(301, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 41);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(109, 24);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Text = "kryptonLabel1";
            this.kryptonLabel1.Values.ExtraText = "";
            this.kryptonLabel1.Values.Image = null;
            this.kryptonLabel1.Values.Text = "kryptonLabel1";
            // 
            // InvoicePrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 76);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.progressBar1);
            this.Name = "InvoicePrinter";
            this.Text = "InvoicePrinter";
            this.Load += new System.EventHandler(this.InvoicePrinter_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InvoicePrinter_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}
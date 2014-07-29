namespace HPSchedule
{
    partial class SuchePatientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuchePatientForm));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(16, 15);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(356, 244);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(273, 327);
            this.bOK.Margin = new System.Windows.Forms.Padding(4);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(100, 28);
            this.bOK.TabIndex = 1;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(17, 327);
            this.bCancel.Margin = new System.Windows.Forms.Padding(4);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(100, 28);
            this.bCancel.TabIndex = 2;
            this.bCancel.Text = "Abbrechen";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 295);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(355, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 263);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.MinimumSize = new System.Drawing.Size(333, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SuchePatientForm
            // 
            this.AcceptButton = this.bOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(389, 370);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SuchePatientForm";
            this.Text = "Wähle Patient aus...";
            this.Load += new System.EventHandler(this.SuchePatientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}
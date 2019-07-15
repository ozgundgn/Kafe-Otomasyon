namespace KafeOtomasyon.cs
{
    partial class HazırSiparisler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkHazirSiparisler = new System.Windows.Forms.CheckedListBox();
            this.btnAl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkHazirSiparisler
            // 
            this.chkHazirSiparisler.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkHazirSiparisler.FormattingEnabled = true;
            this.chkHazirSiparisler.Location = new System.Drawing.Point(12, 12);
            this.chkHazirSiparisler.Name = "chkHazirSiparisler";
            this.chkHazirSiparisler.Size = new System.Drawing.Size(358, 480);
            this.chkHazirSiparisler.TabIndex = 0;
            // 
            // btnAl
            // 
            this.btnAl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAl.Location = new System.Drawing.Point(470, 444);
            this.btnAl.Name = "btnAl";
            this.btnAl.Size = new System.Drawing.Size(123, 48);
            this.btnAl.TabIndex = 1;
            this.btnAl.Text = "Al";
            this.btnAl.UseVisualStyleBackColor = true;
            this.btnAl.Click += new System.EventHandler(this.btnAl_Click);
            // 
            // HazırSiparisler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 521);
            this.Controls.Add(this.btnAl);
            this.Controls.Add(this.chkHazirSiparisler);
            this.Name = "HazırSiparisler";
            this.Text = "HazırSiparisler";
            this.Load += new System.EventHandler(this.HazırSiparisler_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAl;
        public System.Windows.Forms.CheckedListBox chkHazirSiparisler;
    }
}
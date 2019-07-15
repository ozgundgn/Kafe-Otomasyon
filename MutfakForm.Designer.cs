namespace KafeOtomasyon.cs
{
    partial class MutfakForm
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
            this.components = new System.ComponentModel.Container();
            this.grpSprsMasa = new System.Windows.Forms.GroupBox();
            this.chkSiparisLstbx = new System.Windows.Forms.CheckedListBox();
            this.btnHazir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // grpSprsMasa
            // 
            this.grpSprsMasa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSprsMasa.Location = new System.Drawing.Point(382, 12);
            this.grpSprsMasa.Name = "grpSprsMasa";
            this.grpSprsMasa.Size = new System.Drawing.Size(942, 556);
            this.grpSprsMasa.TabIndex = 0;
            this.grpSprsMasa.TabStop = false;
            // 
            // chkSiparisLstbx
            // 
            this.chkSiparisLstbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSiparisLstbx.BackColor = System.Drawing.Color.MistyRose;
            this.chkSiparisLstbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkSiparisLstbx.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.chkSiparisLstbx.FormattingEnabled = true;
            this.chkSiparisLstbx.Location = new System.Drawing.Point(12, 64);
            this.chkSiparisLstbx.Name = "chkSiparisLstbx";
            this.chkSiparisLstbx.Size = new System.Drawing.Size(342, 504);
            this.chkSiparisLstbx.TabIndex = 1;
            // 
            // btnHazir
            // 
            this.btnHazir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnHazir.BackColor = System.Drawing.Color.Brown;
            this.btnHazir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHazir.Location = new System.Drawing.Point(229, 591);
            this.btnHazir.Name = "btnHazir";
            this.btnHazir.Size = new System.Drawing.Size(194, 81);
            this.btnHazir.TabIndex = 3;
            this.btnHazir.Text = "HAZIR";
            this.btnHazir.UseVisualStyleBackColor = false;
            this.btnHazir.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(110, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "SİPARİSLER";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // MutfakForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 712);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHazir);
            this.Controls.Add(this.chkSiparisLstbx);
            this.Controls.Add(this.grpSprsMasa);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "MutfakForm";
            this.Text = "MutfakForm";
            this.Load += new System.EventHandler(this.MutfakForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSprsMasa;
        private System.Windows.Forms.CheckedListBox chkSiparisLstbx;
        private System.Windows.Forms.Button btnHazir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}
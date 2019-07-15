namespace KafeOtomasyon.cs
{
    partial class MasaTasimaForm
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
            this.dtgMasa1 = new System.Windows.Forms.DataGridView();
            this.dtgMasa2 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.dtgGecis = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMasa1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMasa2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGecis)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgMasa1
            // 
            this.dtgMasa1.AllowUserToAddRows = false;
            this.dtgMasa1.AllowUserToDeleteRows = false;
            this.dtgMasa1.AllowUserToResizeColumns = false;
            this.dtgMasa1.AllowUserToResizeRows = false;
            this.dtgMasa1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgMasa1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMasa1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgMasa1.Location = new System.Drawing.Point(12, 71);
            this.dtgMasa1.Name = "dtgMasa1";
            this.dtgMasa1.RowHeadersVisible = false;
            this.dtgMasa1.RowTemplate.Height = 24;
            this.dtgMasa1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMasa1.Size = new System.Drawing.Size(323, 499);
            this.dtgMasa1.TabIndex = 0;
            this.dtgMasa1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMasa1_CellClick);
            // 
            // dtgMasa2
            // 
            this.dtgMasa2.AllowUserToAddRows = false;
            this.dtgMasa2.AllowUserToDeleteRows = false;
            this.dtgMasa2.AllowUserToResizeColumns = false;
            this.dtgMasa2.AllowUserToResizeRows = false;
            this.dtgMasa2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgMasa2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMasa2.ColumnHeadersVisible = false;
            this.dtgMasa2.Location = new System.Drawing.Point(1100, 71);
            this.dtgMasa2.Name = "dtgMasa2";
            this.dtgMasa2.RowHeadersVisible = false;
            this.dtgMasa2.RowTemplate.Height = 24;
            this.dtgMasa2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMasa2.Size = new System.Drawing.Size(326, 494);
            this.dtgMasa2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(341, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(753, 709);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl1.Location = new System.Drawing.Point(114, 31);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(68, 20);
            this.lbl1.TabIndex = 3;
            this.lbl1.Text = "Adisyon";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl2.Location = new System.Drawing.Point(1218, 31);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(68, 20);
            this.lbl2.TabIndex = 4;
            this.lbl2.Text = "Adisyon";
            // 
            // dtgGecis
            // 
            this.dtgGecis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGecis.Location = new System.Drawing.Point(149, 765);
            this.dtgGecis.Name = "dtgGecis";
            this.dtgGecis.RowTemplate.Height = 24;
            this.dtgGecis.Size = new System.Drawing.Size(1183, 150);
            this.dtgGecis.TabIndex = 5;
            this.dtgGecis.Visible = false;
            // 
            // MasaTasimaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1438, 936);
            this.Controls.Add(this.dtgGecis);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtgMasa2);
            this.Controls.Add(this.dtgMasa1);
            this.Name = "MasaTasimaForm";
            this.Text = "MasaTasimaForm";
            this.Load += new System.EventHandler(this.MasaTasimaForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMasa1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMasa2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGecis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgMasa1;
        private System.Windows.Forms.DataGridView dtgMasa2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.DataGridView dtgGecis;
    }
}
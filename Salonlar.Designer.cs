namespace KafeOtomasyon.cs
{
    partial class Salonlar
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpButon = new System.Windows.Forms.GroupBox();
            this.grpMasalar = new System.Windows.Forms.GroupBox();
            this.dtgSiparis = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSiparisAl = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGeri = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOdeme = new System.Windows.Forms.Button();
            this.btnSiparisler = new System.Windows.Forms.Button();
            this.btnHazirSiparis = new System.Windows.Forms.Button();
            this.btnMasaTasi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSiparis)).BeginInit();
            this.SuspendLayout();
            // 
            // grpButon
            // 
            this.grpButon.Location = new System.Drawing.Point(12, 30);
            this.grpButon.Name = "grpButon";
            this.grpButon.Size = new System.Drawing.Size(962, 207);
            this.grpButon.TabIndex = 0;
            this.grpButon.TabStop = false;
            // 
            // grpMasalar
            // 
            this.grpMasalar.Location = new System.Drawing.Point(12, 269);
            this.grpMasalar.Name = "grpMasalar";
            this.grpMasalar.Size = new System.Drawing.Size(236, 123);
            this.grpMasalar.TabIndex = 1;
            this.grpMasalar.TabStop = false;
            // 
            // dtgSiparis
            // 
            this.dtgSiparis.AllowUserToAddRows = false;
            this.dtgSiparis.AllowUserToDeleteRows = false;
            this.dtgSiparis.AllowUserToResizeColumns = false;
            this.dtgSiparis.AllowUserToResizeRows = false;
            this.dtgSiparis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSiparis.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgSiparis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSiparis.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgSiparis.Location = new System.Drawing.Point(997, 64);
            this.dtgSiparis.Name = "dtgSiparis";
            this.dtgSiparis.RowHeadersVisible = false;
            this.dtgSiparis.RowTemplate.Height = 24;
            this.dtgSiparis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSiparis.Size = new System.Drawing.Size(392, 661);
            this.dtgSiparis.TabIndex = 4;
            this.dtgSiparis.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSiparis_CellClick_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1159, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "ADİSYON";
            // 
            // btnSiparisAl
            // 
            this.btnSiparisAl.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSiparisAl.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSiparisAl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiparisAl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSiparisAl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSiparisAl.Location = new System.Drawing.Point(1148, 824);
            this.btnSiparisAl.Name = "btnSiparisAl";
            this.btnSiparisAl.Size = new System.Drawing.Size(123, 61);
            this.btnSiparisAl.TabIndex = 2;
            this.btnSiparisAl.Text = "SİPARİS KAYDET";
            this.btnSiparisAl.UseVisualStyleBackColor = false;
            this.btnSiparisAl.Click += new System.EventHandler(this.btnSiparisEkle_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(992, 745);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "TOPLAM FİYAT :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1190, 745);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            // 
            // btnGeri
            // 
            this.btnGeri.BackColor = System.Drawing.Color.SkyBlue;
            this.btnGeri.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGeri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGeri.Location = new System.Drawing.Point(165, 811);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(125, 61);
            this.btnGeri.TabIndex = 9;
            this.btnGeri.Text = "GERİ";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.Form1_Load);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SkyBlue;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(12, 811);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 61);
            this.button1.TabIndex = 10;
            this.button1.Text = "AYARLAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnAyarlar_Click);
            // 
            // btnOdeme
            // 
            this.btnOdeme.BackColor = System.Drawing.Color.SkyBlue;
            this.btnOdeme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdeme.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOdeme.Location = new System.Drawing.Point(997, 824);
            this.btnOdeme.Name = "btnOdeme";
            this.btnOdeme.Size = new System.Drawing.Size(125, 61);
            this.btnOdeme.TabIndex = 11;
            this.btnOdeme.Text = "ÖDEME AL";
            this.btnOdeme.UseVisualStyleBackColor = false;
            this.btnOdeme.Click += new System.EventHandler(this.btnOdeme_Click);
            // 
            // btnSiparisler
            // 
            this.btnSiparisler.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSiparisler.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSiparisler.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSiparisler.Location = new System.Drawing.Point(582, 767);
            this.btnSiparisler.Name = "btnSiparisler";
            this.btnSiparisler.Size = new System.Drawing.Size(231, 72);
            this.btnSiparisler.TabIndex = 12;
            this.btnSiparisler.Text = "SİPARİSLER";
            this.btnSiparisler.UseVisualStyleBackColor = false;
            this.btnSiparisler.Click += new System.EventHandler(this.btnSiparisler_Click);
            // 
            // btnHazirSiparis
            // 
            this.btnHazirSiparis.BackColor = System.Drawing.Color.Aquamarine;
            this.btnHazirSiparis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHazirSiparis.Location = new System.Drawing.Point(501, 845);
            this.btnHazirSiparis.Name = "btnHazirSiparis";
            this.btnHazirSiparis.Size = new System.Drawing.Size(419, 40);
            this.btnHazirSiparis.TabIndex = 13;
            this.btnHazirSiparis.Text = "HAZİR SİPARİSLER";
            this.btnHazirSiparis.UseVisualStyleBackColor = false;
            this.btnHazirSiparis.Click += new System.EventHandler(this.btnHazirSiparis_Click);
            // 
            // btnMasaTasi
            // 
            this.btnMasaTasi.BackColor = System.Drawing.Color.Snow;
            this.btnMasaTasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMasaTasi.Location = new System.Drawing.Point(1284, 745);
            this.btnMasaTasi.Name = "btnMasaTasi";
            this.btnMasaTasi.Size = new System.Drawing.Size(105, 61);
            this.btnMasaTasi.TabIndex = 14;
            this.btnMasaTasi.Text = "MASA TAŞI";
            this.btnMasaTasi.UseVisualStyleBackColor = false;
            this.btnMasaTasi.Click += new System.EventHandler(this.btnMasaTasi_Click);
            // 
            // Salonlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1438, 936);
            this.Controls.Add(this.btnMasaTasi);
            this.Controls.Add(this.btnHazirSiparis);
            this.Controls.Add(this.btnSiparisler);
            this.Controls.Add(this.btnOdeme);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgSiparis);
            this.Controls.Add(this.btnSiparisAl);
            this.Controls.Add(this.grpMasalar);
            this.Controls.Add(this.grpButon);
            this.Name = "Salonlar";
            this.Text = "Salonlar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Salonlar_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSiparis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpButon;
        private System.Windows.Forms.GroupBox grpMasalar;
        private System.Windows.Forms.DataGridView dtgSiparis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSiparisAl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOdeme;
        public System.Windows.Forms.Button btnSiparisler;
        public System.Windows.Forms.Button btnHazirSiparis;
        private System.Windows.Forms.Button btnMasaTasi;
    }
}


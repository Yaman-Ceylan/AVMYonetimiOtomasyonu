
namespace AVMYonetimiOtomasyonu
{
    partial class GirisSayfasi
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
            this.txtKullaniciID = new System.Windows.Forms.TextBox();
            this.lblKullaniciID = new System.Windows.Forms.Label();
            this.lblSifre = new System.Windows.Forms.Label();
            this.txtKullaniciSifre = new System.Windows.Forms.TextBox();
            this.btnGirisYap = new System.Windows.Forms.Button();
            this.btnGeriDon = new System.Windows.Forms.Button();
            this.picBoxSifreGoster = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSifreGoster)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKullaniciID
            // 
            this.txtKullaniciID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtKullaniciID.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtKullaniciID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKullaniciID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtKullaniciID.Location = new System.Drawing.Point(421, 175);
            this.txtKullaniciID.MaxLength = 25;
            this.txtKullaniciID.Name = "txtKullaniciID";
            this.txtKullaniciID.Size = new System.Drawing.Size(211, 27);
            this.txtKullaniciID.TabIndex = 1;
            this.txtKullaniciID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKullaniciID_KeyPress);
            // 
            // lblKullaniciID
            // 
            this.lblKullaniciID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblKullaniciID.AutoSize = true;
            this.lblKullaniciID.BackColor = System.Drawing.Color.Transparent;
            this.lblKullaniciID.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblKullaniciID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.lblKullaniciID.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblKullaniciID.Location = new System.Drawing.Point(217, 182);
            this.lblKullaniciID.Name = "lblKullaniciID";
            this.lblKullaniciID.Size = new System.Drawing.Size(106, 20);
            this.lblKullaniciID.TabIndex = 2;
            this.lblKullaniciID.Text = "Kullanıcı ID";
            this.lblKullaniciID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSifre
            // 
            this.lblSifre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSifre.AutoSize = true;
            this.lblSifre.BackColor = System.Drawing.Color.Transparent;
            this.lblSifre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.lblSifre.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblSifre.Location = new System.Drawing.Point(274, 235);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(49, 20);
            this.lblSifre.TabIndex = 4;
            this.lblSifre.Text = "Şifre";
            this.lblSifre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKullaniciSifre
            // 
            this.txtKullaniciSifre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtKullaniciSifre.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtKullaniciSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKullaniciSifre.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtKullaniciSifre.Location = new System.Drawing.Point(421, 228);
            this.txtKullaniciSifre.MaxLength = 15;
            this.txtKullaniciSifre.Name = "txtKullaniciSifre";
            this.txtKullaniciSifre.PasswordChar = '*';
            this.txtKullaniciSifre.Size = new System.Drawing.Size(211, 27);
            this.txtKullaniciSifre.TabIndex = 3;
            this.txtKullaniciSifre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKullaniciSifre_KeyPress);
            // 
            // btnGirisYap
            // 
            this.btnGirisYap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGirisYap.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnGirisYap.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnGirisYap.FlatAppearance.BorderSize = 0;
            this.btnGirisYap.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGirisYap.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGirisYap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGirisYap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnGirisYap.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnGirisYap.Location = new System.Drawing.Point(497, 311);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new System.Drawing.Size(135, 45);
            this.btnGirisYap.TabIndex = 5;
            this.btnGirisYap.Text = "Giriş Yap";
            this.btnGirisYap.UseVisualStyleBackColor = false;
            this.btnGirisYap.Click += new System.EventHandler(this.btnGirisYap_Click);
            // 
            // btnGeriDon
            // 
            this.btnGeriDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeriDon.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnGeriDon.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnGeriDon.FlatAppearance.BorderSize = 0;
            this.btnGeriDon.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGeriDon.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGeriDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeriDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnGeriDon.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnGeriDon.Location = new System.Drawing.Point(790, 489);
            this.btnGeriDon.Name = "btnGeriDon";
            this.btnGeriDon.Size = new System.Drawing.Size(130, 45);
            this.btnGeriDon.TabIndex = 6;
            this.btnGeriDon.Text = "Geri Dön";
            this.btnGeriDon.UseVisualStyleBackColor = false;
            this.btnGeriDon.Click += new System.EventHandler(this.btnGeriDon_Click);
            // 
            // picBoxSifreGoster
            // 
            this.picBoxSifreGoster.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picBoxSifreGoster.BackColor = System.Drawing.Color.Transparent;
            this.picBoxSifreGoster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxSifreGoster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxSifreGoster.Image = global::AVMYonetimiOtomasyonu.Properties.Resources.view;
            this.picBoxSifreGoster.Location = new System.Drawing.Point(638, 231);
            this.picBoxSifreGoster.Name = "picBoxSifreGoster";
            this.picBoxSifreGoster.Size = new System.Drawing.Size(24, 24);
            this.picBoxSifreGoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBoxSifreGoster.TabIndex = 35;
            this.picBoxSifreGoster.TabStop = false;
            this.picBoxSifreGoster.Click += new System.EventHandler(this.picBoxSifreGoster_Click);
            // 
            // GirisSayfasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AVMYonetimiOtomasyonu.Properties.Resources.arkaplan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(932, 546);
            this.Controls.Add(this.picBoxSifreGoster);
            this.Controls.Add(this.btnGeriDon);
            this.Controls.Add(this.btnGirisYap);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.txtKullaniciSifre);
            this.Controls.Add(this.txtKullaniciID);
            this.Controls.Add(this.lblKullaniciID);
            this.Name = "GirisSayfasi";
            this.Text = "AVM Yönetimi Otomasyonu - Giriş";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GirisSayfasi_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSifreGoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKullaniciID;
        private System.Windows.Forms.Label lblKullaniciID;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.TextBox txtKullaniciSifre;
        private System.Windows.Forms.Button btnGirisYap;
        private System.Windows.Forms.Button btnGeriDon;
        private System.Windows.Forms.PictureBox picBoxSifreGoster;
    }
}
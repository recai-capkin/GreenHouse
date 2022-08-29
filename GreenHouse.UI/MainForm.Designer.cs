namespace GreenHouse.UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnSideMenu = new System.Windows.Forms.Button();
            this.btnUserDetail = new System.Windows.Forms.Button();
            this.btnBarkodOku = new System.Windows.Forms.Button();
            this.btnArama = new System.Windows.Forms.Button();
            this.btnAddProductOrUpdate = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSideMenu
            // 
            this.btnSideMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSideMenu.BackgroundImage")));
            this.btnSideMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSideMenu.Location = new System.Drawing.Point(12, 12);
            this.btnSideMenu.Name = "btnSideMenu";
            this.btnSideMenu.Size = new System.Drawing.Size(144, 138);
            this.btnSideMenu.TabIndex = 0;
            this.btnSideMenu.UseVisualStyleBackColor = true;
            this.btnSideMenu.Click += new System.EventHandler(this.btnSideMenu_Click);
            // 
            // btnUserDetail
            // 
            this.btnUserDetail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUserDetail.BackgroundImage")));
            this.btnUserDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUserDetail.Location = new System.Drawing.Point(1041, 12);
            this.btnUserDetail.Name = "btnUserDetail";
            this.btnUserDetail.Size = new System.Drawing.Size(144, 138);
            this.btnUserDetail.TabIndex = 1;
            this.btnUserDetail.UseVisualStyleBackColor = true;
            this.btnUserDetail.Click += new System.EventHandler(this.btnUserDetail_Click);
            // 
            // btnBarkodOku
            // 
            this.btnBarkodOku.Image = ((System.Drawing.Image)(resources.GetObject("btnBarkodOku.Image")));
            this.btnBarkodOku.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBarkodOku.Location = new System.Drawing.Point(429, 185);
            this.btnBarkodOku.Name = "btnBarkodOku";
            this.btnBarkodOku.Size = new System.Drawing.Size(331, 75);
            this.btnBarkodOku.TabIndex = 2;
            this.btnBarkodOku.Text = "Barkod Okuma";
            this.btnBarkodOku.UseVisualStyleBackColor = true;
            // 
            // btnArama
            // 
            this.btnArama.Image = ((System.Drawing.Image)(resources.GetObject("btnArama.Image")));
            this.btnArama.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArama.Location = new System.Drawing.Point(429, 266);
            this.btnArama.Name = "btnArama";
            this.btnArama.Size = new System.Drawing.Size(331, 75);
            this.btnArama.TabIndex = 3;
            this.btnArama.Text = "Arama";
            this.btnArama.UseVisualStyleBackColor = true;
            this.btnArama.Click += new System.EventHandler(this.btnArama_Click);
            // 
            // btnAddProductOrUpdate
            // 
            this.btnAddProductOrUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnAddProductOrUpdate.Image")));
            this.btnAddProductOrUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddProductOrUpdate.Location = new System.Drawing.Point(429, 347);
            this.btnAddProductOrUpdate.Name = "btnAddProductOrUpdate";
            this.btnAddProductOrUpdate.Size = new System.Drawing.Size(331, 75);
            this.btnAddProductOrUpdate.TabIndex = 4;
            this.btnAddProductOrUpdate.Text = "Ürün Ekleme/Düzeltme";
            this.btnAddProductOrUpdate.UseVisualStyleBackColor = true;
            this.btnAddProductOrUpdate.Click += new System.EventHandler(this.btnAddProductOrUpdate_Click);
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(429, 428);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(331, 75);
            this.button4.TabIndex = 5;
            this.button4.Text = "Arama Geçmişi";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1197, 629);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnAddProductOrUpdate);
            this.Controls.Add(this.btnArama);
            this.Controls.Add(this.btnBarkodOku);
            this.Controls.Add(this.btnUserDetail);
            this.Controls.Add(this.btnSideMenu);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSideMenu;
        private System.Windows.Forms.Button btnUserDetail;
        private System.Windows.Forms.Button btnBarkodOku;
        private System.Windows.Forms.Button btnArama;
        private System.Windows.Forms.Button btnAddProductOrUpdate;
        private System.Windows.Forms.Button button4;
    }
}
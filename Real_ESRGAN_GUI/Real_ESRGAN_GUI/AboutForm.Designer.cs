
namespace Real_ESRGAN_GUI
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.TelegramLabel = new System.Windows.Forms.LinkLabel();
            this.DeveloperLabel = new System.Windows.Forms.Label();
            this.WebsiteLabel = new System.Windows.Forms.LinkLabel();
            this.MainLabel = new System.Windows.Forms.Label();
            this.MainPic = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPic)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ConfirmButton);
            this.panel1.Controls.Add(this.TelegramLabel);
            this.panel1.Controls.Add(this.DeveloperLabel);
            this.panel1.Controls.Add(this.WebsiteLabel);
            this.panel1.Controls.Add(this.MainLabel);
            this.panel1.Controls.Add(this.MainPic);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 344);
            this.panel1.TabIndex = 0;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ConfirmButton.Location = new System.Drawing.Point(330, 238);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(119, 35);
            this.ConfirmButton.TabIndex = 5;
            this.ConfirmButton.Text = "确定";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.CONFIRM_BUTTON_CLICK);
            // 
            // TelegramLabel
            // 
            this.TelegramLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TelegramLabel.AutoSize = true;
            this.TelegramLabel.Font = new System.Drawing.Font("别喝醉别流泪", 14F);
            this.TelegramLabel.Location = new System.Drawing.Point(310, 179);
            this.TelegramLabel.Name = "TelegramLabel";
            this.TelegramLabel.Size = new System.Drawing.Size(156, 32);
            this.TelegramLabel.TabIndex = 4;
            this.TelegramLabel.TabStop = true;
            this.TelegramLabel.Text = "Telegram频道";
            this.TelegramLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TELEGRAM_LABEL_LINK_CLICKED);
            // 
            // DeveloperLabel
            // 
            this.DeveloperLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DeveloperLabel.AutoSize = true;
            this.DeveloperLabel.Font = new System.Drawing.Font("Ink Free", 7F);
            this.DeveloperLabel.Location = new System.Drawing.Point(228, 293);
            this.DeveloperLabel.Name = "DeveloperLabel";
            this.DeveloperLabel.Size = new System.Drawing.Size(327, 18);
            this.DeveloperLabel.TabIndex = 3;
            this.DeveloperLabel.Text = "Copyright© 2024 LatteYogurt , All rights reserved.";
            // 
            // WebsiteLabel
            // 
            this.WebsiteLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.WebsiteLabel.AutoSize = true;
            this.WebsiteLabel.Font = new System.Drawing.Font("别喝醉别流泪", 14F);
            this.WebsiteLabel.Location = new System.Drawing.Point(316, 121);
            this.WebsiteLabel.Name = "WebsiteLabel";
            this.WebsiteLabel.Size = new System.Drawing.Size(140, 32);
            this.WebsiteLabel.TabIndex = 1;
            this.WebsiteLabel.TabStop = true;
            this.WebsiteLabel.Text = "Github主页";
            this.WebsiteLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WEBSITE_LABEL_LINK_CLICKED);
            // 
            // MainLabel
            // 
            this.MainLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MainLabel.AutoSize = true;
            this.MainLabel.Font = new System.Drawing.Font("Segoe Print", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainLabel.Location = new System.Drawing.Point(292, 41);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(280, 49);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "Real ESRGAN GUI";
            // 
            // MainPic
            // 
            this.MainPic.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MainPic.ErrorImage = null;
            this.MainPic.InitialImage = null;
            this.MainPic.Location = new System.Drawing.Point(223, 34);
            this.MainPic.Name = "MainPic";
            this.MainPic.Size = new System.Drawing.Size(64, 64);
            this.MainPic.TabIndex = 2;
            this.MainPic.TabStop = false;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 344);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "AboutForm";
            this.Text = "关于 Real ESRGAN GUI";
            this.Load += new System.EventHandler(this.ABOUT_FORM_LOAD);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label MainLabel;
        private System.Windows.Forms.LinkLabel WebsiteLabel;
        private System.Windows.Forms.PictureBox MainPic;
        private System.Windows.Forms.Label DeveloperLabel;
        private System.Windows.Forms.LinkLabel TelegramLabel;
        private System.Windows.Forms.Button ConfirmButton;
    }
}
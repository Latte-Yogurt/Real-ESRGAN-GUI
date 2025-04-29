
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
            this.PanelAbout = new System.Windows.Forms.Panel();
            this.ButtonConfirm = new System.Windows.Forms.Button();
            this.LabelLicense = new System.Windows.Forms.LinkLabel();
            this.DeveloperLabel = new System.Windows.Forms.Label();
            this.LabelWebsite = new System.Windows.Forms.LinkLabel();
            this.MainLabel = new System.Windows.Forms.Label();
            this.MainPic = new System.Windows.Forms.PictureBox();
            this.PanelAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPic)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelAbout
            // 
            this.PanelAbout.Controls.Add(this.ButtonConfirm);
            this.PanelAbout.Controls.Add(this.LabelLicense);
            this.PanelAbout.Controls.Add(this.DeveloperLabel);
            this.PanelAbout.Controls.Add(this.LabelWebsite);
            this.PanelAbout.Controls.Add(this.MainLabel);
            this.PanelAbout.Controls.Add(this.MainPic);
            this.PanelAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelAbout.Location = new System.Drawing.Point(0, 0);
            this.PanelAbout.Name = "PanelAbout";
            this.PanelAbout.Size = new System.Drawing.Size(778, 344);
            this.PanelAbout.TabIndex = 0;
            // 
            // ButtonConfirm
            // 
            this.ButtonConfirm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ButtonConfirm.Location = new System.Drawing.Point(336, 239);
            this.ButtonConfirm.Name = "ButtonConfirm";
            this.ButtonConfirm.Size = new System.Drawing.Size(100, 30);
            this.ButtonConfirm.TabIndex = 5;
            this.ButtonConfirm.Text = "确定";
            this.ButtonConfirm.UseVisualStyleBackColor = true;
            this.ButtonConfirm.Click += new System.EventHandler(this.CONFIRM_BUTTON_CLICK);
            // 
            // LabelLicense
            // 
            this.LabelLicense.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelLicense.AutoSize = true;
            this.LabelLicense.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelLicense.Location = new System.Drawing.Point(337, 178);
            this.LabelLicense.Name = "LabelLicense";
            this.LabelLicense.Size = new System.Drawing.Size(99, 36);
            this.LabelLicense.TabIndex = 4;
            this.LabelLicense.TabStop = true;
            this.LabelLicense.Text = "许可证";
            this.LabelLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TELEGRAM_LABEL_LINK_CLICKED);
            // 
            // DeveloperLabel
            // 
            this.DeveloperLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DeveloperLabel.AutoSize = true;
            this.DeveloperLabel.Font = new System.Drawing.Font("Ink Free", 7F);
            this.DeveloperLabel.Location = new System.Drawing.Point(228, 293);
            this.DeveloperLabel.Name = "DeveloperLabel";
            this.DeveloperLabel.Size = new System.Drawing.Size(368, 18);
            this.DeveloperLabel.TabIndex = 3;
            this.DeveloperLabel.Text = "Copyright© 2024-2025 LatteYogurt , All rights reserved.";
            // 
            // LabelWebsite
            // 
            this.LabelWebsite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelWebsite.AutoSize = true;
            this.LabelWebsite.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelWebsite.Location = new System.Drawing.Point(321, 125);
            this.LabelWebsite.Name = "LabelWebsite";
            this.LabelWebsite.Size = new System.Drawing.Size(161, 36);
            this.LabelWebsite.TabIndex = 1;
            this.LabelWebsite.TabStop = true;
            this.LabelWebsite.Text = "Github主页";
            this.LabelWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WEBSITE_LABEL_LINK_CLICKED);
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
            this.Controls.Add(this.PanelAbout);
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
            this.PanelAbout.ResumeLayout(false);
            this.PanelAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelAbout;
        private System.Windows.Forms.Label MainLabel;
        private System.Windows.Forms.LinkLabel LabelWebsite;
        private System.Windows.Forms.PictureBox MainPic;
        private System.Windows.Forms.Label DeveloperLabel;
        private System.Windows.Forms.LinkLabel LabelLicense;
        private System.Windows.Forms.Button ButtonConfirm;
    }
}
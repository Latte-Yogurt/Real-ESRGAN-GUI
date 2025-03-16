using System;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Real_ESRGAN_GUI
{
    public partial class AboutForm : Form
    {
        private Dictionary<string, Dictionary<string, string>> languageTexts;

        public string currentLanguage;
        public float systemScale;
        public int locationX;
        public int locationY;


        public AboutForm()
        {
            InitializeComponent();

            currentLanguage = MainForm.currentLanguage;
            systemScale = MainForm.systemScale;

            SET_BUTTON_CONFIRM_SIZE();
            SET_CLIENT_SIZE();

            InitializeLanguageTexts();
            UpdateLanguage();
            UpdateUI();
        }

        private void InitializeLanguageTexts()
        {
            languageTexts = new Dictionary<string, Dictionary<string, string>>
            {
                { "zh-CN", new Dictionary<string, string>
                    {
                        { "Title","关于 Real ESRGAN GUI" },
                        { "LabelWebsite","Github主页" },
                        { "LabelLicense","许可证" },
                    }
                },
                { "zh-TW", new Dictionary<string, string>
                    {
                        { "Title","關於 Real ESRGAN GUI" },
                        { "LabelWebsite","Github主頁" },
                        { "LabelLicense","許可證" },
                    }
                },
                { "en-US", new Dictionary<string, string>
                    {
                        { "Title","About Real ESRGAN GUI" },
                        { "LabelWebsite","Github Page" },
                        { "LabelLicense","License" },
                    }
                }
            };
        }

        private void SET_BUTTON_CONFIRM_SIZE()
        {
            ButtonConfirm.Size = new Size((int)(100 * systemScale), (int)(30 * systemScale));
        }

        private void SET_CLIENT_SIZE()
        {
            this.ClientSize = new Size((DeveloperLabel.Width + (int)(20.0f * systemScale) * 2) * 2, DeveloperLabel.Width + (int)(20.0f * systemScale) * 2);
            this.MaximumSize = this.ClientSize;
            this.MinimumSize = new Size(this.ClientSize.Width / 2, DeveloperLabel.Width + (int)(20.0f * systemScale) * 2);
        }

        private void UpdateLanguage()
        {
            this.Text = languageTexts[currentLanguage]["Title"];
            LabelWebsite.Text = languageTexts[currentLanguage]["LabelWebsite"];
            LabelLicense.Text = languageTexts[currentLanguage]["LabelLicense"];
        }

        private void UpdateUI()
        {
            MainPic.Location = new Point(PanelAbout.Width / 2 - MainPic.Width / 2 - MainLabel.Width / 2, PanelAbout.Height / 2 - MainPic.Height / 2 - (int)(57.0f * systemScale));
            MainLabel.Location = new Point(PanelAbout.Width / 2 + MainPic.Width / 2 - MainLabel.Width / 2, PanelAbout.Height / 2 - MainLabel.Height / 2 - (int)(57.0f * systemScale));
            LabelWebsite.Location = new Point(PanelAbout.Width / 2 - LabelWebsite.Width / 2, PanelAbout.Height / 2 - LabelWebsite.Height / 2 - (int)(17.0f * systemScale));
            LabelLicense.Location = new Point(PanelAbout.Width / 2 - LabelLicense.Width / 2, PanelAbout.Height / 2 - LabelLicense.Height / 2 + (int)(14.0f * systemScale));
            ButtonConfirm.Location = new Point(PanelAbout.Width / 2 - ButtonConfirm.Width / 2, PanelAbout.Height / 2 - ButtonConfirm.Height / 2 + (int)(54.0f * systemScale));
            DeveloperLabel.Location = new Point(PanelAbout.Width / 2 - DeveloperLabel.Width / 2, PanelAbout.Height / 2 - DeveloperLabel.Height / 2 + (int)(84.0f * systemScale));
        }

        private void ERROR_IMAGE_NOT_FOUND()
        {
            switch (currentLanguage)
            {
                case "zh-CN":
                    MessageBox.Show("图像未找到！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "zh-TW":
                    MessageBox.Show("圖像未找到！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "en-US":
                    MessageBox.Show("Can not Find Image File！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void ABOUT_FORM_LOAD(object sender, EventArgs e)
        {
            locationX = Screen.PrimaryScreen.Bounds.Width / 2 - this.Width / 2;
            locationY = Screen.PrimaryScreen.Bounds.Height / 2 - this.Height / 2;

            this.Location = new Point(locationX, locationY);

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Real_ESRGAN_GUI.Resource.icon.Yoimiya64-1.png"; // 具体的命名空间和资源名称

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    MainPic.Image = Image.FromStream(stream); // 将图像显示到PictureBox中
                }
                else
                {
                    ERROR_IMAGE_NOT_FOUND();
                }
            }
        }

        private void WEBSITE_LABEL_LINK_CLICKED(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 打开网址
            System.Diagnostics.Process.Start("https://github.com/Latte-Yogurt");

            // 标记为已访问
            LabelWebsite.LinkVisited = true;
        }

        private void TELEGRAM_LABEL_LINK_CLICKED(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 打开网址
            System.Diagnostics.Process.Start("https://www.gnu.org/licenses/gpl-3.0.html");

            // 标记为已访问
            LabelWebsite.LinkVisited = true;
        }

        private void CONFIRM_BUTTON_CLICK(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

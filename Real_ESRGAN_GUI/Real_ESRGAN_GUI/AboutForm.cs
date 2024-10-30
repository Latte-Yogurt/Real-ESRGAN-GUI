using System;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
/*
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/

namespace Real_ESRGAN_GUI
{
    public partial class AboutForm : Form
    {
        private Dictionary<string, Dictionary<string, string>> languageTexts;

        public string currentLanguage;
        public int locationX;
        public int locationY;


        public AboutForm()
        {
            InitializeComponent();

            currentLanguage = MainForm.currentLanguage;

            InitializeLanguageTexts();
            UpdateLanguage();
            UpdateUI(currentLanguage);
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

        private void UpdateLanguage()
        {
            this.Text = languageTexts[currentLanguage]["Title"];
            LabelWebsite.Text = languageTexts[currentLanguage]["LabelWebsite"];
            LabelLicense.Text = languageTexts[currentLanguage]["LabelLicense"];
        }

        private void UpdateUI(string language)
        {
            switch (language)
            {
                case "zh-CN":
                    LabelWebsite.Font = new Font("别喝醉别流泪", 14);
                    LabelWebsite.Location = new Point(PanelAbout.Size.Width / 2 - LabelWebsite.Size.Width / 2, PanelAbout.Size.Height / 2 - LabelWebsite.Size.Height / 2 - 27);
                    LabelLicense.Font = new Font("别喝醉别流泪", 14);
                    LabelLicense.Location = new Point(PanelAbout.Size.Width / 2 - LabelLicense.Size.Width / 2, PanelAbout.Size.Height / 2 - LabelLicense.Size.Height / 2 + 24);
                    break;
                case "zh-TW":
                    LabelWebsite.Font = new Font("造字工房情书繁（非商用）常规体", 14, FontStyle.Bold);
                    LabelWebsite.Location = new Point(PanelAbout.Size.Width / 2 - LabelWebsite.Size.Width / 2, PanelAbout.Size.Height / 2 - LabelWebsite.Size.Height / 2 - 27);
                    LabelLicense.Font = new Font("造字工房情书繁（非商用）常规体", 14, FontStyle.Bold);
                    LabelLicense.Location = new Point(PanelAbout.Size.Width / 2 - LabelLicense.Size.Width / 2, PanelAbout.Size.Height / 2 - LabelLicense.Size.Height / 2 + 24);
                    break;
                case "en-US":
                    LabelWebsite.Font = new Font("别喝醉别流泪", 14);
                    LabelWebsite.Location = new Point(PanelAbout.Size.Width / 2 - LabelWebsite.Size.Width / 2, PanelAbout.Size.Height / 2 - LabelWebsite.Size.Height / 2 - 27);
                    LabelLicense.Font = new Font("别喝醉别流泪", 14);
                    LabelLicense.Location = new Point(PanelAbout.Size.Width / 2 - LabelLicense.Size.Width / 2, PanelAbout.Size.Height / 2 - LabelLicense.Size.Height / 2 + 24);
                    break;
            }
        }


        private void ABOUT_FORM_LOAD(object sender, EventArgs e)
        {
            locationX = Screen.PrimaryScreen.Bounds.Width / 2 - this.Size.Width / 2;
            locationY = Screen.PrimaryScreen.Bounds.Height / 2 - this.Size.Height / 2;

            this.Location = new Point(locationX, locationY);

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Real_ESRGAN_GUI.Yoimiya64-1.png"; // 具体的命名空间和资源名称

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    MainPic.Image = Image.FromStream(stream); // 将图像显示到PictureBox中
                }
                else
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

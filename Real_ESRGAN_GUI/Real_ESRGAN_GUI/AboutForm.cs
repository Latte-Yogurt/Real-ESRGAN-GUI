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
                { "CHS", new Dictionary<string, string>
                    {
                        { "Title","关于 Real ESRGAN GUI" },
                        { "LabelWebsite","Github主页" },
                        { "LabelTelegram","Telegram频道" },
                    }
                },
                { "CHT", new Dictionary<string, string>
                    {
                        { "Title","關於 Real ESRGAN GUI" },
                        { "LabelWebsite","Github主頁" },
                        { "LabelTelegram","Telegram頻道" },
                    }
                },
                { "EN", new Dictionary<string, string>
                    {
                        { "Title","About Real ESRGAN GUI" },
                        { "LabelWebsite","Github Page" },
                        { "LabelTelegram","Telegram Channel" },
                    }
                }
            };
        }

        private void UpdateLanguage()
        {
            this.Text = languageTexts[currentLanguage]["Title"];
            LabelWebsite.Text = languageTexts[currentLanguage]["LabelWebsite"];
            LabelTelegram.Text = languageTexts[currentLanguage]["LabelTelegram"];
        }

        private void UpdateUI(string language)
        {
            switch (language)
            {
                case "CHS":
                    LabelWebsite.Font = new Font("别喝醉别流泪", 14);
                    LabelWebsite.Location = new Point(321, 125);
                    LabelTelegram.Font = new Font("别喝醉别流泪", 14);
                    LabelTelegram.Location = new Point(314, 179);
                    break;
                case "CHT":
                    LabelWebsite.Font = new Font("仿宋", 14);
                    LabelWebsite.Location = new Point(319, 125);
                    LabelTelegram.Font = new Font("仿宋", 14);
                    LabelTelegram.Location = new Point(304, 179);
                    break;
                case "EN":
                    LabelWebsite.Font = new Font("别喝醉别流泪", 14);
                    LabelWebsite.Location = new Point(321, 125);
                    LabelTelegram.Font = new Font("别喝醉别流泪", 14);
                    LabelTelegram.Location = new Point(301, 179);
                    break;
            }
        }


        private void ABOUT_FORM_LOAD(object sender, EventArgs e)
        {
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
                        case "CHS":
                            MessageBox.Show("图像未找到！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case "CHT":
                            MessageBox.Show("圖像未找到！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case "EN":
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
            System.Diagnostics.Process.Start("https://t.me/LatteYogurt_Products");

            // 标记为已访问
            LabelWebsite.LinkVisited = true;
        }

        private void CONFIRM_BUTTON_CLICK(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

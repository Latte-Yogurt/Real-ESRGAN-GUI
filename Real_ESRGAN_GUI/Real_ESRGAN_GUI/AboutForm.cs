using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Real_ESRGAN_GUI
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
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
                    MessageBox.Show("图像未找到！");
                }
            }
        }

        private void WEBSITE_LABEL_LINK_CLICKED(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 打开网址
            System.Diagnostics.Process.Start("https://github.com/Latte-Yogurt");

            // 标记为已访问
            WebsiteLabel.LinkVisited = true;
        }

        private void TELEGRAM_LABEL_LINK_CLICKED(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 打开网址
            System.Diagnostics.Process.Start("https://t.me/LatteYogurt_Products");

            // 标记为已访问
            WebsiteLabel.LinkVisited = true;
        }

        private void CONFIRM_BUTTON_CLICK(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

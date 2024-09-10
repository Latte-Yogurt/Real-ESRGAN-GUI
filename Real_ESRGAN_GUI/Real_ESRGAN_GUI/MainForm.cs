using System;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
/*
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
*/

namespace Real_ESRGAN_GUI
{
    public partial class MainForm : Form
    {
        public string filePath;
        public string fileName;
        public string directoryPath;
        public string scale;
        public string model;
        public string extension;
        public string processHidden;
        public string xmlPath;
        public string realesrganPath;
        public string vcomp140Path;
        public string vcomp140dPath;
        public string modelsPath;

        public MainForm(string[] args)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog; // 隐藏最大化按钮
            this.DragEnter += new DragEventHandler(MAINFORM_DRAGENTER);
            this.DragDrop += new DragEventHandler(MAINFORM_DRAGDROP);

            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
            {
                filePath = args[0];

                // 检查文件扩展名
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
                if (!allowedExtensions.Contains(Path.GetExtension(filePath).ToLower()))
                {
                    MessageBox.Show("不支持的文件格式。请提供 JPG、PNG 或 WEBP 文件。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close(); // 关闭应用程序
                    return; // 确保不执行后续代码
                }

                fileName = Path.GetFileNameWithoutExtension(filePath);
                directoryPath = Path.GetDirectoryName(filePath);
            }

            string workPath = GET_WORK_PATH(); // 获取程序路径
            string xml = @"config.xml";
            xmlPath = Path.Combine(workPath, xml);

            string realesrgan = @"realesrgan.exe";
            realesrganPath = Path.Combine(workPath, realesrgan);

            string vcomp140 = @"vcomp140.dll";
            vcomp140Path = Path.Combine(workPath, vcomp140);

            string vcomp140d = @"vcomp140d.dll";
            vcomp140dPath = Path.Combine(workPath, vcomp140d);

            string models = @"models";
            modelsPath = Path.Combine(workPath, models);

            scale = GET_SCALE(xmlPath);
            model = GET_MODEL(xmlPath);
            extension = GET_EXTENSION(xmlPath);
            processHidden = GET_PROCESS_HIDDEN(xmlPath);

            DEFAULT_MODEL_MENU();
            DEFAULT_SCALE_MENU();
            DEFAULT_EXTENSION_MENU();
            DEFAULT_PROCESS_HIDDEN();

            if (filePath != null)
            {
                if (!CHECK_REAL_ESRGAN_EXIST())
                {
                    MessageBox.Show("程序工作路径下Real ESRGAN组件不完整，无法启动Real ESRGAN处理流程。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    string command = $"{realesrganPath} -i \"{filePath}\" -o \"{directoryPath}\\{fileName}_x{scale}.{extension}\" -n {model} -s {scale}";
                    if (processHidden == "true")
                    {
                        EXECUTE_COMMAND_HIDDEN(command);
                        this.Close();
                    }

                    if (processHidden == "false")
                    {
                        EXECUTE_COMMAND_UNHIDDEN(command);
                        this.Close();
                    }
                }
            }
        }

        static string GET_WORK_PATH()
        {
            // 获取当前执行程序集
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            // 返回路径
            return Path.GetDirectoryName(assemblyPath);
        }

        private bool CHECK_REAL_ESRGAN_EXIST()
        {
            return File.Exists(realesrganPath) && File.Exists(vcomp140Path) && File.Exists(vcomp140dPath) && Directory.Exists(modelsPath);
        }

        private void EXECUTE_COMMAND_UNHIDDEN(string command)
        {
            // 创建进程
            var process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/C \"{command}\""; // /K 表示执行后保留窗口 /C 表示执行后不保留窗口(注意！！！给command添加双引号才可以正常运行！！！)
            process.StartInfo.RedirectStandardOutput = true; // 重定向输出
            process.StartInfo.UseShellExecute = false; // 使用操作系统外壳启动
            process.StartInfo.CreateNoWindow = false; // 显示命令行窗口

            // 启动进程
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
        }

        private void EXECUTE_COMMAND_HIDDEN(string command)
        {
            // 创建进程
            var process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/C \"{command}\""; // /C 表示执行后不保留窗口(注意！！！给command添加双引号才可以正常运行！！！)
            process.StartInfo.UseShellExecute = false; // 使用操作系统外壳启动
            process.StartInfo.CreateNoWindow = true; // 不显示命令行窗口

            // 启动进程
            process.Start();
        }

        private void CREATE_DEFAULT_CONFIG(string configFilePath)
        {
            // 创建默认的 XML 结构
            XElement defaultConfig = new XElement("Configuration",
                new XElement("Scale", "4"),
                new XElement("Model", "realesrgan-x4plus"),
                new XElement("Extension", "png"),
                new XElement("ProcessHidden", "false")
            );

            // 保存默认配置到文件
            defaultConfig.Save(configFilePath);
        }

        private string GET_SCALE(string configFilePath)
        {
            // 检查文件是否存在
            if (!File.Exists(configFilePath))
            {
                // 如果不存在，创建默认配置文件
                CREATE_DEFAULT_CONFIG(configFilePath);
            }
            XDocument xdoc = XDocument.Load(configFilePath);
            var scale = xdoc.Descendants("Scale").FirstOrDefault()?.Value;

            return scale;
        }

        private string GET_MODEL(string configFilePath)
        {
            // 检查文件是否存在
            if (!File.Exists(configFilePath))
            {
                // 如果不存在，创建默认配置文件
                CREATE_DEFAULT_CONFIG(configFilePath);
            }
            XDocument xdoc = XDocument.Load(configFilePath);
            var model = xdoc.Descendants("Model").FirstOrDefault()?.Value;

            return model;
        }

        private string GET_EXTENSION(string configFilePath)
        {
            // 检查文件是否存在
            if (!File.Exists(configFilePath))
            {
                // 如果不存在，创建默认配置文件
                CREATE_DEFAULT_CONFIG(configFilePath);
            }
            XDocument xdoc = XDocument.Load(configFilePath);
            var extension = xdoc.Descendants("Extension").FirstOrDefault()?.Value;

            return extension;
        }

        private string GET_PROCESS_HIDDEN(string configFilePath)
        {
            // 检查文件是否存在
            if (!File.Exists(configFilePath))
            {
                // 如果不存在，创建默认配置文件
                CREATE_DEFAULT_CONFIG(configFilePath);
            }
            XDocument xdoc = XDocument.Load(configFilePath);
            var extension = xdoc.Descendants("ProcessHidden").FirstOrDefault()?.Value;

            return extension;
        }

        private void DEFAULT_SCALE_MENU()
        {
            ComboBoxScale.Items.Clear();

            bool scaleAssigned = false; // 用于跟踪是否已分配scale

            if (model == "realesr-animevideov3")
            {
                // 添加Scale的选项菜单
                ComboBoxScale.Items.Add("2");
                ComboBoxScale.Items.Add("3");
                ComboBoxScale.Items.Add("4");

                // 定义Scale的默认显示选项菜单
                if (scale == "2")
                {
                    ComboBoxScale.SelectedIndex = 0;
                    scaleAssigned = true;
                }

                if (scale == "3")
                {
                    ComboBoxScale.SelectedIndex = 1;
                    scaleAssigned = true;
                }

                if (scale == "4")
                {
                    ComboBoxScale.SelectedIndex = 2;
                    scaleAssigned = true;
                }
            }
            else
            {
                ComboBoxScale.Items.Add("4");

                if (scale == "4")
                {
                    ComboBoxScale.SelectedIndex = 0;
                    scaleAssigned = true;
                }
            }

            // 在条件不满足时将scale强制赋值为"4"
            if (!scaleAssigned)
            {
                scale = "4"; // 强制赋值
                ComboBoxScale.SelectedIndex = 0; // 设置为默认选择
            }
        }

        private void DEFAULT_MODEL_MENU()
        {
            // 添加Model的选项菜单
            ComboBoxModel.Items.Add("realesrgan-x4plus");
            ComboBoxModel.Items.Add("realesrgan-x4plus-anime");
            ComboBoxModel.Items.Add("realesr-animevideov3");

            // 定义Model的默认显示选项菜单
            if (model == "realesrgan-x4plus")
            {
                ComboBoxModel.SelectedIndex = 0;
            }

            if (model == "realesrgan-x4plus-anime")
            {
                ComboBoxModel.SelectedIndex = 1;
            }

            if (model == "realesr-animevideov3")
            {
                ComboBoxModel.SelectedIndex = 2;
            }
        }

        private void DEFAULT_EXTENSION_MENU()
        {
            // 添加Extension的选项菜单
            ComboBoxExtension.Items.Add("jpg");
            ComboBoxExtension.Items.Add("png");
            ComboBoxExtension.Items.Add("webp");

            // 定义Extension的默认显示选项菜单
            if (extension == "jpg")
            {
                ComboBoxExtension.SelectedIndex = 0;
            }

            if (extension == "png")
            {
                ComboBoxExtension.SelectedIndex = 1;
            }

            if (extension == "webp")
            {
                ComboBoxExtension.SelectedIndex = 2;
            }
        }

        private void DEFAULT_PROCESS_HIDDEN()
        {
            // 定义后台运行的默认显示状态
            if (processHidden == "false")
            {
                CheckBoxHideProcess.Checked = false;
            }

            if (processHidden == "true")
            {
                CheckBoxHideProcess.Checked = true;
            }
        }

        private void MAINFORM_DRAGENTER(object sender, DragEventArgs e)
        {
            // 检查拖拽的内容是否为文件
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // 获取拖拽的文件路径
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                bool isValidFile = true; // 默认认为文件格式是有效的

                // 检查每个文件的扩展名
                foreach (string file in files)
                {
                    string extension = System.IO.Path.GetExtension(file).ToLower();
                    if (extension != ".jpg" && extension != ".jpeg" && extension != ".png" && extension != ".webp") 
                    {
                        isValidFile = false;
                        break; // 如果有一个文件不符合格式，退出循环
                    }
                }

                // 根据文件格式设置拖拽效果
                if (isValidFile)
                {
                    e.Effect = DragDropEffects.Copy; // 设置拖拽效果
                }
                else
                {
                    e.Effect = DragDropEffects.None; // 不允许拖拽
                }
            }
            else
            {
                e.Effect = DragDropEffects.None; // 不允许拖拽
            }
            // 恢复鼠标指针到正常状态
            Cursor.Current = Cursors.Default; // 设置鼠标指针为默认状态
        }

        private async void MAINFORM_DRAGDROP(object sender, DragEventArgs e)
        {
            // 获取拖拽的文件路径
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files != null && files.Length > 0)
            {
                // 处理文件路径，比如显示在一个文本框中
                filePath = files[0];
                fileName = Path.GetFileNameWithoutExtension(filePath);
                directoryPath = Path.GetDirectoryName(filePath);

                if (!CHECK_REAL_ESRGAN_EXIST())
                {
                    MessageBox.Show("程序工作路径下Real ESRGAN组件不完整，无法启动Real ESRGAN处理流程。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    string command = $"{realesrganPath} -i \"{filePath}\" -o \"{directoryPath}\\{fileName}_x{scale}.{extension}\" -n {model} -s {scale}";
                    if (processHidden == "true")
                    {
                        await Task.Run(() => EXECUTE_COMMAND_HIDDEN(command));
                    }

                    if (processHidden == "false")
                    {
                        await Task.Run(() => EXECUTE_COMMAND_UNHIDDEN(command));
                    }
                }
            }
        }

        private void MAINFORM_DRAGOVER(object sender, DragEventArgs e)
        {
            MAINFORM_DRAGENTER(sender, e); // 复用已有的逻辑
        }

        private void BUTTON_CONFIG_CLICK(object sender, EventArgs e)
        {
            MessageBox.Show("配置已保存，将文件拖拽于本程序以使用配置进行图像分辨率放大。","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);   

            XElement defaultConfig = new XElement("Configuration",
                new XElement("Scale", $"{scale}"),
                new XElement("Model", $"{model}"),
                new XElement("Extension", $"{extension}"),
                new XElement("ProcessHidden", $"{processHidden}")
                );

            // 保存默认配置到文件
            defaultConfig.Save(xmlPath);
        }

        private void CHECKBOX_HIDE_PROCESS_CHECKED_CHANGED(object sender, EventArgs e)
        {
            bool isProcessHidden = CheckBoxHideProcess.Checked;
            if (isProcessHidden)
            {
                processHidden = "true";
            }

            else
            {
                processHidden = "false";
            }
        }

        private void COMBOBOX_SCALE_SELECTED_INDEX_CHANGNED(object sender, EventArgs e)
        {
            string selectedScale = ComboBoxScale.SelectedItem.ToString();
            scale = selectedScale;
        }

        private void COMBOBOX_MODEL_SELECTED_INDEX_CHANGED(object sender, EventArgs e)
        {
            string selectedModel = ComboBoxModel.SelectedItem.ToString();
            model = selectedModel;
            DEFAULT_SCALE_MENU();
        }

        private void COMBOBOX_EXTENSION_SELECTED_INDEX_CHANGED(object sender, EventArgs e)
        {
            string selectedExtension = ComboBoxExtension.SelectedItem.ToString();
            extension = selectedExtension;
        }

        private async void MAINMENU_OPENFILES_CLICK(object sender, EventArgs e)
        {
            // 创建 OpenFileDialog 实例
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // 设置过滤器以仅显示特定类型的文件，例如文本文件
            openFileDialog.Filter = "JPG文件 (*.jpg)|*.jpg|JPEG文件 (*.jpeg)|*.jpeg|PNG文件 (*.png)|*.png|WEBP文件 (*.webp)|*.webp";

            // 显示对话框并检查用户是否选择了文件
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 获取选中文件的完整路径
                filePath = openFileDialog.FileName;
                fileName = Path.GetFileNameWithoutExtension(filePath);
                directoryPath = Path.GetDirectoryName(filePath);

                if (!CHECK_REAL_ESRGAN_EXIST())
                {
                    MessageBox.Show("程序工作路径下Real ESRGAN组件不完整，无法启动Real ESRGAN处理流程。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    string command = $"{realesrganPath} -i \"{filePath}\" -o \"{directoryPath}\\{fileName}_x{scale}.{extension}\" -n {model} -s {scale}";
                    if (processHidden == "true")
                    {
                        await Task.Run(() => EXECUTE_COMMAND_HIDDEN(command));
                    }

                    if (processHidden == "false")
                    {
                        await Task.Run(() => EXECUTE_COMMAND_UNHIDDEN(command));
                    }
                }
            }
        }

        private void MAINMENU_EXIT_CLICK(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABOUTMENU_ABOUT(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void NOTIFYICON_MOUSE_DOUBLE_CLICK(object sender, MouseEventArgs e)
        {
            // 处理双击事件 - 还原窗体
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void EXIT_TOOLSTRIP_MENUITEM_CLICK(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
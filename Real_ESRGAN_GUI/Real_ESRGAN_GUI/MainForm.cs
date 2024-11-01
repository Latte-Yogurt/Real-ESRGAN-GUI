﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Xml.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

/*
using System.Xml;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;
*/

namespace Real_ESRGAN_GUI
{
    public partial class MainForm : Form
    {
        private Dictionary<string, Dictionary<string, string>> languageTexts;

        public static string currentLanguage;
        public int locationX;
        public int locationY;
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

            string workPath = GET_WORK_PATH(); // 获取程序路径
            string xml = @"config.xml";
            xmlPath = Path.Combine(workPath, xml);

            currentLanguage = GET_CURRENT_LANGUAGE(xmlPath);

            InitializeLanguageTexts();
            UpdateLanguage();

            this.FormBorderStyle = FormBorderStyle.FixedDialog; // 隐藏最大化按钮
            this.DragEnter += new DragEventHandler(MAINFORM_DRAGENTER);
            this.DragDrop += new DragEventHandler(MAINFORM_DRAGDROP);
            this.FormClosing += MAINFORM_FORM_CLOSING;

            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
            {
                filePath = args[0];

                // 检查文件扩展名
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
                if (!allowedExtensions.Contains(Path.GetExtension(filePath).ToLower()))
                {
                    switch (currentLanguage)
                    {
                        case "zh-CN":
                            MessageBox.Show("不支持的文件格式。请提供 JPG、PNG 或 WEBP 文件。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case "zh-TW":
                            MessageBox.Show("不支持的文件格式。請提供 JPG、PNG 或 WEBP 文件。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case "en-US":
                            MessageBox.Show("Unsupported file format. Please provide JPG, PNG, or WEBP files.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }

                    this.Close(); // 关闭应用程序
                    return; // 确保不执行后续代码
                }

                fileName = Path.GetFileNameWithoutExtension(filePath);
                directoryPath = Path.GetDirectoryName(filePath);
            }

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
                    switch (currentLanguage)
                    {
                        case "zh-CN":
                            MessageBox.Show("程序工作路径下Real ESRGAN组件不完整，无法启动Real ESRGAN处理流程。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case "zh-TW":
                            MessageBox.Show("程式工作路徑下Real ESRGAN組件不完整，無法啓動Real ESRGAN處理流程。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case "en-US":
                            MessageBox.Show("The Real ESRGAN components in the program's working directory are incomplete and can not start the Real ESRGAN processing flow.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }

                else
                {
                    string command = $"@\"{realesrganPath}\" -i \"{filePath}\" -o \"{directoryPath}\\{fileName}_x{scale}.{extension}\" -n {model} -s {scale}";
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
            process.StartInfo.FileName = @"cmd.exe";
            process.StartInfo.Arguments = $"/C \"{command}\""; // /K 表示执行后保留窗口 /C 表示执行后不保留窗口(注意！！！给command添加双引号才可以正常运行！！！)
            process.StartInfo.RedirectStandardOutput = true; // 重定向输出
            process.StartInfo.UseShellExecute = false; // 不使用操作系统外壳启动
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
            process.StartInfo.FileName = @"cmd.exe"; // 调用系统文件夹中的cmd而非从工作路径调用cmd，避免工作路径下空格带来的影响
            process.StartInfo.Arguments = $"/C \"{command}\""; // /C 表示执行后不保留窗口(注意！！！给command添加双引号才可以正常运行！！！)
            process.StartInfo.UseShellExecute = false; // 不使用操作系统外壳启动
            process.StartInfo.CreateNoWindow = true; // 不显示命令行窗口

            // 启动进程
            process.Start();
        }

        private void InitializeLanguageTexts()
        {
            languageTexts = new Dictionary<string, Dictionary<string, string>>
            {
                { "zh-CN", new Dictionary<string, string>
                    {
                        { "MainMenuText","文件" },
                        { "MainMenuOpenFiles","打开" },
                        { "MainMenuExit","退出" },
                        { "LanguageMenu","语言" },
                        { "LanguageMenuSelect","选择语言" },
                        { "AboutMenu","关于" },
                        { "LabelScale","放大倍数" },
                        { "LabelModel","放大算法" },
                        { "LabelExtension","生成格式" },
                        { "CheckBoxHideProcess","后台运行" },
                        { "ButtonConfig","保存配置" },
                        { "MainContextMenuStripExit","退出" }
                    }
                },
                { "zh-TW", new Dictionary<string, string>
                    {
                        { "MainMenuText","文件" },
                        { "MainMenuOpenFiles","打開" },
                        { "MainMenuExit","退出" },
                        { "LanguageMenu","語言" },
                        { "LanguageMenuSelect","選擇語言" },
                        { "AboutMenu","關於" },
                        { "LabelScale","放大倍數" },
                        { "LabelModel","放大算法" },
                        { "LabelExtension","生成格式" },
                        { "CheckBoxHideProcess","後臺運行" },
                        { "ButtonConfig","保存配置" },
                        { "MainContextMenuStripExit","退出" }
                    }
                },
                { "en-US", new Dictionary<string, string>
                    {
                        { "MainMenuText","Files" },
                        { "MainMenuOpenFiles","Open" },
                        { "MainMenuExit","Exit" },
                        { "LanguageMenu","Language" },
                        { "LanguageMenuSelect","Select Language" },
                        { "AboutMenu","About" },
                        { "LabelScale","Scale" },
                        { "LabelModel","Model" },
                        { "LabelExtension","Extension" },
                        { "CheckBoxHideProcess","Hide Process" },
                        { "ButtonConfig","Save Config" },
                        { "MainContextMenuStripExit","Exit" }
                    }
                }
            };
        }

        private void UpdateLanguage()
        {
            MainMenu.Text = languageTexts[currentLanguage]["MainMenuText"];
            MainMenuOpenFiles.Text = languageTexts[currentLanguage]["MainMenuOpenFiles"];
            MainMenuExit.Text = languageTexts[currentLanguage]["MainMenuExit"];
            LanguageMenu.Text = languageTexts[currentLanguage]["LanguageMenu"];
            LanguageMenuSelect.Text = languageTexts[currentLanguage]["LanguageMenuSelect"];
            AboutMenu.Text = languageTexts[currentLanguage]["AboutMenu"];
            LabelScale.Text = languageTexts[currentLanguage]["LabelScale"];
            LabelModel.Text = languageTexts[currentLanguage]["LabelModel"];
            LabelExtension.Text = languageTexts[currentLanguage]["LabelExtension"];
            CheckBoxHideProcess.Text = languageTexts[currentLanguage]["CheckBoxHideProcess"];
            ButtonConfig.Text = languageTexts[currentLanguage]["ButtonConfig"];
            MainContextMenuStripExit.Text = languageTexts[currentLanguage]["MainContextMenuStripExit"];
        }

        private void CREATE_DEFAULT_CONFIG(string configFilePath)
        {
            int newLocationX = Screen.PrimaryScreen.Bounds.Width / 2 - this.Size.Width / 2;
            int newLocationY = Screen.PrimaryScreen.Bounds.Height / 2 - this.Size.Height / 2;

            // 创建默认的 XML 结构
            XElement defaultConfig = new XElement("Configuration",
                new XElement("Language", "zh-CN"),
                new XElement("LocationX", $"{newLocationX}"),
                new XElement("LocationY", $"{newLocationY}"),
                new XElement("Scale", "4"),
                new XElement("Model", "realesrgan-x4plus"),
                new XElement("Extension", "png"),
                new XElement("ProcessHidden", "false")
            );

            // 保存默认配置到文件
            defaultConfig.Save(configFilePath);
        }

        private void UPDATE_CONFIG(string filePath, string key, string newValue)
        {
            XDocument xdoc = XDocument.Load(filePath); // 加载 XML 文件

            var element = xdoc.Descendants(key).FirstOrDefault(); // 查找指定节点
            if (element != null)
            {
                element.Value = newValue; // 修改节点值
            }
            else
            {
                // 创建新节点并设置值
                xdoc.Root.Add(new XElement(key, newValue));
            }

            xdoc.Save(filePath); // 保存文件
        }


        private string GET_CURRENT_LANGUAGE(string configFilePath)
        {
            // 检查文件是否存在
            if (!File.Exists(configFilePath))
            {
                // 如果不存在，创建默认配置文件
                CREATE_DEFAULT_CONFIG(configFilePath);
            }

            // 加载 XML 文档
            XDocument xdoc = XDocument.Load(configFilePath);

            var language = xdoc.Descendants("Language").FirstOrDefault()?.Value;

            // 如果获取到的值为 null 或为空字符串
            if (string.IsNullOrEmpty(language))
            {
                // 创建新的 XML 节点
                XElement newNode = new XElement("Language", "zh-CN");

                // 将新节点添加到根节点
                xdoc.Root.Add(newNode);

                // 保存更改
                xdoc.Save(configFilePath);

                return "zh-CN";
            }
            else
            {
                // 返回获取到的值
                return language;
            }
        }


        private string GET_LOCATION_X(string configFilePath)
        {
            // 检查文件是否存在
            if (!File.Exists(configFilePath))
            {
                // 如果不存在，创建默认配置文件
                CREATE_DEFAULT_CONFIG(configFilePath);
            }

            // 加载 XML 文档
            XDocument xdoc = XDocument.Load(configFilePath);

            // 获取 LocationX 值
            var locationX = xdoc.Descendants("LocationX").FirstOrDefault()?.Value;

            // 如果获取到的值为 null 或为空字符串
            if (string.IsNullOrEmpty(locationX))
            {
                int newLocationX = Screen.PrimaryScreen.Bounds.Width / 2 - this.Size.Width / 2;

                // 创建新的 XML 节点
                XElement newNode = new XElement("LocationX", newLocationX);

                // 将新节点添加到根节点
                xdoc.Root.Add(newNode);

                // 保存更改
                xdoc.Save(configFilePath);

                return newLocationX.ToString();
            }
            else
            {
                // 返回获取到的值
                return locationX;
            }
        }

        private string GET_LOCATION_Y(string configFilePath)
        {
            // 检查文件是否存在
            if (!File.Exists(configFilePath))
            {
                // 如果不存在，创建默认配置文件
                CREATE_DEFAULT_CONFIG(configFilePath);
            }

            // 加载 XML 文档
            XDocument xdoc = XDocument.Load(configFilePath);

            // 获取 LocationX 值
            var locationY = xdoc.Descendants("LocationY").FirstOrDefault()?.Value;

            // 如果获取到的值为 null 或为空字符串
            if (string.IsNullOrEmpty(locationY))
            {
                int newLocationY = Screen.PrimaryScreen.Bounds.Height / 2 - this.Size.Height / 2;

                // 创建新的 XML 节点
                XElement newNode = new XElement("LocationY", newLocationY);

                // 将新节点添加到根节点
                xdoc.Root.Add(newNode);

                // 保存更改
                xdoc.Save(configFilePath);

                return newLocationY.ToString();
            }
            else
            {
                // 返回获取到的值
                return locationY;
            }
        }

        private string GET_SCALE(string configFilePath)
        {
            // 检查文件是否存在
            if (!File.Exists(configFilePath))
            {
                // 如果不存在，创建默认配置文件
                CREATE_DEFAULT_CONFIG(configFilePath);
            }

            // 加载 XML 文档
            XDocument xdoc = XDocument.Load(configFilePath);

            var scale = xdoc.Descendants("Scale").FirstOrDefault()?.Value;

            // 如果获取到的值为 null 或为空字符串
            if (string.IsNullOrEmpty(scale))
            {
                // 创建新的 XML 节点
                XElement newNode = new XElement("Scale", "4");

                // 将新节点添加到根节点
                xdoc.Root.Add(newNode);

                // 保存更改
                xdoc.Save(configFilePath);

                return "4";
            }
            else
            {
                // 返回获取到的值
                return scale;
            }
        }

        private string GET_MODEL(string configFilePath)
        {
            // 检查文件是否存在
            if (!File.Exists(configFilePath))
            {
                // 如果不存在，创建默认配置文件
                CREATE_DEFAULT_CONFIG(configFilePath);
            }

            // 加载 XML 文档
            XDocument xdoc = XDocument.Load(configFilePath);

            var model = xdoc.Descendants("Model").FirstOrDefault()?.Value;

            // 如果获取到的值为 null 或为空字符串
            if (string.IsNullOrEmpty(model))
            {
                // 创建新的 XML 节点
                XElement newNode = new XElement("Model", "realesrgan-x4plus");

                // 将新节点添加到根节点
                xdoc.Root.Add(newNode);

                // 保存更改
                xdoc.Save(configFilePath);

                return "realesrgan-x4plus";
            }
            else
            {
                // 返回获取到的值
                return model;
            }
        }

        private string GET_EXTENSION(string configFilePath)
        {
            // 检查文件是否存在
            if (!File.Exists(configFilePath))
            {
                // 如果不存在，创建默认配置文件
                CREATE_DEFAULT_CONFIG(configFilePath);
            }

            // 加载 XML 文档
            XDocument xdoc = XDocument.Load(configFilePath);

            var extension = xdoc.Descendants("Extension").FirstOrDefault()?.Value;

            // 如果获取到的值为 null 或为空字符串
            if (string.IsNullOrEmpty(extension))
            {
                // 创建新的 XML 节点
                XElement newNode = new XElement("Extension", "png");

                // 将新节点添加到根节点
                xdoc.Root.Add(newNode);

                // 保存更改
                xdoc.Save(configFilePath);

                return "png";
            }
            else
            {
                // 返回获取到的值
                return extension;
            }
        }

        private string GET_PROCESS_HIDDEN(string configFilePath)
        {
            // 检查文件是否存在
            if (!File.Exists(configFilePath))
            {
                // 如果不存在，创建默认配置文件
                CREATE_DEFAULT_CONFIG(configFilePath);
            }

            // 加载 XML 文档
            XDocument xdoc = XDocument.Load(configFilePath);

            var processHidden = xdoc.Descendants("ProcessHidden").FirstOrDefault()?.Value;

            // 如果获取到的值为 null 或为空字符串
            if (string.IsNullOrEmpty(processHidden))
            {
                // 创建新的 XML 节点
                XElement newNode = new XElement("ProcessHidden", "false");

                // 将新节点添加到根节点
                xdoc.Root.Add(newNode);

                // 保存更改
                xdoc.Save(configFilePath);

                return "false";
            }
            else
            {
                // 返回获取到的值
                return processHidden;
            }
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

        private void MAINFORM_LOAD(object sender, EventArgs e)
        {
            locationX = int.Parse(GET_LOCATION_X(xmlPath));
            locationY = int.Parse(GET_LOCATION_Y(xmlPath));

            this.Location = new Point(locationX, locationY);
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
                    switch (currentLanguage)
                    {
                        case "zh-CN":
                            MessageBox.Show("程序工作路径下Real ESRGAN组件不完整，无法启动Real ESRGAN处理流程。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case "zh-TW":
                            MessageBox.Show("程式工作路徑下Real ESRGAN組件不完整，無法啓動Real ESRGAN處理流程。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case "en-US":
                            MessageBox.Show("The Real ESRGAN components in the program's working directory are incomplete and can not start the Real ESRGAN processing flow.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }

                else
                {
                    string command = $"@\"{realesrganPath}\" -i \"{filePath}\" -o \"{directoryPath}\\{fileName}_x{scale}.{extension}\" -n {model} -s {scale}";
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
            switch (currentLanguage)
            {
                case "zh-CN":
                    MessageBox.Show("配置已保存。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "zh-TW":
                    MessageBox.Show("配置已保存。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "en-US":
                    MessageBox.Show("Configuration Saved.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }

            UPDATE_CONFIG($"{xmlPath}", "Scale", $"{scale}");
            UPDATE_CONFIG($"{xmlPath}", "Model", $"{model}");
            UPDATE_CONFIG($"{xmlPath}", "Extension", $"{extension}");
            UPDATE_CONFIG($"{xmlPath}", "ProcessHidden", $"{processHidden}");

            SAVE_LOCATION();
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
                    switch (currentLanguage)
                    {
                        case "zh-CN":
                            MessageBox.Show("程序工作路径下Real ESRGAN组件不完整，无法启动Real ESRGAN处理流程。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case "zh-TW":
                            MessageBox.Show("程式工作路徑下Real ESRGAN組件不完整，無法啓動Real ESRGAN處理流程。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case "en-US":
                            MessageBox.Show("The Real ESRGAN components in the program's working directory are incomplete and can not start the Real ESRGAN processing flow.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }

                else
                {
                    string command = $"@\"{realesrganPath}\" -i \"{filePath}\" -o \"{directoryPath}\\{fileName}_x{scale}.{extension}\" -n {model} -s {scale}";
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
            SAVE_LOCATION();
            this.Close();
        }

        private void LANGUAGE_MENU_SELECT_zhCN_CLICK(object sender, EventArgs e)
        {
            currentLanguage = "zh-CN";
            UpdateLanguage();
            UPDATE_CONFIG($"{xmlPath}", "Language", $"{currentLanguage}");
        }

        private void LANGUAGE_MENU_SELECT_zhTW_CLICK(object sender, EventArgs e)
        {
            currentLanguage = "zh-TW";
            UpdateLanguage();
            UPDATE_CONFIG($"{xmlPath}", "Language", $"{currentLanguage}");
        }

        private void LANGUAGE_MENU_SELECT_enUS_CLICK(object sender, EventArgs e)
        {
            currentLanguage = "en-US";
            UpdateLanguage();
            UPDATE_CONFIG($"{xmlPath}", "Language", $"{currentLanguage}");
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

        private void MAIN_CONTEXT_MENU_STRIP_EXIT_CLICK(object sender, EventArgs e)
        {
            SAVE_LOCATION();
            this.Close();
        }

        private void MAINFORM_FORM_CLOSING(object sender,FormClosingEventArgs e)
        {
            SAVE_LOCATION();
        }

        private void SAVE_LOCATION()
        {
            locationX = this.Location.X;
            locationY = this.Location.Y;

            UPDATE_CONFIG($"{xmlPath}", "LocationX", $"{locationX}");
            UPDATE_CONFIG($"{xmlPath}", "LocationY", $"{locationY}");
        }
    }
}
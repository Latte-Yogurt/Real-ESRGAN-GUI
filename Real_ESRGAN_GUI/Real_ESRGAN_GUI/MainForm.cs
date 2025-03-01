﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Drawing;
using System.Reflection;
using System.Xml.Linq;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Xml;

namespace Real_ESRGAN_GUI
{
    public partial class MainForm : Form
    {
        private Dictionary<string, Dictionary<string, string>> languageTexts;

        public string workPath;
        public bool hasPermission;
        public string xmlPath;
        public bool isMultipleFiles;
        public bool isCreatedNewFolder = true;
        public string filePath;
        public string fileName;
        public string directoryPath;
        public string realesrganPath;
        public string vcomp140Path;
        public string vcomp140dPath;
        public string modelsPath;
        public string realesr_animevideov3_x2_binPath;
        public string realesr_animevideov3_x2_paramPath;
        public string realesr_animevideov3_x3_binPath;
        public string realesr_animevideov3_x3_paramPath;
        public string realesr_animevideov3_x4_binPath;
        public string realesr_animevideov3_x4_paramPath;
        public string realesrgan_x4plus_binPath;
        public string realesrgan_x4plus_paramPath;
        public string realesrgan_x4plus_anime_binPath;
        public string realesrgan_x4plus_anime_paramPath;
        public static string currentLanguage;
        public static float systemScale;
        public int oldScreenWidth;
        public int oldScreenHeight;
        public float oldSystemScale;
        public int locationX;
        public int locationY;
        public string scale;
        public string model;
        public string extension;
        public bool processHidden;

        public MainForm(string[] args)
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;

            GET_SYSTEM_SCALE();
            SET_BUTTON_CONFIG_SIZE();
            SET_COMBOBOX_SIZE();
            SET_CLIENT_SIZE();
            SET_MAINFORM_LOCATION();

            workPath = GET_WORK_PATH(); // 获取程序路径
            hasPermission = CHECK_WORK_PATH_WRITABLE(workPath, out Exception ex);

            if (!hasPermission)
            {
                ERROR_NO_PREMISSION(workPath, ex);
                this.Close();
                return;
            }

            string xml = @"config.xml";
            xmlPath = Path.Combine(workPath, xml);
            CHECK_XML_LEGAL(xmlPath);

            currentLanguage = GET_CURRENT_LANGUAGE(xmlPath);

            oldScreenWidth = GET_SCREEN_WIDTH(xmlPath);
            oldScreenHeight = GET_SCREEN_HEIGHT(xmlPath);
            oldSystemScale = GET_SYSTEM_SCALE(xmlPath);

            InitializeLanguageTexts();
            UpdateLanguage();

            this.DragEnter += new DragEventHandler(MAINFORM_DRAGENTER);
            this.DragDrop += new DragEventHandler(MAINFORM_DRAGDROP);
            this.FormClosing += MAINFORM_FORM_CLOSING;

            if (args.Length > 0)
            {
                if (args.Length > 1)
                {
                    isMultipleFiles = true;
                }

                else
                {
                    isMultipleFiles = false;
                }
            }

            string realesrgan = @"realesrgan.exe";
            realesrganPath = Path.Combine(workPath, realesrgan);

            string vcomp140 = @"vcomp140.dll";
            vcomp140Path = Path.Combine(workPath, vcomp140);

            string vcomp140d = @"vcomp140d.dll";
            vcomp140dPath = Path.Combine(workPath, vcomp140d);

            string models = @"models";
            modelsPath = Path.Combine(workPath, models);

            string realesr_animevideov3_x2_bin = @"realesr-animevideov3-x2.bin";
            realesr_animevideov3_x2_binPath = Path.Combine(modelsPath, realesr_animevideov3_x2_bin);

            string realesr_animevideov3_x2_param = @"realesr-animevideov3-x2.param";
            realesr_animevideov3_x2_paramPath = Path.Combine(modelsPath, realesr_animevideov3_x2_param);

            string realesr_animevideov3_x3_bin = @"realesr-animevideov3-x3.bin";
            realesr_animevideov3_x3_binPath = Path.Combine(modelsPath, realesr_animevideov3_x3_bin);

            string realesr_animevideov3_x3_param = @"realesr-animevideov3-x3.param";
            realesr_animevideov3_x3_paramPath = Path.Combine(modelsPath, realesr_animevideov3_x3_param);

            string realesr_animevideov3_x4_bin = @"realesr-animevideov3-x4.bin";
            realesr_animevideov3_x4_binPath = Path.Combine(modelsPath, realesr_animevideov3_x4_bin);

            string realesr_animevideov3_x4_param = @"realesr-animevideov3-x4.param";
            realesr_animevideov3_x4_paramPath = Path.Combine(modelsPath, realesr_animevideov3_x4_param);

            string realesrgan_x4plus_bin = @"realesrgan-x4plus.bin";
            realesrgan_x4plus_binPath = Path.Combine(modelsPath, realesrgan_x4plus_bin);

            string realesrgan_x4plus_param = @"realesrgan-x4plus.param";
            realesrgan_x4plus_paramPath = Path.Combine(modelsPath, realesrgan_x4plus_param);

            string realesrgan_x4plus_anime_bin = @"realesrgan-x4plus-anime.bin";
            realesrgan_x4plus_anime_binPath = Path.Combine(modelsPath, realesrgan_x4plus_anime_bin);

            string realesrgan_x4plus_anime_param = @"realesrgan-x4plus-anime.param";
            realesrgan_x4plus_anime_paramPath = Path.Combine(modelsPath, realesrgan_x4plus_anime_param);

            scale = GET_SCALE(xmlPath);
            model = GET_MODEL(xmlPath);
            extension = GET_EXTENSION(xmlPath);
            processHidden = GET_PROCESS_HIDDEN(xmlPath);

            DEFAULT_MODEL_MENU();
            DEFAULT_SCALE_MENU();
            DEFAULT_EXTENSION_MENU();
            DEFAULT_PROCESS_HIDDEN();

            if (!CHECK_REAL_ESRGAN_EXIST())
            {
                CREATE_COMPONENTS();
                if (!isCreatedNewFolder)
                {
                    this.Close();
                    return;
                }
            }

            if (args != null && args.Length > 0 && args.All(arg => !string.IsNullOrEmpty(arg)))
            {
                if (!isMultipleFiles)
                {
                    filePath = args[0];
                    fileName = Path.GetFileNameWithoutExtension(filePath);
                    directoryPath = Path.GetDirectoryName(filePath);

                    if (!CHECK_REAL_ESRGAN_EXIST())
                    {
                        CREATE_COMPONENTS();
                        if (!isCreatedNewFolder)
                        {
                            ERROR_REAL_ESRGAN_EXIST();
                            this.Close();
                            return;
                        }
                    }

                    bool isLegalFile = CHECK_EXTENSION(filePath);

                    if (isLegalFile)
                    {
                        EXECUTE_COMMAND();
                        this.Close();
                    }

                    else
                    {
                        this.Close();
                    }
                }

                else
                {
                    foreach (var simpleFilePath in args)
                    {
                        filePath = simpleFilePath;
                        fileName = Path.GetFileNameWithoutExtension(filePath);
                        directoryPath = Path.GetDirectoryName(filePath);

                        if (!CHECK_REAL_ESRGAN_EXIST())
                        {
                            CREATE_COMPONENTS();
                            if (!isCreatedNewFolder)
                            {
                                ERROR_REAL_ESRGAN_EXIST();
                                break;
                            }
                        }

                        bool isLegalFile = CHECK_EXTENSION(simpleFilePath);

                        if (isLegalFile)
                        {
                            EXECUTE_COMMAND();
                        }
                    }

                    this.Close();
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

        private bool CHECK_WORK_PATH_WRITABLE(string path, out Exception ex)
        {
            ex = null; // 初始化异常为 null
            try
            {
                string testFilePath = Path.Combine(path, "test");
                using (FileStream testFile = File.Create(testFilePath)) { }
                File.Delete(testFilePath);
                return true;
            }
            catch (UnauthorizedAccessException unauthorizedEx)
            {
                ex = unauthorizedEx;
                return false;
            }
            catch (Exception otherEx)
            {
                ex = otherEx;
                return false;
            }
        }

        private void CHECK_XML_LEGAL(string configFilePath)
        {
            FileInfo configFile = new FileInfo(configFilePath);

            if (configFile.Exists && (configFile.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
            {
                configFile.Attributes = FileAttributes.Normal;
            }

            if (configFile.Exists && (configFile.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                configFile.Attributes = FileAttributes.Normal;
            }

            if (!configFile.Exists)
            {
                CREATE_DEFAULT_CONFIG(configFilePath);
            }
        }

        private void CHECK_FOLDER_LEGAL(string directoryPath)
        {
            DirectoryInfo directory = new DirectoryInfo(directoryPath);

            if (directory.Exists && (directory.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
            {
                directory.Attributes = FileAttributes.Normal;
            }

            if (directory.Exists && (directory.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                directory.Attributes = FileAttributes.Normal;
            }
        }

        private bool CHECK_REAL_ESRGAN_EXIST()
        {
            return File.Exists(realesrganPath) && File.Exists(vcomp140Path) && File.Exists(vcomp140dPath) 
                && Directory.Exists(modelsPath) && File.Exists(realesr_animevideov3_x2_binPath) 
                && File.Exists(realesr_animevideov3_x2_paramPath) && File.Exists(realesr_animevideov3_x3_binPath) 
                && File.Exists(realesr_animevideov3_x3_paramPath) && File.Exists(realesr_animevideov3_x4_binPath) 
                && File.Exists(realesr_animevideov3_x4_paramPath) && File.Exists(realesrgan_x4plus_binPath) 
                && File.Exists(realesrgan_x4plus_paramPath) && File.Exists(realesrgan_x4plus_anime_binPath) 
                && File.Exists(realesrgan_x4plus_anime_paramPath);
        }

        private void EXTRACT_RESOURCE(string resourceName, string outputPath)
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    ERROR_RESOURCE_EXIST(resourceName);
                    return;
                }

                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(fileStream);
                }
            }
        }

        private bool CREATE_NEW_FOLDER(string newFolderPath)
        {
            if (!Directory.Exists(newFolderPath))
            {
                try
                {
                    Directory.CreateDirectory(newFolderPath);
                    return true;
                }

                catch (Exception ex)
                {
                    ERROR_CREATE_FOLDER_FAILED(ex);
                    return false;
                }
            }

            else
            {
                return true;
            }
        }

        private void CREATE_COMPONENTS()
        {
            if (!File.Exists(realesrganPath))
            {
                CREATE_REAL_ESRGAN_EXE();
            }

            if (!File.Exists(vcomp140Path))
            {
                CREATE_VCOMP_140_DLL();
            }

            if (!File.Exists(vcomp140dPath))
            {
                CREATE_VCOMP_140D_DLL();
            }

            if (!Directory.Exists(modelsPath))
            {
                isCreatedNewFolder = CREATE_NEW_FOLDER(modelsPath);
            }

            if (Directory.Exists(modelsPath))
            {
                CHECK_FOLDER_LEGAL(modelsPath);

                if (!File.Exists(realesr_animevideov3_x2_binPath))
                {
                    CREATE_REAL_ESRGAN_ANIMEVIDEO_V3_X2_BIN();
                }

                if (!File.Exists(realesr_animevideov3_x2_paramPath))
                {
                    CREATE_REAL_ESRGAN_ANIMEVIDEO_V3_X2_PARAM();
                }

                if (!File.Exists(realesr_animevideov3_x3_binPath))
                {
                    CREATE_REAL_ESRGAN_ANIMEVIDEO_V3_X3_BIN();
                }

                if (!File.Exists(realesr_animevideov3_x3_paramPath))
                {
                    CREATE_REAL_ESRGAN_ANIMEVIDEO_V3_X3_PARAM();
                }

                if (!File.Exists(realesr_animevideov3_x4_binPath))
                {
                    CREATE_REAL_ESRGAN_ANIMEVIDEO_V3_X4_BIN();
                }

                if (!File.Exists(realesr_animevideov3_x4_paramPath))
                {
                    CREATE_REAL_ESRGAN_ANIMEVIDEO_V3_X4_PARAM();
                }

                if (!File.Exists(realesrgan_x4plus_binPath))
                {
                    CREATE_REAL_ESRGAN_X4PLUS_BIN();
                }

                if (!File.Exists(realesrgan_x4plus_paramPath))
                {
                    CREATE_REAL_ESRGAN_X4PLUS_PARAM();
                }

                if (!File.Exists(realesrgan_x4plus_anime_binPath))
                {
                    CREATE_REAL_ESRGAN_X4PLUS_ANIME_BIN();
                }

                if (!File.Exists(realesrgan_x4plus_anime_paramPath))
                {
                    CREATE_REAL_ESRGAN_X4PLUS_ANIME_PARAM();
                }
            }
        }

        private void CREATE_REAL_ESRGAN_EXE()
        {
            string resourceName = "Real_ESRGAN_GUI.Resource.realesrgan.exe";
            string outputFileName = resourceName.Replace("Real_ESRGAN_GUI.Resource.", "");//将原始嵌入资源的文件名中的命名空间前缀替换为空字符串
            string outputPath = Path.Combine(workPath, outputFileName);
            EXTRACT_RESOURCE(resourceName, outputPath);
        }

        private void CREATE_VCOMP_140_DLL()
        {
            string resourceName = "Real_ESRGAN_GUI.Resource.vcomp140.dll";
            string outputFileName = resourceName.Replace("Real_ESRGAN_GUI.Resource.", "");
            string outputPath = Path.Combine(workPath, outputFileName);
            EXTRACT_RESOURCE(resourceName, outputPath);
        }

        private void CREATE_VCOMP_140D_DLL()
        {
            string resourceName = "Real_ESRGAN_GUI.Resource.vcomp140d.dll";
            string outputFileName = resourceName.Replace("Real_ESRGAN_GUI.Resource.", "");
            string outputPath = Path.Combine(workPath, outputFileName);
            EXTRACT_RESOURCE(resourceName, outputPath);
        }

        private void CREATE_REAL_ESRGAN_ANIMEVIDEO_V3_X2_BIN()
        {
            string resourceName = "Real_ESRGAN_GUI.Resource.models.realesr-animevideov3-x2.bin";
            string outputFileName = resourceName.Replace("Real_ESRGAN_GUI.Resource.models.", "");
            string outputPath = Path.Combine(modelsPath, outputFileName);
            EXTRACT_RESOURCE(resourceName, outputPath);
        }

        private void CREATE_REAL_ESRGAN_ANIMEVIDEO_V3_X2_PARAM()
        {
            string resourceName = "Real_ESRGAN_GUI.Resource.models.realesr-animevideov3-x2.param";
            string outputFileName = resourceName.Replace("Real_ESRGAN_GUI.Resource.models.", "");
            string outputPath = Path.Combine(modelsPath, outputFileName);
            EXTRACT_RESOURCE(resourceName, outputPath);
        }

        private void CREATE_REAL_ESRGAN_ANIMEVIDEO_V3_X3_BIN()
        {
            string resourceName = "Real_ESRGAN_GUI.Resource.models.realesr-animevideov3-x3.bin";
            string outputFileName = resourceName.Replace("Real_ESRGAN_GUI.Resource.models.", "");
            string outputPath = Path.Combine(modelsPath, outputFileName);
            EXTRACT_RESOURCE(resourceName, outputPath);
        }

        private void CREATE_REAL_ESRGAN_ANIMEVIDEO_V3_X3_PARAM()
        {
            string resourceName = "Real_ESRGAN_GUI.Resource.models.realesr-animevideov3-x3.param";
            string outputFileName = resourceName.Replace("Real_ESRGAN_GUI.Resource.models.", "");
            string outputPath = Path.Combine(modelsPath, outputFileName);
            EXTRACT_RESOURCE(resourceName, outputPath);
        }

        private void CREATE_REAL_ESRGAN_ANIMEVIDEO_V3_X4_BIN()
        {
            string resourceName = "Real_ESRGAN_GUI.Resource.models.realesr-animevideov3-x4.bin";
            string outputFileName = resourceName.Replace("Real_ESRGAN_GUI.Resource.models.", "");
            string outputPath = Path.Combine(modelsPath, outputFileName);
            EXTRACT_RESOURCE(resourceName, outputPath);
        }

        private void CREATE_REAL_ESRGAN_ANIMEVIDEO_V3_X4_PARAM()
        {
            string resourceName = "Real_ESRGAN_GUI.Resource.models.realesr-animevideov3-x4.param";
            string outputFileName = resourceName.Replace("Real_ESRGAN_GUI.Resource.models.", "");
            string outputPath = Path.Combine(modelsPath, outputFileName);
            EXTRACT_RESOURCE(resourceName, outputPath);
        }

        private void CREATE_REAL_ESRGAN_X4PLUS_BIN()
        {
            string resourceName = "Real_ESRGAN_GUI.Resource.models.realesrgan-x4plus.bin";
            string outputFileName = resourceName.Replace("Real_ESRGAN_GUI.Resource.models.", "");
            string outputPath = Path.Combine(modelsPath, outputFileName);
            EXTRACT_RESOURCE(resourceName, outputPath);
        }

        private void CREATE_REAL_ESRGAN_X4PLUS_PARAM()
        {
            string resourceName = "Real_ESRGAN_GUI.Resource.models.realesrgan-x4plus.param";
            string outputFileName = resourceName.Replace("Real_ESRGAN_GUI.Resource.models.", "");
            string outputPath = Path.Combine(modelsPath, outputFileName);
            EXTRACT_RESOURCE(resourceName, outputPath);
        }

        private void CREATE_REAL_ESRGAN_X4PLUS_ANIME_BIN()
        {
            string resourceName = "Real_ESRGAN_GUI.Resource.models.realesrgan-x4plus-anime.bin";
            string outputFileName = resourceName.Replace("Real_ESRGAN_GUI.Resource.models.", "");
            string outputPath = Path.Combine(modelsPath, outputFileName);
            EXTRACT_RESOURCE(resourceName, outputPath);
        }

        private void CREATE_REAL_ESRGAN_X4PLUS_ANIME_PARAM()
        {
            string resourceName = "Real_ESRGAN_GUI.Resource.models.realesrgan-x4plus-anime.param";
            string outputFileName = resourceName.Replace("Real_ESRGAN_GUI.Resource.models.", "");
            string outputPath = Path.Combine(modelsPath, outputFileName);
            EXTRACT_RESOURCE(resourceName, outputPath);
        }

        private void GET_SYSTEM_SCALE()
        {
            float dpi;
            using (Graphics g = this.CreateGraphics())
            {
                dpi = g.DpiX;
            }

            systemScale = dpi / 96.0f;
        }

        private bool CHECK_EXTENSION(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                // 检查文件扩展名
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
                if (!allowedExtensions.Contains(Path.GetExtension(filePath).ToLower()))
                {
                    ERROR_UNSUPPORTED_FILE();
                    return false;
                }

                return true;
            }

            return false;
        }

        private void EXECUTE_COMMAND()
        {
            string command = $"@\"{realesrganPath}\" -i \"{filePath}\" -o \"{directoryPath}\\{fileName}_x{scale}.{extension}\" -n {model} -s {scale}";
            if (CheckBoxHideProcess.Checked)
            {
                EXECUTE_COMMAND_HIDDEN(command);
            }

            else
            {
                EXECUTE_COMMAND_UNHIDDEN(command);
            }
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

            SET_COMPONENT_POSITION();
        }

        private void CREATE_DEFAULT_CONFIG(string configFilePath)
        {
            if (File.Exists(configFilePath))
            {
                try
                {
                    File.WriteAllText(configFilePath, string.Empty);
                }

                catch (Exception ex)
                {
                    ERROR_EXCEPTION_MESSAGE(ex);
                    this.Close();
                }
            }

            int newLocationX = Screen.PrimaryScreen.Bounds.Width / 2 - this.Width / 2;
            int newLocationY = Screen.PrimaryScreen.Bounds.Height / 2 - this.Height / 2;

            // 获取当前系统的显示语言
            var currentCulture = CultureInfo.CurrentUICulture;

            // 创建一个示例词典，包含支持的语言
            var supportedLanguages = new HashSet<string>
            {
                "zh-CN", // 中文 (简体)
                "zh-TW", // 中文 (繁体)
                "en-US", // 英语 (美国)
                // 其他语言...
            };

            XElement defaultConfig;

            if (supportedLanguages.Contains(currentCulture.Name))
            {
                if (currentLanguage != null)
                {
                    defaultConfig = new XElement("Configuration",
                        new XElement("Language", $"{currentLanguage}"),
                        new XElement("LocationX", $"{newLocationX}"),
                        new XElement("LocationY", $"{newLocationY}"),
                        new XElement("Scale", "4"),
                        new XElement("Model", "realesrgan-x4plus"),
                        new XElement("Extension", "png"),
                        new XElement("ProcessHidden", "false")
                    );
                }

                else
                {
                    defaultConfig = new XElement("Configuration",
                        new XElement("Language", $"{currentCulture.Name}"),
                        new XElement("LocationX", $"{newLocationX}"),
                        new XElement("LocationY", $"{newLocationY}"),
                        new XElement("Scale", "4"),
                        new XElement("Model", "realesrgan-x4plus"),
                        new XElement("Extension", "png"),
                        new XElement("ProcessHidden", "false")
                    );
                }
            }

            else
            {
                defaultConfig = new XElement("Configuration",
                    new XElement("Language", "en-US"),
                    new XElement("LocationX", $"{newLocationX}"),
                    new XElement("LocationY", $"{newLocationY}"),
                    new XElement("Scale", "4"),
                    new XElement("Model", "realesrgan-x4plus"),
                    new XElement("Extension", "png"),
                    new XElement("ProcessHidden", "false")
                );
            }

            try
            {
                defaultConfig.Save(configFilePath);
            }
            catch (Exception ex)
            {
                ERROR_EXCEPTION_MESSAGE(ex);
            }
        }

        private void UPDATE_CONFIG(string filePath, string key, string newValue)
        {
            try
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

            catch (Exception)
            {
                CREATE_DEFAULT_CONFIG(xmlPath);
            }
        }

        private string GET_CURRENT_LANGUAGE(string configFilePath)
        {
            // 检查文件是否存在
            if (!File.Exists(configFilePath))
            {
                // 如果不存在，创建默认配置文件
                CREATE_DEFAULT_CONFIG(configFilePath);
            }

            // 获取当前系统的显示语言
            var currentCulture = CultureInfo.CurrentUICulture;

            // 创建一个示例词典，包含支持的语言
            var supportedLanguages = new HashSet<string>
                {
                    "zh-CN", // 中文 (简体)
                    "zh-TW", // 中文 (繁体)
                    "en-US", // 英语 (美国)
                    // 其他语言...
                };

            XDocument xdoc;

            try
            {
                // 加载 XML 文档
                xdoc = XDocument.Load(configFilePath);
            }

            catch (XmlException)
            {
                // 如果加载失败，创建新的默认配置文件并返回默认值
                CREATE_DEFAULT_CONFIG(configFilePath);

                if (supportedLanguages.Contains(currentCulture.Name))
                {
                    return currentCulture.Name;
                }

                else
                {
                    return "en-US";
                }
            }

            // 检查 Language 节点是否存在
            var languageNode = xdoc.Descendants("Language").FirstOrDefault();

            if (languageNode == null)
            {
                // 检查当前语言是否在词典中
                if (supportedLanguages.Contains(currentCulture.Name))
                {
                    // 如果没有找到 Language 节点，创建新的 XML 节点
                    XElement newNode = new XElement("Language", $"{currentCulture.Name}");

                    // 将新节点添加到根节点
                    xdoc.Root.Add(newNode);

                    // 保存更改
                    xdoc.Save(configFilePath);

                    return currentCulture.Name;
                }

                else
                {
                    XElement newNode = new XElement("Language", "en-US");

                    xdoc.Root.Add(newNode);

                    xdoc.Save(configFilePath);

                    return "en-US";
                }
            }

            // 获取 Language 节点的值
            var language = languageNode.Value;

            // 如果获取到的值为空字符串
            if (string.IsNullOrEmpty(language))
            {
                // 检查当前语言是否在词典中
                if (supportedLanguages.Contains(currentCulture.Name))
                {
                    return currentCulture.Name;
                }

                else
                {
                    return "en-US";
                }
            }

            // 检查语言是否在支持语言词典中
            if (!supportedLanguages.Contains(language))
            {
                // 如果在，返回当前的系统显示语言（如果在支持列表中）
                if (supportedLanguages.Contains(currentCulture.Name))
                {
                    return currentCulture.Name;
                }
                else
                {
                    return "en-US"; // 默认语言
                }
            }

            // 返回获取到的值
            return language;
        }

        private int GET_SCREEN_WIDTH(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                CREATE_DEFAULT_CONFIG(configFilePath);
            }

            int newWidth = Screen.PrimaryScreen.Bounds.Width;

            XDocument xdoc;

            try
            {
                // 加载 XML 文档
                xdoc = XDocument.Load(configFilePath);
            }

            catch (XmlException)
            {
                // 如果加载失败，创建新的默认配置文件并返回默认值
                CREATE_DEFAULT_CONFIG(configFilePath);

                return 0;
            }

            var widthNode = xdoc.Descendants("ScreenWidth").FirstOrDefault();

            if (widthNode == null)
            {

                XElement newNode = new XElement("ScreenWidth", newWidth);

                xdoc.Root.Add(newNode);

                xdoc.Save(configFilePath);

                return 0;
            }

            var width = widthNode.Value;
            int widthToInt;

            if (string.IsNullOrEmpty(width))
            {
                return 0;
            }

            if (!int.TryParse(width, out widthToInt))
            {
                return 0;
            }

            if (widthToInt <= 0)
            {
                return 0;
            }

            if (widthToInt == Screen.PrimaryScreen.Bounds.Width)
            {
                return widthToInt;
            }

            return 0;
        }

        private int GET_SCREEN_HEIGHT(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                CREATE_DEFAULT_CONFIG(configFilePath);
            }

            int newHeight = Screen.PrimaryScreen.Bounds.Height;

            XDocument xdoc;

            try
            {
                // 加载 XML 文档
                xdoc = XDocument.Load(configFilePath);
            }

            catch (XmlException)
            {
                // 如果加载失败，创建新的默认配置文件并返回默认值
                CREATE_DEFAULT_CONFIG(configFilePath);

                return 0;
            }

            var heightNode = xdoc.Descendants("ScreenHeight").FirstOrDefault();

            if (heightNode == null)
            {

                XElement newNode = new XElement("ScreenHeight", newHeight);

                xdoc.Root.Add(newNode);

                xdoc.Save(configFilePath);

                return 0;
            }

            var height = heightNode.Value;
            int heightToInt;

            if (string.IsNullOrEmpty(height))
            {
                return 0;
            }

            if (!int.TryParse(height, out heightToInt))
            {
                return 0;
            }

            if (heightToInt <= 0)
            {
                return 0;
            }

            if (heightToInt == Screen.PrimaryScreen.Bounds.Height)
            {
                return heightToInt;
            }

            return 0;
        }

        private float GET_SYSTEM_SCALE(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                CREATE_DEFAULT_CONFIG(configFilePath);
            }

            XDocument xdoc;

            try
            {
                // 加载 XML 文档
                xdoc = XDocument.Load(configFilePath);
            }

            catch (XmlException)
            {
                // 如果加载失败，创建新的默认配置文件并返回默认值
                CREATE_DEFAULT_CONFIG(configFilePath);

                return 0;
            }

            var scaleNode = xdoc.Descendants("SystemScale").FirstOrDefault();

            if (scaleNode == null)
            {

                XElement newNode = new XElement("SystemScale", systemScale);

                xdoc.Root.Add(newNode);

                xdoc.Save(configFilePath);

                return 0;
            }

            var scale = scaleNode.Value;
            float scaleToFloat;

            if (string.IsNullOrEmpty(scale))
            {
                return 0;
            }

            if (!float.TryParse(scale, out scaleToFloat))
            {
                return 0;
            }

            if (scaleToFloat <= 0)
            {
                return 0;
            }

            if (scaleToFloat == systemScale)
            {
                return scaleToFloat;
            }

            return 0;
        }

        private int GET_LOCATION_X(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                CREATE_DEFAULT_CONFIG(configFilePath);
            }

            int newLocationX = Screen.PrimaryScreen.Bounds.Width / 2 - this.Size.Width / 2;

            XDocument xdoc;

            try
            {
                // 加载 XML 文档
                xdoc = XDocument.Load(configFilePath);
            }

            catch (XmlException)
            {
                // 如果加载失败，创建新的默认配置文件并返回默认值
                CREATE_DEFAULT_CONFIG(configFilePath);

                return newLocationX;
            }

            var locationXNode = xdoc.Descendants("LocationX").FirstOrDefault();

            if (locationXNode == null)
            {

                XElement newNode = new XElement("LocationX", newLocationX);

                xdoc.Root.Add(newNode);

                xdoc.Save(configFilePath);

                return newLocationX;
            }

            var locationX = locationXNode.Value;
            int locationXToInt;

            if (string.IsNullOrEmpty(locationX))
            {
                return newLocationX;
            }

            if (!int.TryParse(locationX, out locationXToInt))
            {
                return newLocationX;
            }

            if (locationXToInt > Screen.PrimaryScreen.Bounds.Width - this.Size.Width || locationXToInt < -10)
            {
                return newLocationX;
            }

            return locationXToInt;
        }

        private int GET_LOCATION_Y(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                CREATE_DEFAULT_CONFIG(configFilePath);
            }

            int newLocationY = Screen.PrimaryScreen.Bounds.Height / 2 - this.Size.Height / 2;

            XDocument xdoc;

            try
            {
                // 加载 XML 文档
                xdoc = XDocument.Load(configFilePath);
            }

            catch (XmlException)
            {
                // 如果加载失败，创建新的默认配置文件并返回默认值
                CREATE_DEFAULT_CONFIG(configFilePath);

                return newLocationY;
            }

            var locationYNode = xdoc.Descendants("LocationY").FirstOrDefault();

            if (locationYNode == null)
            {
                XElement newNode = new XElement("LocationY", newLocationY);

                xdoc.Root.Add(newNode);

                xdoc.Save(configFilePath);

                return newLocationY;
            }

            var locationY = locationYNode.Value;
            int locationYToInt;

            if (string.IsNullOrEmpty(locationY))
            {
                return newLocationY;
            }

            if (!int.TryParse(locationY, out locationYToInt))
            {
                return newLocationY;
            }

            if (locationYToInt > Screen.PrimaryScreen.Bounds.Height - this.Size.Height || locationYToInt < 0)
            {
                return newLocationY;
            }

            return locationYToInt;
        }

        private string GET_SCALE(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                CREATE_DEFAULT_CONFIG(configFilePath);
            }

            XDocument xdoc;

            try
            {
                // 加载 XML 文档
                xdoc = XDocument.Load(configFilePath);
            }

            catch (XmlException)
            {
                // 如果加载失败，创建新的默认配置文件并返回默认值
                CREATE_DEFAULT_CONFIG(configFilePath);

                return "4";
            }

            var scaleNode = xdoc.Descendants("Scale").FirstOrDefault();

            var supportedScale = new HashSet<string>
            {
                "2",
                "3",
                "4"
            };

            if (scaleNode == null)
            {
                XElement newNode = new XElement("Scale", "4");

                xdoc.Root.Add(newNode);

                xdoc.Save(configFilePath);

                return "4";
            }

            var scale = scaleNode.Value;

            if (string.IsNullOrEmpty(scale))
            {
                return "4";
            }

            if (!supportedScale.Contains(scale))
            {
                return "4";
            }

            return scale;
        }

        private string GET_MODEL(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                CREATE_DEFAULT_CONFIG(configFilePath);
            }

            XDocument xdoc;

            try
            {
                // 加载 XML 文档
                xdoc = XDocument.Load(configFilePath);
            }

            catch (XmlException)
            {
                // 如果加载失败，创建新的默认配置文件并返回默认值
                CREATE_DEFAULT_CONFIG(configFilePath);

                return "realesrgan-x4plus";
            }

            var modelNode = xdoc.Descendants("Model").FirstOrDefault();

            var supportedModel = new HashSet<string>
            {
                "realesrgan-x4plus",
                "realesrgan-x4plus-anime",
                "realesr-animevideov3"
            };

            if (modelNode == null)
            {
                XElement newNode = new XElement("Model", "realesrgan-x4plus");

                xdoc.Root.Add(newNode);

                xdoc.Save(configFilePath);

                return "realesrgan-x4plus";
            }

            var model = modelNode.Value;

            if (string.IsNullOrEmpty(model))
            {
                return "realesrgan-x4plus";
            }

            if (!supportedModel.Contains(model))
            {
                return "realesrgan-x4plus";
            }

            return model;
        }

        private string GET_EXTENSION(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                CREATE_DEFAULT_CONFIG(configFilePath);
            }

            XDocument xdoc;

            try
            {
                // 加载 XML 文档
                xdoc = XDocument.Load(configFilePath);
            }

            catch (XmlException)
            {
                // 如果加载失败，创建新的默认配置文件并返回默认值
                CREATE_DEFAULT_CONFIG(configFilePath);

                return "png";
            }

            var extensionNode = xdoc.Descendants("Extension").FirstOrDefault();

            var supportedExtension = new HashSet<string>
            {
                "jpg",
                "png",
                "webp"
            };

            if (extensionNode == null)
            {
                XElement newNode = new XElement("Extension", "png");

                xdoc.Root.Add(newNode);

                xdoc.Save(configFilePath);

                return "png";
            }

            var extension = extensionNode.Value;

            if (string.IsNullOrEmpty(extension))
            {
                return "png";
            }

            if (!supportedExtension.Contains(extension))
            {
                return "png";
            }

            return extension;
        }

        private bool GET_PROCESS_HIDDEN(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                CREATE_DEFAULT_CONFIG(configFilePath);
            }

            XDocument xdoc;

            try
            {
                // 加载 XML 文档
                xdoc = XDocument.Load(configFilePath);
            }

            catch (XmlException)
            {
                // 如果加载失败，创建新的默认配置文件并返回默认值
                CREATE_DEFAULT_CONFIG(configFilePath);

                return false;
            }

            var processHiddenNode = xdoc.Descendants("ProcessHidden").FirstOrDefault();

            var supportedProcessHidden = new HashSet<string>
            {
                "True",
                "False"
            };


            if (processHiddenNode == null)
            {
                XElement newNode = new XElement("ProcessHidden", "false");

                xdoc.Root.Add(newNode);

                xdoc.Save(configFilePath);

                return false;
            }

            var processHidden = processHiddenNode.Value;
            bool processHiddenToBool;

            if (string.IsNullOrEmpty(processHidden))
            {
                return false;
            }

            if (!supportedProcessHidden.Contains(processHidden))
            {
                return false;
            }

            if (!bool.TryParse(processHidden, out processHiddenToBool))
            {
                return false;
            }

            return processHiddenToBool;
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
            if (!processHidden)
            {
                CheckBoxHideProcess.Checked = false;
            }

            else
            {
                CheckBoxHideProcess.Checked = true;
            }
        }

        private void NOTICE_CONFIG_SAVED()
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
        }

        private void ERROR_UNSUPPORTED_FILE()
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
        }

        private void ERROR_NO_PREMISSION(string directoryPath, Exception error)
        {
            var currentCulture = CultureInfo.CurrentUICulture;

            // 创建一个示例词典，包含支持的语言
            var supportedLanguages = new HashSet<string>
            {
                "zh-CN", // 中文 (简体)
                "zh-TW", // 中文 (繁体)
                "en-US", // 英语 (美国)
                // 其他语言...
            };

            if (supportedLanguages.Contains(currentCulture.Name))
            {
                currentLanguage = currentCulture.Name;

                switch (currentLanguage)
                {
                    case "zh-CN":
                        MessageBox.Show($"应用程序没有在{directoryPath}内运行的权限，错误为: {error.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "zh-TW":
                        MessageBox.Show($"應用程式沒有在{directoryPath}内運行的權限，錯誤為: {error.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "en-US":
                        MessageBox.Show($"Permission denied to run the application in {directoryPath},error message is: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }

            else
            {
                MessageBox.Show($"Permission denied to run the application in {directoryPath},error message is: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ERROR_REAL_ESRGAN_EXIST()
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

        private void ERROR_RESOURCE_EXIST(string resourceName)
        {
            switch (currentLanguage)
            {
                case "zh-CN":
                    MessageBox.Show("没有找到资源: " + resourceName, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "zh-TW":
                    MessageBox.Show("沒有找到資源: " + resourceName, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "en-US":
                    MessageBox.Show("Resource not found: " + resourceName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void ERROR_CREATE_FOLDER_FAILED(Exception error)
        {
            switch (currentLanguage)
            {
                case "zh-CN":
                    MessageBox.Show($"创建目标文件夹时出错，错误为: {error.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "zh-TW":
                    MessageBox.Show($"創建目標文件夾時出錯，錯誤為: {error.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "en-US":
                    MessageBox.Show($"The error occurred while creating the target folder,error message is: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void ERROR_EXCEPTION_MESSAGE(Exception error)
        {
            switch (currentLanguage)
            {
                case "zh-CN":
                    MessageBox.Show($"出现错误: {error.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "zh-TW":
                    MessageBox.Show($"出現錯誤: {error.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "en-US":
                    MessageBox.Show($"An error occurred: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void SAVE_CONFIG()
        {
            UPDATE_CONFIG($"{xmlPath}", "Language", $"{currentLanguage}");
            UPDATE_CONFIG($"{xmlPath}", "Scale", $"{scale}");
            UPDATE_CONFIG($"{xmlPath}", "Model", $"{model}");
            UPDATE_CONFIG($"{xmlPath}", "Extension", $"{extension}");
            UPDATE_CONFIG($"{xmlPath}", "ProcessHidden", $"{processHidden}");
        }

        private void SET_BUTTON_CONFIG_SIZE()
        {
            ButtonConfig.Size = new Size((int)(100.0f * systemScale), (int)(30.0f * systemScale));
        }

        private void SET_COMBOBOX_SIZE()
        {
            ComboBoxModel.Size = new Size((int)(242.0f * systemScale / 1.4), (int)(32.0f * systemScale / 1.4));
            ComboBoxScale.Size = new Size((int)(242.0f * systemScale / 1.4), (int)(32.0f * systemScale / 1.4));
            ComboBoxExtension.Size = new Size((int)(242.0f * systemScale / 1.4), (int)(32.0f * systemScale / 1.4));
        }

        private void SET_CLIENT_SIZE()
        {
            if (systemScale <= 1.5)
            {
                this.ClientSize = new Size((int)(15.0f * systemScale) * 2 + LabelModel.Width + ComboBoxModel.Width + (int)(15.0f * systemScale) * 2, (int)(15.0f * systemScale) * 2 + LabelModel.Width + ComboBoxModel.Width + (int)(15.0f * systemScale) * 2);
                this.MaximumSize = this.ClientSize;
                this.MinimumSize = this.MaximumSize;
            }

            else
            {
                this.ClientSize = new Size((int)(20.0f * systemScale) * 2 + LabelModel.Width + ComboBoxModel.Width + (int)(20.0f * systemScale) * 2, (int)(20.0f * systemScale) * 2 + LabelModel.Width + ComboBoxModel.Width + (int)(20.0f * systemScale) * 2);
                this.MaximumSize = this.ClientSize;
                this.MinimumSize = this.MaximumSize;
            }
        }

        private void SET_COMPONENT_POSITION()
        {
            if (currentLanguage=="en-US")
            {
                LabelModel.Location = new Point(MainPanel.Width / 2 - LabelModel.Width / 2 - ComboBoxModel.Width / 2 - (int)(20.0f * systemScale), MainPanel.Height / 2 - LabelModel.Height / 2);
                ComboBoxModel.Location = new Point(MainPanel.Width / 2 - ComboBoxModel.Width / 2 + LabelModel.Width / 2 + (int)(20.0f * systemScale), MainPanel.Height / 2 - ComboBoxModel.Height / 2);

                LabelScale.Location = new Point(MainPanel.Width / 2 - LabelModel.Width / 2 - ComboBoxModel.Width / 2 - (int)(20.0f * systemScale), MainPanel.Height / 2 - LabelModel.Height / 2 - this.Height / 6);
                ComboBoxScale.Location = new Point(MainPanel.Width / 2 - ComboBoxModel.Width / 2 + LabelModel.Width / 2 + (int)(20.0f * systemScale), MainPanel.Height / 2 - ComboBoxModel.Height / 2 - this.Height / 6);

                LabelExtension.Location = new Point(MainPanel.Width / 2 - LabelModel.Width / 2 - ComboBoxModel.Width / 2 - (int)(20.0f * systemScale), MainPanel.Height / 2 - LabelModel.Height / 2 + this.Height / 6);
                ComboBoxExtension.Location = new Point(MainPanel.Width / 2 - ComboBoxModel.Width / 2 + LabelModel.Width / 2 + (int)(20.0f * systemScale), MainPanel.Height / 2 - ComboBoxModel.Height / 2 + this.Height / 6);
            }

            else
            {
                LabelModel.Location = new Point(MainPanel.Width / 2 - LabelModel.Width / 2 - ComboBoxModel.Width / 2 - (int)(10.0f * systemScale), MainPanel.Height / 2 - LabelModel.Height / 2);
                ComboBoxModel.Location = new Point(MainPanel.Width / 2 - ComboBoxModel.Width / 2 + LabelModel.Width / 2 + (int)(10.0f * systemScale), MainPanel.Height / 2 - ComboBoxModel.Height / 2);

                LabelScale.Location = new Point(MainPanel.Width / 2 - LabelModel.Width / 2 - ComboBoxModel.Width / 2 - (int)(10.0f * systemScale), MainPanel.Height / 2 - LabelModel.Height / 2 - this.Height / 6);
                ComboBoxScale.Location = new Point(MainPanel.Width / 2 - ComboBoxModel.Width / 2 + LabelModel.Width / 2 + (int)(10.0f * systemScale), MainPanel.Height / 2 - ComboBoxModel.Height / 2 - this.Height / 6);

                LabelExtension.Location = new Point(MainPanel.Width / 2 - LabelModel.Width / 2 - ComboBoxModel.Width / 2 - (int)(10.0f * systemScale), MainPanel.Height / 2 - LabelModel.Height / 2 + this.Height / 6);
                ComboBoxExtension.Location = new Point(MainPanel.Width / 2 - ComboBoxModel.Width / 2 + LabelModel.Width / 2 + (int)(10.0f * systemScale), MainPanel.Height / 2 - ComboBoxModel.Height / 2 + this.Height / 6);
            }

            CheckBoxHideProcess.Location = new Point((int)(15.0f * systemScale), MainPanel.Height - CheckBoxHideProcess.Height - (int)(10.0f * systemScale));
            ButtonConfig.Location = new Point(MainPanel.Width - ButtonConfig.Width - (int)(10.0f * systemScale), MainPanel.Height - ButtonConfig.Height - (int)(10.0f * systemScale));
        }

        private void SET_MAINFORM_LOCATION()
        {
            if (oldScreenWidth == Screen.PrimaryScreen.Bounds.Width && oldScreenHeight == Screen.PrimaryScreen.Bounds.Height && oldSystemScale == systemScale)
            {
                locationX = GET_LOCATION_X(xmlPath);
                locationY = GET_LOCATION_Y(xmlPath);

                this.Location = new Point(locationX, locationY);
            }

            else
            {
                locationX = Screen.PrimaryScreen.Bounds.Width / 2 - this.Size.Width / 2;
                locationY = Screen.PrimaryScreen.Bounds.Height / 2 - this.Size.Height / 2;

                this.Location = new Point(locationX, locationY);
            }
        }

        private void MAINFORM_LOAD(object sender, EventArgs e)
        {
            SET_MAINFORM_LOCATION();
        }

        private void MAINFORM_RESIZE(object sender, EventArgs e)
        {
            SET_COMPONENT_POSITION();
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
                if (files.Length > 1)
                {
                    foreach (var simpleFilePath in files)
                    {
                        filePath = simpleFilePath;
                        fileName = Path.GetFileNameWithoutExtension(filePath);
                        directoryPath = Path.GetDirectoryName(filePath);

                        if (!CHECK_REAL_ESRGAN_EXIST())
                        {
                            CREATE_COMPONENTS();
                            if (!isCreatedNewFolder)
                            {
                                ERROR_REAL_ESRGAN_EXIST();
                                break;
                            }
                        }

                        await Task.Run(() => EXECUTE_COMMAND());
                    }
                }

                else
                {
                    filePath = files[0];
                    fileName = Path.GetFileNameWithoutExtension(filePath);
                    directoryPath = Path.GetDirectoryName(filePath);

                    if (!CHECK_REAL_ESRGAN_EXIST())
                    {
                        CREATE_COMPONENTS();
                        if (!isCreatedNewFolder)
                        {
                            ERROR_REAL_ESRGAN_EXIST();
                            return;
                        }
                    }

                    await Task.Run(() => EXECUTE_COMMAND());
                }
            }
        }

        private void MAINFORM_DRAGOVER(object sender, DragEventArgs e)
        {
            MAINFORM_DRAGENTER(sender, e); // 复用已有的逻辑
        }

        private void BUTTON_CONFIG_CLICK(object sender, EventArgs e)
        {
            NOTICE_CONFIG_SAVED();
            SAVE_CONFIG();
            SAVE_LOCATION();
        }

        private void CHECKBOX_HIDE_PROCESS_CHECKED_CHANGED(object sender, EventArgs e)
        {
            bool isProcessHidden = CheckBoxHideProcess.Checked;
            if (isProcessHidden)
            {
                processHidden = true;
            }

            else
            {
                processHidden = false;
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
                    CREATE_COMPONENTS();
                    if (!isCreatedNewFolder)
                    {
                        ERROR_REAL_ESRGAN_EXIST();
                        return;
                    }
                }

                await Task.Run(() => EXECUTE_COMMAND());
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

        private void MAINFORM_FORM_CLOSING(object sender,FormClosingEventArgs e)
        {
            SAVE_LOCATION();
        }

        private void SAVE_LOCATION()
        {
            locationX = this.Location.X;
            locationY = this.Location.Y;

            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;

            UPDATE_CONFIG($"{xmlPath}", "ScreenWidth", $"{width}");
            UPDATE_CONFIG($"{xmlPath}", "ScreenHeight", $"{height}");
            UPDATE_CONFIG($"{xmlPath}", "SystemScale", $"{systemScale}");
            UPDATE_CONFIG($"{xmlPath}", "LocationX", $"{locationX}");
            UPDATE_CONFIG($"{xmlPath}", "LocationY", $"{locationY}");
        }
    }
}
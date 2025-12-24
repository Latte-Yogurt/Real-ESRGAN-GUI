
namespace Real_ESRGAN_GUI
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ComboBoxExtension = new System.Windows.Forms.ComboBox();
            this.ComboBoxModel = new System.Windows.Forms.ComboBox();
            this.ComboBoxScale = new System.Windows.Forms.ComboBox();
            this.ButtonConfig = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.MainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuOpenFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageMenuSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageMenuSelectzhCN = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageMenuSelectzhTW = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageMenuSelectenUS = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.LabelScale = new System.Windows.Forms.Label();
            this.LabelModel = new System.Windows.Forms.Label();
            this.LabelExtension = new System.Windows.Forms.Label();
            this.CheckBoxHideProcess = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComboBoxExtension
            // 
            this.ComboBoxExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.SetColumnSpan(this.ComboBoxExtension, 4);
            this.ComboBoxExtension.Cursor = System.Windows.Forms.Cursors.Default;
            this.ComboBoxExtension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxExtension.FormattingEnabled = true;
            this.ComboBoxExtension.Location = new System.Drawing.Point(114, 297);
            this.ComboBoxExtension.Margin = new System.Windows.Forms.Padding(4);
            this.ComboBoxExtension.Name = "ComboBoxExtension";
            this.ComboBoxExtension.Size = new System.Drawing.Size(329, 32);
            this.ComboBoxExtension.TabIndex = 8;
            this.ComboBoxExtension.SelectedIndexChanged += new System.EventHandler(this.COMBOBOX_EXTENSION_SELECTED_INDEX_CHANGED);
            // 
            // ComboBoxModel
            // 
            this.ComboBoxModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.SetColumnSpan(this.ComboBoxModel, 4);
            this.ComboBoxModel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ComboBoxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxModel.FormattingEnabled = true;
            this.ComboBoxModel.Location = new System.Drawing.Point(114, 194);
            this.ComboBoxModel.Margin = new System.Windows.Forms.Padding(4);
            this.ComboBoxModel.Name = "ComboBoxModel";
            this.ComboBoxModel.Size = new System.Drawing.Size(329, 32);
            this.ComboBoxModel.TabIndex = 5;
            this.ComboBoxModel.SelectedIndexChanged += new System.EventHandler(this.COMBOBOX_MODEL_SELECTED_INDEX_CHANGED);
            // 
            // ComboBoxScale
            // 
            this.ComboBoxScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.SetColumnSpan(this.ComboBoxScale, 4);
            this.ComboBoxScale.Cursor = System.Windows.Forms.Cursors.Default;
            this.ComboBoxScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxScale.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComboBoxScale.FormattingEnabled = true;
            this.ComboBoxScale.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ComboBoxScale.Location = new System.Drawing.Point(114, 88);
            this.ComboBoxScale.Margin = new System.Windows.Forms.Padding(4);
            this.ComboBoxScale.Name = "ComboBoxScale";
            this.ComboBoxScale.Size = new System.Drawing.Size(329, 32);
            this.ComboBoxScale.TabIndex = 2;
            this.ComboBoxScale.SelectedIndexChanged += new System.EventHandler(this.COMBOBOX_SCALE_SELECTED_INDEX_CHANGNED);
            // 
            // ButtonConfig
            // 
            this.ButtonConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.SetColumnSpan(this.ButtonConfig, 4);
            this.ButtonConfig.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonConfig.Location = new System.Drawing.Point(303, 389);
            this.ButtonConfig.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonConfig.Name = "ButtonConfig";
            this.ButtonConfig.Size = new System.Drawing.Size(157, 44);
            this.ButtonConfig.TabIndex = 0;
            this.ButtonConfig.Text = "保存配置";
            this.ButtonConfig.UseVisualStyleBackColor = true;
            this.ButtonConfig.Click += new System.EventHandler(this.BUTTON_CONFIG_CLICK);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 8;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel.Controls.Add(this.MenuStrip, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.ComboBoxExtension, 2, 6);
            this.tableLayoutPanel.Controls.Add(this.ComboBoxScale, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.ComboBoxModel, 2, 4);
            this.tableLayoutPanel.Controls.Add(this.ButtonConfig, 3, 8);
            this.tableLayoutPanel.Controls.Add(this.LabelScale, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.LabelModel, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.LabelExtension, 1, 6);
            this.tableLayoutPanel.Controls.Add(this.CheckBoxHideProcess, 1, 8);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 10;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(478, 444);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tableLayoutPanel.SetColumnSpan(this.MenuStrip, 8);
            this.MenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuStrip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MenuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenu,
            this.LanguageMenu,
            this.AboutMenu});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.MenuStrip.Size = new System.Drawing.Size(478, 36);
            this.MenuStrip.TabIndex = 7;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.MainMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuOpenFiles,
            this.MainMenuExit});
            this.MainMenu.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(62, 28);
            this.MainMenu.Text = "文件";
            // 
            // MainMenuOpenFiles
            // 
            this.MainMenuOpenFiles.Name = "MainMenuOpenFiles";
            this.MainMenuOpenFiles.Size = new System.Drawing.Size(146, 34);
            this.MainMenuOpenFiles.Text = "打开";
            this.MainMenuOpenFiles.Click += new System.EventHandler(this.MAINMENU_OPENFILES_CLICK);
            // 
            // MainMenuExit
            // 
            this.MainMenuExit.Name = "MainMenuExit";
            this.MainMenuExit.Size = new System.Drawing.Size(146, 34);
            this.MainMenuExit.Text = "退出";
            this.MainMenuExit.Click += new System.EventHandler(this.MAINMENU_EXIT_CLICK);
            // 
            // LanguageMenu
            // 
            this.LanguageMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LanguageMenuSelect});
            this.LanguageMenu.Name = "LanguageMenu";
            this.LanguageMenu.Size = new System.Drawing.Size(62, 28);
            this.LanguageMenu.Text = "语言";
            // 
            // LanguageMenuSelect
            // 
            this.LanguageMenuSelect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LanguageMenuSelectzhCN,
            this.LanguageMenuSelectzhTW,
            this.LanguageMenuSelectenUS});
            this.LanguageMenuSelect.Name = "LanguageMenuSelect";
            this.LanguageMenuSelect.Size = new System.Drawing.Size(182, 34);
            this.LanguageMenuSelect.Text = "选择语言";
            // 
            // LanguageMenuSelectzhCN
            // 
            this.LanguageMenuSelectzhCN.Name = "LanguageMenuSelectzhCN";
            this.LanguageMenuSelectzhCN.Size = new System.Drawing.Size(182, 34);
            this.LanguageMenuSelectzhCN.Text = "简体中文";
            this.LanguageMenuSelectzhCN.Click += new System.EventHandler(this.LANGUAGE_MENU_SELECT_zhCN_CLICK);
            // 
            // LanguageMenuSelectzhTW
            // 
            this.LanguageMenuSelectzhTW.Name = "LanguageMenuSelectzhTW";
            this.LanguageMenuSelectzhTW.Size = new System.Drawing.Size(182, 34);
            this.LanguageMenuSelectzhTW.Text = "繁體中文";
            this.LanguageMenuSelectzhTW.Click += new System.EventHandler(this.LANGUAGE_MENU_SELECT_zhTW_CLICK);
            // 
            // LanguageMenuSelectenUS
            // 
            this.LanguageMenuSelectenUS.Name = "LanguageMenuSelectenUS";
            this.LanguageMenuSelectenUS.Size = new System.Drawing.Size(182, 34);
            this.LanguageMenuSelectenUS.Text = "English";
            this.LanguageMenuSelectenUS.Click += new System.EventHandler(this.LANGUAGE_MENU_SELECT_enUS_CLICK);
            // 
            // AboutMenu
            // 
            this.AboutMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutMenuAbout});
            this.AboutMenu.Name = "AboutMenu";
            this.AboutMenu.Size = new System.Drawing.Size(62, 28);
            this.AboutMenu.Text = "关于";
            // 
            // AboutMenuAbout
            // 
            this.AboutMenuAbout.Name = "AboutMenuAbout";
            this.AboutMenuAbout.Size = new System.Drawing.Size(261, 34);
            this.AboutMenuAbout.Text = "Real ESRGAN GUI";
            this.AboutMenuAbout.Click += new System.EventHandler(this.ABOUTMENU_ABOUT);
            // 
            // LabelScale
            // 
            this.LabelScale.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LabelScale.AutoSize = true;
            this.LabelScale.Location = new System.Drawing.Point(25, 92);
            this.LabelScale.Name = "LabelScale";
            this.LabelScale.Size = new System.Drawing.Size(82, 24);
            this.LabelScale.TabIndex = 9;
            this.LabelScale.Text = "放大倍数";
            // 
            // LabelModel
            // 
            this.LabelModel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LabelModel.AutoSize = true;
            this.LabelModel.Location = new System.Drawing.Point(25, 195);
            this.LabelModel.Name = "LabelModel";
            this.LabelModel.Size = new System.Drawing.Size(82, 24);
            this.LabelModel.TabIndex = 10;
            this.LabelModel.Text = "放大算法";
            // 
            // LabelExtension
            // 
            this.LabelExtension.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LabelExtension.AutoSize = true;
            this.LabelExtension.Location = new System.Drawing.Point(25, 298);
            this.LabelExtension.Name = "LabelExtension";
            this.LabelExtension.Size = new System.Drawing.Size(82, 24);
            this.LabelExtension.TabIndex = 11;
            this.LabelExtension.Text = "生成格式";
            // 
            // CheckBoxHideProcess
            // 
            this.CheckBoxHideProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckBoxHideProcess.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.CheckBoxHideProcess, 2);
            this.CheckBoxHideProcess.Location = new System.Drawing.Point(13, 406);
            this.CheckBoxHideProcess.Name = "CheckBoxHideProcess";
            this.CheckBoxHideProcess.Size = new System.Drawing.Size(108, 28);
            this.CheckBoxHideProcess.TabIndex = 12;
            this.CheckBoxHideProcess.Text = "后台运行";
            this.CheckBoxHideProcess.UseVisualStyleBackColor = true;
            this.CheckBoxHideProcess.CheckedChanged += new System.EventHandler(this.CHECKBOX_HIDE_PROCESS_CHECKED_CHANGED);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 444);
            this.Controls.Add(this.tableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "MainForm";
            this.Text = "Real ESRGAN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MAINFORM_FORM_CLOSING);
            this.Load += new System.EventHandler(this.MAINFORM_LOAD);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MAINFORM_DRAGDROP);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MAINFORM_DRAGENTER);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ButtonConfig;
        private System.Windows.Forms.ComboBox ComboBoxScale;
        private System.Windows.Forms.ComboBox ComboBoxModel;
        private System.Windows.Forms.ComboBox ComboBoxExtension;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MainMenu;
        private System.Windows.Forms.ToolStripMenuItem MainMenuOpenFiles;
        private System.Windows.Forms.ToolStripMenuItem MainMenuExit;
        private System.Windows.Forms.ToolStripMenuItem LanguageMenu;
        private System.Windows.Forms.ToolStripMenuItem LanguageMenuSelect;
        private System.Windows.Forms.ToolStripMenuItem LanguageMenuSelectzhCN;
        private System.Windows.Forms.ToolStripMenuItem LanguageMenuSelectzhTW;
        private System.Windows.Forms.ToolStripMenuItem LanguageMenuSelectenUS;
        private System.Windows.Forms.ToolStripMenuItem AboutMenu;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuAbout;
        private System.Windows.Forms.Label LabelScale;
        private System.Windows.Forms.Label LabelModel;
        private System.Windows.Forms.Label LabelExtension;
        private System.Windows.Forms.CheckBox CheckBoxHideProcess;
    }
}


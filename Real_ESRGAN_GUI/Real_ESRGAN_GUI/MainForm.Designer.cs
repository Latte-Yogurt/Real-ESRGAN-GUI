﻿
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ComboBoxExtension = new System.Windows.Forms.ComboBox();
            this.LabelExtension = new System.Windows.Forms.Label();
            this.ComboBoxModel = new System.Windows.Forms.ComboBox();
            this.LabelModel = new System.Windows.Forms.Label();
            this.LabelScale = new System.Windows.Forms.Label();
            this.ComboBoxScale = new System.Windows.Forms.ComboBox();
            this.CheckBoxHideProcess = new System.Windows.Forms.CheckBox();
            this.ButtonConfig = new System.Windows.Forms.Button();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuOpenFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.ComboBoxExtension);
            this.MainPanel.Controls.Add(this.LabelExtension);
            this.MainPanel.Controls.Add(this.ComboBoxModel);
            this.MainPanel.Controls.Add(this.LabelModel);
            this.MainPanel.Controls.Add(this.LabelScale);
            this.MainPanel.Controls.Add(this.ComboBoxScale);
            this.MainPanel.Controls.Add(this.CheckBoxHideProcess);
            this.MainPanel.Controls.Add(this.ButtonConfig);
            this.MainPanel.Controls.Add(this.MenuStrip1);
            this.MainPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(378, 344);
            this.MainPanel.TabIndex = 0;
            // 
            // ComboBoxExtension
            // 
            this.ComboBoxExtension.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ComboBoxExtension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxExtension.FormattingEnabled = true;
            this.ComboBoxExtension.Location = new System.Drawing.Point(121, 218);
            this.ComboBoxExtension.Margin = new System.Windows.Forms.Padding(4);
            this.ComboBoxExtension.Name = "ComboBoxExtension";
            this.ComboBoxExtension.Size = new System.Drawing.Size(242, 32);
            this.ComboBoxExtension.TabIndex = 8;
            this.ComboBoxExtension.SelectedIndexChanged += new System.EventHandler(this.COMBOBOX_EXTENSION_SELECTED_INDEX_CHANGED);
            // 
            // LabelExtension
            // 
            this.LabelExtension.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelExtension.AutoSize = true;
            this.LabelExtension.Location = new System.Drawing.Point(17, 222);
            this.LabelExtension.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelExtension.Name = "LabelExtension";
            this.LabelExtension.Size = new System.Drawing.Size(82, 24);
            this.LabelExtension.TabIndex = 7;
            this.LabelExtension.Text = "生成格式";
            // 
            // ComboBoxModel
            // 
            this.ComboBoxModel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ComboBoxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxModel.FormattingEnabled = true;
            this.ComboBoxModel.Location = new System.Drawing.Point(121, 148);
            this.ComboBoxModel.Margin = new System.Windows.Forms.Padding(4);
            this.ComboBoxModel.Name = "ComboBoxModel";
            this.ComboBoxModel.Size = new System.Drawing.Size(242, 32);
            this.ComboBoxModel.TabIndex = 5;
            this.ComboBoxModel.SelectedIndexChanged += new System.EventHandler(this.COMBOBOX_MODEL_SELECTED_INDEX_CHANGED);
            // 
            // LabelModel
            // 
            this.LabelModel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelModel.AutoSize = true;
            this.LabelModel.Location = new System.Drawing.Point(17, 152);
            this.LabelModel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelModel.Name = "LabelModel";
            this.LabelModel.Size = new System.Drawing.Size(82, 24);
            this.LabelModel.TabIndex = 4;
            this.LabelModel.Text = "放大算法";
            // 
            // LabelScale
            // 
            this.LabelScale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelScale.AutoSize = true;
            this.LabelScale.Location = new System.Drawing.Point(17, 80);
            this.LabelScale.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelScale.Name = "LabelScale";
            this.LabelScale.Size = new System.Drawing.Size(82, 24);
            this.LabelScale.TabIndex = 3;
            this.LabelScale.Text = "放大倍数";
            // 
            // ComboBoxScale
            // 
            this.ComboBoxScale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ComboBoxScale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ComboBoxScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxScale.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComboBoxScale.FormattingEnabled = true;
            this.ComboBoxScale.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ComboBoxScale.Location = new System.Drawing.Point(121, 76);
            this.ComboBoxScale.Margin = new System.Windows.Forms.Padding(4);
            this.ComboBoxScale.Name = "ComboBoxScale";
            this.ComboBoxScale.Size = new System.Drawing.Size(242, 32);
            this.ComboBoxScale.TabIndex = 2;
            this.ComboBoxScale.SelectedIndexChanged += new System.EventHandler(this.COMBOBOX_SCALE_SELECTED_INDEX_CHANGNED);
            // 
            // CheckBoxHideProcess
            // 
            this.CheckBoxHideProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckBoxHideProcess.AutoSize = true;
            this.CheckBoxHideProcess.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CheckBoxHideProcess.Location = new System.Drawing.Point(21, 295);
            this.CheckBoxHideProcess.Margin = new System.Windows.Forms.Padding(4);
            this.CheckBoxHideProcess.Name = "CheckBoxHideProcess";
            this.CheckBoxHideProcess.Size = new System.Drawing.Size(108, 28);
            this.CheckBoxHideProcess.TabIndex = 1;
            this.CheckBoxHideProcess.Text = "后台运行";
            this.CheckBoxHideProcess.UseVisualStyleBackColor = true;
            this.CheckBoxHideProcess.CheckedChanged += new System.EventHandler(this.CHECKBOX_HIDE_PROCESS_CHECKED_CHANGED);
            // 
            // ButtonConfig
            // 
            this.ButtonConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonConfig.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonConfig.Location = new System.Drawing.Point(241, 281);
            this.ButtonConfig.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonConfig.Name = "ButtonConfig";
            this.ButtonConfig.Size = new System.Drawing.Size(122, 47);
            this.ButtonConfig.TabIndex = 0;
            this.ButtonConfig.Text = "保存配置";
            this.ButtonConfig.UseVisualStyleBackColor = true;
            this.ButtonConfig.Click += new System.EventHandler(this.BUTTON_CONFIG_CLICK);
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.MenuStrip1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MenuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.MenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenu,
            this.AboutMenu});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.MenuStrip1.Size = new System.Drawing.Size(378, 36);
            this.MenuStrip1.TabIndex = 6;
            this.MenuStrip1.Text = "MenuStrip1";
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
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "Real ESRGAN";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NOTIFYICON_MOUSE_DOUBLE_CLICK);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 34);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(116, 30);
            this.ExitToolStripMenuItem.Text = "退出";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.EXIT_TOOLSTRIP_MENUITEM_CLICK);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 344);
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MainMenuStrip = this.MenuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 400);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "MainForm";
            this.Text = "Real ESRGAN";
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button ButtonConfig;
        private System.Windows.Forms.CheckBox CheckBoxHideProcess;
        private System.Windows.Forms.ComboBox ComboBoxScale;
        private System.Windows.Forms.Label LabelScale;
        private System.Windows.Forms.ComboBox ComboBoxModel;
        private System.Windows.Forms.Label LabelModel;
        private System.Windows.Forms.MenuStrip MenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MainMenu;
        private System.Windows.Forms.ToolStripMenuItem MainMenuOpenFiles;
        private System.Windows.Forms.ToolStripMenuItem MainMenuExit;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.ComboBox ComboBoxExtension;
        private System.Windows.Forms.Label LabelExtension;
        private System.Windows.Forms.ToolStripMenuItem AboutMenu;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuAbout;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
    }
}

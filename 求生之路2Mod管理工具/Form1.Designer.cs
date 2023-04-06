namespace 求生之路2Mod管理工具
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.GetSteamState = new System.Windows.Forms.Timer(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this._log = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.enableModsList = new System.Windows.Forms.ListBox();
            this.disableModsList = new System.Windows.Forms.ListBox();
            this.btn_disable = new System.Windows.Forms.Button();
            this.btn_enable = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openAddons = new System.Windows.Forms.Button();
            this.startGame = new System.Windows.Forms.Button();
            this.closeGame = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Cover = new System.Windows.Forms.Button();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GetSteamState
            // 
            this.GetSteamState.Enabled = true;
            this.GetSteamState.Interval = 250;
            this.GetSteamState.Tick += new System.EventHandler(this.GetSteamState_Tick);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this._log);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(653, 424);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "日志";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // _log
            // 
            this._log.Dock = System.Windows.Forms.DockStyle.Fill;
            this._log.Location = new System.Drawing.Point(3, 3);
            this._log.Multiline = true;
            this._log.Name = "_log";
            this._log.ReadOnly = true;
            this._log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._log.Size = new System.Drawing.Size(647, 418);
            this._log.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Cover);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(653, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "创意工坊MOD转本地";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.closeGame);
            this.tabPage1.Controls.Add(this.startGame);
            this.tabPage1.Controls.Add(this.openAddons);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btn_refresh);
            this.tabPage1.Controls.Add(this.btn_delete);
            this.tabPage1.Controls.Add(this.btn_enable);
            this.tabPage1.Controls.Add(this.btn_disable);
            this.tabPage1.Controls.Add(this.disableModsList);
            this.tabPage1.Controls.Add(this.enableModsList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(653, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "本地MOD管理";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // enableModsList
            // 
            this.enableModsList.AllowDrop = true;
            this.enableModsList.Dock = System.Windows.Forms.DockStyle.Left;
            this.enableModsList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.enableModsList.FormattingEnabled = true;
            this.enableModsList.ItemHeight = 12;
            this.enableModsList.Location = new System.Drawing.Point(3, 3);
            this.enableModsList.Name = "enableModsList";
            this.enableModsList.Size = new System.Drawing.Size(269, 418);
            this.enableModsList.TabIndex = 1;
            this.enableModsList.Click += new System.EventHandler(this.enableModsList_Click);
            this.enableModsList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.enableModsList_DrawItem);
            this.enableModsList.DragDrop += new System.Windows.Forms.DragEventHandler(this.enableModsList_DragDrop);
            this.enableModsList.DragEnter += new System.Windows.Forms.DragEventHandler(this.enableModsList_DragEnter);
            this.enableModsList.DoubleClick += new System.EventHandler(this.enableModsList_DoubleClick);
            // 
            // disableModsList
            // 
            this.disableModsList.AllowDrop = true;
            this.disableModsList.Dock = System.Windows.Forms.DockStyle.Right;
            this.disableModsList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.disableModsList.FormattingEnabled = true;
            this.disableModsList.ItemHeight = 12;
            this.disableModsList.Location = new System.Drawing.Point(381, 3);
            this.disableModsList.Name = "disableModsList";
            this.disableModsList.Size = new System.Drawing.Size(269, 418);
            this.disableModsList.TabIndex = 2;
            this.disableModsList.Click += new System.EventHandler(this.disableModsList_Click);
            this.disableModsList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.disableModsList_DrawItem);
            this.disableModsList.DragDrop += new System.Windows.Forms.DragEventHandler(this.disableModsList_DragDrop);
            this.disableModsList.DragEnter += new System.Windows.Forms.DragEventHandler(this.enableModsList_DragEnter);
            this.disableModsList.DoubleClick += new System.EventHandler(this.disableModsList_DoubleClick);
            // 
            // btn_disable
            // 
            this.btn_disable.Location = new System.Drawing.Point(278, 128);
            this.btn_disable.Name = "btn_disable";
            this.btn_disable.Size = new System.Drawing.Size(97, 23);
            this.btn_disable.TabIndex = 3;
            this.btn_disable.Text = "禁用 →";
            this.btn_disable.UseVisualStyleBackColor = true;
            this.btn_disable.Click += new System.EventHandler(this.btn_disable_Click);
            // 
            // btn_enable
            // 
            this.btn_enable.Location = new System.Drawing.Point(279, 158);
            this.btn_enable.Name = "btn_enable";
            this.btn_enable.Size = new System.Drawing.Size(96, 23);
            this.btn_enable.TabIndex = 4;
            this.btn_enable.Text = "← 启用";
            this.btn_enable.UseVisualStyleBackColor = true;
            this.btn_enable.Click += new System.EventHandler(this.btn_enable_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(278, 230);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(96, 23);
            this.btn_delete.TabIndex = 4;
            this.btn_delete.Text = "× 删除";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(278, 201);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(96, 23);
            this.btn_refresh.TabIndex = 5;
            this.btn_refresh.Text = "⭕ 刷新";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(293, 377);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 42);
            this.label1.TabIndex = 6;
            this.label1.Text = "[C]: 人物\r\n[W]: 武器\r\n[S]: 特感";
            // 
            // openAddons
            // 
            this.openAddons.Location = new System.Drawing.Point(277, 64);
            this.openAddons.Name = "openAddons";
            this.openAddons.Size = new System.Drawing.Size(97, 23);
            this.openAddons.TabIndex = 7;
            this.openAddons.Text = "打开Addons";
            this.openAddons.UseVisualStyleBackColor = true;
            this.openAddons.Click += new System.EventHandler(this.openAddons_Click);
            // 
            // startGame
            // 
            this.startGame.Location = new System.Drawing.Point(277, 6);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(97, 23);
            this.startGame.TabIndex = 7;
            this.startGame.Text = "启动游戏";
            this.startGame.UseVisualStyleBackColor = true;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // closeGame
            // 
            this.closeGame.Location = new System.Drawing.Point(277, 35);
            this.closeGame.Name = "closeGame";
            this.closeGame.Size = new System.Drawing.Size(97, 23);
            this.closeGame.TabIndex = 7;
            this.closeGame.Text = "关闭游戏";
            this.closeGame.UseVisualStyleBackColor = true;
            this.closeGame.Click += new System.EventHandler(this.closeGame_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(661, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // Cover
            // 
            this.Cover.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Cover.Location = new System.Drawing.Point(242, 148);
            this.Cover.Name = "Cover";
            this.Cover.Size = new System.Drawing.Size(166, 102);
            this.Cover.TabIndex = 0;
            this.Cover.Text = "转换";
            this.Cover.UseVisualStyleBackColor = true;
            this.Cover.Click += new System.EventHandler(this.Cover_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 450);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "求生之路2本地Mod管理工具 --> Steam未启动";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer GetSteamState;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox _log;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button closeGame;
        private System.Windows.Forms.Button startGame;
        private System.Windows.Forms.Button openAddons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_enable;
        private System.Windows.Forms.Button btn_disable;
        private System.Windows.Forms.ListBox disableModsList;
        private System.Windows.Forms.ListBox enableModsList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button Cover;
    }
}


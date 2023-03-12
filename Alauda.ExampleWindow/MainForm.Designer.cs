namespace Alauda.ExampleWindow
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.mainFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalLabel = new System.Windows.Forms.Label();
            this.normalText = new System.Windows.Forms.TextBox();
            this.exampleLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.clearMessageButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.decideButton = new System.Windows.Forms.Button();
            this.exampleCheck = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.mainMenuStrip.SuspendLayout();
            this.exampleLayoutPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainFileMenu});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // mainFileMenu
            // 
            this.mainFileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileExitMenuItem});
            this.mainFileMenu.Name = "mainFileMenu";
            this.mainFileMenu.Size = new System.Drawing.Size(67, 20);
            this.mainFileMenu.Text = "ファイル(&F)";
            // 
            // fileExitMenuItem
            // 
            this.fileExitMenuItem.Name = "fileExitMenuItem";
            this.fileExitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.fileExitMenuItem.Size = new System.Drawing.Size(153, 22);
            this.fileExitMenuItem.Text = "終了(&X)";
            this.fileExitMenuItem.Click += new System.EventHandler(this.OnExitMenuClick);
            // 
            // normalLabel
            // 
            this.normalLabel.AutoSize = true;
            this.normalLabel.Location = new System.Drawing.Point(12, 36);
            this.normalLabel.Name = "normalLabel";
            this.normalLabel.Size = new System.Drawing.Size(86, 18);
            this.normalLabel.TabIndex = 1;
            this.normalLabel.Text = "Normal &Label";
            // 
            // normalText
            // 
            this.normalText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.normalText.Location = new System.Drawing.Point(104, 33);
            this.normalText.Name = "normalText";
            this.normalText.Size = new System.Drawing.Size(684, 25);
            this.normalText.TabIndex = 2;
            this.normalText.TextChanged += new System.EventHandler(this.OnCommonTextChanged);
            // 
            // exampleLayoutPanel
            // 
            this.exampleLayoutPanel.ColumnCount = 2;
            this.exampleLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.28572F));
            this.exampleLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.71428F));
            this.exampleLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.exampleLayoutPanel.Controls.Add(this.textBox1, 1, 0);
            this.exampleLayoutPanel.Controls.Add(this.label2, 0, 1);
            this.exampleLayoutPanel.Controls.Add(this.comboBox1, 1, 1);
            this.exampleLayoutPanel.Controls.Add(this.button1, 1, 2);
            this.exampleLayoutPanel.Controls.Add(this.button2, 1, 3);
            this.exampleLayoutPanel.Location = new System.Drawing.Point(15, 64);
            this.exampleLayoutPanel.Name = "exampleLayoutPanel";
            this.exampleLayoutPanel.RowCount = 4;
            this.exampleLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.exampleLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.exampleLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.exampleLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.exampleLayoutPanel.Size = new System.Drawing.Size(350, 128);
            this.exampleLayoutPanel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(81, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(266, 25);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.OnCommonTextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "#0",
            "#1",
            "#2",
            "#3",
            "#4",
            "#5",
            "#6",
            "#7",
            "#8",
            "#9"});
            this.comboBox1.Location = new System.Drawing.Point(81, 35);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(266, 26);
            this.comboBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(81, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(266, 26);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(81, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(266, 26);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // clearMessageButton
            // 
            this.clearMessageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearMessageButton.Location = new System.Drawing.Point(12, 397);
            this.clearMessageButton.Name = "clearMessageButton";
            this.clearMessageButton.Size = new System.Drawing.Size(100, 28);
            this.clearMessageButton.TabIndex = 4;
            this.clearMessageButton.TabStop = false;
            this.clearMessageButton.Text = "&Clear";
            this.clearMessageButton.UseVisualStyleBackColor = true;
            this.clearMessageButton.Click += new System.EventHandler(this.OnClearMessageClick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.ForeColor = System.Drawing.Color.Blue;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(28, 17);
            this.statusLabel.Text = "###";
            // 
            // decideButton
            // 
            this.decideButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.decideButton.Location = new System.Drawing.Point(688, 397);
            this.decideButton.Name = "decideButton";
            this.decideButton.Size = new System.Drawing.Size(100, 28);
            this.decideButton.TabIndex = 5;
            this.decideButton.Text = "&OK";
            this.decideButton.UseVisualStyleBackColor = true;
            this.decideButton.Click += new System.EventHandler(this.OnApplyClick);
            // 
            // exampleCheck
            // 
            this.exampleCheck.AutoSize = true;
            this.exampleCheck.Location = new System.Drawing.Point(371, 64);
            this.exampleCheck.Name = "exampleCheck";
            this.exampleCheck.Size = new System.Drawing.Size(116, 22);
            this.exampleCheck.TabIndex = 9;
            this.exampleCheck.Text = "&Example Check";
            this.exampleCheck.UseVisualStyleBackColor = true;
            this.exampleCheck.CheckedChanged += new System.EventHandler(this.OnExampleCheckCheckedChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "#0",
            "#1",
            "#2",
            "#3",
            "#4",
            "#5",
            "#6",
            "#7",
            "#8",
            "#9"});
            this.comboBox2.Location = new System.Drawing.Point(96, 198);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(269, 26);
            this.comboBox2.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.exampleCheck);
            this.Controls.Add(this.decideButton);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.clearMessageButton);
            this.Controls.Add(this.exampleLayoutPanel);
            this.Controls.Add(this.normalText);
            this.Controls.Add(this.normalLabel);
            this.Controls.Add(this.mainMenuStrip);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Alauda Example Window";
            this.Load += new System.EventHandler(this.OnLoad);
            this.Shown += new System.EventHandler(this.OnShown);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.exampleLayoutPanel.ResumeLayout(false);
            this.exampleLayoutPanel.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mainFileMenu;
        private System.Windows.Forms.ToolStripMenuItem fileExitMenuItem;
        private System.Windows.Forms.Label normalLabel;
        private System.Windows.Forms.TextBox normalText;
        private System.Windows.Forms.TableLayoutPanel exampleLayoutPanel;
        private System.Windows.Forms.Button clearMessageButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Button decideButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox exampleCheck;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}


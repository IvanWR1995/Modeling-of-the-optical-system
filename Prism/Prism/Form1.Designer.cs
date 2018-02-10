namespace Prism
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.объектыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MirrorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrismToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LightSource = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolPanel = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.PrismDialogTool = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.About = new System.Windows.Forms.ToolStripButton();
            this.StatusPanel = new System.Windows.Forms.StatusStrip();
            this.Status_X = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusCoord_X = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusCoord_Y = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusNameObject = new System.Windows.Forms.ToolStripStatusLabel();
            this.NameLableObj = new System.Windows.Forms.Label();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.Menu.SuspendLayout();
            this.ToolPanel.SuspendLayout();
            this.StatusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.объектыToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(1364, 24);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Save,
            this.Open,
            this.Exit,
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.toolStripMenuItem1.Text = "Файл";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(152, 22);
            this.Save.Text = "Сохранить";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Open
            // 
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(152, 22);
            this.Open.Text = "Открыть";
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(152, 22);
            this.Exit.Text = "Выйти";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // объектыToolStripMenuItem
            // 
            this.объектыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MirrorMenuItem,
            this.PrismToolStripMenuItem,
            this.LightSource});
            this.объектыToolStripMenuItem.Name = "объектыToolStripMenuItem";
            this.объектыToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.объектыToolStripMenuItem.Text = "Объекты";
            // 
            // MirrorMenuItem
            // 
            this.MirrorMenuItem.Name = "MirrorMenuItem";
            this.MirrorMenuItem.Size = new System.Drawing.Size(128, 22);
            this.MirrorMenuItem.Text = "Зеркала";
            this.MirrorMenuItem.Click += new System.EventHandler(this.MirrorMenuItem_Click);
            // 
            // PrismToolStripMenuItem
            // 
            this.PrismToolStripMenuItem.Name = "PrismToolStripMenuItem";
            this.PrismToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.PrismToolStripMenuItem.Text = "Призмы";
            this.PrismToolStripMenuItem.Click += new System.EventHandler(this.PrismToolStripMenuItem_Click);
            // 
            // LightSource
            // 
            this.LightSource.Name = "LightSource";
            this.LightSource.Size = new System.Drawing.Size(128, 22);
            this.LightSource.Text = "Источник";
            this.LightSource.Click += new System.EventHandler(this.LightSource_Click);
            // 
            // ToolPanel
            // 
            this.ToolPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ToolPanel.GripMargin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.ToolPanel.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.PrismDialogTool,
            this.toolStripButton4,
            this.toolStripButton5,
            this.About});
            this.ToolPanel.Location = new System.Drawing.Point(0, 24);
            this.ToolPanel.MaximumSize = new System.Drawing.Size(0, 30);
            this.ToolPanel.Name = "ToolPanel";
            this.ToolPanel.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.ToolPanel.Size = new System.Drawing.Size(1364, 27);
            this.ToolPanel.TabIndex = 1;
            this.ToolPanel.Text = "Панель управления";
            this.ToolPanel.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 26);
            this.toolStripButton1.Text = "Сохранить файл";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Margin = new System.Windows.Forms.Padding(5, 1, 0, 0);
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 26);
            this.toolStripButton2.Text = "Открыть файл";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // PrismDialogTool
            // 
            this.PrismDialogTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PrismDialogTool.Image = ((System.Drawing.Image)(resources.GetObject("PrismDialogTool.Image")));
            this.PrismDialogTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PrismDialogTool.Margin = new System.Windows.Forms.Padding(5, 1, 0, 0);
            this.PrismDialogTool.Name = "PrismDialogTool";
            this.PrismDialogTool.Size = new System.Drawing.Size(24, 26);
            this.PrismDialogTool.Text = "Призма";
            this.PrismDialogTool.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Margin = new System.Windows.Forms.Padding(5, 1, 0, 0);
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(24, 26);
            this.toolStripButton4.Text = "Источник";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Margin = new System.Windows.Forms.Padding(5, 1, 0, 0);
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(24, 26);
            this.toolStripButton5.Text = " Зеркало";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // About
            // 
            this.About.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.About.Image = ((System.Drawing.Image)(resources.GetObject("About.Image")));
            this.About.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(24, 24);
            this.About.Text = "About";
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // StatusPanel
            // 
            this.StatusPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.StatusPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status_X,
            this.StatusCoord_X,
            this.toolStripStatusLabel3,
            this.StatusCoord_Y,
            this.toolStripStatusLabel1,
            this.StatusNameObject});
            this.StatusPanel.Location = new System.Drawing.Point(0, 685);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.Size = new System.Drawing.Size(1364, 22);
            this.StatusPanel.TabIndex = 2;
            this.StatusPanel.Text = "StatusPanel";
            this.StatusPanel.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // Status_X
            // 
            this.Status_X.Name = "Status_X";
            this.Status_X.Size = new System.Drawing.Size(22, 17);
            this.Status_X.Text = "X=";
            // 
            // StatusCoord_X
            // 
            this.StatusCoord_X.Name = "StatusCoord_X";
            this.StatusCoord_X.Size = new System.Drawing.Size(13, 17);
            this.StatusCoord_X.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(22, 17);
            this.toolStripStatusLabel3.Text = "Y=";
            this.toolStripStatusLabel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStripStatusLabel3_MouseMove);
            // 
            // StatusCoord_Y
            // 
            this.StatusCoord_Y.Name = "StatusCoord_Y";
            this.StatusCoord_Y.Size = new System.Drawing.Size(13, 17);
            this.StatusCoord_Y.Text = "0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // StatusNameObject
            // 
            this.StatusNameObject.Name = "StatusNameObject";
            this.StatusNameObject.Size = new System.Drawing.Size(13, 17);
            this.StatusNameObject.Text = "0";
            // 
            // NameLableObj
            // 
            this.NameLableObj.AutoSize = true;
            this.NameLableObj.Location = new System.Drawing.Point(244, 121);
            this.NameLableObj.Name = "NameLableObj";
            this.NameLableObj.Size = new System.Drawing.Size(13, 13);
            this.NameLableObj.TabIndex = 3;
            this.NameLableObj.Text = "0";
            this.NameLableObj.Visible = false;
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1364, 707);
            this.Controls.Add(this.NameLableObj);
            this.Controls.Add(this.StatusPanel);
            this.Controls.Add(this.ToolPanel);
            this.Controls.Add(this.Menu);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Лабораторная работа :Призма";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnUpMouse);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ToolPanel.ResumeLayout(false);
            this.ToolPanel.PerformLayout();
            this.StatusPanel.ResumeLayout(false);
            this.StatusPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStrip ToolPanel;
        private System.Windows.Forms.StatusStrip StatusPanel;
        private System.Windows.Forms.ToolStripStatusLabel Status_X;
        private System.Windows.Forms.ToolStripStatusLabel StatusCoord_X;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem объектыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MirrorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrismToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LightSource;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel StatusCoord_Y;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel StatusNameObject;
        private System.Windows.Forms.Label NameLableObj;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.ToolStripMenuItem Open;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton PrismDialogTool;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.SaveFileDialog SaveFile;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton About;
    }
}


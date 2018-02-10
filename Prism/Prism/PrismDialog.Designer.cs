namespace Prism
{
    partial class PrismDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RedText = new System.Windows.Forms.TextBox();
            this.GreenText = new System.Windows.Forms.TextBox();
            this.BlueText = new System.Windows.Forms.TextBox();
            this.ListPrism = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NamberDots = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TextCoord = new System.Windows.Forms.TextBox();
            this.LableCoord = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Коэффициенты приломления для RGB:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Red";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Green";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Blue";
            // 
            // RedText
            // 
            this.RedText.Location = new System.Drawing.Point(12, 67);
            this.RedText.Name = "RedText";
            this.RedText.Size = new System.Drawing.Size(46, 20);
            this.RedText.TabIndex = 4;
            // 
            // GreenText
            // 
            this.GreenText.Location = new System.Drawing.Point(93, 67);
            this.GreenText.Name = "GreenText";
            this.GreenText.Size = new System.Drawing.Size(46, 20);
            this.GreenText.TabIndex = 5;
            // 
            // BlueText
            // 
            this.BlueText.Location = new System.Drawing.Point(183, 67);
            this.BlueText.Name = "BlueText";
            this.BlueText.Size = new System.Drawing.Size(46, 20);
            this.BlueText.TabIndex = 6;
            // 
            // ListPrism
            // 
            this.ListPrism.FormattingEnabled = true;
            this.ListPrism.Location = new System.Drawing.Point(12, 113);
            this.ListPrism.Name = "ListPrism";
            this.ListPrism.Size = new System.Drawing.Size(217, 199);
            this.ListPrism.TabIndex = 7;
            this.ListPrism.SelectedIndexChanged += new System.EventHandler(this.ListPrism_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Количство вершин призмы:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // NamberDots
            // 
            this.NamberDots.Location = new System.Drawing.Point(246, 40);
            this.NamberDots.Name = "NamberDots";
            this.NamberDots.Size = new System.Drawing.Size(54, 20);
            this.NamberDots.TabIndex = 9;
            this.NamberDots.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Создать по умолчанию";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(246, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Ввести координаты";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TextCoord
            // 
            this.TextCoord.Location = new System.Drawing.Point(251, 158);
            this.TextCoord.Name = "TextCoord";
            this.TextCoord.Size = new System.Drawing.Size(165, 20);
            this.TextCoord.TabIndex = 13;
            // 
            // LableCoord
            // 
            this.LableCoord.AutoSize = true;
            this.LableCoord.Location = new System.Drawing.Point(248, 142);
            this.LableCoord.Name = "LableCoord";
            this.LableCoord.Size = new System.Drawing.Size(113, 13);
            this.LableCoord.TabIndex = 14;
            this.LableCoord.Text = "Координаты вершин:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(246, 208);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 38);
            this.button3.TabIndex = 15;
            this.button3.Text = "Применить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(327, 208);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 38);
            this.button4.TabIndex = 16;
            this.button4.Text = "Отменить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(246, 252);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 43);
            this.button5.TabIndex = 17;
            this.button5.Text = "Удалить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(327, 252);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 43);
            this.button6.TabIndex = 18;
            this.button6.Text = "Изменить";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Список призм:";
            // 
            // PrismDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 334);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.LableCoord);
            this.Controls.Add(this.TextCoord);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NamberDots);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ListPrism);
            this.Controls.Add(this.BlueText);
            this.Controls.Add(this.GreenText);
            this.Controls.Add(this.RedText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(1111, 372);
            this.MinimumSize = new System.Drawing.Size(1111, 372);
            this.Name = "PrismDialog";
            this.Text = "Диалог создания  призм";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PrismDialog_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PrismDialog_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PrismDialog_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PrismDialog_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox RedText;
        private System.Windows.Forms.TextBox GreenText;
        private System.Windows.Forms.TextBox BlueText;
        private System.Windows.Forms.ListBox ListPrism;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NamberDots;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TextCoord;
        private System.Windows.Forms.Label LableCoord;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label6;
    }
}
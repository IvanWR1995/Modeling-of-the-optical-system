namespace Prism
{
    partial class PrismPreviewDialog
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
            this.label5 = new System.Windows.Forms.Label();
            this.LabelNamePrism = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.TextCoord = new System.Windows.Forms.TextBox();
            this.LabelCountVert = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Коэффициенты приломления для RGB:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Red";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Green";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Blue";
            // 
            // RedText
            // 
            this.RedText.Location = new System.Drawing.Point(15, 72);
            this.RedText.Name = "RedText";
            this.RedText.Size = new System.Drawing.Size(44, 20);
            this.RedText.TabIndex = 4;
            // 
            // GreenText
            // 
            this.GreenText.Location = new System.Drawing.Point(97, 72);
            this.GreenText.Name = "GreenText";
            this.GreenText.Size = new System.Drawing.Size(49, 20);
            this.GreenText.TabIndex = 5;
            // 
            // BlueText
            // 
            this.BlueText.Location = new System.Drawing.Point(186, 71);
            this.BlueText.Name = "BlueText";
            this.BlueText.Size = new System.Drawing.Size(46, 20);
            this.BlueText.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Имя призмы:";
            // 
            // LabelNamePrism
            // 
            this.LabelNamePrism.AutoSize = true;
            this.LabelNamePrism.Location = new System.Drawing.Point(12, 138);
            this.LabelNamePrism.Name = "LabelNamePrism";
            this.LabelNamePrism.Size = new System.Drawing.Size(13, 13);
            this.LabelNamePrism.TabIndex = 8;
            this.LabelNamePrism.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Количество вершин призмы:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(254, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 39);
            this.button1.TabIndex = 11;
            this.button1.Text = "Применить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(254, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 39);
            this.button2.TabIndex = 12;
            this.button2.Text = "Отменить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(254, 192);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 38);
            this.button3.TabIndex = 13;
            this.button3.Text = "Удалить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Координаты вершин призмы:";
            // 
            // TextCoord
            // 
            this.TextCoord.Location = new System.Drawing.Point(15, 277);
            this.TextCoord.Name = "TextCoord";
            this.TextCoord.Size = new System.Drawing.Size(383, 20);
            this.TextCoord.TabIndex = 15;
            // 
            // LabelCountVert
            // 
            this.LabelCountVert.AutoSize = true;
            this.LabelCountVert.Location = new System.Drawing.Point(12, 217);
            this.LabelCountVert.Name = "LabelCountVert";
            this.LabelCountVert.Size = new System.Drawing.Size(13, 13);
            this.LabelCountVert.TabIndex = 16;
            this.LabelCountVert.Text = "0";
            this.LabelCountVert.Paint += new System.Windows.Forms.PaintEventHandler(this.LabelCountVert_Paint);
            // 
            // PrismPreviewDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 334);
            this.Controls.Add(this.LabelCountVert);
            this.Controls.Add(this.TextCoord);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LabelNamePrism);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BlueText);
            this.Controls.Add(this.GreenText);
            this.Controls.Add(this.RedText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(1111, 372);
            this.MinimumSize = new System.Drawing.Size(1111, 372);
            this.Name = "PrismPreviewDialog";
            this.Text = "Диалог изменения/удаления призмы";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PrismPreviewDialog_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PrismPreviewDialog_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PrismPreviewDialog_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PrismPreviewDialog_MouseUp);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LabelNamePrism;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TextCoord;
        private System.Windows.Forms.Label LabelCountVert;
    }
}
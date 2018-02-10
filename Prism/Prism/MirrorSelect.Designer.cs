namespace Prism
{
    partial class MirrorSelect
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
            this.NameMirrorLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Change = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.BeginMirror_X = new System.Windows.Forms.TextBox();
            this.BeginMirror_Y = new System.Windows.Forms.TextBox();
            this.EndMirror_X = new System.Windows.Forms.TextBox();
            this.EndMirror_Y = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // NameMirrorLabel
            // 
            this.NameMirrorLabel.AutoSize = true;
            this.NameMirrorLabel.Location = new System.Drawing.Point(12, 25);
            this.NameMirrorLabel.Name = "NameMirrorLabel";
            this.NameMirrorLabel.Size = new System.Drawing.Size(13, 13);
            this.NameMirrorLabel.TabIndex = 0;
            this.NameMirrorLabel.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Координаты начала зеркала";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "X=";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Y=";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Координаты конца зеркала";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(169, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "X=";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(254, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Y=";
            // 
            // Change
            // 
            this.Change.Location = new System.Drawing.Point(143, 150);
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(75, 23);
            this.Change.TabIndex = 11;
            this.Change.Text = "Изменить";
            this.Change.UseVisualStyleBackColor = true;
            this.Change.Click += new System.EventHandler(this.Change_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(257, 150);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 12;
            this.Delete.Text = "Удалить";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(15, 150);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 13;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            this.Cancel.Paint += new System.Windows.Forms.PaintEventHandler(this.Cancel_Paint);
            // 
            // BeginMirror_X
            // 
            this.BeginMirror_X.Location = new System.Drawing.Point(195, 47);
            this.BeginMirror_X.Name = "BeginMirror_X";
            this.BeginMirror_X.Size = new System.Drawing.Size(37, 20);
            this.BeginMirror_X.TabIndex = 14;
            // 
            // BeginMirror_Y
            // 
            this.BeginMirror_Y.Location = new System.Drawing.Point(280, 47);
            this.BeginMirror_Y.Name = "BeginMirror_Y";
            this.BeginMirror_Y.Size = new System.Drawing.Size(36, 20);
            this.BeginMirror_Y.TabIndex = 15;
            this.BeginMirror_Y.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // EndMirror_X
            // 
            this.EndMirror_X.Location = new System.Drawing.Point(195, 102);
            this.EndMirror_X.Name = "EndMirror_X";
            this.EndMirror_X.Size = new System.Drawing.Size(37, 20);
            this.EndMirror_X.TabIndex = 16;
            // 
            // EndMirror_Y
            // 
            this.EndMirror_Y.Location = new System.Drawing.Point(280, 99);
            this.EndMirror_Y.Name = "EndMirror_Y";
            this.EndMirror_Y.Size = new System.Drawing.Size(36, 20);
            this.EndMirror_Y.TabIndex = 17;
            // 
            // MirrorSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 200);
            this.Controls.Add(this.EndMirror_Y);
            this.Controls.Add(this.EndMirror_X);
            this.Controls.Add(this.BeginMirror_Y);
            this.Controls.Add(this.BeginMirror_X);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Change);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameMirrorLabel);
            this.Name = "MirrorSelect";
            this.Text = "Диалог изменения/удаления зеркала";
            this.Load += new System.EventHandler(this.MirrorSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameMirrorLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Change;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.TextBox BeginMirror_X;
        private System.Windows.Forms.TextBox BeginMirror_Y;
        private System.Windows.Forms.TextBox EndMirror_X;
        private System.Windows.Forms.TextBox EndMirror_Y;
    }
}
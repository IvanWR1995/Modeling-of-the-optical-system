using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace Prism
{
    public partial class PrismDialog : Form
    {
        PreviewPrism PreObj;
        Point last_dot;
        int number;
        bool flag,IsRedact;
        PointF[] DotsArray;
        public delegate bool CreatePrism(PointF[] ArrayVert_In, float n_R, float n_G, float n_B, string namePrism);
        
        public delegate PointF[] FindPrism(string Name,ref float [] RGB_Coef);
         public delegate void InvalidateMainForm();
         public delegate void DeletePrism(string Name);
         public DeletePrism Delete;
         public InvalidateMainForm InvalidateForm_1;
         public FindPrism Find;
        public CreatePrism Create,RedactPrism;

        PreviewPrism.MoveDelegate Func_Move;
        public PrismDialog()
        {

            
            InitializeComponent();
            DotsArray = null;
            last_dot = new Point();
            Func_Move = null;
            number = 0;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] ArrayString;
            try
            {
                ArrayString = Regex.Split(TextCoord.Text, ";");
                if (((ArrayString.Length - 1) < 3) || ((ArrayString.Length - 1) > 10))
                {
                    MessageBox.Show("Значение количества вершин призмы может принимать только числовое значение в диапазоне[3;10] ",
                              "Ошибка",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Не правильный формат ввода координат,формат ввода смотри в меню Файл->About",
                                             "Ошибка",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Warning);
                return;
            }
            
            string[] Dot = new string[2];

            number = ArrayString.Length-1;
             DotsArray = new PointF[number];
            for (int i = 0; i != number; i++)
            {
                Dot = Regex.Split(ArrayString[i], " ");
                DotsArray[i].X =(float) Convert.ToDouble(Dot[0]);
                DotsArray[i].Y = (float)Convert.ToDouble(Dot[1]);
            }
            flag = true;
            number = Convert.ToInt16(DotsArray.Length);
            NamberDots.Text = number.ToString();
            PreObj = new PreviewPrism(DotsArray);
           Invalidate();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                number = Convert.ToInt16(NamberDots.Text);
                if ((number < 3) || (number > 10))
                {
                    MessageBox.Show("Значение количества вершин призмы может принимать только числовое значение в диапазоне[3;10] ",
                              "Ошибка",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                    return;
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Значение количества вершин призмы может принимать только числовое значение в диапазоне[3;10] ",
                               "Ошибка",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);

                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Значение количества вершин призмы может принимать только числовое значение в диапазоне[3;10] ",
                               "Ошибка",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);

                return;
            }

            PreObj = new PreviewPrism(number);
            PointF[] tmp = new PointF[number];
            PreObj.GetPrism.CopyTo(tmp, 0);
            for (int i = 0; i != tmp.Length; i++)
            {
                tmp[i].X -= 421;

            }
            for (int i = 0; i != tmp.Length; i++)
                TextCoord.Text += tmp[i].X + " " + tmp[i].Y + ";";
            Invalidate();

        }

        private void PrismDialog_Paint(object sender, PaintEventArgs e)
        {

                if(PreObj!=null)
                {
                    PreObj.Draw(e.Graphics);
                }
        }

        private void PrismDialog_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left == e.Button)
            {

                if (PreObj != null)
                {
                    Func_Move = PreObj.IsSelect(new PointF(e.X, e.Y));

                    last_dot.X = e.X;
                    last_dot.Y = e.Y;
                }
                
            }
           
        }

        private void PrismDialog_MouseMove(object sender, MouseEventArgs e)
        {
            if (Func_Move != null)
            {
                Func_Move((e.X - (int)last_dot.X), (e.Y - (int)last_dot.Y));
                last_dot.X = e.X;
                last_dot.Y = e.Y;
                PointF[] tmp = new PointF[number];
                PreObj.GetPrism.CopyTo(tmp, 0);
                TextCoord.Text = null;
              /*  for (int i = 0; i != tmp.Length; i++)
                {
                    tmp[i].X -= 421;

                }*/
                for (int i = 0; i != tmp.Length; i++)
                    TextCoord.Text += tmp[i].X + " " + tmp[i].Y + ";";
            }
            Invalidate();
        }

        private void PrismDialog_MouseUp(object sender, MouseEventArgs e)
        {
            if (Func_Move != null)
            {
                PointF[] tmp = new PointF[number];
                 PreObj.GetPrism.CopyTo(tmp,0);
                TextCoord.Text = null;
             
                for (int i = 0; i != tmp.Length; i++)
                    TextCoord.Text += tmp[i].X + " " + tmp[i].Y + ";";
            }
            Func_Move = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            float red,green,blue;
            try
            {
                red = (float)Convert.ToDouble(RedText.Text);
                
                green = (float)Convert.ToDouble(GreenText.Text);
                blue = (float)Convert.ToDouble(BlueText.Text);
                if ((red < 1) || (red > 5) || (green < 1) || (green > 5)||(blue < 1) || (blue > 5))
                {
                    MessageBox.Show("Значение коэффициентов приломления должно  быть в диапазоне[1;5]",
                               "Ошибка",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                    return;

                }
            }

            catch (FormatException)
            {
                MessageBox.Show("Значение коэффициентов приломления должно быть числовым и находться в диапазоне[1;5],для обозначения дробной десятичной части используется \",\"",
                               "Ошибка",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);

                return;

 

            }
            if (!IsRedact)
            {
                PointF[] tmp = new PointF[PreObj.GetPrism.Length];
                try
                {
                    PreObj.GetPrism.CopyTo(tmp, 0);
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("Для создания призмы необходимо выбрать один из методов создания \"Создать по умолчанию \" или \"Ввести координаты\" ",
                              "Ошибка",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
 
                }
                string PrismName = "Призма" + (ListPrism.Items.Count + 1).ToString();
                if (Create(tmp, red, green, blue, PrismName))
                {
                    ListPrism.Items.Add("Призма" + (ListPrism.Items.Count + 1).ToString());

                    InvalidateForm_1();
                }
                else
                {
                    MessageBox.Show(" Призма не должна пересекаться с существующими объектами на форме и не должна выходить за границы формы",
                                        "Ошибка",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                }
            }
            else
            {
                IsRedact = false;
                if (!RedactPrism(PreObj.GetPrism, red, green, blue, ListPrism.SelectedItem.ToString()))
                {
                    MessageBox.Show(" Призма не должна пересекаться с существующими объектами на форме и не должна выходить за границы формы",
                                       "Ошибка",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Warning);
                }
                InvalidateForm_1();
            }
          
  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void SetListName(List<string> ListNameMirror_in)
        {
            foreach (string index in ListNameMirror_in)
                ListPrism.Items.Add(index);
        }

        private void ListPrism_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListPrism.SelectedIndex >= 0)
            {
                float[] RGB = new float[3];
                PointF[] ArrayDots = Find(ListPrism.SelectedItem.ToString(), ref RGB);
                TextCoord.Text = null;
                DotsArray = new PointF[ArrayDots.Length];
                ArrayDots.CopyTo(DotsArray, 0);
                RedText.Text = RGB[0].ToString();
                GreenText.Text = RGB[1].ToString();
                BlueText.Text = RGB[2].ToString();
                
                for (int i = 0; i != ArrayDots.Length; i++)
                    TextCoord.Text += DotsArray[i].X + " " + DotsArray[i].Y + ";";
                NamberDots.Text = ArrayDots.Length.ToString();
                number = ArrayDots.Length;
                PreObj = new PreviewPrism(DotsArray);
                IsRedact = false;
                Invalidate();
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ListPrism.SelectedIndex >= 0)
            {
                Delete(ListPrism.SelectedItem.ToString());
                ListPrism.Items.Remove(ListPrism.SelectedItem);
                PreObj = null;
                RedText.Text = null;
                GreenText.Text = null;
                BlueText.Text =null;
                NamberDots.Text = null;
                TextCoord.Text = null;
                IsRedact = false;
                Invalidate();
                InvalidateForm_1();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
             if (ListPrism.SelectedIndex >= 0)
            {
            string[] ArrayString = Regex.Split(TextCoord.Text, ";");
            string[] Dot = new string[2];
            DotsArray = new PointF[number];
            IsRedact = true;
            InvalidateForm_1();
             }
        }
    }
}

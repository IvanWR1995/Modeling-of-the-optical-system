using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prism
{
    public partial class MirrorDialog : Form
    {
        public delegate bool NewMirror(PointF Begin, PointF End, string name);
        public delegate PointF[] FindMirror(string Name);
        public delegate void DeleteMirror(string Name);
        public delegate void InvalidateMainForm();
        public InvalidateMainForm InvalidateForm_1;
        public NewMirror CreateMirror, RedactMirror;
        public FindMirror Find;
        public DeleteMirror Delete;

        public MirrorDialog()
        {

            InitializeComponent();

        }
        public void SetListName(List<string> ListNameMirror_in)
        {
            foreach (string index in ListNameMirror_in)
                ListMirror.Items.Add(index);
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            PointF Begin = new PointF();
            PointF End = new PointF();
            try
            {
                Begin.X = (float)Convert.ToDouble(TextBegin_X.Text);
                Begin.Y = (float)Convert.ToDouble(TextBegin_Y.Text);
                End.X = (float)Convert.ToDouble(TextEnd_X.Text);
                End.Y = (float)Convert.ToDouble(TextEnd_Y.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Координаты зеркала могут иметь только числовые значения ,для обозначения дробной части используйте запятую ",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                return;
            }
            catch (OverflowException)
            {
                string ErrorText = "Допустимый диапазон значенийй для ввода координат[" + float.MinValue.ToString() + ";" + float.MaxValue.ToString() + "]";
                MessageBox.Show(ErrorText,
                              "Ошибка",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);

                return;
            }
            string NameMirror = "Зеркало номер " + (ListMirror.Items.Count + 1).ToString();
            if (CreateMirror(Begin, End, NameMirror))
            {
                ListMirror.Items.Add("Зеркало номер " + (ListMirror.Items.Count + 1).ToString());

                InvalidateForm_1();
            }
            else
            {

                MessageBox.Show(" Зеркало не должно пересекаться с существующими объектами на форме и не должно выходить за границы формы",
                                 "Ошибка",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);


            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ListMirror_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListMirror.SelectedIndex >= 0)
            {
                PointF[] ArrayDots = Find(ListMirror.SelectedItem.ToString());
                TextBegin_X.Text = ArrayDots[0].X.ToString();
                TextBegin_Y.Text = ArrayDots[0].Y.ToString();
                TextEnd_X.Text = ArrayDots[1].X.ToString();
                TextEnd_Y.Text = ArrayDots[1].Y.ToString();

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ListMirror.SelectedIndex >= 0)
            {
                Delete(ListMirror.SelectedItem.ToString());
                ListMirror.Items.Remove(ListMirror.SelectedItem);
                InvalidateForm_1();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ListMirror.SelectedIndex >= 0)
            {
                PointF Begin = new PointF();
                PointF End = new PointF();
                try
                {

                    Begin.X = (float)Convert.ToDouble(TextBegin_X.Text);
                    Begin.Y = (float)Convert.ToDouble(TextBegin_Y.Text);
                    End.X = (float)Convert.ToDouble(TextEnd_X.Text);
                    End.Y = (float)Convert.ToDouble(TextEnd_Y.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Координаты зеркала могут иметь только числовые значения ,для обозначения дробной части используйте запятую ",
                                    "Ошибка",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
                catch (OverflowException)
                {
                    string ErrorText = "Допустимый диапазон значенийй для ввода координат[" + float.MinValue.ToString() + ";" + float.MaxValue.ToString() + "]";
                    MessageBox.Show(ErrorText,
                                  "Ошибка",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);

                    return;
                }
           

                if (!RedactMirror(Begin, End, ListMirror.SelectedItem.ToString()))
                    MessageBox.Show(" Зеркало не должно пересекаться с существующими объектами на форме и не должно выходить за границы формы",
                                     "Ошибка",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning);


            }
            InvalidateForm_1();
        }




    }
}

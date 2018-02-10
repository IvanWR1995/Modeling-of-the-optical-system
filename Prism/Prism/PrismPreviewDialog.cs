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
    public partial class PrismPreviewDialog : Form
    {
        public delegate bool RedactionPrism(PointF[] ArrayVert_In, float n_R, float n_G, float n_B, string namePrism);
        public delegate void InvalidateMainForm();
        public delegate void DeletePrism(string Name);
        public DeletePrism Delete;
        public InvalidateMainForm InvalidateForm_1;
        PreviewPrism.MoveDelegate Func_Move;
        public RedactionPrism RedactPrism;
        PreviewPrism PreObj;
        Point last_dot;
       
        int number;
       
        public PrismPreviewDialog(string NamePrism_in,PointF[] DotsArray_in,float n_R,float n_G, float n_B)
        {
            InitializeComponent();
            PreObj = new PreviewPrism(DotsArray_in);
            RedText.Text = n_R.ToString();
            GreenText.Text = n_G.ToString();
            BlueText.Text = n_B.ToString();
            number = PreObj.GetPrism.Length;
            LabelNamePrism.Text = NamePrism_in;
            LabelCountVert.Text = number.ToString();
            for (int i = 0; i != DotsArray_in.Length; i++)
                    TextCoord.Text += DotsArray_in[i].X + " " + DotsArray_in[i].Y + ";";
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
             float red,green,blue;
            red = (float)Convert.ToDouble(RedText.Text);
            green = (float)Convert.ToDouble(GreenText.Text);
            blue = (float)Convert.ToDouble(BlueText.Text);
            if (!RedactPrism(PreObj.GetPrism, red, green, blue, LabelNamePrism.Text))
                {
                    MessageBox.Show(" Призма не должна пересекаться с существующими объектами на форме и не должна выходить за границы формы",
                                       "Ошибка",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Warning);
                }
                InvalidateForm_1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete(LabelNamePrism.Text);
            InvalidateForm_1();
            Close();
        }

        private void PrismPreviewDialog_MouseDown(object sender, MouseEventArgs e)
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

        private void PrismPreviewDialog_MouseMove(object sender, MouseEventArgs e)
        {
            if (Func_Move != null)
            {
                Func_Move((e.X - (int)last_dot.X), (e.Y - (int)last_dot.Y));
                last_dot.X = e.X;
                last_dot.Y = e.Y;
                PointF[] tmp = new PointF[number];
                PreObj.GetPrism.CopyTo(tmp, 0);
                TextCoord.Text = null;
                for (int i = 0; i != tmp.Length; i++)
                    TextCoord.Text += tmp[i].X + " " + tmp[i].Y + ";";
            }
            Invalidate();
        }

        private void PrismPreviewDialog_MouseUp(object sender, MouseEventArgs e)
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

        private void LabelCountVert_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void PrismPreviewDialog_Paint(object sender, PaintEventArgs e)
        {
            if (PreObj != null)
            {
                PreObj.Draw(e.Graphics);
            }

        }
        
    }
}

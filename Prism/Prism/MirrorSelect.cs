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
    public partial class MirrorSelect : Form
    {
       public  string NameMirror
        { get; set; }
       public delegate PointF[] FindMirror(string Name);
       public delegate void DeleteMirror(string Name);
       public delegate bool NewMirror(PointF Begin, PointF End, string name);
       public delegate void InvalidateMainForm();
       public InvalidateMainForm InvalidateForm_1;
       public DeleteMirror DeleteObject;
       public NewMirror RedactMirror;
       public FindMirror Find;
        public MirrorSelect()
        {
            InitializeComponent();
            
            
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DeleteObject(NameMirror);
            Close();
        }

        private void Change_Click(object sender, EventArgs e)
        {
             PointF Begin = new PointF();
                PointF End = new PointF();
                Begin.X = (float)Convert.ToDouble(BeginMirror_X.Text);
                Begin.Y = (float)Convert.ToDouble(BeginMirror_Y.Text);
                End.X = (float)Convert.ToDouble(EndMirror_X.Text);
                End.Y = (float)Convert.ToDouble(EndMirror_Y.Text);
                if(!RedactMirror(Begin, End, NameMirror))
                MessageBox.Show(" Зеркало не должно пересекаться с существующими объектами на форме и не должно выходить за границы формы",
                                        "Ошибка",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Cancel_Paint(object sender, PaintEventArgs e)
        {
            NameMirrorLabel.Text = NameMirror;
            PointF[] ArrayCoord = Find(NameMirror);
            BeginMirror_X.Text = ArrayCoord[0].X.ToString();
            BeginMirror_Y.Text = ArrayCoord[0].Y.ToString();
            EndMirror_X.Text = ArrayCoord[1].X.ToString();
            EndMirror_Y.Text = ArrayCoord[1].Y.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MirrorSelect_Load(object sender, EventArgs e)
        {

        }
    }
}

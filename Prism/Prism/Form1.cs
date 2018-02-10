using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
namespace Prism
{
    public partial class Form1 : Form
    {
       
        ViewController ViewObject;
        bool IsDown;
        Point last_dot;
        GraphicsPath RectWindow;
        public Form1()
        {
            InitializeComponent();
            Point p = new Point (200,200),p2 = new Point(100,300);


            last_dot = new Point();
            PointF []PolygonWindow = new PointF[4];
            PolygonWindow[0].X = 0;
            PolygonWindow[0].Y = Menu.ClientSize.Height+ToolPanel.ClientSize.Height;

            PolygonWindow[1].X = 0;
            PolygonWindow[1].Y = ClientSize.Height - StatusPanel.ClientSize.Height;

            PolygonWindow[2].X = ClientSize.Width;
            PolygonWindow[2].Y = ClientSize.Height - StatusPanel.ClientSize.Height;

            PolygonWindow[3].X = ClientSize.Width;
            PolygonWindow[3].Y = Menu.ClientSize.Height + ToolPanel.ClientSize.Height;
            RectWindow = new GraphicsPath();
           RectWindow.AddPolygon(PolygonWindow);
            ViewObject = new ViewController(PolygonWindow);
          // ViewObject.CreateRay(ClientSize.Height);
          
         
           
        }

        private void OnDown(object sender, MouseEventArgs e)
        {

            if (MouseButtons.Left == e.Button)
            {

                IsDown = ViewObject.IsSelected(new Point(e.X, e.Y));
                last_dot.X = e.X;
                last_dot.Y = e.Y;
            }
            else if (MouseButtons.Right == e.Button)
            {
                string NameObject = ViewObject.IsVisibleMy(new PointF(e.X, e.Y));
                if (NameObject.Contains("Зеркало"))
                {
                    MirrorSelect dialog = new MirrorSelect();
                    dialog.NameMirror = NameObject;
                    dialog.InvalidateForm_1 = Invalidate;
                    dialog.Find = ViewObject.FindMirror;
                    dialog.DeleteObject = ViewObject.DeleteObject;
                    dialog.RedactMirror = ViewObject.ChangeMirror;
                    dialog.ShowDialog();
                    
                }
                else if (NameObject.Contains("Призма"))
                {
                    float [] RGB= new float[3];
                    PointF [] tmp = ViewObject.FindPrism(NameObject,ref RGB);
                    PrismPreviewDialog dialog = new PrismPreviewDialog(NameObject, tmp, RGB[0], RGB[1], RGB[2]);
                    dialog.InvalidateForm_1 = Invalidate;
                    dialog.Delete = ViewObject.DeleteObject;
                    dialog.RedactPrism = ViewObject.RedactPrism;
                    dialog.ShowDialog();
 
                }
                else if (ViewObject.IsVisibleMy(new Point(e.X, e.Y)).Contains("Источник"))
                {
                    LightSourceDialog dialog = new LightSourceDialog();
                    dialog.SetLAngle = ViewObject.GetLAngleSource();
                    dialog.SourceOn = ViewObject.On;
                    dialog.flag_OnOff = ViewObject.GetSourceStatus();
                    dialog.InvalidateForm_1 = Invalidate;
                    dialog.SourceOff = ViewObject.Off;
                    dialog.ChangeSetting = ViewObject.ChangeSettings;
                    dialog.InitLightSource(ViewObject.GetSource.GetLen, ViewObject.GetSource.GetCountRay, ViewObject.GetSource.GetColorRay, ViewObject.GetSource.GetLeftAngle);
                    dialog.ShowDialog();
                }
            }

        }

        private void OnMove(object sender, MouseEventArgs e)
        {
            if (IsDown)
            {
                ViewObject.MoveOrDeform(e.X - last_dot.X, e.Y - last_dot.Y);
                ViewObject.Draw(this.CreateGraphics());
                last_dot.X = e.X;
                last_dot.Y = e.Y;

               
            }
            StatusCoord_Y.Text = e.Y.ToString();
            StatusCoord_X.Text = e.X.ToString();
            StatusNameObject.Text = ViewObject.IsVisibleMy(new PointF(e.X,e.Y));
            if(StatusNameObject.Text!=null)
            {
                NameLableObj.Text = StatusNameObject.Text;
                Point tmp = new Point();
                tmp.X = e.X;
                tmp.Y = e.Y - NameLableObj.Height;
                NameLableObj.Location = tmp;
                NameLableObj.Visible = true;
 
            }
            else
                NameLableObj.Visible = false;


            Invalidate();
        }

        private void OnUpMouse(object sender, MouseEventArgs e)
        {
            IsDown = false;
           Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            ViewObject.Draw(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void MirrorMenuItem_Click(object sender, EventArgs e)
        {
            MirrorDialog dialog = new MirrorDialog();
            dialog.CreateMirror = ViewObject.CreateMirror;
            dialog.InvalidateForm_1 = Invalidate;
            dialog.Find = ViewObject.FindMirror;
            dialog.Delete = ViewObject.DeleteObject;
            dialog.RedactMirror = ViewObject.ChangeMirror;
            dialog.SetListName(ViewObject.GetListMirror());
            dialog.ShowDialog();
            Invalidate();
           
        }

        private void toolStripStatusLabel3_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void LightSource_Click(object sender, EventArgs e)
        {

            LightSourceDialog dialog = new LightSourceDialog();
            dialog.SetLAngle = ViewObject.GetLAngleSource();
            dialog.SourceOn = ViewObject.On;
            dialog.flag_OnOff = ViewObject.GetSourceStatus();
            dialog.InvalidateForm_1 = Invalidate;
            dialog.SourceOff = ViewObject.Off;
            dialog.ChangeSetting = ViewObject.ChangeSettings;
            dialog.InitLightSource(ViewObject.GetSource.GetLen, ViewObject.GetSource.GetCountRay, ViewObject.GetSource.GetColorRay, ViewObject.GetSource.GetLeftAngle);
            dialog.ShowDialog();
        }

        private void PrismToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrismDialog dialog = new PrismDialog();
            dialog.Create = ViewObject.CreatePrism;
            dialog.InvalidateForm_1 = Invalidate;
            dialog.SetListName(ViewObject.GetListPrism());
            dialog.Delete = ViewObject.DeleteObject;
            dialog.RedactPrism = ViewObject.RedactPrism;
            dialog.Find = ViewObject.FindPrism;
            dialog.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            PrismDialog dialog = new PrismDialog();
            dialog.Create = ViewObject.CreatePrism;
            dialog.InvalidateForm_1 = Invalidate;
            dialog.SetListName(ViewObject.GetListPrism());
            dialog.Delete = ViewObject.DeleteObject;
            dialog.RedactPrism = ViewObject.RedactPrism;
            dialog.Find = ViewObject.FindPrism;
            dialog.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            LightSourceDialog dialog = new LightSourceDialog();
            dialog.SetLAngle = ViewObject.GetLAngleSource();
            dialog.SourceOn = ViewObject.On;
            dialog.flag_OnOff = ViewObject.GetSourceStatus();
            dialog.InvalidateForm_1 = Invalidate;
            dialog.SourceOff = ViewObject.Off;
            dialog.ChangeSetting = ViewObject.ChangeSettings;
            dialog.InitLightSource(ViewObject.GetSource.GetLen, ViewObject.GetSource.GetCountRay, ViewObject.GetSource.GetColorRay, ViewObject.GetSource.GetLeftAngle);
            dialog.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            MirrorDialog dialog = new MirrorDialog();
            dialog.CreateMirror = ViewObject.CreateMirror;
            dialog.InvalidateForm_1 = Invalidate;
            dialog.Find = ViewObject.FindMirror;
            dialog.Delete = ViewObject.DeleteObject;
            dialog.RedactMirror = ViewObject.ChangeMirror;
            dialog.SetListName(ViewObject.GetListMirror());
            dialog.ShowDialog();
            Invalidate();

        }

        private DialogResult SaveFileFunc()
        {
            if (SaveFile.ShowDialog() == DialogResult.OK)
            {

                BinaryFormatter binFormatSave = new BinaryFormatter();
                using (Stream fstream = new FileStream(SaveFile.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    binFormatSave.Serialize(fstream, ViewObject);

                }
                return DialogResult.OK;
            }
            return DialogResult.Cancel;
 
        }
        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileFunc();
        }
        private void OpenFileFunc()
        {
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter binFormatOpen = new BinaryFormatter();
                    using (Stream fstream = File.OpenRead(OpenFile.FileName))
                    {
                        ViewObject = (ViewController)binFormatOpen.Deserialize(fstream);

                    }
                  //  ViewObject.Draw(this.CreateGraphics());
                    ViewObject.SetWindowRect(RectWindow);
                    Invalidate();
               

            }
 
        }
        private void Open_Click(object sender, EventArgs e)
        {

            OpenFileFunc();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileFunc();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            SaveFileFunc();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            DialogResult res=MessageBox.Show("Хотите сохранения при выходе?", "Выход", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res== DialogResult.Yes)
            {
                if (SaveFileFunc() == DialogResult.OK)
                    Close();
            }
            else if (res == DialogResult.No)
                Close();
        }

        private void About_Click(object sender, EventArgs e)
        {
            AboutDialog dialog = new AboutDialog();
            dialog.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog dialog = new AboutDialog();
            dialog.ShowDialog();
        }

       

    }
}

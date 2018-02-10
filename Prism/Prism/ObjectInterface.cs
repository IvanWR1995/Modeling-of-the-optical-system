using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace Prism
{
    [Serializable]
    abstract class  OpticObject
    {
        public delegate void MoveDelegate(int shift_x, int shift_y, List<OpticObject> FigureList);
        abstract public void Move(int Shifting_X, int Shifting_Y, List<OpticObject> FigureList);
        abstract public void Draw(System.Drawing.Graphics graphics);
        abstract public bool IsMyVisible(PointF Dot);
        abstract public MoveDelegate IsSelect(PointF dot);
        abstract public bool Intersect(PointF Begin_in, PointF End_in);
        abstract public void SetWindowRect(GraphicsPath RectWindow_in);
    }
}

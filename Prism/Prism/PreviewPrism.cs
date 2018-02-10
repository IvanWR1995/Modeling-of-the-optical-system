using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace Prism
{
    class PreviewPrism
    {
        string NamePrism;
        public delegate void MoveDelegate(int shift_x, int shift_y);
        GraphicsPath ClientSize;
        public string Name
        {
            get
            {
                return NamePrism;
            }
        }
        int index_coal;
        PointF[] ArrayVertices,ArrayClienIn;

        public PointF[] GetPrism
        {
            get {
                return ArrayClienIn; 
            }
        }
        public PreviewPrism()
        { 
        }

        public PreviewPrism(int NamberVert)
        {
            ClientSize = new GraphicsPath();
            PointF[] Client = new PointF[4];
            Client[0].X = 421;
            Client[0].Y = 0;
            Client[1].X = 421;
            Client[1].Y = 340;
            Client[2].X = 1090;
            Client[2].Y = 340;
            Client[3].X = 1090;
      
            Client[3].Y = 0;
            ClientSize.AddPolygon(Client);
            ArrayVertices = new PointF[NamberVert];
            
            for (int i = 0; i != NamberVert; i++)
            {
                ArrayVertices[i].X = (float)(766 + 50 * Math.Cos(  2 * Math.PI * i / NamberVert));
                ArrayVertices[i].Y = (float)(186 + 50 * Math.Sin( 2 * Math.PI * i / NamberVert));
            }
            ArrayClienIn = new PointF[ArrayVertices.Length];
            for (int i = 0; i != NamberVert; i++)
            {
                ArrayClienIn[i].X = ArrayVertices[i].X * 2 - 766;
                ArrayClienIn[i].Y = ArrayVertices[i].Y * 2 - 186;
            }
        }
        public PreviewPrism(PointF[] ArrayVert_in)
        {
            PointF Centr = new PointF(0,0);
            float shift_X=0,shift_Y = 0; 
            ArrayVertices = new PointF[ArrayVert_in.Length];
             ArrayClienIn = new PointF[ArrayVertices.Length];
             ClientSize = new GraphicsPath();
             PointF[] Client = new PointF[4];  
            Client[0].X = 421;
            Client[0].Y = 0;
            Client[1].X = 421;
            Client[1].Y = 340;
            Client[2].X = 1090;
            Client[2].Y = 340;
            Client[3].X = 1090;
      
            Client[3].Y = 0;
            ClientSize.AddPolygon(Client);
            ArrayVert_in.CopyTo(ArrayClienIn, 0);

            for (int i = 0; i != ArrayClienIn.Length; i++)
            {
                ArrayVertices[i].X = ArrayClienIn[i].X /2;
                ArrayVertices[i].Y =ArrayClienIn[i].Y/ 2;
            }
            for (int i = 0; i != ArrayVertices.Length; i++)
            {
                Centr.X += ArrayVertices[i].X;
                Centr.Y += ArrayVertices[i].Y;
            }
            Centr.X /= ArrayVertices.Length;
            Centr.Y /= ArrayVertices.Length;
            shift_X = 766 - Centr.X;
            shift_Y =186-  Centr.Y ;
            for (int i = 0; i != ArrayClienIn.Length; i++)
            {
                ArrayVertices[i].X += shift_X;
                ArrayVertices[i].Y += shift_Y;

            }
        }

       
        public void MoveTop(int x, int y)
        {
            PointF Tmp = new PointF();
            if (index_coal == ArrayVertices.Length - 1)
                Tmp = ArrayVertices[0];
            else
                Tmp = ArrayVertices[index_coal + 1];
            if (ClientSize.IsVisible(ArrayVertices[index_coal].X + x, ArrayVertices[index_coal].Y + y) == false)
                return;
           
            ArrayVertices[index_coal].X += x;
            ArrayVertices[index_coal].Y += y;
            ArrayClienIn[index_coal].X += x*2;
            ArrayClienIn[index_coal].Y += y*2;
 
        }
        public MoveDelegate IsSelect(PointF dot)
        {
            
            for (int i = 0; i != ArrayVertices.Length; i++)
            {
                GraphicsPath IsDot = new GraphicsPath();
                IsDot.AddEllipse(ArrayVertices[i].X - 2, ArrayVertices[i].Y - 2, 5, 5);
                if (IsDot.IsVisible(dot))
                {
                    index_coal = i;
                    return MoveTop;
                }

            }

           

            return null;
        }
           
         public void Draw(System.Drawing.Graphics graphics)
        {
            graphics.DrawPolygon(new Pen(Color.DarkRed), ArrayVertices);

        }
  
    }
}

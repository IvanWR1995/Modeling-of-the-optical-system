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
    class Receiver
    {
        PointF[] ReceiverCoord;
       public Receiver(float ClientWidth, float ClientHeight)
        {
            ReceiverCoord = new PointF[4];
            ReceiverCoord[0].X = 0;
            ReceiverCoord[0].Y = ClientHeight -20;
            ReceiverCoord[1].X = 0;
            ReceiverCoord[1].Y = ClientHeight;
 
           ReceiverCoord[2].X = ClientWidth;
            ReceiverCoord[2].Y = ClientHeight;
            
            ReceiverCoord[3].X = ClientWidth;
            ReceiverCoord[3].Y = ClientHeight-20;
        }

        public bool IsMyVisible(PointF Dot)
       {
           GraphicsPath PrismPolygon = new GraphicsPath();

           PrismPolygon.AddPolygon(ReceiverCoord);
           if (PrismPolygon.IsVisible(Dot))
               return true;
           return false;
       }
        public void Draw(System.Drawing.Graphics graphics)
        {
           graphics.DrawPolygon(new Pen(Color.Brown), ReceiverCoord);

        }  
        public  bool Crossing(PointF Begin_in,PointF End_in,ref PointF res,ref PointF End_new)
        {  
            float a_in = End_in.X - Begin_in.X, b_in = End_in.Y - Begin_in.Y, c_in = -1 * a_in * Begin_in.Y + b_in * Begin_in.X;
            float a =ReceiverCoord[3].X-ReceiverCoord[0].X , b = ReceiverCoord[3].Y-ReceiverCoord[0].Y;
            float c = -1 * a * ReceiverCoord[0].Y + b * ReceiverCoord[0].X;
            float x = 0, y = 0 ;
            if ((a / a_in) != (b / b_in))
            {
                if (a != 0)
                {
                    x = (a_in * c / a - c_in) / (a_in * b / a - b_in);
                    y = (b * x - c) / a;
                }
                else
                {
                    x = c / b;
                    y = (b_in * x - c_in) / a_in;
                }
                End_new.X = x;
                End_new.Y = End_in.Y;
                res.X = x;
                res.Y = y;
                if (End_in.Y > ReceiverCoord[0].Y)
                    return true;
 
            }
            End_new = End_in;
            res.X = 0;
            res.Y = 0;
               
            return false;
        }

        
       
    }
}

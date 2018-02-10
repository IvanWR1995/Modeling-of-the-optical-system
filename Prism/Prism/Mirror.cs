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
    class Mirror : OpticObject
    {
        string NameMirror;
        public string Name
        {
            get
            {
                return NameMirror;
            }
        }
        PointF Begin,End,Calc_Begin,Calc_End;
        [NonSerialized]
        GraphicsPath ClientSize;
        int index_coal;
       public Vectors vector;
        public PointF GetBegin
        {
            get
            {
                return Begin;
            }
        }
       public PointF GetEnd
        {
            get
            {
                return End;
            }
        }

       public Mirror()
       { 
       }
      override public void SetWindowRect(GraphicsPath RectWindow_in)
       {
           ClientSize = new GraphicsPath();
            ClientSize.AddPolygon(RectWindow_in.PathPoints);
       }
        public Mirror(PointF Begin_in,PointF End_in, GraphicsPath ClientSize_in,string Name_in)
        {
            NameMirror = Name_in;
            ClientSize = new GraphicsPath();
            ClientSize = ClientSize_in;
            Begin = new PointF();
            End = new PointF();
            Calc_Begin = new PointF();
            Calc_End = new PointF();
         Calc_Begin = End_in;
         Calc_End = Begin_in;
         Begin = Begin_in;
         End = End_in;
             vector = new Vectors(Begin, End);
        }
        public bool Change(PointF Begin_in, PointF End_in, List<OpticObject> FigureList)
        {

            foreach (OpticObject index in FigureList)
            {
                if ((index.Intersect(Begin_in,End_in) && (!index.Equals(this))))
                    return false;
            }
            if ((!ClientSize.IsVisible(Begin_in))||(!ClientSize.IsVisible(End_in)))
                return false;
                    
            Calc_Begin = End_in;
            Calc_End = Begin_in;
            Begin = Begin_in;
            End = End_in;
            vector = new Vectors(Begin, End);
            return true;
        }
        
        public override void Move(int Shifting_X, int Shifting_Y, List<OpticObject> FigureList)
        {
            foreach (OpticObject index in FigureList)
            {
                if ((index.Intersect(new PointF(Begin.X + Shifting_X, Begin.Y + Shifting_Y), new PointF(End.X + Shifting_X, End.Y + Shifting_Y)))&&(!index.Equals(this)))
                    return;
            }
            if (ClientSize.IsVisible(Begin.X + Shifting_X, Begin.Y + Shifting_Y) == false)
                return;
             if (ClientSize.IsVisible(End.X + Shifting_X, End.Y + Shifting_Y) == false)
                return;
                    
            Begin.X += Shifting_X;
            Begin.Y += Shifting_Y;
            End.X += Shifting_X;
            End.Y += Shifting_Y;
            Calc_Begin = Begin;
            Calc_End = End;
            vector.ChangeVector(Calc_Begin, Calc_End);
        }
        //static public CanCreate() 
        public void MoveTop(int x, int y, List<OpticObject> FigureList)
        {
               switch (index_coal)
                {
                    case 0:
                        if (ClientSize.IsVisible(Begin.X + x, Begin.Y + y) == false)
                            return;
                        foreach (OpticObject index in FigureList)
                        {

                            if ((index.Intersect(new PointF(Begin.X + x, Begin.Y + y), End))&&(!index.Equals(this)))
                                return;
                        }
                        Begin.X += x;
                        Begin.Y += y;
                     break;
                   case 1:
                     if (ClientSize.IsVisible(End.X + x, End.Y + y) == false)
                         return;
                     foreach (OpticObject index in FigureList)
                     {
                         if ((index.Intersect(Begin, new PointF(End.X + x, End.Y + y)))&&(!index.Equals(this)))
                             return;
                     }
                     End.X += x;
                     End.Y += y;
                   break;
                }
               if ((Begin.X > End.X) )
               {
                   Calc_Begin = End;
                   Calc_End = Begin;


               }
               else
               {
                   Calc_Begin = Begin;
                   Calc_End = End;
               }
          vector.ChangeVector(Calc_Begin,Calc_End);

        }
      public bool Invalidate(PointF Begin, PointF End, ref PointF Res, ref PointF EndRes)
        {
             double corner = Crossing(Begin, End, ref Res);
             if (corner != 0)
             {
                 EndRes = Rotation(corner, Res, End);
                 return true;
               
             }
           
             EndRes = End;
             return false;
         
        }
      override public bool IsMyVisible(PointF Dot)
      {
          GraphicsPath SelectMirror = new GraphicsPath();
            
            PointF [] tmp_path = new PointF[4];
            tmp_path[0].X = Begin.X - 3;
            tmp_path[0].Y = Begin.Y - 3;

            tmp_path[1].X = Begin.X + 3;
            tmp_path[1].Y = Begin.Y - 3;

            tmp_path[2].X = End.X + 3;
            tmp_path[2].Y = End.Y - 3;
            tmp_path[3].X = End.X - 3;
            tmp_path[3].Y = End.Y - 3;
            SelectMirror.AddPolygon(tmp_path);

            if (SelectMirror.IsVisible(Dot))
                return true;
            return false;
          
 
      }
       override public MoveDelegate IsSelect(PointF dot)
        {
            GraphicsPath SelectMirror = new GraphicsPath();
            SelectMirror.AddEllipse(Begin.X - 3, Begin.Y - 3,  6, 6);
            if (SelectMirror.IsVisible(dot))
            {
                index_coal = 0;
                return MoveTop;
            }
            SelectMirror.Reset();
            SelectMirror.AddEllipse(End.X - 3, End.Y - 3, 6, 6);
            if (SelectMirror.IsVisible(dot))
            {
                index_coal = 1;
                return MoveTop;
            }
            SelectMirror.Reset();
            PointF [] tmp_path = new PointF[4];
            tmp_path[0].X = Begin.X - 3;
            tmp_path[0].Y = Begin.Y - 3;

            tmp_path[1].X = Begin.X + 3;
            tmp_path[1].Y = Begin.Y - 3;

            tmp_path[2].X = End.X + 3;
            tmp_path[2].Y = End.Y - 3;
            tmp_path[3].X = End.X - 3;
            tmp_path[3].Y = End.Y - 3;
            SelectMirror.AddPolygon(tmp_path);

            if (SelectMirror.IsVisible(dot))
                return Move;
            return null;
        }

        public override void Draw(System.Drawing.Graphics  graphics)
        {
         
            graphics.DrawLine(new Pen(Color.Black), Begin,End);
           
        }
        
       public  bool IsCut(PointF Begin, PointF End,PointF Dot)
        {
            bool flag  = false ;
           
            if ((Begin.X <=End.X) && (Dot.X >= Begin.X) && (Dot.X <= End.X))
                flag = true;
            else  if ((Begin.X >= End.X) && (Dot.X <= Begin.X) && (Dot.X >= End.X))
                flag = true;
            if (flag == true)
            {
                if ((Begin.Y <= End.Y) && (Dot.Y >= Begin.Y) && (Dot.Y <= End.Y) )
                    return true;
                if ((Begin.Y == End.Y) && ((Dot.Y == Begin.Y) || (Dot.Y == End.Y)) )
                    return true;
                if ((Begin.Y >= End.Y) && (Dot.Y <= Begin.Y) && (Dot.Y >= End.Y) )
                    return true;
            }

            return false;
        }
       override public bool Intersect(PointF Begin_in, PointF End_in)
       {
           PointF res = new PointF();
           res.X = 0;
           res.Y = 0;
             double angle = 0; 
           angle = Crossing(Begin_in,End_in,ref res);
           if ((angle != 0)||(Begin_in==Begin)||(Begin_in==End)||(End_in==End)||(End_in==Begin))
               return true;
          
               
           return false;
       }
       
         public double Crossing(PointF Begin_in, PointF End_in, ref PointF Dot)
        {
            float a_in = End_in.X - Begin_in.X, b_in = End_in.Y - Begin_in.Y, c_in = -1 * a_in * Begin_in.Y + b_in * Begin_in.X;
            float a = vector.Get_X, b = vector.Get_Y;
            float c = -1 * a * Calc_Begin.Y + b * Calc_Begin.X;
            float x = 0, y = 0 ,tmp_x=0,tmp_y=0;
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
                    y= (b_in*x - c_in)/a_in;
                }
                tmp_x = (float)Math.Round((double)x);
                tmp_y = (float)Math.Round((double)y);
                Begin_in.X = (float)Math.Round((double)Begin_in.X);
                Begin_in.Y = (float)Math.Round((double)Begin_in.Y);
                End_in.X = (float)Math.Round((double)End_in.X);
                End_in.Y = (float)Math.Round((double)End_in.Y);
                if ((IsCut(Calc_Begin, Calc_End, new PointF(tmp_x, tmp_y))) && (IsCut(Begin_in, End_in, new PointF(tmp_x, tmp_y)))) 
                {
                    double nominator = vector.Get_X * (End_in.X - Begin_in.X) + vector.Get_Y * (End_in.Y - Begin_in.Y);
                    double sqrt_1 = Math.Sqrt(Math.Pow(vector.Get_X, 2) + Math.Pow(vector.Get_Y, 2));
                    double sqrt_2 = Math.Sqrt(Math.Pow((End_in.X - Begin_in.X), 2) + Math.Pow((End_in.Y - Begin_in.Y), 2));
                    double res = 0,cos = 0;
                   
                    Dot.X =x;
                    Dot.Y = y;
                    cos = nominator / (sqrt_1 * sqrt_2);
                    
                    res = Math.Acos(cos);
                    /*if(res>(Math.PI/2))
                    {
                        res = Math.PI - res; 
                    }*/
                    
                    return res;
                }
                
               

            }
             Dot.X = 0;
             Dot.Y = 0;
               

            return 0;

 
        }
    
        public  PointF Rotation(double Corner, PointF Begin, PointF End)
        {
            double x_tmp = End.X - Begin.X, y_tmp = End.Y-Begin.Y, sign = -1;
            double alpha =2 * Corner;
            double sqrt_2;
            if ((vector.Get_X * (Begin.Y - End.Y) - vector.Get_Y * (Begin.X - End.X) <=0))
            {
                sign = 1;
            }
            End.X =(float)( x_tmp * Math.Cos(alpha) + sign * y_tmp * Math.Sin(alpha));
            End.Y = (float)((-1)*sign* x_tmp * Math.Sin(alpha) + y_tmp * Math.Cos(alpha));
            do
            {
                sqrt_2 = Math.Sqrt(Math.Pow((End.X - Begin.X), 2) + Math.Pow((End.Y - Begin.Y), 2));
           
                if ((sqrt_2 <= 2600))
                {
                    End.Y *= 2;
                    End.X *= 2;
                }
            } while (sqrt_2 <= 2600);
            End.X += Begin.X;
            End.Y += Begin.Y;
           return End;
        }
    
    }
}

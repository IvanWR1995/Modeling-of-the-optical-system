using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization.Formatters.Binary;

namespace Prism
{
    [Serializable]
    class PrismObject : OpticObject
    {
        string NamePrism;
        public string Name
        {
            get
            {
                return NamePrism;
            }
        }
        PointF[] ArrayVertices;
        public PointF[] ArrayPrism
        {
            get { return ArrayVertices; }
        }
        public delegate void RayNewAdd(Ray Ray_in);
        RayNewAdd CreateNewRay;
        float[] RefractRGB;

        Vectors[] Vector_Normal;
        int index_coal;
        [NonSerialized]
        GraphicsPath ClientSize;
        public float GetRedCoef
        {
            get
            {
                return RefractRGB[0];
            }
        }
        public float GetGreenCoef
        {
            get
            {
                return RefractRGB[1];
            }
        }
        public float GetBlueCoef
        {
            get
            {
                return RefractRGB[2];
            }
        }
        override public void SetWindowRect(GraphicsPath RectWindow_in)
        {
           ClientSize= new GraphicsPath();
           ClientSize.AddPolygon(RectWindow_in.PathPoints);
        }
        public PrismObject()
        {
        }
        public PrismObject(PointF[] ArrayVert_In, RayNewAdd FuncCreateRay, float n_R, float n_G, float n_B, GraphicsPath ClientSize_in, string Name_in)
        {

            NamePrism = Name_in;
            ArrayVertices = new PointF[ArrayVert_In.Length];
            ArrayVert_In.CopyTo(ArrayVertices, 0);
            Vector_Normal = new Vectors[ArrayVertices.Length];
            CreateNewRay = FuncCreateRay;
            ClientSize = new GraphicsPath();
            ClientSize = ClientSize_in;
            for (int i = 0; i != ArrayVertices.Length; i++)
            {
                Vector_Normal[i] = new Vectors();
                if (i != ArrayVertices.Length - 1)
                    Vector_Normal[i].ChangeVector(ArrayVertices[i], ArrayVertices[i + 1]);
                else
                    Vector_Normal[i].ChangeVector(ArrayVertices[i], ArrayVertices[0]);
            }
            RefractRGB = new float[3];
            RefractRGB[0] = n_R;
            RefractRGB[1] = n_G;
            RefractRGB[2] = n_B;


        }
        public void RedactPrism(PointF[] ArrayVert_In, float n_R, float n_G, float n_B)
        {
            ArrayVertices = new PointF[ArrayVert_In.Length];
            ArrayVert_In.CopyTo(ArrayVertices, 0);
            RefractRGB = new float[3];
            RefractRGB[0] = n_R;
            RefractRGB[1] = n_G;
            RefractRGB[2] = n_B;

        }
        override public bool IsMyVisible(PointF Dot)
        {
            GraphicsPath PrismPolygon = new GraphicsPath();

            PrismPolygon.AddPolygon(ArrayVertices);
            if (PrismPolygon.IsVisible(Dot))
                return true;
            return false;
        }
        override public void Move(int Shifting_X, int Shifting_Y, List<OpticObject> FigureList)
        {
            PointF Tmp = new PointF();
            for (int i = 0; i != ArrayVertices.Length; i++)
            {
                if (i == ArrayVertices.Length - 1)
                    Tmp = ArrayVertices[0];
                else
                    Tmp = ArrayVertices[i + 1];
                if (ClientSize.IsVisible(ArrayVertices[i].X + Shifting_X, ArrayVertices[i].Y + Shifting_Y) == false)
                    return;
                foreach (OpticObject index in FigureList)
                {
                    if ((index.Intersect(new PointF(ArrayVertices[i].X + Shifting_X, ArrayVertices[i].Y + Shifting_Y), Tmp)) && (!index.Equals(this)))
                        return;
                }

            }
            for (int i = 0; i != ArrayVertices.Length; i++)
            {
                ArrayVertices[i].X += Shifting_X;
                ArrayVertices[i].Y += Shifting_Y;
            }
            for (int i = 0; i != ArrayVertices.Length; i++)
            {
                if (i != ArrayVertices.Length - 1)
                    Vector_Normal[i].ChangeVector(ArrayVertices[i], ArrayVertices[i + 1]);
                else
                    Vector_Normal[i].ChangeVector(ArrayVertices[i], ArrayVertices[0]);

            }
        }
        public bool Invalidate(PointF Begin, PointF End, ref PointF Res_in, Color RGB)
        {
            bool result_flag = false;
            PointF Res = new PointF();

            if (RGB.R != 0)
                result_flag = RefractRay(Begin, End, Color.FromArgb(RGB.R, 0, 0), RefractRGB[0], ref Res);
            if (RGB.G != 0)
                result_flag = RefractRay(Begin, End, Color.FromArgb(0, RGB.G, 0), RefractRGB[1], ref Res);
            if (RGB.B != 0)
                result_flag = RefractRay(Begin, End, Color.FromArgb(0, 0, RGB.B), RefractRGB[2], ref Res);
            Res_in = Res;
            return result_flag;
        }
        public void MoveTop(int x, int y, List<OpticObject> FigureList)
        {
            PointF Tmp = new PointF();
            if (index_coal == ArrayVertices.Length - 1)
                Tmp = ArrayVertices[0];
            else
                Tmp = ArrayVertices[index_coal + 1];
            if (ClientSize.IsVisible(ArrayVertices[index_coal].X + x, ArrayVertices[index_coal].Y + y) == false)
                return;
            foreach (OpticObject index in FigureList)
            {
                if ((index.Intersect(new PointF(ArrayVertices[index_coal].X + x, ArrayVertices[index_coal].Y + y), Tmp)) && (!index.Equals(this)))
                    return;
                if ((index_coal != 0) && (index.Intersect(new PointF(ArrayVertices[index_coal - 1].X + x, ArrayVertices[index_coal - 1].Y + y), ArrayVertices[index_coal])) && (!index.Equals(this)))
                    return;
            }
            ArrayVertices[index_coal].X += x;
            ArrayVertices[index_coal].Y += y;

        }
        override public MoveDelegate IsSelect(PointF dot)
        {
            GraphicsPath PrismPolygon = new GraphicsPath();
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

            PrismPolygon.AddPolygon(ArrayVertices);
            if (PrismPolygon.IsVisible(dot))
                return Move;

            return null;
        }
        public bool RefractRay(PointF Begin_in, PointF End_in, Color RGB, double n, ref PointF res)
        {
            List<PointF> DotList = new List<PointF>();
            PointF Begin = new PointF();
            PointF End = new PointF();
            Begin = Begin_in;
            End = End_in;
            double alpha = 0, n_1 = 1, n_2 = n, fi = 0;
            int j = ArrayVertices.Length, index = -1;
            PointF ResDot = new PointF();
            PointF TmpDot = new PointF();
            do
            {

                alpha = FindCrossing(Begin, End, ref ResDot, ref index);
                if (index == ArrayVertices.Length - 1)
                    TmpDot = ArrayVertices[0];
                else
                    TmpDot = ArrayVertices[index + 1];

                if (alpha != 0)
                {
                    if ((IsReflection(n_1, n_2, alpha)) && ((Math.Round((double)ResDot.X) != Math.Round((double)DotList[DotList.Count - 1].X)) && (Math.Round((double)ResDot.Y) != Math.Round((double)DotList[DotList.Count - 1].Y))))
                    {
                        End = Rotation(2 * alpha,ResDot, End, ArrayVertices[index], TmpDot, -1);
                    }
                    else
                    {
                        fi = RefractAngle(n_1, n_2, alpha);
                        End = Rotation(fi, ResDot, End, ArrayVertices[index], TmpDot);
                    }
                    if (DotList.Count == 0)
                    {
                        DotList.Add(ResDot);
                        Begin = ResDot;
                    }
                    else if ((Math.Round((double)ResDot.X) != Math.Round((double)DotList[DotList.Count - 1].X)) && (Math.Round((double)ResDot.Y) != Math.Round((double)DotList[DotList.Count - 1].Y)))
                    {
                        DotList.Add(ResDot);
                        Begin = ResDot;
                    }
                    n_1 = n;
                    n_2 = 1;

                }

            } while (alpha != 0);
            if (DotList.Count != 0)
            {
                DotList.Add(End);
                res = DotList[0];
                CreateNewRay(new Ray(DotList.ToArray(), RGB));
                return true;
            }
            else res = new PointF();
            return false;
        }
        public double FindCrossing(PointF Begin, PointF End, ref PointF Min_Cross, ref int index)
        {
            PointF Cross = new PointF();
            PointF TmpDot = new PointF();
            double min = 10000, dist = 0, angle = 0, alpha = 0;

            for (int i = 0; i != ArrayVertices.Length; i++)
            {
                if (i != index)
                {

                    if (i == ArrayVertices.Length - 1)
                        TmpDot = ArrayVertices[0];
                    else
                        TmpDot = ArrayVertices[i + 1];
                    angle = Crossing(Begin, End, ArrayVertices[i], TmpDot, ref Cross);
                    if ((angle != 0) && (!IsCut(ArrayVertices[i], TmpDot, End)))
                    {
                        dist = Math.Sqrt(Math.Pow(Cross.X - Begin.X, 2) + Math.Pow(Cross.Y - Begin.Y, 2));
                        if ((dist < min) && (dist != 0))
                        {
                            Min_Cross = Cross;
                            min = dist;
                            index = i;
                            alpha = angle;
                        }


                    }
                }
            }
            return alpha;

        }
        override public bool Intersect(PointF Begin_in, PointF End_in)
        {
            PointF Cross = new PointF();
            PointF TmpDot = new PointF();
            double angle = 0;
            GraphicsPath PrismContour = new GraphicsPath();
            PrismContour.AddPolygon(ArrayVertices);
            for (int i = 0; i != ArrayVertices.Length; i++)
            {
                if (i == ArrayVertices.Length - 1)
                    TmpDot = ArrayVertices[0];
                else
                    TmpDot = ArrayVertices[i + 1];
                angle = Crossing(Begin_in, End_in, ArrayVertices[i], TmpDot, ref Cross);
                if (angle != 0)
                    return true;
            }
            if ((PrismContour.IsVisible(Begin_in)) && (PrismContour.IsVisible(End_in)))
                return true;
            return false;

        }
        public double Crossing(PointF Begin_in, PointF End_in, PointF Begin, PointF End, ref PointF Dot)
        {
            float a_in = End_in.X - Begin_in.X, b_in = End_in.Y - Begin_in.Y, c_in = -1 * a_in * Begin_in.Y + b_in * Begin_in.X;
            float a = End.X - Begin.X, b = End.Y - Begin.Y;
            float c = -1 * a * Begin.Y + b * Begin.X;
            float x = 0, y = 0;
            double alpha = 0;
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
                if ((IsCut(Begin, End, new PointF(x, y))) && (IsCut(Begin_in, End_in, new PointF(x, y))))
                {
                    double nominator = (End.X - Begin.X) * (End_in.X - Begin_in.X) + (End.Y - Begin.Y) * (End_in.Y - Begin_in.Y);
                    double sqrt_1 = Math.Sqrt(Math.Pow((End.X - Begin.X), 2) + Math.Pow((End.Y - Begin.Y), 2));
                    double sqrt_2 = Math.Sqrt(Math.Pow((End_in.X - Begin_in.X), 2) + Math.Pow((End_in.Y - Begin_in.Y), 2));
                    double cos = 0;
                    Dot.X = x;
                    Dot.Y = y;
                    cos = nominator / (sqrt_1 * sqrt_2);

                    alpha = Math.Acos(cos);

                    return alpha;
                }
                Dot.X = x;
                Dot.Y = y;


            }
            return 0;


        }
        public bool IsCut(PointF Begin, PointF End, PointF Dot)
        {
            bool flag = false;

            if((Dot==Begin)||(Dot==End))
                return false;
            if ((Begin.X <= End.X) && (Dot.X >= Begin.X) && (Dot.X <= End.X))
                flag = true;
            else if ((Begin.X >= End.X) && (Dot.X <= Begin.X) && (Dot.X >= End.X))
                flag = true;
            if ((Begin.Y <= End.Y) && (Dot.Y >= Begin.Y) && (Dot.Y <= End.Y) && flag)
                return true;
            if ((Begin.Y >= End.Y) && (Dot.Y <= Begin.Y) && (Dot.Y >= End.Y) && flag)
                return true;

            return false;
        }
        public bool IsReflection(double n_1, double n_2, double corner)
        {
            double tmp = Math.Abs(n_1 * Math.Sin(Math.PI / 2 - corner));
            if (tmp >= n_2)
                return true;
            return false;

        }
        public double RefractAngle(double n_1, double n_2, double corner)
        {
            double sin = n_1 * Math.Sin(Math.PI / 2 - corner) / n_2;
            return Math.PI / 2 - corner - Math.Asin(n_1 * Math.Sin(Math.PI / 2 - corner) / n_2);
        }
        public PointF Rotation(double Corner, PointF Begin_Ray, PointF End_Ray, PointF Begin, PointF End, int sign = 1)
        {
            /*float x_tmp = End_Ray.X - Begin_Ray.X, y_tmp = End_Ray.Y - Begin_Ray.Y;
            double alpha = Corner;
            if ((End.X - Begin.X) * (Begin_Ray.Y - End_Ray.Y) - (End.Y - Begin.Y) * (Begin_Ray.X - End_Ray.X) <= 0)
            {
                sign = -sign;
            }
            End_Ray.X = x_tmp * (float)Math.Cos(alpha) + sign * y_tmp * (float)Math.Sin(alpha);
            End_Ray.Y = -1 * sign * x_tmp * (float)Math.Sin(alpha) + y_tmp * (float)Math.Cos(alpha);
            End_Ray.X += Begin_Ray.X;
            End_Ray.Y += Begin_Ray.Y;

            return End_Ray;*/
            double x_tmp = End_Ray.X - Begin_Ray.X, y_tmp = End_Ray.Y - Begin_Ray.Y;
            double alpha =  Corner;
            if (((End.X - Begin.X) * (Begin_Ray.Y - End_Ray.Y) - (End.Y - Begin.Y) * (Begin_Ray.X - End_Ray.X) <= 0))
            {
                sign = -sign;
            }
            End_Ray.X =  (float)(x_tmp * Math.Cos(alpha) + sign * y_tmp * Math.Sin(alpha));
            End_Ray.Y =  (float)((-1) * sign * x_tmp * Math.Sin(alpha) + y_tmp * Math.Cos(alpha));
            double sqrt_2 = Math.Sqrt(Math.Pow((End_Ray.X - Begin_Ray.X), 2) + Math.Pow((End_Ray.Y - Begin_Ray.Y), 2));
            do
            {
                sqrt_2 = Math.Sqrt(Math.Pow((End_Ray.X - Begin_Ray.X), 2) + Math.Pow((End_Ray.Y - Begin_Ray.Y), 2));

                if ((sqrt_2 <= 2600))
                {
                    End_Ray.Y *= 2;
                    End_Ray.X *= 2;
                }
            } while (sqrt_2 <= 2600);
            End_Ray.X += Begin_Ray.X;
            End_Ray.Y += Begin_Ray.Y; 
            return End_Ray;
           
        }
        override public void Draw(System.Drawing.Graphics graphics)
        {
            graphics.DrawPolygon(new Pen(Color.DarkRed), ArrayVertices);

        }
    }
}

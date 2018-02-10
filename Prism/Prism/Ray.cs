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
    class Ray
    {
        PointF[] PointRay;
        public PointF GetDot
        {
            get { return PointRay[PointRay.Length - 2]; }
        }
        Color ColorRay;
        public Ray()
        {
        }
        Vectors vector;
        public Ray(PointF[] PointRayIn, Color ColorIn)
        {
            ColorRay = ColorIn;
            PointRay = new PointF[PointRayIn.Length];
            PointRay = PointRayIn;

        }
        public void ReceiverRay(Receiver obj)
        {
            PointF New_End = new PointF();
            PointF Cross = new PointF();
            if (obj.Crossing(PointRay[PointRay.Length - 2], PointRay[PointRay.Length - 1], ref Cross, ref New_End))
            {
                Array.Resize<PointF>(ref PointRay, PointRay.Length + 1);
                PointRay[PointRay.Length - 2] = Cross;
                PointRay[PointRay.Length - 1] = New_End;
            }

        }
  

        public void Draw(System.Drawing.Graphics graphics)
        {
            graphics.DrawLines(new Pen(ColorRay, 1), PointRay);

        }

        public void ReCreate()
        {
          
            PointF Begin = new PointF();
            PointF End = new PointF();

            Begin = PointRay[0];
            End.X = Begin.X;
            End.Y = 2000;

            List<PointF> PointList = new List<PointF>();
            PointList.Add(Begin);
            PointList.Add(End);
            Array.Resize<PointF>(ref PointRay, PointList.Count);
            PointList.ToArray().CopyTo(PointRay, 0);


        }
        public bool FindNearest(List<OpticObject> OpticObjecList_in,ref int index)
        {
            PointF tmp = new PointF();
            OpticObject obj = null;
            int j = -1;
            double dist = 0,dist_min =0;
            for(int i = 0;i!=OpticObjecList_in.Count;i++)
            {
                if (OpticObjecList_in[i] is Mirror)
                {
                    double corner = 0;
                    if(index != i)
                    corner = ((Mirror)OpticObjecList_in[i]).Crossing(PointRay[PointRay.Length - 2], PointRay[PointRay.Length - 1], ref tmp);
                    if ((corner != 0) && ((Math.Round(PointRay[PointRay.Length - 2].X) != Math.Round(tmp.X)) || (Math.Round(PointRay[PointRay.Length - 2].Y )!=Math.Round( tmp.Y))))
                        dist =  Math.Sqrt(Math.Pow(tmp.X-PointRay[PointRay.Length - 2].X,2)+Math.Pow(tmp.Y-PointRay[PointRay.Length - 2].Y,2));
                 }
                else if (OpticObjecList_in[i] is PrismObject)
                {
                    double corner = 0;
                    if (index != i)
                    corner = ((PrismObject)OpticObjecList_in[i]).FindCrossing(PointRay[PointRay.Length - 2], PointRay[PointRay.Length - 1], ref tmp, ref j);
                    if ((corner != 0) && ((Math.Round(PointRay[PointRay.Length - 2].X) != Math.Round(tmp.X)) || (Math.Round(PointRay[PointRay.Length - 2].Y) != Math.Round(tmp.Y))))
                    dist = Math.Sqrt(Math.Pow(tmp.X - PointRay[PointRay.Length - 2].X, 2) + Math.Pow(tmp.Y - PointRay[PointRay.Length - 2].Y, 2));
             
                }
                if (((dist_min == 0) || (dist < dist_min)) &&(dist!=0))
                {
                    dist_min = dist;
                    obj = OpticObjecList_in[i];
                    index = i;
                }
             
            }
            if (obj != null)
               return Invalidate(obj);

            index = OpticObjecList_in.Count;
            return false;

          
        }
        public bool Invalidate(OpticObject OpticObjec_in)
        {
            PointF tmp = new PointF(), tmp2 = new PointF();

            if (OpticObjec_in is Mirror)
            {
                if (((Mirror)OpticObjec_in).Invalidate(PointRay[PointRay.Length - 2], PointRay[PointRay.Length - 1], ref tmp, ref  tmp2))
                {
                    Array.Resize<PointF>(ref PointRay, PointRay.Length + 1);
                   PointRay[PointRay.Length - 1] = new PointF();
                    PointRay[PointRay.Length - 2] = new PointF();
                    PointRay[PointRay.Length - 1] = tmp2;
                    PointRay[PointRay.Length - 2] = tmp;
                    return true;
                }

            }
            else if (OpticObjec_in is PrismObject)
            {
                if (((PrismObject)OpticObjec_in).Invalidate(PointRay[PointRay.Length - 2], PointRay[PointRay.Length - 1], ref tmp, ColorRay))
                {
                  PointRay[PointRay.Length - 1] = new PointF();
                    PointRay[PointRay.Length - 1].X = tmp.X;
                    PointRay[PointRay.Length - 1].Y = tmp.Y;

                    return true;
                }
            }

            return false;
        }


    }
}

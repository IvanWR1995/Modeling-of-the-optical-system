using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Prism
{
    [Serializable]
    class Vectors

    {
        float  X, Y;
        public float Get_X 
        {
            get { return X; }
        }
        public float Get_Y 
        {
            get { return Y; }
        }

        public Vectors()
        {
            X = 0;
            Y = 0;
        }
        public Vectors(  Vectors obj)
        {
            X = obj.Get_X;
            Y = obj.Get_Y;
        }
        public Vectors(PointF Vec)
        {
            X = Vec.X;
            Y = Vec.Y;

        }
        public Vectors(PointF Begin ,PointF End)
        {
            X = End.X -Begin.X;
            Y = End.Y -Begin.Y;
        }
        public void ChangeVector(PointF Begin, PointF End)
        {
            X = End.X - Begin.X;
            Y = End.Y - Begin.Y;
        }
        public void Normalize()
        {
            float Len = (float)Math.Sqrt(Math.Pow((double)X, 2) + Math.Pow((double)Y, 2));
            X /= Len;
            Y /= Len;
        }
        public float Scalar(Vectors vec_in)
        {
            return vec_in.X * X + vec_in.Y * Y;
        }
        public void MultiplyDigit(float dig)
        {
            X *= (float)dig;
            Y *= (float)dig;
        }
        public static Vectors  operator+(Vectors vec_1,Vectors vec_2)
        {
            return new Vectors(new PointF(vec_1.X + vec_2.X, vec_1.Y + vec_2.Y));
        }
        
     }
}

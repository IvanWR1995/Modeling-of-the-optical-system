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
    class LightSource:OpticObject
    {
       
        List<Ray> RayList;
        List<Ray> RefractRayList, tmpRefractRayList;
        bool On_Off;
       public  bool GetSourceStatus
        {
            get 
            {
                return On_Off;
            }
        }
       public PointF GetLeftAngle
       {
           get 
           {
               return CoordReceiver[0];
           }
       }
        public int  GetLen
        {
            get
            {
                return Len;
            }
        }
        public Color GetColorRay
        {
            get
            {
                return RGB;
            }
        }
        public int GetCountRay
        {
            get 
            {
                return CountRay;
            }
 
        }
        [NonSerialized]
        GraphicsPath ClientSize;
        PointF[] CoordReceiver;
        int index_coal,CountRay,Len;
        Color RGB;
        public LightSource(PointF CoordIn, int len_in,GraphicsPath ClientSize_in)
        {
            RayList = new List<Ray>();
            RefractRayList = new List<Ray>();
            tmpRefractRayList = new List<Ray>();
            ClientSize = new GraphicsPath();
            ClientSize = ClientSize_in;
            Len = len_in;
            CoordReceiver = new PointF[4];
            CoordReceiver[0] = CoordIn;
            CoordReceiver[1].X = CoordIn.X;
            CoordReceiver[1].Y =CoordIn.Y+ 10;


            CoordReceiver[2].X = CoordIn.X + Len;
            CoordReceiver[2].Y = CoordIn.Y+10;
            CoordReceiver[3].X = CoordIn.X +Len;
            CoordReceiver[3].Y = CoordIn.Y;
            index_coal = 0;
            RGB = Color.White;
            On_Off = false;
        }

        override public void SetWindowRect(GraphicsPath RectWindow_in)
        {
            ClientSize = new GraphicsPath();
           ClientSize.AddPolygon(RectWindow_in.PathPoints);
        }
        public bool On()
        {
            On_Off = true;
            if (CountRay < Len / 2)
            {
                for (int i = 0; i != CountRay; i++)
                    CreateRay();
                return true;
            }
      
            return false;
 
        }
        public void Off()
        {
            On_Off = false;
            RefractRayList.Clear();
            RayList.Clear();
 
        }
        public bool ChangeSettings(int Len_in, int CountRay_in, Color RGB_in)
        {
            if (CountRay_in <= Len_in)
            {
                Len = Len_in;
                CountRay = CountRay_in;
                RGB = RGB_in;
                RefractRayList.Clear();
                RayList.Clear();
                if (On_Off)
                {
                    if (CountRay <=Len )
                    {
                        for (int i = 0; i != CountRay; i++)
                            CreateRay();
                    }
                    else
                        return false;

                }
                if (!(ClientSize.IsVisible(CoordReceiver[0].X + Len, CoordReceiver[0].Y)))
                    return false;
                 CoordReceiver[2].X =CoordReceiver[0].X  + Len;
                CoordReceiver[3].X = CoordReceiver[0].X + Len;
                
                return true;

            }
            CoordReceiver[2].X = CoordReceiver[0].X + Len;
            CoordReceiver[3].X = CoordReceiver[0].X + Len;

            return false;

        }
        override public bool Intersect(PointF Begin_in, PointF End_in)
        {
            return false;
        }
       override public MoveDelegate IsSelect(PointF ClickOn)
        {
            GraphicsPath SourcePath = new GraphicsPath();
            SourcePath.AddPolygon(CoordReceiver);
            if (SourcePath.IsVisible(ClickOn))
                return Move;
            for (int i = 0; i != CoordReceiver.Length; i++)
            {
                SourcePath = new GraphicsPath();
                SourcePath.AddEllipse(CoordReceiver[i].X - 2, CoordReceiver[i].Y - 2, 5, 5);
                if (SourcePath.IsVisible(ClickOn))
                {
                    if ((i == 0) || (i == 1))
                        index_coal = 0;
                    else
                        index_coal = 1;
                    return MoveTop;
                }
 
            }

            return null;
        }
       public void MoveTop(int x, int y, List<OpticObject> FigureList)
       {
           PointF Tmp = new PointF();
           for (int i =0 ; i != CoordReceiver.Length; i++)
           {

               if (i == CoordReceiver.Length - 1)
                   Tmp = CoordReceiver[0];
               else
                   Tmp = CoordReceiver[i + 1];
               if (ClientSize.IsVisible(CoordReceiver[i].X + x, CoordReceiver[i].Y + y) == false)
                   return;
           }
           if (index_coal == 0)
           {
               CoordReceiver[0].X += x;
               CoordReceiver[1].X += x;
           }
           else
           {
               CoordReceiver[2].X += x;
               CoordReceiver[3].X += x;
 
           }
           int count = RayList.Count;
           RayList.Clear();
           for (int i = 0; i != count; i++)
               CreateRay();
           
       }
        override public void Move(int Shifting_X, int Shifting_Y, List<OpticObject> FigureList)
        {
            PointF Tmp = new PointF();
            for (int i = 0; i != CoordReceiver.Length; i++)
            {
                if (i == CoordReceiver.Length - 1)
                    Tmp = CoordReceiver[0];
                else
                    Tmp = CoordReceiver[i + 1];
                if (ClientSize.IsVisible(CoordReceiver[i].X + Shifting_X, CoordReceiver[i].Y + Shifting_Y) == false)
                    return;
         
            }
            for (int i = 0; i != CoordReceiver.Length; i++)
            {
                CoordReceiver[i].X += Shifting_X;
            }
            int count = RayList.Count;
            RayList.Clear();
            for (int i = 0; i != count; i++)
                CreateRay();

        }
        public void CreateRefractRay(Ray Ray_in)
        {
            tmpRefractRayList.Add(Ray_in);
        }
        public void DeleteRefractRay()
        {
            if (RefractRayList.Count != 0)
                RefractRayList.Clear();

        }
        public void CreateRay( )
        {

        
            PointF[] NewRayDots = new PointF[2];
            NewRayDots[0].Y = CoordReceiver[0].Y;
            NewRayDots[0].X = CoordReceiver[0].X + RayList.Count;
            NewRayDots[1].X = NewRayDots[0].X ;
            NewRayDots[1].Y = 2500;
            RayList.Add(new Ray(NewRayDots, RGB));
            
            }

        public void ChangeRays(List<OpticObject> ListOpticObject,Receiver LightReceiver)
        {
           
            OpticObject[] tmp_array = new OpticObject[ListOpticObject.Count];
            Array.Copy(ListOpticObject.ToArray(), tmp_array, tmp_array.Length);
            int tmp = tmp_array.Length, index = ListOpticObject.Count;
                RefractRayList.Clear();
            tmpRefractRayList.Clear();

            foreach (Ray Ray_index in RayList)
            {
                Ray_index.ReCreate();

                do
                {
                    if (!Ray_index.FindNearest(ListOpticObject, ref index))
                        break;
                } while (true);


            }
            index = ListOpticObject.Count;
            foreach (Ray index_ray in tmpRefractRayList)
            {
                RefractRayList.Add(index_ray);
            }
            tmpRefractRayList.Clear();

           
          do
          {
                foreach (Ray Ray_index in RefractRayList)
                {


                    do
                    {
                        if (!Ray_index.FindNearest(ListOpticObject, ref index))
                            break;
                    } while (true);

                }
                if (tmpRefractRayList.Count == 0)
                    break;
                foreach (Ray index_ray in tmpRefractRayList)
                {
                    RefractRayList.Add(index_ray);
                }
                tmpRefractRayList.Clear();
              }while(true);
          foreach (Ray Ray_index in RefractRayList)
          {
              Ray_index.ReceiverRay(LightReceiver);
          }
          foreach (Ray Ray_index in RayList)
          {
              Ray_index.ReceiverRay(LightReceiver);
          }
     
        }
        override public bool IsMyVisible(PointF Dot)
        {
            GraphicsPath PrismPolygon = new GraphicsPath();

            PrismPolygon.AddPolygon(CoordReceiver);
            if (PrismPolygon.IsVisible(Dot))
                return true;
            return false;
        }
      override  public void Draw(System.Drawing.Graphics graphics)
        {
            graphics.DrawPolygon(new Pen(Color.Black),CoordReceiver);
            foreach (Ray index in RayList)
            {
                index.Draw(graphics);
            }
            foreach (Ray index in RefractRayList)
            {
                index.Draw(graphics);
            }
        }

    }
}

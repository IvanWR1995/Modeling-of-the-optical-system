using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace Prism
{
    [Serializable]
    class ViewController
    {

    
        List<Mirror> MirrorList;
        List<PrismObject> PrismObjectList;
        List<OpticObject> ListOpticObject;
        LightSource ReceiverObject;
        Receiver LightReceiver;
        
        OpticObject.MoveDelegate obj_ret;
        [NonSerialized]
        GraphicsPath RectWindow;
        int IndexMirror;
        public LightSource GetSource
        {   
            get
            {
                return ReceiverObject;
            }
        }
        public ViewController()
        { 
           

        }
        public ViewController(PointF[] RectWindow_in)
        {
            MirrorList = new List<Mirror>();
            PrismObjectList = new List<PrismObject>();

            ListOpticObject = new List<OpticObject>();

            LightReceiver = new Receiver(RectWindow_in[RectWindow_in.Length - 2].X, RectWindow_in[RectWindow_in.Length - 2].Y);
            RectWindow = new GraphicsPath();
            RectWindow_in[1].Y -= 20;
            RectWindow_in[2].Y -= 20;
            RectWindow.AddPolygon(RectWindow_in);
            PointF tmp = new PointF(10, RectWindow_in[0].Y);
            obj_ret = null;
            ReceiverObject = new LightSource(tmp, 100,RectWindow);
            PointF[] ArrayMy = new PointF[3];
            ArrayMy[0].X = 350;
            ArrayMy[0].Y = 100;
            ArrayMy[1].X = 250;
            ArrayMy[1].Y = 300;
            ArrayMy[2].X = 350;
            ArrayMy[2].Y = 300;
     
        }
        
       public  void  SetWindowRect(GraphicsPath RectWindow_in)
       {
           RectWindow = new GraphicsPath();
           RectWindow = RectWindow_in;
           foreach (OpticObject index in ListOpticObject)
               index.SetWindowRect(RectWindow_in);
           ReceiverObject.SetWindowRect(RectWindow_in);
       }
        public bool CreatePrism(PointF[] ArrayVert_In, float n_R, float n_G, float n_B, string namePrism)
        {
            PointF tmp = new PointF();
            for (int i = 0; i != ArrayVert_In.Length; i++)
            {
                if (i == ArrayVert_In.Length - 1)
                    tmp = ArrayVert_In[0];
                else
                    tmp = ArrayVert_In[i + 1];

                if (!CanCreate(ArrayVert_In[i], tmp))
                    return false;
            }
             ListOpticObject.Add(new PrismObject(ArrayVert_In, ReceiverObject.CreateRefractRay, n_R, n_G, n_B, RectWindow, namePrism));
             ReceiverObject.ChangeRays(ListOpticObject, LightReceiver); 
            return true;
        }
        public bool  RedactPrism(PointF[] ArrayVert_In, float n_R, float n_G, float n_B, string namePrism)
        {
            PointF Tmp_Dot = new PointF();

            for (int i = 0; i != ArrayVert_In.Length; i++)
            {
                if (i == ArrayVert_In.Length - 1)
                    Tmp_Dot = ArrayVert_In[0];
                else
                    Tmp_Dot = ArrayVert_In[i + 1];

                if (!CanCreate(ArrayVert_In[i], Tmp_Dot,namePrism))
                    return false;
            }
            OpticObject tmp = ListOpticObject.Find(delegate(OpticObject Curent)
            {
                
                if (Curent is PrismObject)
                    return ((PrismObject)Curent).Name == namePrism;
                return false;
            }
           );

            ((PrismObject)tmp).RedactPrism(ArrayVert_In, n_R, n_G, n_B);
            ReceiverObject.ChangeRays(ListOpticObject, LightReceiver);
            return true;
        }
        public List<string> GetListMirror()
        {
            List<string> ListNameMirror = new List<string>();
            foreach (OpticObject index in ListOpticObject)
            {
                if(index is Mirror)
                {
                    ListNameMirror.Add(((Mirror)index).Name);
                }
            }
            return ListNameMirror;

        }
        public List<string> GetListPrism()
        {
            List<string> ListNameMirror = new List<string>();
            foreach (OpticObject index in ListOpticObject)
            {
                if (index is PrismObject)
                {
                    ListNameMirror.Add(((PrismObject)index).Name);
                }
            }
            return ListNameMirror;

        }
        public bool On()
        {
            if (ReceiverObject.On())
            {
                ReceiverObject.ChangeRays(ListOpticObject, LightReceiver);
         
                return true;
            }
            return false;
 
        }
        public void Off()
        {
            ReceiverObject.Off();
        }
        public bool ChangeSettings(int Len_in, int CountRay_in, Color RGB_in)
        {
           if( ReceiverObject.ChangeSettings(Len_in,CountRay_in,RGB_in))
           {
             ReceiverObject.ChangeRays(ListOpticObject, LightReceiver);
             return true;
           }
           return false;
        }
        public string IsVisibleMy(PointF Dot)
        {
            foreach (OpticObject index in ListOpticObject)
            {
                if (index.IsMyVisible(Dot))
                {
                    if (index is Mirror)
                        return ((Mirror)index).Name;
                    if (index is PrismObject)
                        return ((PrismObject)index).Name;
                }
            }
            if (LightReceiver.IsMyVisible(Dot))
                return "Приемник";
            if (ReceiverObject.IsMyVisible(Dot))
                return "Источник";
            return null;
        }
        public bool CanCreate(PointF Begin, PointF End,string NameObj = null)
        {
            if ((!RectWindow.IsVisible(Begin)) || (!RectWindow.IsVisible(End)))
                return false;
            foreach (OpticObject index in ListOpticObject)
            {
                if (index.Intersect(Begin, End))
                {
                    if (index is PrismObject)
                    {
                        if (((PrismObject)index).Name != NameObj)
                            return false;
 
                    }
                    else 
                        return false;
                }
             }
            return true;
         }
        
        public bool CreateMirror(PointF Begin, PointF End,string NameMirror)
        {
            if (CanCreate(Begin, End))
            {
                IndexMirror++;
                ListOpticObject.Add(new Mirror(Begin, End, RectWindow, NameMirror));

                ReceiverObject.ChangeRays(ListOpticObject, LightReceiver);
                return true;
           
            }
           
            return false;
        }
        public void DeleteObject(string index)
        { 
           OpticObject  tmp = ListOpticObject.Find(delegate(OpticObject Curent)
            {
                if(Curent is Mirror)
                return ((Mirror)Curent).Name == index;
                if (Curent is PrismObject)
                    return ((PrismObject)Curent).Name == index;
                return false;   
            }
            );
           ListOpticObject.Remove(tmp);
           ReceiverObject.ChangeRays(ListOpticObject, LightReceiver);
        }
        public bool ChangeMirror(PointF Begin, PointF End,string index)
        {
               OpticObject tmp = ListOpticObject.Find(delegate(OpticObject Curent)
                {
                    if (Curent is Mirror)
                        return ((Mirror)Curent).Name == index;
                    return false;
                });
             if(((Mirror)tmp).Change(Begin, End, ListOpticObject))
             {
                 ReceiverObject.ChangeRays(ListOpticObject, LightReceiver);
                 return true;
             }

            return false;
               
           
        }
        public PointF[] FindMirror(string index)
        {
            PointF[] ArrayDots = null;
           OpticObject tmp = ListOpticObject.Find(delegate(OpticObject Curent)
            {
                if(Curent is Mirror)
                return ((Mirror)Curent).Name == index;
                 return ((PrismObject)Curent).Name == index;
             }
            );
           if (tmp is Mirror)
           {
                ArrayDots = new PointF[2] { ((Mirror)tmp).GetBegin, ((Mirror)tmp).GetEnd };
           }
       
            return ArrayDots;
        }
        public PointF[] FindPrism(string index,ref float [] RGB_Coef)
        {
            OpticObject tmp = ListOpticObject.Find(delegate(OpticObject Curent)
            {
                if (Curent is Mirror)
                    return ((Mirror)Curent).Name == index;
                return ((PrismObject)Curent).Name == index;
            }
            );
            if (tmp is PrismObject)
            {
                RGB_Coef[0] = ((PrismObject)tmp).GetRedCoef;
                RGB_Coef[1] = ((PrismObject)tmp).GetGreenCoef;
                RGB_Coef[2] = ((PrismObject)tmp).GetBlueCoef;
                return ((PrismObject)tmp).ArrayPrism;
            }
            return null;
 
        }

        public bool GetSourceStatus()
        {
            return ReceiverObject.GetSourceStatus;
        }
        public PointF GetLAngleSource()
        {
            return ReceiverObject.GetLeftAngle;
        }
    
        public bool IsSelected(Point ClickOn)
        {
            foreach (OpticObject tmp in ListOpticObject)
                {

                    obj_ret =tmp.IsSelect(ClickOn);
                if(obj_ret!=null)
                    return true;
                }
            
            obj_ret= ReceiverObject.IsSelect(ClickOn);
                if(obj_ret!=null)
                    return true;
            
            return false; 

        }
        public void MoveOrDeform(int shift_x,int shift_y)
        {
            if (obj_ret != null)
            {
                obj_ret(shift_x, shift_y,ListOpticObject);

                ReceiverObject.ChangeRays(ListOpticObject, LightReceiver);
            }
           
        }
        public void Draw(System.Drawing.Graphics  graphics)
        {
            foreach (OpticObject tmp in ListOpticObject)
                tmp.Draw(graphics);
          ReceiverObject.Draw(graphics);
          LightReceiver.Draw(graphics);
     
        }
  
    }
   
}

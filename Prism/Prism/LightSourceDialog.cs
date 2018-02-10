using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prism
{
    public partial class LightSourceDialog : Form
    {
       public  bool flag_OnOff
        {
            get;set;

        }
        PointF LeftTopAngle;
       public PointF SetLAngle
       {
           set
           {
               LeftTopAngle = value;
           }
       }
        public delegate bool SwitchOn();
        public delegate void SwitchOff( );
        public delegate void InvalidateMainForm();
        public delegate bool SetSetting(int Len_in, int CountRay_in, Color RGB_in);
        public SwitchOn SourceOn;
        public InvalidateMainForm InvalidateForm_1;
        public SwitchOff SourceOff;
        public SetSetting ChangeSetting;
        
        public LightSourceDialog()
        {
            
            InitializeComponent();
        }

        private void LightSourceDialog_Load(object sender, EventArgs e)
        {

        }

        public void InitLightSource(int Len_in, int CountRay_in, Color RGB_in,PointF BeginCoord)
        {
            CountRay.Text = CountRay_in.ToString();
            RedPortion.Text = RGB_in.R.ToString();
            GreenPortion.Text = RGB_in.G.ToString();
            BluePortion.Text = RGB_in.B.ToString();
            LenSource.Text = Len_in.ToString();
 
 
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!flag_OnOff)
            {
                SourceOn();
                OnOffButton.Text = "Выключить";
                flag_OnOff = true;
                InvalidateForm_1();
            }
            else
            {
                SourceOff();
                OnOffButton.Text = "Включить";
                flag_OnOff = false;
                InvalidateForm_1();
 
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            int len; 
            int count;
            Color RaysColor;
            try
            {
                len = Convert.ToInt16(LenSource.Text);
                if ((len >= 1380)||(len<=0))
                {
                    MessageBox.Show("Длинна источника может быть только в диапазоне [0;1380] ",
                                            "Ошибка",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                    return;
                }
               
            }
            catch (FormatException)
            {
                MessageBox.Show("Длинна источника может быть только числовым целочисленным значением",
                                             "Ошибка",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Warning);

                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Длинна источника может быть только в диапазоне [0;1380] ",
                                             "Ошибка",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Warning);

                return;
            }
            try
            {
                count = Convert.ToInt16(CountRay.Text);

            }
            catch (FormatException)
            {
                MessageBox.Show("Количество лучей может быть только числовым целочисленным значением",
                                              "Ошибка",
                                              MessageBoxButtons.OK,
                                              MessageBoxIcon.Warning);

                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Превышено максимальное значеие количества лучей для данной длины источника и длинна источник не должен фыходить за границы формы",
                                              "Ошибка",
                                              MessageBoxButtons.OK,
                                              MessageBoxIcon.Warning);
                return;

 
            }
             try
             {
                 RaysColor = Color.FromArgb(Convert.ToInt16(RedPortion.Text), Convert.ToInt16(GreenPortion.Text), Convert.ToInt16(BluePortion.Text));
             }
             catch (ArgumentException)
             {
                 MessageBox.Show("Значения цвета должно быть больше 0 и меньше 255.Повторите попытку ",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                 return;
             }
             catch (FormatException)
             {
                 MessageBox.Show("Значения цвета может принимать только целочисленные числовые значения в диапазоне[0;255].Повторите попытку ",
                                              "Ошибка",
                                              MessageBoxButtons.OK,
                                              MessageBoxIcon.Warning);

                 return;
             }
             catch (OverflowException)
             {
                 MessageBox.Show("Значения цвета должно быть больше 0 и меньше 255.Повторите попытку ",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                 return;
 
             }
             if (!ChangeSetting(len, count, RaysColor))
             {
                 MessageBox.Show("Превышено максимальное значеие количества лучей для данной длины источника и длинна источник не должен фыходить за границы формы",
                                               "Ошибка",
                                               MessageBoxButtons.OK,
                                               MessageBoxIcon.Warning);

                 return;
             }
            InvalidateForm_1();
        }

        private void LightSourceDialog_Paint(object sender, PaintEventArgs e)
        {

            BeginText_X.Text = LeftTopAngle.X.ToString();
            BeginText_Y.Text = LeftTopAngle.Y.ToString();
            if (flag_OnOff)
                OnOffButton.Text = "Выключить";
            else
                OnOffButton.Text = "Включить";
           
        }

        private void CountRay_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

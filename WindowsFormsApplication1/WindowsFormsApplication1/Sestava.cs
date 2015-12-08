using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Sestava
    {
        double celkemRTP;
        Form1 mForm;
        double ciloveRTP;
        double prumernaVyhra;
       static List <Zaznam> listZaznamu=new List<Zaznam>();
       // List<int> list = new List<int>();


        public Sestava(double _ciloveRtp,Form1 _mForm)
        {
            ciloveRTP = _ciloveRtp;
            mForm = _mForm;

        }
        public double getCiloveRTP()
        {
            return ciloveRTP;
        }
        public void AddZaznam(string _nazev,int _rozsahTrackbaru,double _rtp,double _vyhra,Form1 _mForm)
        {
            listZaznamu.Add(new Zaznam( _nazev, _rozsahTrackbaru,_rtp,  _vyhra, _mForm));
        }
        public void AddPodZaznam(string _nazev, int _rozsahTrackbaru,double _rtp, double _vyhra, Form1 _mForm)
        {
            if (!listZaznamu.Last().MaPodzaznam()) mForm.setEventHandler(listZaznamu.Last());
            listZaznamu.Last().AddPodZaznam(_nazev, _rozsahTrackbaru, _rtp, _vyhra, _mForm);
           //listZaznamu.Last().lNazev.Click += new EventHandler(mForm.linkLabel_Click);
            
        
        }
        public List<Zaznam> GetZaznamy()
        {
            return listZaznamu;
        } 
        public void ShowControls()
        {
            Point tempPoint = new Point(20,20);
            Point tempPoint2 = new Point();

            foreach (Zaznam z in listZaznamu)
            {
                z.lNazev.Location = tempPoint;
                z.lNazev.Width = 120;
                tempPoint2 = tempPoint;
                tempPoint2.X = tempPoint2.X + z.lNazev.Width;
                
                if (!z.MaPodzaznam()) z.lNazev.LinkColor = Color.Black;
                else z.lNazev.LinkColor = Color.Blue;
                //pridavani do formu
                mForm.Controls.Add(z.lNazev);

                //trackbar
                z.TRtp.Location = tempPoint2;
                z.TRtp.Tag = z.lNazev.Text;
                z.TRtp.Value = Convert.ToInt32(z.rtp*100);
                mForm.Controls.Add(z.TRtp);

                //label RTP
                tempPoint2.X = tempPoint2.X + z.TRtp.Width;
                z.lRtp.Text = ((double)z.TRtp.Value / 100).ToString();
                z.lRtp.Width = z.lNazev.Width / 3;
                z.lRtp.Location = tempPoint2;
                mForm.Controls.Add(z.lRtp);
                //textbox
                tempPoint2.X = tempPoint2.X + z.lRtp.Width;
                z.TBVyhra.Location = tempPoint2;
                z.TBVyhra.Text = z.vyhra.ToString();
                mForm.Controls.Add(z.TBVyhra);
                //lotackz
                tempPoint2.X= tempPoint2.X + z.TBVyhra.Width;
                z.lOtacky.Location = tempPoint2;
                z.lOtacky.Text = (1 /(( z.rtp * 5) /( 100 * z.vyhra)    )).ToString();
                mForm.Controls.Add(z.lOtacky);
                
                z.levyHorni = z.lNazev.Location;
                z.vyskaZaznamu = z.TRtp.Height;
                z.LevySpodni = new Point(z.lNazev.Location.X, z.lNazev.Location.Y + z.vyskaZaznamu);
                // z.LevySpodni = tempPoint;

                tempPoint = z.LevySpodni;
            }
        }



    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Zaznam
    {
        //string nazev;
      
        List<Zaznam> listPodZaznamu = new List<Zaznam>();
        Form mForm;
        float rtp;
        float vyhra;
        //Controls
        public Label lNazev;
        public TrackBar TRtp;
        public Label lRtp;
        public Label lWin;
        public Label lOtacky;
        //umisteni
        Point levyHorni;
        Point LevySpodni;

        public Zaznam(string _nazev,int _rozsahTrackbaru,float _vyhra,Form _mForm)
        {
            
            lNazev = new Label();
            TRtp = new TrackBar();

            lNazev.Text = _nazev;
            TRtp.Maximum = _rozsahTrackbaru;

            vyhra = _vyhra;
            mForm = _mForm;
        }
        public void AddPodZaznam(string _nazev, int _rozsahTrackbaru, float _vyhra, Form _mForm)
        {
            listPodZaznamu.Add(new Zaznam(_nazev, _rozsahTrackbaru, _vyhra, _mForm));
        }
        



    }
}
 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Zaznam
    {
        //string nazev;
      
        List<Zaznam> listPodZaznamu = new List<Zaznam>();
        Form1 mForm;
        public double rtp;
        public double vyhra;
        //Controls
        public LinkLabel lNazev;
        public TrackBar TRtp;
        public Label lRtp;
        public Label lWin;
        public Label lOtacky;
        public TextBox TBVyhra;
        //umisteni
       public Point levyHorni;
        public Point LevySpodni;
       public int vyskaZaznamu;

        public Zaznam(string _nazev,int _rozsahTrackbaru,double _rtp,double _vyhra,Form1 _mForm)
        {
            
            lNazev = new LinkLabel();
            TRtp = new TrackBar();
            lRtp = new Label();
            TBVyhra = new TextBox();
            lOtacky = new Label();

            lNazev.Text = _nazev;
            TRtp.Maximum = _rozsahTrackbaru;

            //TRtp.cha
            rtp = _rtp;
            vyhra = _vyhra;
            mForm = _mForm;

        }
        public void AddPodZaznam(string _nazev, int _rozsahTrackbaru,double _rtp, double _vyhra, Form1 _mForm)
        {
            listPodZaznamu.Add(new Zaznam(_nazev, _rozsahTrackbaru,_rtp, _vyhra, _mForm));
        }
        public List<Zaznam> GetPodZaznamy()
        {
            return listPodZaznamu;
        }
        internal bool MaPodzaznam()
        {
            if (listPodZaznamu.Count != 0) return true;
            else return false;
        }
    }
}
 
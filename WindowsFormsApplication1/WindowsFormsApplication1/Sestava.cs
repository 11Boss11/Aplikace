using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Sestava
    {
        float celkemRTP;
        Form mForm;
        float ciloveRTP;
        float prumernaVyhra;
        List <Zaznam> listZaznamu=new List<Zaznam>();
       // List<int> list = new List<int>();


        public Sestava(float _ciloveRtp,Form _mForm)
        {
            ciloveRTP = _ciloveRtp;
            mForm = _mForm;

        }

        public void AddZaznam(string _nazev,int _rozsahTrackbaru,float _vyhra,Form _mForm)
        {
            listZaznamu.Add(new Zaznam( _nazev, _rozsahTrackbaru,  _vyhra, _mForm));
        }
        public void AddPodZaznam(string _nazev, int _rozsahTrackbaru, float _vyhra, Form _mForm)
        {
            listZaznamu.Last().AddPodZaznam(_nazev, _rozsahTrackbaru, _vyhra, _mForm);
        
        }
        public void ShowControls()
        {
            foreach (Zaznam z in listZaznamu)
            {
                
            }
        }



    }
}

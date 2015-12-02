﻿using System;
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
        float celkemRTP;
        Form1 mForm;
        float ciloveRTP;
        float prumernaVyhra;
       static List <Zaznam> listZaznamu=new List<Zaznam>();
       // List<int> list = new List<int>();


        public Sestava(float _ciloveRtp,Form1 _mForm)
        {
            ciloveRTP = _ciloveRtp;
            mForm = _mForm;

        }

        public void AddZaznam(string _nazev,int _rozsahTrackbaru,float _vyhra,Form1 _mForm)
        {
            listZaznamu.Add(new Zaznam( _nazev, _rozsahTrackbaru,  _vyhra, _mForm));
        }
        public void AddPodZaznam(string _nazev, int _rozsahTrackbaru, float _vyhra, Form1 _mForm)
        {
            if (!listZaznamu.Last().MaPodzaznam()) mForm.setEventHandler(listZaznamu.Last());
            listZaznamu.Last().AddPodZaznam(_nazev, _rozsahTrackbaru, _vyhra, _mForm);
           //listZaznamu.Last().lNazev.Click += new EventHandler(mForm.linkLabel_Click);
            
        
        }
        public List<Zaznam> GetZaznamy()
        {
            return listZaznamu;
        } 
        public void ShowControls()
        {
            foreach (Zaznam z in listZaznamu)
            {
                z.lNazev.Left = 20;
                if (!z.MaPodzaznam()) z.lNazev.LinkColor = Color.Black;
                else z.lNazev.LinkColor = Color.Blue;
                z.lNazev.AutoSize = true;
                //z.lNazev 
                mForm.Controls.Add(z.lNazev);
                z.levyHorni = z.lNazev.Location;
                z.LevySpodni = new Point(z.lNazev.Location.X, z.lNazev.Location.Y + z.lNazev.Height);


                /*abel NewLabel = new Label();
            NewLabel.Width = 50; // Space little less than 2/3
            NewLabel.Height = 25;
            NewLabel.Left = 0; // Start at the left edge of the panel1
            NewLabel.Top = TopValue;
            this.Controls.Add(NewLabel);
            NewLabel.TextAlign = ContentAlignment.MiddleRight;
            NewLabel.Text = LabelName;*/
            }
        }



    }
}

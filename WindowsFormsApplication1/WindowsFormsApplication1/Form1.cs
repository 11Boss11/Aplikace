using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
       
        private TrackBar trackbar1;
        static int pocet = 3;
        static int pocetLink = 2;
        private Label[] labelField = new Label[pocet];
        private Label[] labelField2 = new Label[pocet];
        private LinkLabel[] linkLabelField = new LinkLabel[pocetLink];
        int[] linkPole = new int[3];


        //SESTAVA
        Sestava S;





        public Form1()
        {
            InitializeComponent();
            // work();
            S = new Sestava(95,this);
            S.AddZaznam("Zaklad", 100, 324, this);
            S.AddPodZaznam("cau", 100, 324, this);
            S.AddPodZaznam("neco", 100, 324, this);
            S.AddPodZaznam("necoDalsiho", 100, 324, this);
            
            S.AddZaznam("Hvezda", 100, 324, this);
            S.AddPodZaznam("cau", 100, 324, this);
            S.AddPodZaznam("neco", 100, 324, this);
            S.AddPodZaznam("necoDalsiho", 100, 324, this);

            S.ShowControls();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //creating labels
      
        public void setEventHandler(Zaznam zaznam)
        {
            zaznam.lNazev.Click += new EventHandler(this.linkLabel_Click);
        }
        
        private void linkLabel_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("CLICK");
              LinkLabel l = sender as LinkLabel;
              Zaznam linkZaznam;
              Point tempPoint = new Point();

            List<Zaznam> tempList = S.GetZaznamy();
            linkZaznam = tempList.Last();

            //hledam svuj zaznam
            foreach (Zaznam z in tempList)
            {

                // TODO misto switche dej jako tuhle podminku dole
                if (z.lNazev.Text == l.Text)
                {
                    //MessageBox.Show("Prochazim zaznam "+z.lNazev.Text);
                    tempPoint = z.LevySpodni;
                    tempPoint.X = tempPoint.X + 5;
                    linkZaznam = z;
                    tempList = z.GetPodZaznamy();

                    break;
                }
                // TODO exception
                else
                {
                    MessageBox.Show("ERROR");
                    return;
                }
            }

            #region Show
            if (l.LinkColor == Color.Blue)
              {

                  l.LinkColor = Color.Red;
                  //prochazim podzaznamy
                  foreach (Zaznam z in tempList)
                  {
                    z.lNazev.LinkColor = Color.Black;
                    z.lNazev.Location = tempPoint;
                    z.lNazev.AutoSize = true;
                    this.Controls.Add(z.lNazev);

                    tempPoint.Y = tempPoint.Y + z.lNazev.Height;
                     
                  }
                  linkZaznam.LevySpodni = tempPoint;

              }
            #endregion Show
            #region Hide
            else
            {
                  l.LinkColor = Color.Blue;

                foreach (Zaznam z in tempList)
                {
              
                   // this.Controls.Add(z.lNazev);
                    z.lNazev.Dispose();

                   // tempPoint.Y = tempPoint.Y + z.lNazev.Height;

                }
               // linkZaznam.LevySpodni = tempPoint;

            }
            #endregion Hide

            /*switch (l.Text)
            {
                case "Zaklad":
                    {


                        break;
                    }
                case "Hvezda":
                    {

                        break;
                    }
                case "Sedm":
                    {

                        break;
                    }

        }
        */


            // MessageBox.Show("END");
        }






    }
}

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
       
     /*   private TrackBar trackbar1;
        static int pocet = 3;
        static int pocetLink = 2;
        private Label[] labelField = new Label[pocet];
        private Label[] labelField2 = new Label[pocet];
        private LinkLabel[] linkLabelField = new LinkLabel[pocetLink];
        int[] linkPole = new int[3];
*/

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
            int tempVzdalenost = 0;

            List<Zaznam> tempList = S.GetZaznamy();
            linkZaznam = tempList.Last();
            List<Zaznam> tempLinkList = S.GetZaznamy();

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
                    z.vyskaZaznamu = z.lNazev.Height;
                    tempPoint.Y = tempPoint.Y + z.vyskaZaznamu;
                    tempVzdalenost += z.vyskaZaznamu;
                     
                  }
                  linkZaznam.LevySpodni = tempPoint;
              
                preskup(tempLinkList, linkZaznam, tempVzdalenost);

              }
            #endregion Show
            #region Hide
            else
            {
                  l.LinkColor = Color.Blue;

                foreach (Zaznam z in tempList)
                {
                    
                    linkZaznam.LevySpodni.Y = linkZaznam.LevySpodni.Y - linkZaznam.vyskaZaznamu;
                    tempVzdalenost -= z.vyskaZaznamu;                    
                    // TODO mozna predelat na hide
                    this.Controls.Remove(z.lNazev);


                }
                linkZaznam.LevySpodni.X = linkZaznam.LevySpodni.X - 5;
                
                preskup(tempLinkList, linkZaznam, tempVzdalenost) ;


            }
            #endregion Hide

        }


        private void posunZaznam(Zaznam z,int yVzdalenost)
        {
            Point tempPoint = new Point();
            z.levyHorni.Y = z.levyHorni.Y + yVzdalenost;
            z.LevySpodni.Y = z.LevySpodni.Y + yVzdalenost;
            tempPoint.X = z.lNazev.Location.X;
            tempPoint.Y = z.lNazev.Location.Y + yVzdalenost;
            z.lNazev.Location = tempPoint;

        }
        private void preskup(List<Zaznam> listZaznamu,Zaznam zaznam,int vzdalenost)
        {
            
            Point tempPoint = new Point();
            int tempVzdalenost = 0;
            bool tempBool = false;
            
            //hledam svuj zaznam
            for(int i=0;i<listZaznamu.Count();i++)
            {
               // MessageBox.Show("Pracuji " + listZaznamu[i].lNazev.Text+" "+zaznam.lNazev.Text+"/n");
                if (listZaznamu[i].lNazev.Text == zaznam.lNazev.Text) tempBool = true;
                else if(tempBool)
                {
                    
                    posunZaznam(listZaznamu[i], vzdalenost);
                    /*  listZaznamu[i].levyHorni.Y = listZaznamu[i].levyHorni.Y + vzdalenost;
                      listZaznamu[i].LevySpodni.Y = listZaznamu[i].LevySpodni.Y + vzdalenost;
                      tempPoint.X = listZaznamu[i].lNazev.Location.X;
                      tempPoint.Y = listZaznamu[i].lNazev.Location.Y + vzdalenost;
                      listZaznamu[i].lNazev.Location = tempPoint;
                      */
                    if (listZaznamu[i].lNazev.LinkColor == Color.Red)
                    {
                        tempPoint = listZaznamu[i].LevySpodni;

                        foreach (Zaznam z in listZaznamu[i].GetPodZaznamy())
                        {
                            posunZaznam(z, vzdalenost);
                            tempVzdalenost = tempVzdalenost - z.vyskaZaznamu;
                        }
                        vzdalenost += tempVzdalenost;
                    }


                    // TODO misto switche dej jako tuhle podminku dole


                    //MessageBox.Show("Prochazim zaznam "+z.lNazev.Text);
                    /* tempPoint = z.LevySpodni;
                     tempPoint.X = tempPoint.X + 5;
                     linkZaznam = z;
                     */


                }
            }

       
               
               

            }
            
        }


    }


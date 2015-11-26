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
        struct details
        {
            int pocet;
            //hodnoty
        }
        private TrackBar trackbar1;
        static int pocet = 3;
        static int pocetLink = 2;
        private Label[] labelField = new Label[pocet];
        private Label[] labelField2 = new Label[pocet];
        private LinkLabel[] linkLabelField = new LinkLabel[pocetLink];
        int[] linkPole = new int[3];


        //SESTAVA
        Sestava S;

        //patri k work
        ListBox list = new ListBox();
        int[] pole = new int[20];




        public Form1()
        {
            InitializeComponent();
            // work();
            S = new Sestava(95,this);
            S.AddZaznam("ahoj", 100, 324, this);
        }

        public void work()
        {


            for (int i = 0; i < pocetLink; i++)
            {
                linkLabelField[i] = CreateLinkLabel (50, "LinkLabel" + i.ToString());
                linkLabelField[i].Location = new Point(30, 40 + i * 20);
                //label se muze rozkliknout
                   if (true)
                  {
               
                      linkLabelField[i].Click += new EventHandler(this.linkLabel1_LinkClicked);
                  }
               // MessageBox.Show(i.ToString());

            }
            linkLabelField[0].Text = "Zaklad";
            linkLabelField[1].Text = "Hvezda";


            /*   for (int i = 0; i < 20; i++)
               {
                   pole[i] = i;
               }

               for (int i = 0; i < pocet; i++)
               {
                   labelField[i] = CreateLabel(50, "label" + i.ToString());
                   labelField[i].Location = new Point(30, 40 + i * 20);
                   //label se muze rozkliknout
                 //    if (i == 2)
                 //  {
                 //      labelField[i].Click += new EventHandler(this.label3_Click);
                 //  }

               }
               labelField[0].Text = "sedm";
               labelField[1].Text = "hveyda";
               */
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //creating labels
        private Label CreateLabel(int TopValue, string LabelName)
        {
            // Label Control
            Label NewLabel = new Label();
            NewLabel.Width = 50; // Space little less than 2/3
            NewLabel.Height = 25;
            NewLabel.Left = 0; // Start at the left edge of the panel1
            NewLabel.Top = TopValue;
            this.Controls.Add(NewLabel);
            NewLabel.TextAlign = ContentAlignment.MiddleRight;
            NewLabel.Text = LabelName;
            return NewLabel;
        }
        private LinkLabel CreateLinkLabel(int TopValue, string LabelName)
        {
            // Label Control
            LinkLabel NewLabel = new LinkLabel();
            NewLabel.Width = 50; // Space little less than 2/3
            NewLabel.Height = 25;
            NewLabel.Top = TopValue;
            NewLabel.LinkColor = Color.Blue;
            this.Controls.Add(NewLabel);
            NewLabel.TextAlign = ContentAlignment.MiddleRight;
            NewLabel.Name = LabelName;
            return NewLabel;
            
        }

        private void linkLabel1_LinkClicked(object sender, EventArgs e)
        {
            Point umisteni;
            LinkLabel someLabel= sender as LinkLabel;
            if(someLabel.LinkColor== System.Drawing.Color.Blue)
            {
                someLabel.LinkColor = System.Drawing.Color.Red;

                switch (someLabel.Text)
                {
                    case "Zaklad":
                        {
                            if (linkLabelField[1].LinkColor == Color.Blue)
                            {

                                for (int i = 0; i < pocet; i++)
                                {
                                    labelField[i] = CreateLabel(50, "label" + i.ToString());
                                    labelField[i].Location = new Point(30, 60 + i * 20);

                                }

                                for (int i = 1; i < pocetLink; i++)
                                {
                                    linkLabelField[i].Location = new Point(30, pocet * 40 + i * 20);
                                }
                            }
                        /*    else
                            {
                                for (int i = 0; i < pocet; i++)
                                {
                                    labelField[i] = CreateLabel(50, "label" + i.ToString());
                                    labelField[i].Location = new Point(30, 60 + i * 20);

                                }

                                for (int i = 1; i < pocetLink; i++)
                                {
                                    linkLabelField[i].Location = new Point(30, pocet * 40 + i * 20);
                                }
                            }
                            */
                            break;
                           
                        }

                    case "Hvezda":
                        {
                            if(linkLabelField[0].LinkColor==Color.Blue)
                            {
                                for (int i = 0; i < pocet; i++)
                                {
                                    labelField2[i] = CreateLabel(50, "label" + i.ToString());
                                    labelField2[i].Location = new Point(30, 90 + i * 20);

                                }
                                for (int i = 2; i < pocetLink; i++)
                                {


                                    linkLabelField[i].Location = new Point(30, 200 + pocet * 20);
                                }
                                break;
                            }

                            for (int i = 0; i < pocet; i++)
                            {
                                labelField2[i] = CreateLabel(50, "label" + i.ToString());
                                labelField2[i].Location = new Point(30, 160 + i * 20);

                            }
                            for (int i = 2; i < pocetLink; i++)
                            {


                                linkLabelField[i].Location = new Point(30, 200 + pocet * 20);
                            }

                            break;
                        }
                    case "`Sedm":
                        {

                            for (int i = 0; i < pocet; i++)
                            {
                                labelField[i] = CreateLabel(50, "label" + i.ToString());
                                labelField[i].Location = new Point(30, 160 + i * 20);

                            }
                            for (int i = 2; i < pocetLink; i++)
                            {


                                linkLabelField[i].Location = new Point(30, 200 + pocet * 40);
                            }

                            break;
                        }
                }
            }
            else
            {
                someLabel.LinkColor = Color.Blue;
                switch(someLabel.Text)
                {
                    case "Zaklad":
                        for (int i = 0; i < 3; i++)
                        {
                            labelField[i].Dispose();
                        }
                        Point bod = linkLabelField[1].Location;
                        linkLabelField[1].Location = new Point(bod.X, bod.Y - pocet * 40+40);
                        break;
                    case "Hvezda":
                        for (int i = 0; i < 3; i++)
                        {
                            labelField2[i].Dispose();
                        }
                        break;
                }
                
    
            }
            
           



            
            
        }
       private void posunSe(int cisloLinkLabelu, Label [] pole,int delkaPole,int posunO)
        {

        }

    }
}

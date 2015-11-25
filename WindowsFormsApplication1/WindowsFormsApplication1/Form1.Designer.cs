using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackbar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackbar1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackbar1
            // 
            this.trackbar1.Location = new System.Drawing.Point(186, 31);
            this.trackbar1.Name = "trackbar1";
            this.trackbar1.Size = new System.Drawing.Size(104, 45);
            this.trackbar1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 455);
            this.Name = "Form1";
            this.Text = "Moje aplikace";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackbar1)).EndInit();
            this.ResumeLayout(false);

    }

        // PROBLEM nemuzu se dostat k LabelField
        private void label3_Click(object sender, EventArgs e)
        {
            for (int i = 3; i < 9; i++)
            {
                //labelField[i].Location(); 
                    }
        }

        private void trackbar1_ValueChanged(object sender, EventArgs e)
        {
            // Zjistíme jezdce:
            TrackBar tb = (TrackBar)sender;
            //label1.Text = tb.Value.ToString();
            // Nastavíme průhlednost okna dle hodnoty jezdce:
            this.Opacity = 0.5 + 0.01 * tb.Value;
        }




        #endregion
    }
}


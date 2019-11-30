using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        int kalan = 3;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(337,360);

            int[] mayinlar = new int[20];
            for (int i = 0; i < 20; i++)

            {
                int sayi = rnd.Next(1, 101);
                if(!mayinlar.Contains (sayi))
                {
                    mayinlar [i] = sayi;
                }
                else
                {
                    i--;
                }
            }

                      

            for (int i = 1; i < 101; i++)
            {
                PictureBox pcb = new PictureBox();

                pcb.Click += Pcb_Click;     


                pcb.Width = 30;
                pcb.Height = 30;
                pcb.Name = "pcb" + i.ToString();
                pcb.BackColor = Color.FromArgb (rnd.Next(0,256), rnd.Next (0,256), rnd.Next (0,256));
                flowLayoutPanel1.Controls.Add(pcb);
                pcb.Margin= new Padding(1);
                if (mayinlar.Contains(i) )
                    {
                    pcb.Tag = true;                      
                    }

                                                             
                 
            }
        }

        private void Pcb_Click(object sender, EventArgs e)
        {
            PictureBox pcb = (PictureBox) sender;

            if (kalan == 0)
            {
                MessageBox.Show("Oyun Bitti");
                timer1.Start();
            }

            if ((pcb.Tag is null) && !(pcb.Tag is true))
            {

                pcb.BackColor = Color.White;
                //MessageBox.Show( "Bu bir mayındır!");
                //timer1.Stop();
                pcb.Tag = false;

            }

            else
            {
                pcb.BackColor = Color.Black;
                kalan--;
            }



        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.Text = this.Size.ToString();
            //timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //timer1.Interval=500;
            foreach (Control item in flowLayoutPanel1.Controls)
            {
                if(item is PictureBox)
                {

                    
                        if (!(item.Tag is null))
                        {
                        item.BackColor = Color.Black;
                        }

                        else
                        {
                        item.BackColor = Color.White;
                        }

                    

                    //item.BackColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                }

            }
            
            
        }
    }
}

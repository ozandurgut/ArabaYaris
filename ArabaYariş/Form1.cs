using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace ArabaYariş
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int kazanilanpuan = 0;
        int yolhizi = 7;
        int arabahizi = 5; //kendi arabamın hız değeri 
        bool sagYon = false;
        bool solYon = false;
        int digerarabahizlari = 5;
        Random rdn = new Random();


        public void OyunuBaslat()
        {
            btn_oyunubaslat.Enabled = false;
            carpma.Visible = false;
            arabahizi = 5;
            digerarabahizlari = 5;
            kazanilanpuan=0;

            //bizim arabanın koordinat

            bizimaraba.Left = 160;
            bizimaraba.Top = 300;

            araba1.Left = 30;
            araba1.Top = 50;

            araba2.Left = 320;
            araba2.Top = 50;

            solYon = false;
            sagYon = false;

            timer1.Start();

        
        
        
        }


        private void Form1_Load(object sender, EventArgs e)
        {
         OyunuBaslat();
        }

        private void yol_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            kazanilanpuan++;
            lbl_puan.Text= kazanilanpuan.ToString();
            yol.Top += yolhizi;
            if (yol.Top > 400)
            {
                yol.Top = -100;
            }
            if (solYon) { bizimaraba.Left -= arabahizi; }
            if (sagYon) { bizimaraba.Left += arabahizi; }
            if(bizimaraba.Left < 1) { solYon = false; }
            else if(bizimaraba.Left + bizimaraba.Width > 510) { sagYon = false; }

            araba1.Top += arabahizi;
            araba2.Top += arabahizi;

            if (araba1.Top > panel1.Height)
            {
                araba1degistir();
                araba1.Left = rdn.Next(20, 50);
                araba1.Top = rdn.Next(40, 140) * -1;
            }
            if (araba2.Top > panel1.Height)
            {
                araba2degistir();
                araba2.Left = rdn.Next(100, 200);
                araba2.Top = rdn.Next(40, 140) * -1;

            }
            if (bizimaraba.Bounds.IntersectsWith(araba1.Bounds) || bizimaraba.Bounds.IntersectsWith(araba2.Bounds)) 
            {
                oyunbitti();
            }
        }

        private void araba1degistir()
        {
            int sira = rdn.Next(1, 7);
            switch (sira)
            {
                case 1:
                    araba1.Image = Properties.Resources.araba5;
                    break;
                case 2:
                    araba1.Image= Properties.Resources.araba7;
                    break;
                case 3:
                    araba1.Image = Properties.Resources.araba3;
                    break;
                case 4:
                    araba1.Image = Properties.Resources.araba4;
                    break;
                case 5:
                    araba1.Image = Properties.Resources.araba5;
                    break;
                case 6:
                    araba1.Image = Properties.Resources.araba6;
                    break;
                case 7:
                    araba1.Image = Properties.Resources.araba7;
                    break;
                
            }
        }

        private void araba2degistir()
        {
            int sira = rdn.Next(1, 7);
            switch (sira)
            {
                case 1:
                    araba2.Image = Properties.Resources.araba1;
                    break;
                case 2:
                    araba2.Image = Properties.Resources.araba2;
                    break;
                case 3:
                    araba2.Image = Properties.Resources.araba3;
                    break;
                case 4:
                    araba2.Image = Properties.Resources.araba4;
                    break;
                case 5:
                    araba2.Image = Properties.Resources.araba5;
                    break;
                case 6:
                    araba2.Image = Properties.Resources.araba6;
                    break;
                case 7:
                    araba2.Image = Properties.Resources.araba7;
                    break;

            }
        }


        private void oyunbitti()
        {
            timer1.Stop();
            btn_oyunubaslat.Enabled = true;
            carpma.Visible = true;
            carpma.BringToFront();
            carpma.BackColor = Color.Transparent;
            MessageBox.Show("Tebrikler kazandığınız puan :  " + lbl_puan.Text,"Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void carpma_Click(object sender, EventArgs e)
        {

        }
    }

}

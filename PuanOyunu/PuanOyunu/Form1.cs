using System;
using System.Drawing;
using System.Windows.Forms;

namespace PuanOyunu
{
    public partial class Form1 : Form
    {
        //Ortak puan
        static int puan = 0;

        bool oyunModu = false;

        Button oyunButon;
        Random rnd = new Random();

        public Form1(bool oyunModu = false)
        {
            InitializeComponent();
            this.oyunModu = oyunModu;
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(600, 400);

            //Label 
            label1.Text = $"Puan: {puan}";
            label1.Font = new Font("Arial", 14, FontStyle.Bold);
            label1.AutoSize = true;
            label1.Location = new Point(10, 10);

            if (!oyunModu)
            { 
                //Ýlk form
                this.Text = "Puan Ekraný (Sadece Label)";

                //Oyun formu
                Form1 oyunFormu = new Form1(true);
                oyunFormu.Show();
            }
            else
            {
                
                this.Text = "Oyun Ekraný (Butonlu)";

                oyunButon = new Button();
                oyunButon.Size = new Size(80, 80);
                oyunButon.Font = new Font("Arial", 20, FontStyle.Bold);
                oyunButon.FlatStyle = FlatStyle.Flat;
                oyunButon.FlatAppearance.BorderSize = 0;
                oyunButon.Click += OyunButon_Click;

                this.Controls.Add(oyunButon);

                timer1.Interval = 1000;
                timer1.Tick += Timer1_Tick;
                timer1.Start();

                YeniKonumVeSayi();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            YeniKonumVeSayi();
        }

        private void YeniKonumVeSayi()
        {
            int sayi = rnd.Next(1, 11);
            oyunButon.Text = sayi.ToString();

            int maxX = this.ClientSize.Width - oyunButon.Width;
            int maxY = this.ClientSize.Height - oyunButon.Height;
            int x = rnd.Next(0, maxX);
            int y = rnd.Next(0, maxY);
            oyunButon.Location = new Point(x, y);

            if (ButonOrtadaMi(x, y))
            {
                oyunButon.BackColor = Color.Red;
                oyunButon.ForeColor = Color.White;
            }
            else
            {
                oyunButon.BackColor = Color.Black;
                oyunButon.ForeColor = Color.White;
            }
        }

        private bool ButonOrtadaMi(int x, int y)
        {
            Rectangle ortaAlan = new Rectangle(
                this.ClientSize.Width / 4,
                this.ClientSize.Height / 4,
                this.ClientSize.Width / 2,
                this.ClientSize.Height / 2
            );

            Rectangle butonAlan = new Rectangle(x, y, oyunButon.Width, oyunButon.Height);
            return ortaAlan.IntersectsWith(butonAlan);
        }

        private void OyunButon_Click(object sender, EventArgs e)
        {
            int sayi = int.Parse(oyunButon.Text);
            if (oyunButon.BackColor == Color.Red)
                puan += sayi;
            else
                puan -= sayi;

            PuanGuncelle();
        }

        private void PuanGuncelle()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is Form1 form)
                {
                    form.label1.Text = $"Puan: {puan}";
                }
            }

            // KAZANMA KONTROLÜ:
            if (puan >= 100)
            {
                timer1.Stop(); // Oyunu durdur
                oyunButon.Enabled = false; // Butona basýlmasýn
                MessageBox.Show("Tebrikler, kazandýnýz!", "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Boþ designer eventleri için 
        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
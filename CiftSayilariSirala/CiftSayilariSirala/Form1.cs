using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CiftSayilariSirala
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int sure = 60;
        List<int> sayilar = new List<int>();
        List<int> ciftSirasi = new List<int>();
        int index = 0;
        int hareketSayaci = 0;
        Random rnd = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            lblZaman.Text = sure + " sn";
            lstDogruSiralar.Items.Clear();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button tiklanan = sender as Button;
            if (tiklanan == null)
                return;

            int deger = int.Parse(tiklanan.Text);

            if (index < ciftSirasi.Count && deger == ciftSirasi[index])
            {
                tiklanan.Enabled = false;
                tiklanan.BackColor = Color.LightGreen;

                lstDogruSiralar.Items.Add(deger);

                index++;

                if (index == ciftSirasi.Count)
                {
                    timer1.Stop();
                    MessageBox.Show($"Tebrikler! Tüm çift sayýlara doðru bastýn.\nKalan süre: {sure} sn");
                    grpOyunAlani.Controls.Clear();
                    lstDogruSiralar.Items.Clear();
                }
            }
            else
            {
                MessageBox.Show("Sýralama yanlýþ! Tekrar dene.");
                index = 0;

                lstDogruSiralar.Items.Clear();

                foreach (Control c in grpOyunAlani.Controls)
                {
                    if (c is Button b)
                    {
                        b.Enabled = true;
                        b.BackColor = DefaultBackColor;
                    }
                }

                timer1.Stop();
                sure = 0;
                lblZaman.Text = sure + " sn";
            }
        }

        private void btnBasla_Click(object sender, EventArgs e)
        {
            grpOyunAlani.Controls.Clear();
            sayilar.Clear();
            ciftSirasi.Clear();
            index = 0;
            sure = 60;
            hareketSayaci = 0;
            lblZaman.Text = sure + " sn";
            lstDogruSiralar.Items.Clear();

            //5 farklý çift sayý üretmek için HashSet
            HashSet<int> ciftSet = new HashSet<int>();
            while (ciftSet.Count < 5)
            {
                int s = rnd.Next(2, 101);
                if (s % 2 == 0)
                    ciftSet.Add(s);
            }

            sayilar.AddRange(ciftSet);

            while (sayilar.Count < 10)
            {
                int s = rnd.Next(1, 101);
                if (s % 2 == 0 && ciftSet.Count >= 5)
                    continue; 
                sayilar.Add(s);
            }

            // Sayýlarý karýþtýr
            sayilar = sayilar.OrderBy(x => rnd.Next()).ToList();

            // Çift sayýlarýn küçükten büyüðe sýrasý (5 tane)
            ciftSirasi = ciftSet.OrderBy(x => x).ToList();


            int x = 20, y = 30;
            foreach (int s in sayilar)
            {
                Button btn = new Button();
                btn.Text = s.ToString();
                btn.Width = 50;
                btn.Height = 30;
                btn.Left = x;
                btn.Top = y;
                btn.Click += Btn_Click;
                grpOyunAlani.Controls.Add(btn);

                x += 60;
                if (x > grpOyunAlani.Width - 60)
                {
                    x = 20;
                    y += 40;
                }
            }

            timer1.Interval = 500;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sure--;
            lblZaman.Text = sure + " sn";

            if (sure <= 0)
            {
                timer1.Stop();
                MessageBox.Show("Süre bitti!");
                grpOyunAlani.Controls.Clear();
                lstDogruSiralar.Items.Clear();
                return;
            }

            hareketSayaci++;

            if (hareketSayaci % 2 == 0)
            {
                List<Rectangle> usedRects = new List<Rectangle>();
                int maxX = grpOyunAlani.Width;
                int maxY = grpOyunAlani.Height;

                foreach (Control ctrl in grpOyunAlani.Controls)
                {
                    if (ctrl is Button btn)
                    {
                        Rectangle newRect;
                        int attempts = 0;
                        do
                        {
                            int x = rnd.Next(0, maxX - btn.Width);
                            int y = rnd.Next(0, maxY - btn.Height);
                            newRect = new Rectangle(x, y, btn.Width, btn.Height);
                            attempts++;
                            if (attempts > 100) break; 
                        }
                        while (usedRects.Any(r => r.IntersectsWith(newRect)));

                        btn.Left = newRect.X;
                        btn.Top = newRect.Y;
                        usedRects.Add(newRect);
                    }
                }
            }
        }


        private void btnBitir_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show("Oyun bitti!");
            grpOyunAlani.Controls.Clear();
            lstDogruSiralar.Items.Clear();
        }

        private void lstDogruSiralar_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}

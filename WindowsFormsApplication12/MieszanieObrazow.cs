using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication12
{
    public partial class MieszanieObrazow : Form
    {
        private int szer = 0, wys = 0;

        public MieszanieObrazow()
        {
            InitializeComponent();
        }

        private int reguluj(int i1)
        {
            if (i1 <= 0) return 1;
            else if (i1 >= 255) return 255;
            else return i1;
        }

//Wczytywanie obrazu nr 1 
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                szer = pictureBox1.Image.Width;
                wys = pictureBox1.Image.Height;
                pictureBox3.Image = new Bitmap(szer, wys);
            }
        }
//Wczytywanie obrazu nr 2
        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox2.Load(openFileDialog1.FileName);
                szer = pictureBox2.Image.Width;
                wys = pictureBox2.Image.Height;
                pictureBox3.Image = new Bitmap(szer, wys);
            }
        }

//SUMA
        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Color k1;
            Color k2; 
            Color k3;
            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    int re1 = k1.R;
                    int gr1 = k1.G;
                    int bl1 = k1.B;

                    k2 = b2.GetPixel(i, j);
                    int re2 = k2.R;
                    int gr2 = k2.G;
                    int bl2 = k2.B;

                    int re3 = Math.Min(re1 + re2, 255);
                    int gr3 = Math.Min(gr1 + gr2, 255);
                    int bl3 = Math.Min(bl1 + bl2, 255);

                    k3 = Color.FromArgb(re3, gr3, bl3);
                    b3.SetPixel(i, j, k3);
                }
            }
            pictureBox3.Refresh();
        }

//ODEJMOWANIE
        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Color k1;
            Color k2;
            Color k3;
            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    int re1 = k1.R;
                    int gr1 = k1.G;
                    int bl1 = k1.B;

                    k2 = b2.GetPixel(i, j);
                    int re2 = k2.R;
                    int gr2 = k2.G;
                    int bl2 = k2.B;

                    int re3 = reguluj(re1 - re2);
                    int gr3 = reguluj(gr1 - gr2);
                    int bl3 = reguluj(bl1 - bl2);

                    k3 = Color.FromArgb(re3, gr3, bl3);
                    b3.SetPixel(i, j, k3);
                }
            }
            pictureBox3.Refresh();
        }

//RÓŻNICA
        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Color k1;
            Color k2;
            Color k3;
            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    int re1 = k1.R;
                    int gr1 = k1.G;
                    int bl1 = k1.B;
                    int al1 = k1.A;

                    k2 = b2.GetPixel(i, j);
                    int re2 = k2.R;
                    int gr2 = k2.G;
                    int bl2 = k2.B;
                    int al2 = k2.A;

                    int re3 = Math.Abs(re1 - re2);
                    int gr3 = Math.Abs(gr1 - gr2);
                    int bl3 = Math.Abs(bl1 - bl2);

                    k3 = Color.FromArgb(re3, gr3, bl3);
                    b3.SetPixel(i, j, k3);
                }
            }
            pictureBox3.Refresh();
        }

//MNOŻENIE
        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Color k1;
            Color k2;
            Color k3;
            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    int re1 = k1.R;
                    int gr1 = k1.G;
                    int bl1 = k1.B;

                    k2 = b2.GetPixel(i, j);
                    int re2 = k2.R;
                    int gr2 = k2.G;
                    int bl2 = k2.B;

                    int re3 = (re1 * re2)/255;
                    int gr3 = (gr1 * gr2)/255;
                    int bl3 = (bl1 * bl2)/255;

                    k3 = Color.FromArgb(re3, gr3, bl3);
                    b3.SetPixel(i, j, k3);
                }
            }
            pictureBox3.Refresh();
        }

//MNOŻENIE ODWROTNOŚCI
        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Color k1;
            Color k2;
            Color k3;
            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    int re1 = k1.R;
                    int gr1 = k1.G;
                    int bl1 = k1.B;

                    k2 = b2.GetPixel(i, j);
                    int re2 = k2.R;
                    int gr2 = k2.G;
                    int bl2 = k2.B;

                    int re3 = ((255 - (((255 - re1) * (255 - re2)) >> 8)));
                    int gr3 = ((255 - (((255 - gr1) * (255 - gr2)) >> 8)));
                    int bl3 = ((255 - (((255 - bl1) * (255 - bl2)) >> 8)));

                    k3 = Color.FromArgb(re3, gr3, bl3);
                    b3.SetPixel(i, j, k3);
                }
            }
            pictureBox3.Refresh();
        }

//NEGACJA
        private void button8_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Color k1;
            Color k2;
            Color k3;
            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    int re1 = k1.R;
                    int gr1 = k1.G;
                    int bl1 = k1.B;

                    k2 = b2.GetPixel(i, j);
                    int re2 = k2.R;
                    int gr2 = k2.G;
                    int bl2 = k2.B;

                    int re3 = 255 - Math.Abs(255 - re1 - re2);
                    int gr3 = 255 - Math.Abs(255 - gr1 - gr2);
                    int bl3 = 255 - Math.Abs(255 - bl1 - bl2);

                    k3 = Color.FromArgb(re3, gr3, bl3);
                    b3.SetPixel(i, j, k3);
                }
            }
            pictureBox3.Refresh();
        }

//CIEMNIEJSZE
        private void button9_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Color k1;
            Color k2;
            Color k3;
            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    int re1 = k1.R;
                    int gr1 = k1.G;
                    int bl1 = k1.B;

                    k2 = b2.GetPixel(i, j);
                    int re2 = k2.R;
                    int gr2 = k2.G;
                    int bl2 = k2.B;

                    int re3;
                    int gr3;
                    int bl3;

                    if (re1 < re2) re3 = re1;
                    else re3 = re2;
                    if (gr1 < gr2) gr3 = gr1;
                    else gr3 = gr2;
                    if (bl1 < bl2) bl3 = bl1;
                    else bl3 = bl2;

                    k3 = Color.FromArgb(re3, gr3, bl3);
                    b3.SetPixel(i, j, k3);
                }
            }
            pictureBox3.Refresh();
        }

//JAŚNIEJSZE
        private void button10_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Color k1;
            Color k2;
            Color k3;
            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    int re1 = k1.R;
                    int gr1 = k1.G;
                    int bl1 = k1.B;

                    k2 = b2.GetPixel(i, j);
                    int re2 = k2.R;
                    int gr2 = k2.G;
                    int bl2 = k2.B;

                    int re3;
                    int gr3;
                    int bl3;

                    if (re1 > re2) re3 = re1;
                    else re3 = re2;
                    if (gr1 > gr2) gr3 = gr1;
                    else gr3 = gr2;
                    if (bl1 > bl2) bl3 = bl1;
                    else bl3 = bl2;

                    k3 = Color.FromArgb(re3, gr3, bl3);
                    b3.SetPixel(i, j, k3);
                }
            }
            pictureBox3.Refresh();
        }

//WYŁĄCZENIE
        private void button11_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Color k1;
            Color k2;
            Color k3;
            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    int re1 = k1.R;
                    int gr1 = k1.G;
                    int bl1 = k1.B;

                    k2 = b2.GetPixel(i, j);
                    int re2 = k2.R;
                    int gr2 = k2.G;
                    int bl2 = k2.B;

                    int re3 = re1 + re2 - 2 * re1 * re2 / 255;
                    int gr3 = gr1 + gr2 - 2 * gr1 * gr2 / 255;
                    int bl3 = bl1 + bl2 - 2 * bl1 * bl2 / 255;

                    k3 = Color.FromArgb(re3, gr3, bl3);
                    b3.SetPixel(i, j, k3);
                }
            }
            pictureBox3.Refresh();
        }

//NAKŁADKA
        private void button13_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Color k1;
            Color k2;
            Color k3;
            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    int re1 = k1.R;
                    int gr1 = k1.G;
                    int bl1 = k1.B;

                    k2 = b2.GetPixel(i, j);
                    int re2 = k2.R;
                    int gr2 = k2.G;
                    int bl2 = k2.B;

                    int re3;
                    int gr3;
                    int bl3;

                    if (re1 < 128)
                    {
                        re3 = Math.Min(255, (2 * re1 * re2 / 255));
                    }
                    else
                    {
                        re3 = Math.Min(255, (255 - 2 * (255 - re1) * (255 - re2) / 255));
                    }

                    if (gr1 < 128)
                    {
                        gr3 = Math.Min(255, (2 * gr1 * gr2 / 255));
                    }
                    else
                    {
                        gr3 = Math.Min(255, (255 - 2 * (255 - gr1) * (255 - gr2) / 255));
                    }

                    if (bl1 < 128)
                    {
                        bl3 = Math.Min(255, (2 * bl1 * bl2 / 255));
                    }
                    else
                    {
                        bl3 = Math.Min(255, (255 - 2 * (255 - bl1) * (255 - bl2) / 255));
                    }

                    k3 = Color.FromArgb(re3, gr3, bl3);
                    b3.SetPixel(i, j, k3);
                }
            }
            pictureBox3.Refresh();
        }

//OSTRE ŚWIATŁO
        private void button14_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Color k1;
            Color k2;
            Color k3;
            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    int re1 = k1.R;
                    int gr1 = k1.G;
                    int bl1 = k1.B;

                    k2 = b2.GetPixel(i, j);
                    int re2 = k2.R;
                    int gr2 = k2.G;
                    int bl2 = k2.B;

                    int re3;
                    int gr3;
                    int bl3;

                    if (re2 < 128)
                    {
                        re3 = Math.Min(255, (2 * re1 * re2 / 255));
                    }
                    else
                    {
                        re3 = Math.Min(255, (255 - 2 * (255 - re1) * (255 - re2) / 255));
                    }

                    if (gr2 < 128)
                    {
                        gr3 = Math.Min(255, (2 * gr1 * gr2 / 255));
                    }
                    else
                    {
                        gr3 = Math.Min(255, (255 - 2 * (255 - gr1) * (255 - gr2) / 255));
                    }

                    if (bl2 < 128)
                    {
                        bl3 = Math.Min(255, (2 * bl1 * bl2 / 255));
                    }
                    else
                    {
                        bl3 = Math.Min(255, (255 - 2 * (255 - bl1) * (255 - bl2) / 255));
                    }

                    k3 = Color.FromArgb(re3, gr3, bl3);
                    b3.SetPixel(i, j, k3);
                }
            }
            pictureBox3.Refresh();
        }

//ŁAGODNE ŚWIATŁO
        private void button15_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Color k1;
            Color k2;
            Color k3;
            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    int re1 = k1.R;
                    int gr1 = k1.G;
                    int bl1 = k1.B;

                    k2 = b2.GetPixel(i, j);
                    int re2 = k2.R;
                    int gr2 = k2.G;
                    int bl2 = k2.B;

                    int re3;
                    int gr3;
                    int bl3;
/*
                    if (re2 < 128)
                    {
                        re3 = Math.Min(255, (2 * re2 * re1 + re1 * re1 * (255 - 2 * re2)/ 255));
                    }
                    else
                    {
                        re3 = (int)Math.Min(255, (Math.Sqrt(re1) * (2 * re2 - 255) + (2 * re1) * (255 - re2)));
                    }

                    if (gr2 < 128)
                    {
                        gr3 = Math.Min(255, (2 * gr2 * gr1 + gr1 * gr1 * (255 - 2 * gr2) / 255));
                    }
                    else
                    {
                        gr3 = (int)Math.Min(255, (Math.Sqrt(gr1) * (2 * gr2 - 255) + (2 * gr1) * (255 - gr2)));
                    }

                    if (bl2 < 128)
                    {
                        bl3 = Math.Min(255, (2 * bl2 * bl1 + bl1 * bl1 * (255 - 2 * bl2) / 255));
                    }
                    else
                    {
                        bl3 = (int)Math.Min(255, (Math.Sqrt(bl1) * (2 * bl2 - 255) + (2 * bl1) * (255 - bl2)));
                    }
*/

                    if (re1 > 127.5)
                    {
                        re3 = (int)Math.Min(255, (re2 + (255 - re2) * ((re1 - 127.5) / 127.5) * (0.5 - Math.Abs(re2 - 127.5) / 255)));
                    }
                    else
                    {
                        re3 = (int)Math.Min(255, (re2 - re2 *((127.5 - re1)/127.5) * (0.5 - Math.Abs(re2 - 127.5) / 255 )));
                    }

                    if (gr1 > 127.5)
                    {
                        gr3 = (int)Math.Min(255, (gr2 + (255 - gr2) * ((gr1 - 127.5) / 127.5) * (0.5 - Math.Abs(gr2 - 127.5) / 255)));
                    }
                    else
                    {
                        gr3 = (int)Math.Min(255, (gr2 - gr2 * ((127.5 - gr1) / 127.5) * (0.5 - Math.Abs(gr2 - 127.5) / 255)));
                    }

                    if (bl1 > 127.5)
                    {
                        bl3 = (int)Math.Min(255, (bl2 + (255 - bl2) * ((bl1 - 127.5) / 127.5) * (0.5 - Math.Abs(bl2 - 127.5) / 255)));
                    }
                    else
                    {
                        bl3 = (int)Math.Min(255, (bl2 - bl2 * ((127.5 - bl1) / 127.5) * (0.5 - Math.Abs(bl2 - 127.5) / 255)));
                    }

                        k3 = Color.FromArgb(re3, gr3, bl3);
                    b3.SetPixel(i, j, k3);
                }
            }
            pictureBox3.Refresh();
        }

//ROZCIEŃCZENIE
        private void button16_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Color k1;
            Color k2;
            Color k3;
            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    int re1 = k1.R;
                    int gr1 = k1.G;
                    int bl1 = k1.B;

                    k2 = b2.GetPixel(i, j);
                    int re2 = k2.R;
                    int gr2 = k2.G;
                    int bl2 = k2.B;

                    int re3 = re1 / reguluj(255 - re2);
                    int gr3 = gr1 / reguluj(255 - gr2);
                    int bl3 = bl1 / reguluj(255 - bl2);

                    k3 = Color.FromArgb(re3, gr3, bl3);
                    b3.SetPixel(i, j, k3);
                }
            }
            pictureBox3.Refresh();
        }

//WYPALANIE
        private void button17_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Color k1;
            Color k2;
            Color k3;
            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    int re1 = k1.R;
                    int gr1 = k1.G;
                    int bl1 = k1.B;

                    k2 = b2.GetPixel(i, j);
                    int re2 = k2.R;
                    int gr2 = k2.G;
                    int bl2 = k2.B;

                    int re3;
                    int gr3;
                    int bl3;
                                        if (re2 == 255)
                                        {
                                            re3 = 255;
                                        }
                                        else
                                        {
                                            re3 = Math.Min(255, ((re1 << 8) / (255 - re2)));
                                        }

                                        if (gr2 == 255)
                                        {
                                            gr3 = 255;
                                        }
                                        else
                                        {
                                            gr3 = Math.Min(255, ((gr1 << 8) / (255 - gr2)));
                                        }

                                        if (bl2 == 255)
                                        {
                                            bl3 = 255;
                                        }
                                        else
                                        {
                                            bl3 = Math.Min(255, ((bl1 << 8) / (255 - bl2)));
                                        }
                    k3 = Color.FromArgb(re3, gr3, bl3);
                    b3.SetPixel(i, j, k3);
                }
            }
            pictureBox3.Refresh();
        }

//REFLECT MODE
        private void button18_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Color k1;
            Color k2;
            Color k3;
            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    int re1 = k1.R;
                    int gr1 = k1.G;
                    int bl1 = k1.B;

                    k2 = b2.GetPixel(i, j);
                    int re2 = k2.R;
                    int gr2 = k2.G;
                    int bl2 = k2.B;

                    int re3;
                    int gr3;
                    int bl3;
                    if (re2 == 255)
                    {
                        re3 = 255;
                    }
                    else
                    {
                        re3 = Math.Min(255, (re1 * re1 / (255 - re2)));
                    }

                    if (gr2 == 255)
                    {
                        gr3 = 255;
                    }
                    else
                    {
                        gr3 = Math.Min(255, (gr1 * gr1 / (255 - gr2)));
                    }

                    if (bl2 == 255)
                    {
                        bl3 = 255;
                    }
                    else
                    {
                        bl3 = Math.Min(255, (bl1 * bl1 / (255 - bl2)));
                    }
                    k3 = Color.FromArgb(re3, gr3, bl3);
                    b3.SetPixel(i, j, k3);
                }
            }
            pictureBox3.Refresh();
        }

//PRZEZROCZYSTOŚĆ
        private void button19_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Color k1;
            Color k2;
            Color k3;
            float alfa = (float)0.5;
            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    int re1 = k1.R;
                    int gr1 = k1.G;
                    int bl1 = k1.B;

                    k2 = b2.GetPixel(i, j);
                    int re2 = k2.R;
                    int gr2 = k2.G;
                    int bl2 = k2.B;

                    int re3 = reguluj((int)((255-alfa) * re2 + alfa * re1));
                    int gr3 = reguluj((int)((255 - alfa) * gr2 + alfa * gr1));
                    int bl3 = reguluj((int)((255 - alfa) * bl2 + alfa * bl1));

                    k3 = Color.FromArgb(re3, gr3, bl3);
                    b3.SetPixel(i, j, k3);
                }
            }
            pictureBox3.Refresh();
        }



        //Zapisywanie otrzymanego obrazu o naazwie wpisanej w textBox1
        private void button12_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Image != null)
            {
                pictureBox3.Image.Save("C:\\Users\\krzys\\OneDrive\\Obrazy\\JPG\\" + textBox1.Text + "(zmieszane).jpg", ImageFormat.Jpeg);
            }
            else
            {
                string message = "Nie ma zmienionego obrazu. Anulować operację?";
                string caption = "Error Detected";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                //Wyświetla MassageBox
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }

            }
        }

    }
}

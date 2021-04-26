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
using WindowsFormsApplication12;

namespace EdytorZdjec_v1
{
    public partial class Form1 : Form
    {
        private int szer=0, wys=0;

        public Form1()
        {
            InitializeComponent();
        }
//Wczytywanie obrazu
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                szer = pictureBox1.Image.Width;
                wys = pictureBox1.Image.Height;
                pictureBox2.Image = new Bitmap(szer, wys);

            }
        }

 //Kopiowanie
        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image; 
                for (int i = 0; i < szer; i++)
                {
                    for (int j = 0; j < wys; j++)
                    {
                        b1.SetPixel(i, j, b2.GetPixel(i, j));
                    }
                }
                pictureBox1.Refresh();
        }


        private void button8_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k1;
            Color k2;
            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    k2 = Color.FromArgb(255 - k1.R, 255 - k1.G, 255 - k1.B);

                    b2.SetPixel(i, j, k2);
                }
            }
            pictureBox2.Refresh();
        }

//Otwórz okno do mieszania obrazów
        private void button13_Click(object sender, EventArgs e)
        {
            new MieszanieObrazow().Show();
        }

//Rozjaśnij
        private void button9_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox3.Text))
            {
                int stala = Int32.Parse(textBox3.Text);
                Bitmap b2 = (Bitmap)pictureBox1.Image;
                Bitmap b1 = (Bitmap)pictureBox2.Image;
                Color k1;
                Color k2;
       
                for (int i = 0; i < szer; i++)
                {
                    for (int j = 0; j < wys; j++)
                    {
                        k1 = b2.GetPixel(i, j);

                        int re1 = k1.R;
                        int gr1 = k1.G;
                        int bl1 = k1.B;

                        if (re1 > 255 || re1 + stala > 255) re1 = 255;
                        else re1 = re1 + stala;
                        if (gr1 > 255 || gr1 + stala > 255) gr1 = 255;
                        else gr1 = gr1 + stala;
                        if (bl1 > 255 || bl1 + stala > 255) bl1 = 255;
                        else bl1 = bl1 + stala;
                    
                        k2 = Color.FromArgb(re1, gr1, bl1);
                        b1.SetPixel(i, j, k2);
                    }
                }
                pictureBox2.Refresh();
            }
            else
            {
                string message = "Nie ma wpisanej stałej do TextBox'a. Anulować operację?";
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

//Przyciemnij
        private void button14_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox5.Text))
            {
                int stala = Int32.Parse(textBox5.Text);
                Bitmap b2 = (Bitmap)pictureBox1.Image;
                Bitmap b1 = (Bitmap)pictureBox2.Image;
                Color k1;
                Color k2;

                for (int i = 0; i < szer; i++)
                {
                    for (int j = 0; j < wys; j++)
                    {
                        k1 = b2.GetPixel(i, j);

                        int re1 = k1.R;
                        int gr1 = k1.G;
                        int bl1 = k1.B;

                        if (re1 < 0 || re1 - stala < 0) re1 = 0;
                        else re1 = re1 - stala;
                        if (gr1 < 0 || gr1 - stala < 0) gr1 = 0;
                        else gr1 = gr1 - stala;
                        if (bl1 < 0 || bl1 - stala < 0) bl1 = 0;
                        else bl1 = bl1 - stala;

                        k2 = Color.FromArgb(re1, gr1, bl1);
                        b1.SetPixel(i, j, k2);
                    }
                }
                pictureBox2.Refresh();
            }
            else
            {
                string message = "Nie ma wpisanej stałej do TextBox'a. Anulować operację?";
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

//Zapisywanie otrzymanego obrazu o naazwie wpisanej w textBox1
        private void button12_Click(object sender, EventArgs e)
        {
            if(pictureBox2.Image != null)
            {
                pictureBox2.Image.Save("C:\\Users\\krzys\\OneDrive\\Obrazy\\JPG\\"+ textBox1.Text + "(zmienione).jpg", ImageFormat.Jpeg);
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

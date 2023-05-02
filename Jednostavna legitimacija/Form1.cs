using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jednostavna_legitimacija
{
    public partial class Form1 : Form
    {
        private Graphics g;
        private Bitmap b;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = b;
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.LightBlue);
            g.FillEllipse(Brushes.Orange, 100, -50, pictureBox1.Width - 150, pictureBox1.Height + 100);
            g.FillRectangle(Brushes.LightBlue, 150, 120, pictureBox1.Width - 250, pictureBox1.Height - 230);
            pictureBox1.Invalidate();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            string ime = txtIme.Text;
            string prezime = txtPrezime.Text;
            g.DrawString(ime, new Font("Arial", 56, FontStyle.Bold), Brushes.DarkBlue, 150, 120);
            g.DrawString(prezime, new Font("Arial", 56, FontStyle.Bold), Brushes.DarkBlue, 150, 210);

            pictureBox1.Invalidate();
            label1.Visible = false;
            label2.Visible = false;
            txtIme.Visible = false;
            txtPrezime.Visible = false;
            btnDodaj.Visible = false;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Png fotografija |*.png";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image.Save(sfd.FileName);
                    MessageBox.Show("Legitimacija je uspesno sacuvana.");
                }
                catch
                {
                    MessageBox.Show("Greska: Legitimacija nije sacuvana."); ;
                }
            }
        }
    }
}
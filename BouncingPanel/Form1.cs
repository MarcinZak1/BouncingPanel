using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncingPanel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Random random = new Random((int)DateTime.Now.Ticks);
        private Form frm;
        int time = 0;

        public void Form1_Load(object sender, EventArgs e)
        {
            Form frm = (Form)sender;
            this.frm = frm;
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            time++;
            pnl.BackColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            //pnl.Location = new Point(784,412); prawy dolny rog konsoli
            pnl.Location = new Point(random.Next(0, WielkoscFormyX(frm)-pnl.Width), random.Next(0, WielkoscFormyY(frm)-pnl.Height));
        }
        private int WielkoscFormyX(Form frm)
        {
            int maxX = frm.ClientSize.Width;            // uzyskujemy tylko szerokosc okna klienta (bez ramki)

            return maxX;
        }
        private int WielkoscFormyY(Form frm)
        {
            int maxY = frm.ClientSize.Height;           // uzyskujemy tylko wysokosc okna klienta (bez ramki)

            return maxY;
        }

    }
}

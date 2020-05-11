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
        int delta = 75;
        int x, y;

        public void Form1_Load(object sender, EventArgs e)
        {
            Form frm = (Form)sender;
            this.frm = frm;
            x = random.Next(0, SzerokoscFormyX(frm) - pnl.Width);
            y = random.Next(0, WysokoscFormyY(frm) - pnl.Height);
            pnl.Location = new Point(x, y);     //punkt startowy
            PanelColor();
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            x = random.Next(x - delta, x + delta);
            y = random.Next(y - delta, y + delta);

            // ponawianie wyboru współrzędnych punktu, jeśli znajduje się on poza formą
            if(x<0)
            {
                    x = random.Next(0, x + delta);
            }
            if(x> (SzerokoscFormyX(frm) - pnl.Width))
            {
                    x = random.Next(x - delta, (SzerokoscFormyX(frm) - pnl.Width));
            }
            if (y < 0)
            {
                    y = random.Next(0, y + delta);
            }
            if (y > (WysokoscFormyY(frm) - pnl.Height))
            {
                    y = random.Next(y - delta, (WysokoscFormyY(frm) - pnl.Height));
            }

            pnl.Location = new Point(x, y);
            PanelColor();
        }
        private int SzerokoscFormyX(Form frm)
        {
            int maxX = frm.ClientSize.Width;            // uzyskujemy tylko szerokosc okna klienta (bez ramki)

            return maxX;
        }
        private int WysokoscFormyY(Form frm)
        {
            int maxY = frm.ClientSize.Height;           // uzyskujemy tylko wysokosc okna klienta (bez ramki)

            return maxY;
        }
        private void PanelColor()
        {
            pnl.BackColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }

    }
}

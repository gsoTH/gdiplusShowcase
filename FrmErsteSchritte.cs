using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gdiplusShowcase
{
    public partial class FrmErsteSchritte : Form
    {
        public FrmErsteSchritte()
        {
            InitializeComponent();
            ResizeRedraw = true; //Größenänderung verursacht Neuzeichnen der gesamten Form.
        }

        private void FrmErsteSchritte_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Pen pen = new Pen(Color.Green, 2);
            Pen grauerPen = new Pen(Color.Gray, 1);
            Brush brush = new SolidBrush(Color.Blue);
            Brush brush2 = new SolidBrush(Color.Red);

            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            Point obenMitte = new Point(w / 2, 0);
            Point untenMitte = new Point(w / 2, h);
            Point linksUnten = new Point(0, h);
            Point rechtsUnten = new Point(w, h);

            //Linie
            g.DrawLine(pen, obenMitte, untenMitte);

            //Dreieck
            g.DrawLine(pen, linksUnten, rechtsUnten);
            g.DrawLine(pen, rechtsUnten, obenMitte);
            g.DrawLine(pen, obenMitte, linksUnten);

            //Kreis
            g.DrawEllipse(pen, w / 4, h / 4, w / 4 * 2, h / 4 * 3);
            g.DrawRectangle(grauerPen, w / 4, h / 4, w / 4 * 2, h / 4 * 3);

            //Kreis ausfüllen
            //g.FillEllipse(brush, w / 4, h / 4, w / 4 * 2, h / 4 * 3);

        }
    }
}

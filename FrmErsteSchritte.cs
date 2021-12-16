using System;
using System.Drawing;
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
            // Hilfsvariablen
            Graphics g = e.Graphics; //Verweis auf die GUI
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            //Zeichenmittel
            Pen pen = new Pen(Color.Green, 2);
            Pen grauerPen = new Pen(Color.Gray, 1);


            //Linie
            Point obenMitte = new Point(w / 2, 0);
            Point untenMitte = new Point(w / 2, h);
            g.DrawLine(pen, obenMitte, untenMitte);


            //Dreieck
            Point linksUnten = new Point(0, h);
            Point rechtsUnten = new Point(w, h);
            g.DrawLine(pen, linksUnten, rechtsUnten);
            g.DrawLine(pen, rechtsUnten, obenMitte);
            g.DrawLine(pen, obenMitte, linksUnten);

            //Kreis
            // Hier wird ein Rechteck definiert, damit wir die Berechnungen 
            // nicht mehrfach angeben müssen.
            Rectangle rect = new Rectangle(w / 4, h / 4, w / 4 * 2, h / 4 * 3);
            
            g.DrawEllipse(pen, rect);
            g.DrawRectangle(grauerPen, rect);

            //// Ohne Rechteck würde die Zeichenanweisung so aussehen:
            //g.DrawEllipse(pen, w / 4, h / 4, w / 4 * 2, h / 4 * 3);


            ////Kreis ausfüllen
            //Brush brush = new SolidBrush(Color.Blue);
            //g.FillEllipse(brush, rect);
        }

        private void FrmErsteSchritte_Resize(object sender, EventArgs e)
        {
            //// Löst ein Neuzeichnen der Form aus, wenn die Größe geändert wird.
            //// Entspricht ResizeRedraw = true
            // Refresh();
        }
    }
}

using System.Drawing;
using System.Windows.Forms;

namespace gdiplusShowcase
{
    public partial class ClickToRectangle : Form
    {
        // Deklaration außerhalb der Methoden, damit in allen Methoden sichtbar.
        private Point letzterKlick;

        public ClickToRectangle()
        {
            InitializeComponent();
        }

        private void ClickToRectangle_MouseClick(object sender, MouseEventArgs e)
        {
            // e ist die Kontextvariable
            // Kontextvariablen enthalten für dieses Ereignis relevante Eigenschaften/Methoden
            // Im MouseClick-Ereignis enthält e z.B. die Stelle (Typ Point) an die geklickt wurde.
            letzterKlick = e.Location;

            // Identisches Ergebnis zur lezten Zeile:
            letzterKlick = new Point(e.X, e.Y);

            Refresh();
        }

        private void ClickToRectangle_Paint(object sender, PaintEventArgs e)
        {
            // Im Paint-Ereignis enthält Kontextvariable e z.B. einen Verweis auf das Objekt, 
            // mit dem auf der GUI gezeichnet wird.

            // Hilfsvariablen
            Graphics g = e.Graphics;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            Brush brush = new SolidBrush(Color.DarkGoldenrod);

            int breite = 40;

            Rectangle rect = new Rectangle( letzterKlick.X - breite / 2, 
                                            letzterKlick.Y - breite / 2, 
                                            breite, 
                                            breite);

            g.FillRectangle(brush, rect);

            ////MousePosition bezieht sich auf den gesamten Bildschirm und nicht nur auf die GUI der Form
            //Rectangle rect = new Rectangle(MousePosition.X, MousePosition.Y, breite, breite);
        }
    }
}

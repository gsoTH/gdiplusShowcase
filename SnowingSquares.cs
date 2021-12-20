using System;
using System.Drawing;
using System.Windows.Forms;

namespace gdiplusShowcase
{
    public partial class SnowingSquares : Form
    {
        static int limitRectangles = 75;


        Rectangle[] rectangles  = new Rectangle[limitRectangles];
        static Timer timer;
        Random rnd = new Random();
        public SnowingSquares()
        {
            DoubleBuffered = true;

            InitializeComponent();
            CreateRectangles();
            SetTimer();

        }

        /// <summary>
        /// Erzeugt einen Timer und stellt das zugehörige Ereignis her.
        /// </summary>
        private void SetTimer()
        {
            // Timer mit Intervall in ms erstellen
            timer = new Timer();
            timer.Interval = 50;

            //Stellt einen Verweis zur Ereignisbehandlungsmethode her.
            timer.Tick += TickEvent;
            timer.Start();
        }

        /// <summary>
        /// Wird immer aufgerufen, sobald der Timer-Interval abgelaufen ist.
        /// </summary>
        private void TickEvent(Object source, EventArgs e)
        {
            int faktorGeschwindigkeit = 15;

            for (int i = 0; i < rectangles.Length; i++)
            {
                rectangles[i].Y = rectangles[i].Y + rectangles[i].Height / faktorGeschwindigkeit;

                if (rectangles[i].Top > this.ClientSize.Height)
                {
                    rectangles[i].X = rnd.Next(0, this.ClientSize.Width);
                    rectangles[i].Y = 0 - rectangles[i].Height;
                }
            }

            Refresh();
        }

        private void CreateRectangles()
        {
            int faktorMin = 70;
            int faktorMax = 20;

            for (int i = 0; i < rectangles.Length; i++)
            {
                // Zufällige Größe in Relation zur Clientsize
                int rectWidth = rnd.Next(this.ClientSize.Width / faktorMin, this.ClientSize.Width / faktorMax);

                // Zufälle Anordung 
                Rectangle rect = new Rectangle( rnd.Next(0, this.ClientSize.Width), 
                                                rnd.Next(0, this.ClientSize.Height), 
                                                rectWidth, 
                                                rectWidth);
                rectangles[i] = rect;
            }
        }

        private void SnowingSquares_Paint(object sender, PaintEventArgs e)
        {
            //Hilfvariablen
            Graphics g = e.Graphics;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            
            Paint_Background(g);

            Brush brush = new SolidBrush(Color.White);
            foreach(Rectangle rect in rectangles)
            {
                g.FillEllipse(brush, rect);
            }
           
            
            //TODO jpg mit Schneeflockenform statt Draw.
        }

        private void Paint_Background(Graphics g)
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            int faktorX = w/40;
            int faktorY = h/20;
            
            //Zeichenmittel
            Brush brMauern = new SolidBrush(Color.FromArgb(116, 113, 109));
            Brush brGlass = new SolidBrush(Color.FromArgb(100, 98, 92));
            Brush brHolz = new SolidBrush(Color.FromArgb(126, 69, 43));
            Brush brBoden = new SolidBrush(Color.FromArgb(188,145,129));
            

            Rectangle mauern = new Rectangle(faktorX, faktorY * 6, w-faktorX * 2,  faktorY * 12);
            g.FillRectangle(brMauern, mauern);

            Rectangle glassGanzLinks = new Rectangle(mauern.X + faktorX, mauern.Y + faktorY, faktorX * 3, mauern.Height - faktorY);
            g.FillRectangle(brGlass, glassGanzLinks);

            Rectangle holz = new Rectangle(glassGanzLinks.Right, glassGanzLinks.Top, faktorX * 16, glassGanzLinks.Height);
            g.FillRectangle(brHolz, holz);

            Rectangle glassRechtsNebenHolz= new Rectangle(holz.Right, glassGanzLinks.Top, faktorX * 3, glassGanzLinks.Height);
            g.FillRectangle(brGlass, glassRechtsNebenHolz);
            
            Rectangle glassUberTuer= new Rectangle(glassRechtsNebenHolz.Right + faktorX, glassGanzLinks.Top, faktorX * 6, glassGanzLinks.Height);
            g.FillRectangle(brGlass, glassUberTuer);
            
            Rectangle glassGanzRechts= new Rectangle(glassUberTuer.Right + faktorX, glassGanzLinks.Top, glassUberTuer.Width, glassGanzLinks.Height);
            g.FillRectangle(brGlass, glassGanzRechts);

            Rectangle Tuer = new Rectangle(glassUberTuer.X, glassUberTuer.Bottom - faktorY * 3, glassUberTuer.Width, faktorY * 3);
            g.FillRectangle(brHolz, Tuer);


            int faktorFensterX = holz.Width / 13; //6 fenster
            int faktorFensterY = holz.Height / 7;

            for (int i = 1; i < 7; i+=3)
            {
                for (int j = 1; j < 13; j+= 3)
                {
                    Rectangle fenster = new Rectangle(holz.X + faktorFensterX * j, holz.Y + faktorFensterY * i, faktorFensterX*2, faktorFensterY*2);
                    g.FillRectangle(brGlass,fenster);

                }
            }

            Rectangle boden = new Rectangle(0,mauern.Bottom, w, h-mauern.Bottom);
            g.FillRectangle(brBoden, boden);

        }
    }
}

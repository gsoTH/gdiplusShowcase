using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            
            //PaintGSO(g);

            Brush brush = new SolidBrush(Color.White);
            foreach(Rectangle rect in rectangles)
            {
                g.FillEllipse(brush, rect);
            }
           
            PaintWindow(g);
            //TODO jpg mit Schneeflockenform statt Draw.
            Brush brText = new SolidBrush(Color.Red);
            RectangleF text = new RectangleF(0.0f, 0.0f, Convert.ToSingle(w / 2), Convert.ToSingle(h / 3));
           
            g.DrawString("Frohe Weihnachten!", this.Font,brText, text);
        }

        private void PaintWindow(Graphics g)
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            //Zeichenmittel
            Pen pFensterrahmen = new Pen(Color.SaddleBrown, 12);
            Brush brMauernHell = new SolidBrush(Color.FromArgb(116, 113, 109));
            Brush brMauernDunkel = new SolidBrush(Color.FromArgb(100, 98, 92));
            Brush brHolz = new SolidBrush(Color.FromArgb(126, 69, 43));
            Brush brVorhang = new SolidBrush(Color.DarkGreen);
            Pen pVorhangRand = new Pen(Color.Gold, 2);


            //Rechtecke hinter dem Vorhang
            Rectangle linkeWand = new Rectangle(0, 0, w/5, h);
            Rectangle rechteWand = new Rectangle(w - linkeWand.Width, 0, linkeWand.Width, h);

            g.FillRectangle(brMauernHell, linkeWand);
            g.FillRectangle(brMauernHell, rechteWand);


            //Fensterbank
            int faktor = linkeWand.Width / 6;
            Point[] fensterbank =
            {
                new Point(faktor, h - faktor*2),//links, unten, unterkante
                new Point(faktor, h - faktor), //links, unten, oberkante
                new Point(w - faktor, h - faktor), //rechts, unten, oberkante
                new Point(w - faktor, h - faktor*2),//rechts, unten, unterkante
                new Point(rechteWand.Left, h - faktor*3),
                new Point(linkeWand.Right, h - faktor*3)
            };
            //Darstellung ganz unten
            


            //Fenster
            Rectangle fenster = new Rectangle(linkeWand.Right, 0, w - linkeWand.Width - rechteWand.Width, fensterbank[fensterbank.Length-1].Y);
            g.DrawRectangle(pFensterrahmen, fenster);
            fenster.Width = fenster.Width/2;
            g.DrawRectangle(pFensterrahmen, fenster);
            fenster.Height = fenster.Height/2;
            fenster.Width = fenster.Width*2;
            g.DrawRectangle(pFensterrahmen, fenster);

            g.DrawArc(pFensterrahmen, fenster, 270, 90); //Rundung oben rechts. 0° = 3 Uhr.
            g.DrawArc(pFensterrahmen, fenster, 180, 90);



            Rectangle untereWand = new Rectangle(fensterbank[0].X + 10, fensterbank[0].Y, w - ((fensterbank[0].X + 10) *2), h);
            g.FillRectangle(brMauernDunkel, untereWand);

            
            //Vorhänge            
            Point[] vorhangLinks =
            {
                new Point(-1, -1),
                new Point(w/5*2, -1), //Oben, relativ mittig
                new Point(linkeWand.Width/3*4, fenster.Bottom),
                new Point(linkeWand.Width/2, fensterbank[fensterbank.Length-1].Y),
                new Point(linkeWand.Width/2, h+1),
                new Point(-1, h+1)
            };
            
            Point[] vorhangRechts =
            {
                new Point(w+1, -1),
                new Point(w- vorhangLinks[1].X, -1), 
                new Point(w-linkeWand.Width/3*4, fenster.Bottom),
                new Point(w-linkeWand.Width/2, fensterbank[fensterbank.Length-1].Y),
                new Point(w-linkeWand.Width/2, h+1),
                new Point(w+1, h+1)
            };

            g.FillPolygon(brVorhang, vorhangLinks);
            g.DrawPolygon(pVorhangRand, vorhangLinks);
            g.FillPolygon(brVorhang, vorhangRechts);
            g.DrawPolygon(pVorhangRand, vorhangRechts);
            
            //Fensterbank zeichen, damit sie vor dem Rest dargestellt wird
            g.FillPolygon(brHolz, fensterbank);


        }

        private void PaintGSO(Graphics g)
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

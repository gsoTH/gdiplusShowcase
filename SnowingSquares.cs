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

            Brush brush = new SolidBrush(Color.White);
            foreach(Rectangle rect in rectangles)
            {
                g.FillEllipse(brush, rect);
            }
           
            //TODO Hintergrund darstellen
            //TODO jpg mit Schneeflockenform statt Draw.
        }
    }
}

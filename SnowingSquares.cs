using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Timers;

namespace gdiplusShowcase
{
    public partial class SnowingSquares : Form
    {
        static int limitRectangles = 10;


        Rectangle[] rectangles  = new Rectangle[limitRectangles];
        static Timer timer;
        Random rnd = new Random();
        public SnowingSquares()
        {
            InitializeComponent();
            CreateRectangles();
            SetTimer();

        }

        /// <summary>
        /// Erzeugt einen Timer und stellt das zugehörige Ereignis her.
        /// </summary>
        private void SetTimer()
        {
            // Create a timer with interval in ms
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
            for (int i = 0; i < rectangles.Length; i++)
            {
                rectangles[i].Y = rectangles[i].Y + rectangles[i].Height/15;

                if (rectangles[i].Top > this.ClientSize.Height)
                {
                    rectangles[i].Y = 0 - rectangles[i].Height;
                }
            }

            Refresh();
        }

        private void CreateRectangles()
        {
            for (int i = 0; i < rectangles.Length; i++)
            {
                // Zufällige Größe in Relation zur Clientsize
                int rectWidth = rnd.Next(this.ClientSize.Width / 70, this.ClientSize.Width /20);

                // Zufälle Anordung 
                Rectangle rect = new Rectangle( rnd.Next(0, this.ClientSize.Width), 
                                                rnd.Next(0, this.ClientSize.Height), 
                                                rectWidth, 
                                                rectWidth);
                rectangles[i] = rect;
                //rectangles.Add(rect);
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
            //TODO jpg mit Schneeflockenform statt Rechteck.
        }
    }
}

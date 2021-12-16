using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace gdiplusShowcase
{
    public partial class SnowingSquares : Form
    {
        int rectangleLimit = 10;
        List<Rectangle> rectangles  = new List<Rectangle>();
        static System.Timers.Timer timer;
        Random rnd = new Random();
        public SnowingSquares()
        {
            InitializeComponent();
            SetTimer();

        }

        /// <summary>
        /// Erzeugt einen Timer und stellt das zugehörige Ereignis her.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/de-de/dotnet/api/system.timers.timer?view=net-6.0"/>
        private void SetTimer()
        {
            // Create a timer with interval in ms
            timer = new System.Timers.Timer(500);

            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        /// <summary>
        /// Wird immer aufgerufen, sobald der Timer-Interval abgelaufen ist.
        /// </summary>
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            CreateRectangles();
            Refresh();
        }

        private void CreateRectangles()
        {
            if(rectangles.Count < rectangleLimit)
            {
                int rectWidth = rnd.Next(10, 50);
                Rectangle rect = new Rectangle( rnd.Next(0, this.ClientSize.Width), 
                                                rnd.Next(0, this.ClientSize.Height), 
                                                rectWidth, 
                                                rectWidth);

                rectangles.Add(rect);
            }
        }

        private void SnowingSquares_Paint(object sender, PaintEventArgs e)
        {
            //Hilfvariablen
            Graphics g = e.Graphics;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            Pen pen = new Pen(Color.AliceBlue, 2);
            foreach(Rectangle rect in rectangles)
            {
                g.DrawRectangle(pen, rect);
            }
           
        }
    }
}

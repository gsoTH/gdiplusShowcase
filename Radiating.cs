using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace gdiplusShowcase
{
    public partial class Radiating : Form
    {
        Timer animationTimer;
        List<Rectangle> rects = new List<Rectangle>();

        public Radiating()
        {
            InitializeComponent();
            this.Size = new Size(600, 600);
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            DoubleBuffered = true;
            //TODO AntiAliasing einbauen

            animationTimer = new Timer();
            animationTimer.Interval = 10;
            animationTimer.Tick += TimerTickEvent;
            animationTimer.Start();

        }

        private void TimerTickEvent(Object source, EventArgs e)
        {
            Refresh();
        }

        private void Radiating_Paint(object sender, PaintEventArgs e)
        {
            //Hilfsvariablen
            Graphics g = e.Graphics;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            int sizeFactor = 10;

            rects.Add(new Rectangle(w / 2, h / 2, 1, 1));
            
            GrowCircles(g, sizeFactor);
        }

        private void GrowCircles(Graphics g, int sizeFactor)
        {
            for (int i = 0; i < rects.Count; i++)
            {
                if (rects[i].Size.Width > this.ClientSize.Width * 1.5
                    || rects[i].Size.Height > this.ClientSize.Height * 1.5)
                {
                    rects.RemoveAt(i);
                }

                Rectangle r = rects[i];

                r.X -= sizeFactor / 2;
                r.Y -= sizeFactor / 2;
                r.Width += sizeFactor;
                r.Height += sizeFactor;

                //Value Semantics...
                //r ist eine volle Kopie von rects[i].
                //Die Veränderung muss wieder zurückgespielt werden.
                rects[i] = r;
                
                
                DrawCircles(g, sizeFactor, i, r);
            }
        }

        private static void DrawCircles(Graphics g, int sizeFactor, int i, Rectangle r)
        {
            if (i % 2 == 0)
            {
                g.DrawEllipse(new Pen(Color.White, sizeFactor), r);
            }
            else
            {
                g.DrawEllipse(new Pen(Color.Black, sizeFactor), r);
            }
        }
    }
}

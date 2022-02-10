using System;
using System.Drawing;
using System.Windows.Forms;

namespace gdiplusShowcase
{
    public partial class Radiating : Form
    {
        // System.Windows.Forms besitzt einen eigenen Timer, daher 
        // muss die gewünschte Klasse hier explizit genannt werden.
        System.Timers.Timer animationTimer;

        public Radiating()
        {
            InitializeComponent();
            this.Size = new Size(600, 600);
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            animationTimer = new System.Timers.Timer();
            animationTimer.Interval = 500;
            animationTimer.Elapsed += TimerElapsedEvent;
            animationTimer.Start();

        }

        private void TimerElapsedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Refresh();
        }

        private void Radiating_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

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
    public partial class SimpleTimer : Form
    {
        static Timer timer = new Timer();
        Rectangle rect = new Rectangle(0, 0, 50, 50);
        public SimpleTimer()
        {
            InitializeComponent();
            SetTimer();
        }

        /// <summary>
        /// Einstellungen für den Timer vornehmen und Timer starten.
        /// </summary>
        private void SetTimer()
        {
            // Timer mit Intervall in ms erstellen
            timer.Interval = 50;

            // Stellt einen Verweis zur Ereignisbehandlungsmethode her.
            //TODO kann ein Timer auch mehrere TickEvents haben?
            timer.Tick += TickEvent;

            timer.Start();
        }

        /// <summary>
        /// Jeder Timer erhält ein Timer-Event. 
        /// Dieses Event wird immer aufgerufen, sobald der Timer-Interval abgelaufen ist.
        /// </summary>
        private void TickEvent(Object source, EventArgs e)
        {
            // Rechteck nach rechts verschieben
            rect.X += 10;

            // Paint Ereignis auslösen
            Refresh();

            // Wenn das Rechteck aus dem Fenster gewandert ist, wird der Timer gestoppt.
            if(rect.X > this.ClientSize.Width)
            {
                timer.Stop();
                MessageBox.Show("Timer gestoppt.");
            }
        }

        private void SimpleTimer_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen (Color.Black);
            e.Graphics.DrawRectangle(pen, rect);
        }
    }
}

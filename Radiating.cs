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
    public partial class Radiating : Form
    {
        // System.Windows.Forms besitzt einen eigenen Timer, daher 
        // muss die gewünschte Klasse hier explizit genannt werden.
        System.Timers.Timer animationTimer = new System.Timers.Timer();

        public Radiating()
        {
            InitializeComponent();
            this.Size = new Size(600, 600);
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void Radiating_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

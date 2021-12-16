
namespace gdiplusShowcase
{
    partial class FrmErsteSchritte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmErsteSchritte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "FrmErsteSchritte";
            this.Text = "Erste Schritte";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmErsteSchritte_Paint);
            this.Resize += new System.EventHandler(this.FrmErsteSchritte_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
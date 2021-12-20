namespace gdiplusShowcase
{
    partial class SnowingSquares
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
            // SnowingSquares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1486, 960);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "SnowingSquares";
            this.Text = "FlyingSquares";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SnowingSquares_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
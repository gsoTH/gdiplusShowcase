
namespace gdiplusShowcase
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbxChooseForm = new System.Windows.Forms.ListBox();
            this.btnShowForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxChooseForm
            // 
            this.lbxChooseForm.FormattingEnabled = true;
            this.lbxChooseForm.ItemHeight = 32;
            this.lbxChooseForm.Location = new System.Drawing.Point(41, 29);
            this.lbxChooseForm.Name = "lbxChooseForm";
            this.lbxChooseForm.Size = new System.Drawing.Size(393, 356);
            this.lbxChooseForm.TabIndex = 0;
            // 
            // btnShowForm
            // 
            this.btnShowForm.Location = new System.Drawing.Point(41, 409);
            this.btnShowForm.Name = "btnShowForm";
            this.btnShowForm.Size = new System.Drawing.Size(393, 72);
            this.btnShowForm.TabIndex = 1;
            this.btnShowForm.Text = "Anzeigen!";
            this.btnShowForm.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AcceptButton = this.btnShowForm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 493);
            this.Controls.Add(this.btnShowForm);
            this.Controls.Add(this.lbxChooseForm);
            this.Name = "FrmMain";
            this.Text = "GDI+ Showcase";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxChooseForm;
        private System.Windows.Forms.Button btnShowForm;
    }
}


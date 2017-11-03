namespace MyGame
{
    partial class GameForm
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
            this.ContainerBox = new System.Windows.Forms.PictureBox();
            this.btnStartStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ContainerBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ContainerBox
            // 
            this.ContainerBox.Location = new System.Drawing.Point(13, 13);
            this.ContainerBox.Name = "ContainerBox";
            this.ContainerBox.Size = new System.Drawing.Size(259, 207);
            this.ContainerBox.TabIndex = 0;
            this.ContainerBox.TabStop = false;
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(101, 226);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 1;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.ContainerBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ContainerBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ContainerBox;
        private System.Windows.Forms.Button btnStartStop;
    }
}


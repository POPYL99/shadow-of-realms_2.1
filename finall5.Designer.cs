namespace project
{
    partial class finall5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(finall5));
            this.door = new System.Windows.Forms.PictureBox();
            this.blayer = new System.Windows.Forms.PictureBox();
            this.conversation1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.door)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conversation1)).BeginInit();
            this.SuspendLayout();
            // 
            // door
            // 
            this.door.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door.Image = ((System.Drawing.Image)(resources.GetObject("door.Image")));
            this.door.Location = new System.Drawing.Point(120, 10);
            this.door.Margin = new System.Windows.Forms.Padding(1);
            this.door.Name = "door";
            this.door.Size = new System.Drawing.Size(128, 111);
            this.door.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.door.TabIndex = 25;
            this.door.TabStop = false;
            // 
            // blayer
            // 
            this.blayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blayer.Image = ((System.Drawing.Image)(resources.GetObject("blayer.Image")));
            this.blayer.Location = new System.Drawing.Point(167, 448);
            this.blayer.Margin = new System.Windows.Forms.Padding(1);
            this.blayer.Name = "blayer";
            this.blayer.Size = new System.Drawing.Size(43, 65);
            this.blayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.blayer.TabIndex = 26;
            this.blayer.TabStop = false;
            this.blayer.Click += new System.EventHandler(this.blayer_Click);
            // 
            // conversation1
            // 
            this.conversation1.Image = ((System.Drawing.Image)(resources.GetObject("conversation1.Image")));
            this.conversation1.Location = new System.Drawing.Point(255, 544);
            this.conversation1.Name = "conversation1";
            this.conversation1.Size = new System.Drawing.Size(652, 144);
            this.conversation1.TabIndex = 27;
            this.conversation1.TabStop = false;
            // 
            // finall5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(953, 700);
            this.Controls.Add(this.conversation1);
            this.Controls.Add(this.blayer);
            this.Controls.Add(this.door);
            this.Name = "finall5";
            this.Text = "finall5";
            this.Load += new System.EventHandler(this.finall5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.door)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conversation1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox door;
        private System.Windows.Forms.PictureBox blayer;
        private System.Windows.Forms.PictureBox conversation1;
    }
}
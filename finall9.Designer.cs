namespace project
{
    partial class finall9
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
            this.blayer = new System.Windows.Forms.PictureBox();
            this.door = new System.Windows.Forms.PictureBox();
            this.p2 = new System.Windows.Forms.PictureBox();
            this.p1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.blayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.door)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).BeginInit();
            this.SuspendLayout();
            // 
            // blayer
            // 
            this.blayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blayer.Image = global::project.Properties.Resources.uporiginalpluse2;
            this.blayer.Location = new System.Drawing.Point(453, 537);
            this.blayer.Margin = new System.Windows.Forms.Padding(1);
            this.blayer.Name = "blayer";
            this.blayer.Size = new System.Drawing.Size(28, 37);
            this.blayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.blayer.TabIndex = 30;
            this.blayer.TabStop = false;
            // 
            // door
            // 
            this.door.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door.Image = global::project.Properties.Resources.oie_transparent__27_1;
            this.door.Location = new System.Drawing.Point(403, 278);
            this.door.Margin = new System.Windows.Forms.Padding(1);
            this.door.Name = "door";
            this.door.Size = new System.Drawing.Size(135, 137);
            this.door.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.door.TabIndex = 41;
            this.door.TabStop = false;
            this.door.Click += new System.EventHandler(this.door_Click);
            // 
            // p2
            // 
            this.p2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p2.Image = global::project.Properties.Resources.Zt76lyt1Gpkb;
            this.p2.Location = new System.Drawing.Point(349, 389);
            this.p2.Margin = new System.Windows.Forms.Padding(1);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(34, 38);
            this.p2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.p2.TabIndex = 42;
            this.p2.TabStop = false;
            // 
            // p1
            // 
            this.p1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p1.Image = global::project.Properties.Resources.Zt76lyt1Gpkb;
            this.p1.Location = new System.Drawing.Point(566, 389);
            this.p1.Margin = new System.Windows.Forms.Padding(1);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(34, 38);
            this.p1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.p1.TabIndex = 43;
            this.p1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Cursor = System.Windows.Forms.Cursors.Help;
            this.label1.Font = new System.Drawing.Font("Viner Hand ITC", 28.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(637, 289);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 74);
            this.label1.TabIndex = 45;
            this.label1.Text = "back to home";
            // 
            // finall9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::project.Properties.Resources.BBsPdo;
            this.ClientSize = new System.Drawing.Size(947, 584);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.door);
            this.Controls.Add(this.blayer);
            this.Name = "finall9";
            this.Text = "finall9";
            this.Load += new System.EventHandler(this.finall9_Load);
            ((System.ComponentModel.ISupportInitialize)(this.blayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.door)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox blayer;
        private System.Windows.Forms.PictureBox door;
        private System.Windows.Forms.PictureBox p2;
        private System.Windows.Forms.PictureBox p1;
        private System.Windows.Forms.Label label1;
    }
}
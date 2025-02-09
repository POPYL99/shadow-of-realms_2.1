using System;
using System.Drawing;
using System.Windows.Forms;

namespace project
{
    public partial class finall6 : Form
    {
        bool goUp, goDown, goLeft, goRight;
        int playerSpeed = 8;
        bool showConversation1 = true;
        bool showConversation2 = false;
        bool showConversation3 = false;
        bool formOpened = false;

        public finall6()
        {
            InitializeComponent();
            this.KeyPreview = true;

            // Attach key events
            this.KeyDown += new KeyEventHandler(KeyIsDown);
            this.KeyUp += new KeyEventHandler(KeyIsUp);

            // Setup and start the timer
            Timer timer = new Timer();
            timer.Interval = 20;
            timer.Tick += new EventHandler(TimerEvent);
            timer.Start();
        }

        private void finall6_Load(object sender, EventArgs e)
        {
            // Animated background setup
            PictureBox animatedBackground = new PictureBox();
            animatedBackground.Dock = DockStyle.Fill;
            animatedBackground.Image = Properties.Resources.oie_overlay;
            animatedBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(animatedBackground);
            animatedBackground.SendToBack();

            // Initial conversation setup
            conversation1.Parent = this;
            conversation1.BackColor = Color.Transparent;
            conversation1.Visible = true;

            conversation2.Parent = this;
            conversation2.BackColor = Color.Transparent;
            conversation2.Visible = false;

            conversation3.Parent = this;
            conversation3.BackColor = Color.Transparent;
            conversation3.Visible = false;

            // Setup other elements
            blayer.Parent = this;
            blayer.BackColor = Color.Transparent;

            skeleton1.Parent = this;
            skeleton1.BackColor = Color.Transparent;

            skeleton2.Parent = this;
            skeleton2.BackColor = Color.Transparent;

            skeleton3.Parent = this;
            skeleton3.BackColor = Color.Transparent;

            skeleton4.Parent = this;
            skeleton4.BackColor = Color.Transparent;

            skeleton5.Parent = this;
            skeleton5.BackColor = Color.Transparent;

            p1.Parent = this;
            p1.BackColor = Color.Transparent;

            p2.Parent = this;
            p2.BackColor = Color.Transparent;

            door.Parent = this;
            door.BackColor = Color.Transparent;
            
            surprise.Parent = this;
            surprise.BackColor = Color.Transparent;
        }


        private void TimerEvent(object sender, EventArgs e)
        {
            // Player movement logic
            if (goLeft && blayer.Left > 0) blayer.Left -= playerSpeed;
            if (goRight && blayer.Right < ClientSize.Width) blayer.Left += playerSpeed;
            if (goDown && blayer.Bottom < ClientSize.Height) blayer.Top += playerSpeed;
            if (goUp && blayer.Top > 0) blayer.Top -= playerSpeed;

            // Check for collision with skeleton1
            if (blayer.Bounds.IntersectsWith(skeleton1.Bounds) && !showConversation2)
            {
                conversation2.Visible = true;
                showConversation2 = true;
                blayer.Left -= 60;
            }

            // Check for collision with the DOOR to open the new form once
            if (blayer.Bounds.IntersectsWith(door.Bounds) && !formOpened)
            {
                formOpened = true; // تحديد أن الفورم تم فتحه
                finall7 newForm = new finall7(); // إنشاء الفورم الجديد
                newForm.Show(); // عرض الفورم الجديد
                this.Hide();
            }
        }


        private void KeyIsDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
                blayer.Image = Properties.Resources.leftoriginalplus;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                blayer.Image = Properties.Resources.rightoriginalplus;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                blayer.Image = Properties.Resources.uporiginalpluse;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                blayer.Image = Properties.Resources.downoriginalplus;
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (showConversation1)
                {
                    conversation1.Visible = false;
                    showConversation1 = false;
                }
                else if (showConversation2)
                {
                    conversation2.Visible = false;
                    conversation3.Visible = true;
                    showConversation2 = false;
                    showConversation3 = true;
                }
                else if (showConversation3)
                {
                    conversation3.Visible = false;
                    showConversation3 = false;
                }
            }

            if (e.KeyCode == Keys.Left) goLeft = true;
            if (e.KeyCode == Keys.Right) goRight = true;
            if (e.KeyCode == Keys.Up) goUp = true;
            if (e.KeyCode == Keys.Down) goDown = true;
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) goLeft = false;
            if (e.KeyCode == Keys.Right) goRight = false;
            if (e.KeyCode == Keys.Up) goUp = false;
            if (e.KeyCode == Keys.Down) goDown = false;
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace project
{
    public partial class finall4 : Form
    {
        bool goUp, goDown, goLeft, goRight;
        int playerSpeed = 8;
        bool showConversation1, showConversation2, showConversation3;
        bool formOpened = false; // متغير للتحقق من فتح الفورم مرة واحدة

        public finall4()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(KeyIsDown);
            this.KeyUp += new KeyEventHandler(KeyIsUp);

            Timer timer = new Timer();
            timer.Interval = 20;
            timer.Tick += new EventHandler(TimerEvent);
            timer.Start();
        }

        private void door_Click(object sender, EventArgs e)
        {

        }

        private void finall4_Load(object sender, EventArgs e)
        {
            blayer.Parent = this;
            blayer.BackColor = Color.Transparent;

            candle1.Parent = this;
            candle1.BackColor = Color.Transparent;

            candle2.Parent = this;
            candle2.BackColor = Color.Transparent;

            candle3.Parent = this;
            candle3.BackColor = Color.Transparent;

            candle4.Parent = this;
            candle4.BackColor = Color.Transparent;

            door.Parent = this;
            door.BackColor = Color.Transparent;

            women.Parent = this;
            women.BackColor = Color.Transparent;

            surprise.Parent = this;
            surprise.BackColor = Color.Transparent;

            pictureBox1.Parent= this;
            pictureBox1.BackColor = Color.Transparent;

            // إظهار conversation1 عند بدء الفورم
            conversation1.Visible = true;
            showConversation1 = true;

            conversation2.Visible = false;
            conversation3.Visible = false;
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            if (goLeft && blayer.Left > 0) blayer.Left -= playerSpeed;
            if (goRight && blayer.Right < ClientSize.Width) blayer.Left += playerSpeed;
            if (goDown && blayer.Bottom < ClientSize.Height) blayer.Top += playerSpeed;
            if (goUp && blayer.Top > 0) blayer.Top -= playerSpeed;

            // عرض conversation2 عند اقتراب اللاعب من women
            if (blayer.Bounds.IntersectsWith(women.Bounds) && !showConversation2 && !showConversation3)
            {
                showConversation2 = true;
                conversation2.Visible = true;
                blayer.Left -= 60;
            }

            // التحقق من الوصول إلى صورة DOOR
            if (blayer.Bounds.IntersectsWith(door.Bounds) && !formOpened)
            {
                // فتح الفورم التالي finall5 مرة واحدة فقط
                formOpened = true;
                finall5 nextForm = new finall5();
                nextForm.Show();
                this.Hide();
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (showConversation1 && conversation1.Visible)
                {
                    conversation1.Visible = false;
                    showConversation1 = false;
                }
                else if (conversation2.Visible)
                {
                    conversation2.Visible = false;
                    showConversation2 = false;
                    showConversation3 = true;
                    conversation3.Visible = true;
                }
                else if (conversation3.Visible)
                {
                    conversation3.Visible = false;
                    showConversation3 = false;
                }
            }

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

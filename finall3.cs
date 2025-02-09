using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class finall3 : Form
    {
        bool goUp, goDown, goLeft, goRight;
        int playerSpeed = 8;
        bool gotKey, errorMessage = false;
        bool formOpened = false;
        bool showConversation2, showConversation3; // لتتبع حالة ظهور الصور

        public finall3()
        {
            InitializeComponent();
            this.KeyPreview = true;

            // ربط أحداث الضغط ورفع الضغط عن الأزرار
            this.KeyDown += new KeyEventHandler(KeyIsDown);
            this.KeyUp += new KeyEventHandler(KeyIsUp);

            // إعداد وتفعيل التايمر
            Timer timer = new Timer();
            timer.Interval = 20;
            timer.Tick += new EventHandler(TimerEvent);
            timer.Start();

            // إظهار الصورة عند بدء الفورم
            conversation1.Visible = true;
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            if (goLeft && blayer.Left > 0)
            {
                blayer.Left -= playerSpeed;
            }
            if (goRight && blayer.Right < ClientSize.Width)
            {
                blayer.Left += playerSpeed;
            }
            if (goDown && blayer.Bottom < ClientSize.Height)
            {
                blayer.Top += playerSpeed;
            }
            if (goUp && blayer.Top > 0)
            {
                blayer.Top -= playerSpeed;
            }

            // التحقق من التصادم مع UncleJane
            if (blayer.Bounds.IntersectsWith(UncleJane.Bounds) && !showConversation2 && !showConversation3)
            {
                showConversation2 = true;
                conversation2.Visible = true;
                blayer.Left += 50;
                GameTimer.Stop();
                GameTimer.Start();
            }

            // التحقق من التصادم مع الباب door
            if (blayer.Bounds.IntersectsWith(door.Bounds) && !formOpened)
            {
                formOpened = true; // تعيين المتغير إلى true حتى لا يتم فتح النموذج مرة أخرى
                finall4 newForm = new finall4();
                newForm.Show();
                this.Hide();

            }
        }


        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (conversation1.Visible)
                {
                    conversation1.Visible = false;
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
                blayer.BackColor = Color.Transparent;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                blayer.Image = Properties.Resources.rightoriginalplus;
                blayer.BackColor = Color.Transparent;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                blayer.Image = Properties.Resources.uporiginalpluse;
                blayer.BackColor = Color.Transparent;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                blayer.Image = Properties.Resources.downoriginalplus;
                blayer.BackColor = Color.Transparent;
            }

            if (boxlimits1.Bounds.IntersectsWith(blayer.Bounds))
            {
                blayer.Left += 120;
                GameTimer.Stop();
                GameTimer.Start();
            }
            if (boxlimits2.Bounds.IntersectsWith(blayer.Bounds))
            {
                blayer.Left += 50;
                GameTimer.Stop();
                GameTimer.Start();
            }
            if (boxlimits3.Bounds.IntersectsWith(blayer.Bounds))
            {
                blayer.Left -= 80;
                GameTimer.Stop();
                GameTimer.Start();
            }
            if (boxlimits4.Bounds.IntersectsWith(blayer.Bounds))
            {
                blayer.Left += 80;
                GameTimer.Stop();
                GameTimer.Start();
            }
        }

        private void finall3_Load(object sender, EventArgs e)
        {
            blayer.Parent = this;
            blayer.BackColor = Color.Transparent;

            UncleJane.Parent = this;
            UncleJane.BackColor = Color.Transparent;

            fishing.Parent = this;
            fishing.BackColor = Color.Transparent;

            fish1.Parent = this;
            fish1.BackColor = Color.Transparent;

            fish2.Parent = this;
            fish2.BackColor = Color.Transparent; 

            tree1.Parent = this;
            tree1.BackColor = Color.Transparent;

            tree2.Parent = this;
            tree2.BackColor = Color.Transparent;

            cow1.Parent = this;
            cow1.BackColor = Color.Transparent;

            cow2.Parent = this;
            cow2.BackColor = Color.Transparent;

            horse.Parent = this;
            horse.BackColor = Color.Transparent;

            door.Parent = this;
            door.BackColor = Color.Transparent;

            surprise.Parent = this;
            surprise.BackColor = Color.Transparent;

            conversation1.BringToFront();
            conversation2.BringToFront();
            conversation3.BringToFront();
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

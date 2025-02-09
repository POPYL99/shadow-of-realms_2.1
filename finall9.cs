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
    public partial class finall9 : Form
    {

        bool goUp, goDown, goLeft, goRight;
        int playerSpeed = 8;
        bool gotKey, errorMessage = false;
        bool hasEnteredDoor = false;  // متغير لتتبع حالة دخول الباب


        public finall9()
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

        }

        private void finall9_Load(object sender, EventArgs e)
        {
            PictureBox animatedBackground = new PictureBox();
            animatedBackground.Dock = DockStyle.Fill;
            animatedBackground.Image = Properties.Resources.BBsPdo;
            animatedBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(animatedBackground);
            animatedBackground.SendToBack();

            door.Parent = this;
            door.BackColor = Color.Transparent;

            p1.Parent = this;
            p1.BackColor = Color.Transparent;

            p2.Parent = this;
            p2.BackColor = Color.Transparent;

            label1.Parent = this;
            label1.BackColor = Color.Transparent;
        }

        private void door_Click(object sender, EventArgs e)
        {

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

            if (blayer.Bounds.IntersectsWith(door.Bounds) && !hasEnteredDoor)
            {
                hasEnteredDoor = true; // تحديد أن الفورم تم فتحه
                fina10 newForm = new fina10(); // إنشاء الفورم الجديد
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

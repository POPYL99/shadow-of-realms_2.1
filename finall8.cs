using System;
using System.Drawing;
using System.Windows.Forms;

namespace project
{
    public partial class finall8 : Form
    {
        bool goUp, goDown, goLeft, goRight;
        int playerSpeed = 8;
        bool gotKey, errorMessage = false;
        PictureBox animatedBackground;
        int backgroundX = 0;

        bool itemCollected = false;  // متغير لتتبع حالة العنصر
        bool hasEnteredDoor = false;  // متغير لتتبع حالة دخول الباب
        bool hasOpenedDocument = false;
        public finall8()
        {
            InitializeComponent();
            this.KeyPreview = true;

            // ربط أحداث الضغط ورفع الضغط عن الأزرار
            this.KeyDown += new KeyEventHandler(KeyIsDown);
            this.KeyUp += new KeyEventHandler(KeyIsUp);

            // إعداد وتفعيل التايمر لحركة اللاعب
            Timer playerTimer = new Timer();
            playerTimer.Interval = 20;
            playerTimer.Tick += new EventHandler(TimerEvent);
            playerTimer.Start();
        }

        private void finall8_Load(object sender, EventArgs e)
        {
            // Setup animated background
            animatedBackground = new PictureBox();
            animatedBackground.Dock = DockStyle.Fill;
            animatedBackground.Image = Properties.Resources.OCywxn;
            animatedBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(animatedBackground);
            animatedBackground.SendToBack();

            blayer.Parent = this;
            blayer.BackColor = Color.Transparent;

            soor.Parent = this;
            soor.BackColor = Color.Transparent;

            p1.Parent = this;
            p1.BackColor = Color.Transparent;

            p2.Parent = this;
            p2.BackColor = Color.Transparent;

            document.Parent = this;
            document.BackColor = Color.Transparent;

            door.Parent = this;
            door.BackColor = Color.Transparent;
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
                finall9 newForm = new finall9(); // إنشاء الفورم الجديد
                newForm.Show(); // عرض الفورم الجديد
                this.Hide();
            }

            if (blayer.Bounds.IntersectsWith(document.Bounds) && !hasOpenedDocument)
            {
                hasOpenedDocument = true; // تحديد أن الفورم الخاص بالـ document تم فتحه
                finallDocment newForm = new finallDocment(); // إنشاء الفورم الجديد
                newForm.Show(); // عرض الفورم الجديد
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

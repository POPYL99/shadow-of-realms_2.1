using System;
using System.Drawing;
using System.Windows.Forms;

namespace project
{
    public partial class finall7 : Form
    {
        bool goUp, goDown, goLeft, goRight;
        int playerSpeed = 8;
        PictureBox animatedBackground;
        bool showStartImage = true;  // متغير لتتبع حالة الصورة عند بدء النموذج
        bool showConversation1 = false;
        bool showConversation2 = false;
        bool itemCollected = false;  // متغير لتتبع حالة العنصر
        bool hasEnteredDoor = false;  // متغير لتتبع حالة دخول الباب

        public finall7()
        {
            InitializeComponent();
            this.KeyPreview = true;

            // Attach key events
            this.KeyDown += new KeyEventHandler(KeyIsDown);
            this.KeyUp += new KeyEventHandler(KeyIsUp);

            // Setup and start the movement timer
            Timer movementTimer = new Timer();
            movementTimer.Interval = 20;
            movementTimer.Tick += new EventHandler(TimerEvent);
            movementTimer.Start();
        }

        private void finall7_Load(object sender, EventArgs e)
        {
            // Setup animated background
            animatedBackground = new PictureBox();
            animatedBackground.Dock = DockStyle.Fill;
            animatedBackground.Image = Properties.Resources.PIuk47;
            animatedBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(animatedBackground);
            animatedBackground.SendToBack();

            // Timer to refresh the PictureBox to ensure animation plays
            Timer refreshTimer = new Timer();
            refreshTimer.Interval = 100;
            refreshTimer.Tick += (s, ev) => animatedBackground.Invalidate();
            refreshTimer.Start();

            // إعدادات المحادثات
            fortuneTeller.Parent = this;
            fortuneTeller.BackColor = Color.Transparent;

            blayer.Parent = this;
            blayer.BackColor = Color.Transparent;

            door.Parent = this;
            door.BackColor = Color.Transparent;

            surprise.Parent = this;
            surprise.BackColor = Color.Transparent;

            // conversation1
            conversation1.Parent = this;
            conversation1.BackColor = Color.Transparent;
            conversation1.Visible = false;

            // conversation2
            conversation2.Parent = this;
            conversation2.BackColor = Color.Transparent;
            conversation2.Visible = false;

            // conversation3
            conversation3.Parent = this;
            conversation3.BackColor = Color.Transparent;
            conversation3.Visible = true;  // اجعلها مرئية عند بدء التشغيل

            // إعداد الصورة لجمعها
            itemImage.Parent = this;  // تأكد من تعيين Parent
            itemImage.BackColor = Color.Transparent;  // خلفية شفافة
            itemImage.Visible = false;  // اجعلها مخفية في البداية

            p2.Parent = this;
            p2.BackColor = Color.Transparent;
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            // Player movement logic
            if (goLeft && blayer.Left > 0) blayer.Left -= playerSpeed;
            if (goRight && blayer.Right < ClientSize.Width) blayer.Left += playerSpeed;
            if (goDown && blayer.Bottom < ClientSize.Height) blayer.Top += playerSpeed;
            if (goUp && blayer.Top > 0) blayer.Top -= playerSpeed;

            // Check for collision with fortune teller
            if (blayer.Bounds.IntersectsWith(fortuneTeller.Bounds) && !showConversation1)
            {
                conversation1.Visible = true;
                showConversation1 = true;
                blayer.Left += 60;
            }

            // Check for collision with item
            if (blayer.Bounds.IntersectsWith(itemImage.Bounds) && !itemCollected)
            {
                itemCollected = true; // اجمع العنصر
                itemImage.Visible = false; // اجعل العنصر غير مرئي
            }

            // Check for collision with door
            if (blayer.Bounds.IntersectsWith(door.Bounds) && !hasEnteredDoor)
            {
                hasEnteredDoor = true; // تحديد أن الفورم تم فتحه
                finall8 newForm = new finall8(); // إنشاء الفورم الجديد
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
                if (showStartImage)
                {
                    // اخفاء conversation3 عند الضغط على Enter
                    conversation3.Visible = false;
                    showStartImage = false;
                }
                else if (showConversation1)
                {
                    // اظهار conversation2
                    conversation1.Visible = false;
                    conversation2.Visible = true;
                    showConversation1 = false;
                    showConversation2 = true;
                }
                else if (showConversation2)
                {
                    // اخفاء conversation2
                    conversation2.Visible = false;
                    showConversation2 = false;

                    // إظهار الصورة بعد المحادثة
                    ShowItemImage();
                }
            }
        }

        private void ShowItemImage()
        {
            itemImage.Visible = true; // اجعل الصورة مرئية
            itemImage.BringToFront(); // اجعلها في المقدمة
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

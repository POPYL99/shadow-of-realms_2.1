using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace project
{
    public partial class fina10 : Form
    {
        bool goUp, goDown, goLeft, goRight;
        int playerSpeed = 8;
        bool isShooting = false;
        PictureBox projectile;
        Timer projectileTimer;

        bool showConversation1 = true;
        bool showConversation2 = false;
        bool showConversation3 = false;

        bool hasTalkedToAngel = false; // متغير لتحديد حالة التحدث مع الملاك
        Timer angelMoveTimer; // مؤقت لحركة الملاك
        bool angelMovingUp = true; // لتحديد اتجاه حركة الملاك
        bool followPlayer = false; // لتحديد إذا كان الملاك يتبع اللاعب

        public fina10()
        {
            InitializeComponent();
            this.KeyPreview = true;

            // ربط أحداث الضغط ورفع الضغط عن الأزرار
            this.KeyDown += new KeyEventHandler(KeyIsDown);
            this.KeyUp += new KeyEventHandler(KeyIsUp);

            // إعداد وتفعيل التايمر لحلقة اللعبة
            Timer gameTimer = new Timer();
            gameTimer.Interval = 20;
            gameTimer.Tick += new EventHandler(GameLoop);
            gameTimer.Start();

            // إعداد مؤقت المقذوف
            InitializeProjectileTimer();

            // إعداد مؤقت حركة الملاك
            InitializeAngelMoveTimer();
        }

        private void fina10_Load(object sender, EventArgs e)
        {
            tran.Parent = this;
            tran.BackColor = Color.Transparent;

            conversation1.Parent = this;
            conversation1.BackColor = Color.Transparent;
            conversation1.Visible = true;

            conversation2.Parent = this;
            conversation2.BackColor = Color.Transparent;
            conversation2.Visible = false;

            conversation3.Parent = this;
            conversation3.BackColor = Color.Transparent;
            conversation3.Visible = false;

            blayer.Parent = this;
            blayer.BackColor = Color.Transparent;

            angel.Parent = this;
            angel.BackColor = Color.Transparent;

            door2.Parent = this;
            door2.BackColor = Color.Transparent;

            p1.Parent = this;
            p1.BackColor = Color.Transparent;

            p2.Parent = this;
            p2.BackColor = Color.Transparent;

            surprise.Parent = this;
            surprise.BackColor = Color.Transparent;

            label1.Parent = this;
            label1.BackColor = Color.Transparent;

            // إعداد المقذوف
            projectile = new PictureBox
            {
                Size = new Size(20, 20),
                Image = Properties.Resources.trtr,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Visible = false
            };
            this.Controls.Add(projectile);
        }

        private void InitializeAngelMoveTimer()
        {
            angelMoveTimer = new Timer
            {
                Interval = 50 // سرعة حركة الملاك
            };
            angelMoveTimer.Tick += new EventHandler(MoveAngel);
        }

        private void MoveAngel(object sender, EventArgs e)
        {
            if (followPlayer)
            {
                // جعل الملاك يتحرك باتجاه اللاعب
                if (angel.Left < blayer.Left)
                {
                    angel.Left += 3; // السرعة تجاه اليمين
                }
                else if (angel.Left > blayer.Left)
                {
                    angel.Left -= 3; // السرعة تجاه اليسار
                }

                if (angel.Top < blayer.Top)
                {
                    angel.Top += 3; // السرعة تجاه الأسفل
                }
                else if (angel.Top > blayer.Top)
                {
                    angel.Top -= 3; // السرعة تجاه الأعلى
                }
            }
            else
            {
                // حركة الملاك التقليدية للأعلى والأسفل
                if (angelMovingUp)
                {
                    angel.Top -= 5; // تحرك للأعلى
                    if (angel.Top <= 50) // حدود الحركة للأعلى
                    {
                        angelMovingUp = false;
                    }
                }
                else
                {
                    angel.Top += 5; // تحرك للأسفل
                    if (angel.Bottom >= this.ClientSize.Height - 50) // حدود الحركة للأسفل
                    {
                        angelMovingUp = true;
                    }
                }
            }
        }
        // إضافة متغير لتحديد ما إذا كان الباب تم المرور من خلاله
        bool hasEnteredDoor = false;

        private void GameLoop(object sender, EventArgs e)
        {
            if (blayer == null || projectile == null || angel == null) return;

            // حركة اللاعب
            if (goLeft && blayer.Left > 0) blayer.Left -= playerSpeed;
            if (goRight && blayer.Right < ClientSize.Width) blayer.Left += playerSpeed;
            if (goUp && blayer.Top > 0) blayer.Top -= playerSpeed;
            if (goDown && blayer.Bottom < ClientSize.Height) blayer.Top += playerSpeed;

            // التحقق من الاصطدام مع الباب وفتح الفورم الجديد
            if (blayer.Bounds.IntersectsWith(door2.Bounds) && !hasEnteredDoor)
            {
                hasEnteredDoor = true; // تحديد أن الفورم تم فتحه
                fina10 newForm = new fina10(); // إنشاء الفورم الجديد
                newForm.Show(); // عرض الفورم الجديد
                this.Hide(); // إخفاء الفورم الحالي
            }
        }


        private void InitializeProjectileTimer()
        {
            projectileTimer = new Timer { Interval = 20 };
            projectileTimer.Tick += new EventHandler(MoveProjectile);
        }

        int angelHealth = 5; // عدد الطلقات التي يجب أن يأخذها الملاك قبل أن يموت

        private void MoveProjectile(object sender, EventArgs e)
        {
            projectile.Left += 10;

            // التحقق من خروج المقذوف من الشاشة
            if (projectile.Left > this.ClientSize.Width)
            {
                projectile.Visible = false;
                isShooting = false;
                projectileTimer.Stop();
            }

            // التحقق من الاصطدام مع الملاك
            if (projectile.Bounds.IntersectsWith(angel.Bounds) && angel.Visible)
            {
                angelHealth--; // تقليل صحة الملاك (عدد الطلقات التي أصابت الملاك)
                projectile.Visible = false; // إخفاء المقذوف
                isShooting = false;
                projectileTimer.Stop(); // إيقاف مؤقت المقذوف

                if (angelHealth <= 0) // إذا وصل عدد الطلقات إلى 3
                {
                    angel.Visible = false; // إخفاء الملاك
                    angelMoveTimer.Stop(); // إيقاف حركة الملاك
                    followPlayer = false; // التأكد من إيقاف متابعة اللاعب
                    p1.Visible = true;
                    p2.Visible = true;
                    label1.Visible = false;
                }
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

            if (e.KeyCode == Keys.Space && !isShooting && hasTalkedToAngel)
            {
                isShooting = true;
                projectile.Visible = true;

                projectile.Location = new Point(
                    blayer.Right,
                    blayer.Top + blayer.Height / 2 - projectile.Height / 2
                );
                projectileTimer.Start();
            }

            if (blayer.Bounds.IntersectsWith(angel.Bounds) && !showConversation2)
            {
                conversation2.Visible = true;
                showConversation2 = true;
                blayer.Left -= 60;

                // بدء حركة الملاك
                if (!hasTalkedToAngel)
                {
                    angelMoveTimer.Start();
                    hasTalkedToAngel = true;
                }
                surprise.Visible = false;
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
                    label1.Visible = true;
                    // بدء متابعة اللاعب
                    followPlayer = true;
                }
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) goLeft = false;
            if (e.KeyCode == Keys.Right) goRight = false;
            if (e.KeyCode == Keys.Up) goUp = false;
            if (e.KeyCode == Keys.Down) goDown = false;
        }
    }
}

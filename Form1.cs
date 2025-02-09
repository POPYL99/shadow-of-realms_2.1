using System;
using System.Drawing;
using System.Windows.Forms;

namespace project
{
    public partial class Form1 : Form
    {
        bool goUp, goDown, goLeft, goRight;
        int playerSpeed = 30;
        bool gotKey, errorMessage = false;
        /// <summary>
        /// //
        /// 
        bool hasEnteredDoor = false;  // متغير لتتبع حالة دخول الباب

        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true; // لتفعيل استقبال أحداث الضغط على المفاتيح في الفورم
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            // إذا كان اللاعب يحاول الدخول للباب وليس لديه مفتاح
            if (door.Bounds.IntersectsWith(blayer.Bounds) && gotKey == false)
            {
                GameTimer.Stop(); // إيقاف التايمر (يوقف الحركة)
                blayer.Top += playerSpeed + 60; // تحريك اللاعب بعيدًا عن الباب
                MessageBox.Show("You don't have the key!!!!", "Home Closed", MessageBoxButtons.OK, MessageBoxIcon.Stop); // عرض رسالة الخطأ
                GameTimer.Start(); // استئناف التايمر (إذا أردت استئناف الحركة بعد الرسالة)
                return; // منع تنفيذ باقي الكود بعد أن يتوقف اللاعب
            }

            // حركة اللاعب
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

            // التحقق من المفتاح
            if (key.Bounds.IntersectsWith(blayer.Bounds))
            {
                gotKey = true;
                key.Visible = false;
            }

            // فتح الباب عند وجود المفتاح
            if (door.Bounds.IntersectsWith(blayer.Bounds) && gotKey == true)
            {
                level1 newLevel = new level1();
                this.Hide();
                GameTimer.Stop();
                newLevel.Show();
            }

            // رسالة عند محاولة دخول الكهف
            if (cave.Bounds.IntersectsWith(blayer.Bounds) && errorMessage == false)
            {
                errorMessage = true;
                GameTimer.Stop();
                blayer.Top += playerSpeed + 60;
                MessageBox.Show("You can't Enter the cave now", "Cave Closed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                GameTimer.Start();
            }
            errorMessage = false;

            // التأكد من عدم التكرار عند دخول الباب بعد أخذ المفتاح
            //if (blayer.Bounds.IntersectsWith(door2.Bounds) && !hasEnteredDoor)
            //{
            //    hasEnteredDoor = true; // تحديد أن الفورم تم فتحه
            //    finall2 newForm = new finall2(); // إنشاء الفورم الجديد
            //    newForm.Show(); // عرض الفورم الجديد
            //    this.Hide();
            //}
        }


 
        // لجعل الصور شفافة
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Parent = this;
            pictureBox1.BackColor = Color.Transparent;

            blayer.Parent = this;
            blayer.BackColor = Color.Transparent;

            door.Parent = this;
            door.BackColor = Color.Transparent;

            key.Parent = this;
            key.BackColor = Color.Transparent;

            label1.Parent = this;
            label1.BackColor = Color.Transparent;

            label2.Parent = this;
            label2.BackColor = Color.Transparent;

            cave.Parent = this;
            cave.BackColor = Color.Transparent;

            worker.Parent = this;
            worker.BackColor = Color.Transparent;

            workerTools.Parent = this;
            workerTools.BackColor = Color.Transparent;

            boteatingForm1.Parent = this;
            boteatingForm1.BackColor = Color.Transparent;

            surprise.Parent = this;
            surprise.BackColor = Color.Transparent;

            

            // إعدادات صورة conversation1
            conversation1.Visible = true;
            conversation1.Parent = this;
            conversation1.BackColor = Color.Transparent;
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
            if (Math.Abs(blayer.Right - boxlimits.Right) < 100)
            {
                blayer.Left += 50;
                GameTimer.Stop();
                GameTimer.Start();
            }
         
            if (boxlimits2.Bounds.IntersectsWith(blayer.Bounds))
            {
                blayer.Left -= 50;
                GameTimer.Stop();
                GameTimer.Start();
            }
        

            if (boxlimits4.Bounds.IntersectsWith(blayer.Bounds))
            {
                blayer.Top += 50;
                GameTimer.Stop();
                GameTimer.Start();
            }
            if (boxlimits5.Bounds.IntersectsWith(blayer.Bounds))
            {
                blayer.Top -= 50;
                GameTimer.Stop();
                GameTimer.Start();
            }

            // التحقق من الضغط على Enter لإخفاء conversation1
            if (e.KeyCode == Keys.Enter && conversation1.Visible)
            {
                conversation1.Visible = false;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

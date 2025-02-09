using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace project
{
    public partial class finall : Form
    {
        bool goUp, goDown, goLeft, goRight;
        int playerSpeed = 2 ;
        bool R = false, RRR = false, RR = false;
        bool W1 = false, W2 = false;

        int monster1HitCount = 0;
        const int maxMonster1Hits = 5;
        bool isMonster1Visible = true;

        int monster2HitCount = 0;
        const int maxMonster2Hits = 5;
        bool isMonster2Visible = true;

        int monster3HitCount = 0;
        const int maxMonster3Hits = 5;
        bool isMonster3Visible = true;

        List<PictureBox> bullets = new List<PictureBox>();
        Timer movementTimer;

        //تاس=يمر للمونستر 3 
        Timer monster3MovementTimer;
        int monster3StepCount = 0; // عداد الخطوات
        int monster3MaxSteps = 5; // عدد الخطوات المسموح بها يمينًا ويسارًا
        int monster3Speed = 20; // سرعة الحركة
        bool monster3MovingLeft = true; // اتجاه الحركة



        //تحريك المونستر الثاني للفوق الاسفل 
        Timer monster2MovementTimer;
        int monster2StepCount = 0; // عداد الخطوات
        int monster2MaxSteps = 4; // عدد الخطوات المسموح بها للأعلى والأسفل
        int monster2Speed = 30; // سرعة الحركة
        bool monster2MovingUp = true; // اتجاه الحركة


        public finall()
        {
            InitializeComponent();
            movementTimer = new Timer();
            movementTimer.Interval = 20;
            movementTimer.Tick += TimerEvent;
            movementTimer.Start();


            //تاس=يمر للمونستر 3 

            monster3MovementTimer = new Timer();
            monster3MovementTimer.Interval = 500; // توقيت الحركة (500 مللي ثانية بين كل خطوة)
            monster3MovementTimer.Tick += Monster3Move;
            monster3MovementTimer.Start();

            movementTimer = new Timer();
            movementTimer.Interval = 20;
            movementTimer.Tick += TimerEvent;
            movementTimer.Start();

            //تحريك المونستر الثاني 
            monster2MovementTimer = new Timer();
            monster2MovementTimer.Interval = 500; // توقيت الحركة (500 مللي ثانية بين كل خطوة)
            monster2MovementTimer.Tick += Monster2Move;
            monster2MovementTimer.Start();

            movementTimer = new Timer();
            movementTimer.Interval = 20;
            movementTimer.Tick += TimerEvent;
            movementTimer.Start();

        }

        private void TimerEvent(object sender, EventArgs e)
        {
            Inventory.Visible = true;
            youHaveRock.Visible = false;
            youHaveWood.Visible = false;

            // حركة اللاعب
            if (goLeft && blayer.Left > 0) blayer.Left -= playerSpeed;
            if (goRight && blayer.Right < ClientSize.Width) blayer.Left += playerSpeed;
            if (goDown && blayer.Bottom < ClientSize.Height) blayer.Top += playerSpeed;
            if (goUp && blayer.Top > 0) blayer.Top -= playerSpeed;

            // تحقق من تجميع الصخور
            if (R1.Bounds.IntersectsWith(blayer.Bounds)) { R = true; R1.Visible = false; }
            if (R2.Bounds.IntersectsWith(blayer.Bounds)) { RR = true; R2.Visible = false; }
            if (R3.Bounds.IntersectsWith(blayer.Bounds)) { RRR = true; R3.Visible = false; }

            if (R && RR && RRR) youHaveRock.Visible = true;

            // تحقق من تجميع الخشب
            if (wood1.Bounds.IntersectsWith(blayer.Bounds)) { W1 = true; wood1.Visible = false; }
            if (wood2.Bounds.IntersectsWith(blayer.Bounds)) { W2 = true; wood2.Visible = false; }

            if (W1 && W2) youHaveWood.Visible = true;

            // تحقق من اصطدام اللاعب مع الوحوش
            if (isMonster1Visible && blayer.Bounds.IntersectsWith(monster1.Bounds)) RestartLevel();
            if (isMonster2Visible && blayer.Bounds.IntersectsWith(monster2.Bounds)) RestartLevel();
            if (isMonster3Visible && blayer.Bounds.IntersectsWith(monster3.Bounds)) RestartLevel();

            // حركة الطلقات والتحقق من إصابة الوحوش
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                var bullet = bullets[i];
                bullet.Left += 3;

                if (bullet.Bounds.IntersectsWith(monster1.Bounds) && isMonster1Visible)
                {
                    monster1HitCount++;
                    bullet.Visible = false;
                    bullets.Remove(bullet);
                    if (monster1HitCount >= maxMonster1Hits) monster1.Visible = isMonster1Visible = false;
                }
                else if (bullet.Bounds.IntersectsWith(monster2.Bounds) && isMonster2Visible)
                {
                    monster2HitCount++;
                    bullet.Visible = false;
                    bullets.Remove(bullet);
                    if (monster2HitCount >= maxMonster2Hits) monster2.Visible = isMonster2Visible = false;
                }
                else if (bullet.Bounds.IntersectsWith(monster3.Bounds) && isMonster3Visible)
                {
                    monster3HitCount++;
                    bullet.Visible = false;
                    bullets.Remove(bullet);
                    if (monster3HitCount >= maxMonster3Hits) monster3.Visible = isMonster3Visible = false;
                }
            }

            // تحقق من الشروط لظهور الباب
            if (!door1.Visible && !isMonster1Visible && !isMonster2Visible && !isMonster3Visible && R && RR && RRR && W1 && W2)
            {
                exit.Visible = true;
                door2.Visible = false;
                door1.Visible = true;

            }

            //التحقق من دخول اللاعب من الباب
            if (door1.Visible && blayer.Bounds.IntersectsWith(door1.Bounds))
            {
                finall2 nextForm = new finall2();
                nextForm.Show();
                this.Hide();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void RestartLevel()
        {
            blayer.Location = new Point(50, 50);
            isMonster1Visible = isMonster2Visible = isMonster3Visible = true;
            monster1.Visible = monster2.Visible = monster3.Visible = true;
            monster1HitCount = monster2HitCount = monster3HitCount = 0;
            door1.Visible = false;

            bullets.ForEach(b => b.Visible = false);
            bullets.Clear();
        }

        private void finall_Load(object sender, EventArgs e)
        {
            blayer.Parent = this;
            blayer.BackColor = Color.Transparent;

            label2.Parent = this;
            label2.BackColor = Color.Transparent;

            R1.Parent = this;
            R1.BackColor = Color.Transparent;

            R2.Parent = this;
            R2.BackColor = Color.Transparent;

            R3.Parent = this;
            R3.BackColor = Color.Transparent;

            wood2.Parent = this;
            wood2.BackColor = Color.Transparent;

            wood1.Parent = this;
            wood1.BackColor = Color.Transparent;

            monster1.Parent = this;
            monster1.BackColor = Color.Transparent;

            monster2.Parent = this;
            monster2.BackColor = Color.Transparent;

            monster3.Parent = this;
            monster3.BackColor = Color.Transparent;

            youHaveRock.Parent = this;
            youHaveRock.BackColor = Color.Transparent;

            youHaveWood.Parent = this;
            youHaveWood.BackColor = Color.Transparent;

            Inventory.Parent = this;
            Inventory.BackColor = Color.Transparent;

            exit.Parent = this;
            exit.BackColor = Color.Transparent;

            door1.Parent = this;
            door1.BackColor = Color.Transparent;

            door2.Parent = this;
            door2.BackColor = Color.Transparent;

            lol3.Parent = this;
            lol3.BackColor = Color.Transparent;

            door1.Visible = false;
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

            if (e.KeyCode == Keys.Space) 
                Shoot();
        }

        private void Monster3Move(object sender, EventArgs e)
        {
            if (monster3MovingLeft)
            {
                monster3.Left -= monster3Speed; // تحرك إلى اليسار
                monster3StepCount++; // زيادة عداد الخطوات

                if (monster3StepCount >= monster3MaxSteps) // إذا أكمل خطوتين
                {
                    monster3MovingLeft = false; // غير الاتجاه
                    monster3StepCount = 0; // أعد تعيين عداد الخطوات
                }
            }
            else
            {
                monster3.Left += monster3Speed; // تحرك إلى اليمين
                monster3StepCount++; // زيادة عداد الخطوات

                if (monster3StepCount >= monster3MaxSteps) // إذا أكمل خطوتين
                {
                    monster3MovingLeft = true; // غير الاتجاه
                    monster3StepCount = 0; // أعد تعيين عداد الخطوات
                }
            }
        }

        private void Monster2Move(object sender, EventArgs e)
        {
            if (monster2MovingUp)
            {
                monster2.Top -= monster2Speed; // تحرك إلى الأعلى
                monster2StepCount++; // زيادة عداد الخطوات

                if (monster2StepCount >= monster2MaxSteps) // إذا أكمل خطوتين
                {
                    monster2MovingUp = false; // غير الاتجاه إلى الأسفل
                    monster2StepCount = 0; // أعد تعيين عداد الخطوات
                }
            }
            else
            {
                monster2.Top += monster2Speed; // تحرك إلى الأسفل
                monster2StepCount++; // زيادة عداد الخطوات

                if (monster2StepCount >= monster2MaxSteps) // إذا أكمل خطوتين
                {
                    monster2MovingUp = true; // غير الاتجاه إلى الأعلى
                    monster2StepCount = 0; // أعد تعيين عداد الخطوات
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

        private void Shoot()
        {
            // تحقق إذا كان اللاعب قد جمع جميع الصخور والخشب
            if (!(R && RR && RRR && W1 && W2))
            {
                MessageBox.Show("Collect all the ammo! ! !");
                return;
            }

            PictureBox bullet = new PictureBox
            {
                Image = Properties.Resources.oie_transparent__9_,
                Size = new Size(70, 70),
                Location = new Point(blayer.Right, blayer.Top + blayer.Height / 2 - 2),
                BackColor = Color.Transparent
            };
            Controls.Add(bullet);
            bullets.Add(bullet);
        }


        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

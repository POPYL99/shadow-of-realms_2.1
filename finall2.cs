using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace project
{
    public partial class finall2 : Form
    {
        bool goUp, goDown, goLeft, goRight;
        int playerSpeed = 8;
        int monster1HitCount = 0;
        int monster2HitCount = 0;
        const int maxMonsterHits = 5;
        bool isMonster1Visible = true;
        bool isMonster2Visible = true;

        List<PictureBox> bullets = new List<PictureBox>();
        List<PictureBox> monsterProjectiles = new List<PictureBox>();
        System.Windows.Forms.Timer movementTimer;
        System.Windows.Forms.Timer projectileTimer;
        Point playerStartPosition;
        bool isCatapultActive = true;

        public finall2()
        {
            InitializeComponent();
            movementTimer = new System.Windows.Forms.Timer();
            movementTimer.Interval = 20;
            movementTimer.Tick += TimerEvent;
            movementTimer.Start();

            projectileTimer = new System.Windows.Forms.Timer();
            projectileTimer.Interval = 2000;
            projectileTimer.Tick += SpawnProjectile;
            projectileTimer.Start();
        }

        private void finall2_Load(object sender, EventArgs e)
        {
            blayer.Parent = this;
            blayer.BackColor = Color.Transparent;

            monster1.Parent = this;
            monster1.BackColor = Color.Transparent;

            monster22.Parent = this;
            monster22.BackColor = Color.Transparent;

            catapult1.Parent = this;
            catapult1.BackColor = Color.Transparent;

            doorImage.Parent = this;
            doorImage.BackColor = Color.Transparent;
            doorImage.Visible = false;

            Burningtrashcan3.Parent = this;
            Burningtrashcan3.BackColor = Color.Transparent;

            Burningtrashcan2.Parent = this;
            Burningtrashcan2.BackColor = Color.Transparent;

            Burningtrashcan1.Parent = this;
            Burningtrashcan1.BackColor = Color.Transparent;

            lol1.Parent = this;
            lol1.BackColor = Color.Transparent;

            lol2.Parent = this;
            lol2.BackColor = Color.Transparent;

            lol3.Parent = this;
            lol3.BackColor = Color.Transparent;

            conversation1.Parent = this;
            conversation1.BackColor = Color.Transparent;
            conversation1.Visible = false;

            playerStartPosition = blayer.Location;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(KeyIsDown);
            this.KeyUp += new KeyEventHandler(KeyIsUp);
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            // حركة اللاعب
            if (goLeft && blayer.Left > 0) blayer.Left -= playerSpeed;
            if (goRight && blayer.Right < ClientSize.Width) blayer.Left += playerSpeed;
            if (goDown && blayer.Bottom < ClientSize.Height) blayer.Top += playerSpeed;
            if (goUp && blayer.Top > 0) blayer.Top -= playerSpeed;

            // حركة المونستر 1 باتجاه اللاعب
            if (isMonster1Visible)
            {
                int monsterSpeed = 2;  // سرعة المونستر

                // تحديد الاتجاهات X و Y للمونستر 1
                if (monster1.Left < blayer.Left)
                {
                    monster1.Left += monsterSpeed;
                }
                else if (monster1.Left > blayer.Left)
                {
                    monster1.Left -= monsterSpeed;
                }

                if (monster1.Top < blayer.Top)
                {
                    monster1.Top += monsterSpeed;
                }
                else if (monster1.Top > blayer.Top)
                {
                    monster1.Top -= monsterSpeed;
                }
            }

            // التعامل مع الرصاصات والمونستر 2
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                var bullet = bullets[i];
                bullet.Left += 5;

                if (bullet.Bounds.IntersectsWith(monster1.Bounds) && isMonster1Visible)
                {
                    monster1HitCount++;
                    bullet.Visible = false;
                    bullets.Remove(bullet);
                    if (monster1HitCount >= maxMonsterHits)
                    {
                        monster1.Visible = false;
                        isMonster1Visible = false;
                        if (Controls.Contains(monster1))
                        {
                            Controls.Remove(monster1);
                        }
                        catapult1.Visible = false;
                        isCatapultActive = false;
                    }
                }

                if (bullet.Bounds.IntersectsWith(monster22.Bounds) && isMonster2Visible)
                {
                    monster2HitCount++;
                    bullet.Visible = false;
                    bullets.Remove(bullet);
                    if (monster2HitCount >= maxMonsterHits)
                    {
                        monster22.Visible = false;
                        isMonster2Visible = false;
                        if (Controls.Contains(monster22))
                        {
                            Controls.Remove(monster22);
                        }
                        doorImage.Visible = true;
                        conversation1.Visible = true;
                    }
                }
            }

            // حركة المشروعiles من المونستر
            for (int i = monsterProjectiles.Count - 1; i >= 0; i--)
            {
                var projectile = monsterProjectiles[i];
                projectile.Left -= 5;
                if (projectile.Left < 0)
                {
                    projectile.Visible = false;
                    Controls.Remove(projectile);
                    monsterProjectiles.RemoveAt(i);
                }
                else if (projectile.Bounds.IntersectsWith(blayer.Bounds))
                {
                    ResetGame();
                }
            }

            if (blayer.Bounds.IntersectsWith(catapult1.Bounds) && isCatapultActive)
            {
                ResetGame();
            }

            if (blayer.Bounds.IntersectsWith(doorImage.Bounds) && doorImage.Visible)
            {
                finall3 newForm = new finall3();
                newForm.Show();
                this.Hide();
            }
        }


        bool isMonsterMoving = false; // متغير لتعقب حركة الوحش

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
            if (e.KeyCode == Keys.Space) Shoot();

            if (e.KeyCode == Keys.Enter && conversation1.Visible)
            {
                conversation1.Visible = false;
                isMonsterMoving = true; // السماح بحركة الوحش بعد اختفاء الصورة
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
            PictureBox bullet = new PictureBox
            {
                Image = Properties.Resources.oie_transparent__9_,
                Size = new Size(20, 20),
                Location = new Point(blayer.Right, blayer.Top + blayer.Height / 2 - 10),
                BackColor = Color.Transparent
            };
            Controls.Add(bullet);
            bullets.Add(bullet);
        }

        private void ResetGame()
        {
            blayer.Location = playerStartPosition;
            monster1HitCount = 0;
            monster2HitCount = 0;
            isMonster1Visible = true;
            isMonster2Visible = true;
            doorImage.Visible = false;
            catapult1.Visible = true;
            foreach (var bullet in bullets)
            {
                bullet.Visible = false;
            }
            bullets.Clear();
            foreach (var projectile in monsterProjectiles)
            {
                projectile.Visible = false;
            }
            monsterProjectiles.Clear();
            projectileTimer.Start();
        }

        private void SpawnProjectile(object sender, EventArgs e)
        {
            if (isCatapultActive && isMonster1Visible)
            {
                PictureBox projectile = new PictureBox
                {
                    Size = new Size(10, 10),
                    Location = new Point(monster1.Left, monster1.Top + monster1.Height / 2),
                    BackColor = Color.Red
                };
                this.Controls.Add(projectile);
                monsterProjectiles.Add(projectile);
            }
            else if (!isMonster1Visible)
            {
                projectileTimer.Stop();
            }
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

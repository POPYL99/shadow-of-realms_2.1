using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class cave : Form
    {
        bool goUp, goDown, goLeft, goRight;
        int playerSpeed = 8;

        bool showFirstConversation = false;
        bool showSecondConversation = false;

        public cave()
        {
            InitializeComponent();

            PictureBox background = new PictureBox();
            background.Dock = DockStyle.Fill;
            background.Image = Properties.Resources.Jpp8AQ;
            background.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(background);
            background.SendToBack();
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            if (goLeft)
            {
                blayer.Left -= playerSpeed;
            }
            if (goRight)
            {
                blayer.Left += playerSpeed;
            }
            if (goDown)
            {
                blayer.Top += playerSpeed;
            }
            if (goUp)
            {
                blayer.Top -= playerSpeed;
            }

            // التحكم في الطبقات بناءً على موقع اللاعب
            if (blayer.Bounds.IntersectsWith(worker.Bounds))
            {
                // إذا كان اللاعب أمام الصورة، أرسل اللاعب للخلف
                blayer.SendToBack();
                worker.BringToFront();

                // عرض المحادثة الأولى عند التصادم مع العامل
                if (!showFirstConversation && !showSecondConversation)
                {
                    conversation1.Visible = true;
                    showFirstConversation = true;
                    blayer.Left += 60;

                }
            }
            else
            {
                // اللاعب ليس على الصورة، تأكد من وجوده في المقدمة
                blayer.BringToFront();
            }

            // إذا وصل اللاعب إلى الكهف
            if (cave1.Bounds.IntersectsWith(blayer.Bounds))
            {
                finall newLevel = new finall();
                this.Hide();
                GameTimer.Stop();
                newLevel.Show();
            }

            if (blayer.Bounds.IntersectsWith(collisionImage.Bounds))
            {
                displayImage1.Visible = true; // إظهار الصورة الأولى
                displayImage2.Visible = true; // إظهار الصورة الثانية
            }
            else
            {
                displayImage1.Visible = false; // إخفاء الصورة الأولى
                displayImage2.Visible = false; // إخفاء الصورة الثانية
            }

            if (cave2.Bounds.IntersectsWith(blayer.Bounds))
            {
                finall newLevel = new finall();
                this.Hide();
                GameTimer.Stop();
                newLevel.Show();
            }
        }

        private void cave_Load(object sender, EventArgs e)
        {
            blayer.Parent = this;
            blayer.BackColor = Color.Transparent;

            cave1.Parent = this;
            cave1.BackColor = Color.Transparent;

            cave2.Parent = this;
            cave2.BackColor = Color.Transparent;

            label1.Parent = this;
            label1.BackColor = Color.Transparent;

            worker.Parent = this;
            worker.BackColor = Color.Transparent;

            wood1.Parent = this;
            wood1.BackColor = Color.Transparent;

            wood2.Parent = this;
            wood2.BackColor = Color.Transparent;

            wood3.Parent = this;
            wood3.BackColor = Color.Transparent;

            d1.Parent = this;
            d1.BackColor = Color.Transparent;

            d2.Parent = this;
            d2.BackColor = Color.Transparent;

            d3.Parent = this;
            d3.BackColor = Color.Transparent;

            d4.Parent = this;
            d4.BackColor = Color.Transparent;

            d5.Parent = this;
            d5.BackColor = Color.Transparent;

            p1.Parent = this;
            p1.BackColor = Color.Transparent;

            displayImage1.Parent = this;
            displayImage1.BackColor = Color.Transparent;

            displayImage2.Parent = this;
            displayImage2.BackColor = Color.Transparent;

            collisionImage.Parent = this;
            collisionImage.BackColor = Color.Transparent;

            surprise.Parent = this;
            surprise.BackColor = Color.Transparent;

            conversation1.Parent = this;
            conversation1.BackColor = Color.Transparent;
            conversation1.Visible = false;

            conversation2.Parent = this;
            conversation2.BackColor = Color.Transparent;
            conversation2.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

            // الانتقال بين الصور عند الضغط على Enter
            if (e.KeyCode == Keys.Enter)
            {
                if (showFirstConversation && !showSecondConversation)
                {
                    conversation1.Visible = false;
                    conversation2.Visible = true;
                    showSecondConversation = true;
                }
                else if (showSecondConversation)
                {
                    conversation2.Visible = false;
                    showFirstConversation = false;
                    showSecondConversation = false;
                }
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

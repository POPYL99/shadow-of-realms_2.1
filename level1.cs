using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class level1 : Form
    {
        bool goUp, goDown, goLeft, goRight;
        bool gotKey=true, pikaxeM=false, errorMessage = false;
        int playerSpeed = 8;
        public level1()
        {
            InitializeComponent();
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

            if (blayer.Left < 110)
            {
                blayer.Left = 110;
            }
            if (blayer.Right > ClientSize.Width)
            {
                blayer.Left = ClientSize.Width - blayer.Width;
            }
            if (blayer.Top < 50)
            {
                blayer.Top = 50;
            }
            if (blayer.Bottom > ClientSize.Height)
            {
                blayer.Top = ClientSize.Height - blayer.Height;
            }

            //you have the pikack
            if (pikaxe.Bounds.IntersectsWith(blayer.Bounds))
            {
                pikaxeM = true;
                pikaxe.Visible = false;
                //  GameTimer.Stop();

            }

            //You don't have the picak!!!!
            if (door.Bounds.IntersectsWith(blayer.Bounds) && pikaxeM == false)
            {
                errorMessage = true;
                GameTimer.Stop();
                blayer.Top += playerSpeed - 100;
                MessageBox.Show("You don't have the foods!!!!", "go and get foods", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                GameTimer.Start();
            }
            errorMessage = false;

            if (door.Bounds.IntersectsWith(blayer.Bounds) && gotKey && pikaxeM==true)
            {
                backAfterHome newLevel = new backAfterHome();
                this.Hide();
                GameTimer.Stop();
                newLevel.Show();
            }
        }

        //to do Transparent for pics
        private void level1_Load(object sender, EventArgs e)
        {
            // تعيين اللون الشفاف لصورة اللاعب
            blayer.Parent = this;
            blayer.BackColor = Color.Transparent;

            door.Parent = this;
            door.BackColor = Color.Transparent;

            pikaxe.Parent = this;
            pikaxe.BackColor = Color.Transparent;


 
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

            if (boxlimits1.Bounds.IntersectsWith(blayer.Bounds))
            {
                blayer.Left += 50;
                GameTimer.Stop();
                GameTimer.Start();
            }
            if (boxlimits2.Bounds.IntersectsWith(blayer.Bounds))
            {
                blayer.Top -= 180;
                GameTimer.Stop();
                GameTimer.Start();
            }
            if (boxlimits3.Bounds.IntersectsWith(blayer.Bounds))
            {
                blayer.Left+=100;
                GameTimer.Stop();
                GameTimer.Start();
            }

            if (boxlimits4.Bounds.IntersectsWith(blayer.Bounds))
            {
                blayer.Top -= 80;
                GameTimer.Stop();
                GameTimer.Start();
            }
            if (boxlimits5.Bounds.IntersectsWith(blayer.Bounds))
            {
                blayer.Left -= 100;
                GameTimer.Stop();
                GameTimer.Start();
            }
            if (boxlimits6.Bounds.IntersectsWith(blayer.Bounds))
            {
                blayer.Left -= 100;
                GameTimer.Stop();
                GameTimer.Start();
            }
            if (boxlimits7.Bounds.IntersectsWith(blayer.Bounds))
            {
                blayer.Left -= 110;
                GameTimer.Stop();
                GameTimer.Start();
            }
            if (boxlimits8.Bounds.IntersectsWith(blayer.Bounds))
            {
                blayer.Top -= 110;
                GameTimer.Stop();
                GameTimer.Start();
            }
            if (boxlimits9.Bounds.IntersectsWith(blayer.Bounds))
            {
                blayer.Left -= 80;
                GameTimer.Stop();
                GameTimer.Start();
            }
            if (boxlimits10.Bounds.IntersectsWith(blayer.Bounds))
            {
                blayer.Left += 80;
                GameTimer.Stop();
                GameTimer.Start();
            }
            if (boxlimits11.Bounds.IntersectsWith(blayer.Bounds))
            {
                blayer.Top -= 110;
                GameTimer.Stop();
                GameTimer.Start();
            }

        }
        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}

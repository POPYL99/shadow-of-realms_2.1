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
    public partial class backAfterHome : Form
    {

        bool goUp, goDown, goLeft, goRight;
        int playerSpeed = 8;
        bool gotKey=true;
        bool pikaxeM= true;

        public backAfterHome()
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

            if (door.Bounds.IntersectsWith(blayer.Bounds) && gotKey)
            {
                level1 newLevel = new level1();
                this.Hide();
                GameTimer.Stop();
                gotKey = false;
                newLevel.Show();
            }


            //you can join the cave
            if (cavee.Bounds.IntersectsWith(blayer.Bounds) && pikaxeM == true)
            {
                cave newLevel = new cave();
                this.Hide();
                GameTimer.Stop();
                pikaxeM = false;
                newLevel.Show();
            }
        }

        // to do Transparent for pic
        private void backAfterHome_Load(object sender, EventArgs e)
        {
            blayer.Parent = this;
            blayer.BackColor = Color.Transparent;

            door.Parent = this;
            door.BackColor = Color.Transparent;

            label1.Parent = this;
            label1.BackColor = Color.Transparent;

            boteatingForm2.Parent = this;
            boteatingForm2.BackColor = Color.Transparent;

            cavee.Parent = this;
            cavee.BackColor = Color.Transparent;

            surprise1.Parent = this;
            surprise1.BackColor = Color.Transparent;

            worker.Parent = this;
            worker.BackColor = Color.Transparent;

            workerTools.Parent = this;
            workerTools.BackColor = Color.Transparent;
        }

        private void blayer_Click(object sender, EventArgs e)
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

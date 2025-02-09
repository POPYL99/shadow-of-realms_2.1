using System;
using System.Drawing;
using System.Windows.Forms;

namespace project
{
    public partial class finall5 : Form
    {
        bool goUp, goDown, goLeft, goRight;
        int playerSpeed = 8;
        bool showConversation1 = true;
        bool doorEntered = false; // متغير لتحديد الدخول للباب

        public finall5()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(KeyIsDown);
            this.KeyUp += new KeyEventHandler(KeyIsUp);

            PictureBox background = new PictureBox();
            background.Dock = DockStyle.Fill;
            background.Image = Properties.Resources.oie_xNy2tQpCYxET;
            background.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(background);
            background.SendToBack();

            Timer gameTimer = new Timer();
            gameTimer.Interval = 20;
            gameTimer.Tick += new EventHandler(TimerEvent);
            gameTimer.Start();
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

            // التحقق من اصطدام اللاعب بالباب
            if (!doorEntered && blayer.Bounds.IntersectsWith(door.Bounds))
            {
                doorEntered = true; // تعيين الدخول للباب لمنع التكرار
                OpenNextForm();
            }
        }

        private void OpenNextForm()
        {
            // الكود الخاص بفتح الفورم الجديد
            Form nextForm = new finall6(); // استبدل NextForm باسم الفورم المستهدف
            nextForm.Show();
            this.Hide(); // يمكنك إخفاء الفورم الحالي أو إغلاقه بناءً على متطلباتك
        }

        private void finall5_Load(object sender, EventArgs e)
        {
            blayer.Parent = this;
            blayer.BackColor = Color.Transparent;

            door.Parent = this;
            door.BackColor = Color.Transparent;

            conversation1.Parent = this;
            conversation1.BackColor = Color.Transparent;
            conversation1.Visible = true;
        }

        private void blayer_Click(object sender, EventArgs e)
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && showConversation1)
            {
                conversation1.Visible = false;
                showConversation1 = false;
            }

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

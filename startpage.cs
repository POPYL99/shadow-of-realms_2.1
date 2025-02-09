using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace project
{
    public partial class startpage : Form
    {
        public startpage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1(); // إنشاء الفورم الجديد
            newForm.Show(); // عرض الفورم الجديد
            this.Hide(); // إخفاء الفورم الحالي
        }
        private void startpage_Load(object sender, EventArgs e)
        {
            // إعداد النص داخل TextBox5
            text5.Text = "Shadows of Realms"; // اسم اللعبة
            text5.Font = new Font("Arial", 20, FontStyle.Bold | FontStyle.Italic); // خط قوي وكبير مع تأثير مائل
            text5.ForeColor = Color.White; // لون النص أبيض ليتناسب مع الأجواء المظلمة
            text5.BackColor = Color.Transparent; // جعل الخلفية شفافة
            text5.BorderStyle = BorderStyle.None; // إزالة الحدود لجعل الشكل أكثر جمالية

            // إضافة تأثير الظل للنص
            text5.Paint += (s, args) =>
            {
                // رسم الظل
                args.Graphics.DrawString(text5.Text, text5.Font, Brushes.Gray, new PointF(text5.Width / 2 + 2, text5.Height / 2 + 2));
                args.Graphics.DrawString(text5.Text, text5.Font, Brushes.White, new PointF(text5.Width / 2, text5.Height / 2));
            };

            // تخصيص باقي العناصر كما في الكود السابق
            x1.Parent = this;
            x1.BackColor = Color.Transparent;

            x2.Parent = this;
            x2.BackColor = Color.Transparent;

            blayer.Parent = this;
            blayer.BackColor = Color.Transparent;

            pictureBox1.Parent = this;
            pictureBox1.BackColor = Color.Transparent;

            xx1.Parent = this;
            xx1.BackColor = Color.Transparent;

            xx2.Parent = this;
            xx2.BackColor = Color.Transparent;

            xx3.Parent = this;
            xx3.BackColor = Color.Transparent;
        }




    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoAreYou
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 2);
            string Sex = (randomNumber == 0) ? "男生" : "女生" ;

            string Name = textBox1.Text ;

            DialogResult Question = MessageBox.Show(Name + "我猜你是" + Sex, "電腦挑花生", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Question == DialogResult.Yes)
            {
                MessageBox.Show("嘿嘿嘿....我很厲害吧!!");
            }
            else if (Question == DialogResult.No)
            {
                MessageBox.Show("你有做過蝦米祕密的手術嗎?");
            }

            textBox1.Text = "" ;

        }
    }
}

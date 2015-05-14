using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessNumber
{
    public partial class Form1 : Form
    {

        string MyGuessList;
        string Number;
 
        public Form1()
        {
            InitializeComponent();
        }

        private void GuessButton_Click(object sender, EventArgs e)
        {
            string MyGuess = GuessNumberBox.Text;

            MessageBox.Show(MyGuess + "  " + Number);
            int a = 0, b = 0;

            for (int i = 1; i <= 1000; i *= 10)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetNumber();
        }

        private void SetNumber() 
        {
            Random random = new Random();
            int Num = random.Next(0, 9999);

            if (Num < 10)
            {
                this.Number = "000" + Num.ToString();
            }
            else if (Num < 100)
            {
                this.Number = "00" + Num.ToString();
            }
            else if (Num < 1000)
            {
                this.Number = "0" + Num.ToString();
            }
            else 
            {
                this.Number = Num.ToString();
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            SetNumber();
            MessageBox.Show(this.Number);
        }
                
    }
}

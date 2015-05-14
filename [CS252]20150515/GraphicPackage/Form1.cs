using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicPackage
{
    public partial class Form1 : Form
    {
        Graphics g;

        public Form1()
        {
            InitializeComponent();

        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            DrawBox drawbox = new DrawBox(g);
            drawbox.DoIt(int.Parse(WidthTextBox.Text), int.Parse(HeightTextBox.Text));
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            DrawBox drawbox = new DrawBox(g);
            drawbox.Clear();
       
        }
    }
}

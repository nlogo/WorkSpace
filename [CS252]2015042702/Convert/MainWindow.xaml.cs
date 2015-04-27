using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Convert
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_click(object sender, RoutedEventArgs e)
        {
            int Number1 = System.Convert.ToInt32(tb1.Text);
            int Number2 = System.Convert.ToInt32(tb2.Text);
            double Number12 = Number1 + Number2;

            int Number3 = System.Convert.ToInt32(tb3.Text);
            int Number4 = System.Convert.ToInt32(tb4.Text);
            double Number34 = Number3 + Number4;

            string Total = Number12.ToString() + Number34.ToString() ;

            MessageBox.Show(Total);

          }
    }
}

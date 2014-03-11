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

namespace GAWrap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        struct coord
        {
            readonly public int x;
            readonly public int y;

            public coord(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            this.ConToSUT.Tag = new coord(302, 160);
            this.TCs.Tag = new coord(316, 318);

            this.Width = 302;
            this.Height = 160;
            this.ConToSUT.IsSelected = true;
        }

        /// <summary>
        /// Resize window based on selected tab
        /// </summary>
        private void Tab_GotFocus(object sender, RoutedEventArgs e)
        {
            TabItem ti = (TabItem)sender;
            this.Width = ((coord)ti.Tag).x;
            this.Height = ((coord)ti.Tag).y;
        }
    }
}

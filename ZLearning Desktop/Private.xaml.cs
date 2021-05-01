using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZLearning_Desktop
{
    /// <summary>
    /// Interaction logic for Private.xaml
    /// </summary>
    public partial class Private : UserControl
    {
        public Private()
        {
            InitializeComponent();
        }
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            user_img.ImageSource = new BitmapImage(new Uri(@"..\..\..\" + Functions.getImageOfUser(), UriKind.Relative));
        }
    }
}

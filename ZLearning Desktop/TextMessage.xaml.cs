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
    /// Interaction logic for TextMessage.xaml
    /// </summary>
    public partial class TextMessage : UserControl
    {
        public TextMessage()
        {
            InitializeComponent();
        }
        public string Text { get; set; }
        public string Url { get; set; }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            textMessageTxt.Text = Text;
            textMessageTime.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();

            if (!string.IsNullOrEmpty(Url))
            {
                messageImg.ImageSource = new BitmapImage(new Uri(Url));
                messageRect.Visibility = Visibility.Visible;
            }
        }
    }
}

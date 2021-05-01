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
    /// Interaction logic for TextMessageFriend.xaml
    /// </summary>
    public partial class TextMessageFriend : UserControl
    {
        public TextMessageFriend()
        {
            InitializeComponent();
        }
        public string Text { get; set; }
        public string Username { get; set; }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            textMessageFriendTxt.Text = Text;
            textMessageFriendTime.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
            usernameTxt.Text = Username;
        }
    }
}

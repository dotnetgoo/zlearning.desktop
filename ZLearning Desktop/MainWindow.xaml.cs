﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZLearning_Desktop.Models;

namespace ZLearning_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<User> GLOBAL_USERS = new List<User>();
        private void drag_grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
            {
                maximize_btn_Click(sender, null);
            } 
            else
            {
                this.DragMove();
            }
        }

        private void minimize_btn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void maximize_btn_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                windowGrid.Margin = new Thickness(8, 10, 10, 10);
                WindowStyle = WindowStyle.SingleBorderWindow;
                WindowState = WindowState.Maximized;
                WindowStyle = WindowStyle.None;
            }
            else
            {
                this.WindowState = WindowState.Normal;
                windowGrid.Margin = new Thickness(0);
            }
        }

        private void close_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpenMenu_Btn_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu_Border.Visibility = Visibility.Visible;
        }

        private void CloseMenu_Border_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CloseMenu_Border.Visibility = Visibility.Collapsed;
        }

        private void newGroup_Btn_Click(object sender, RoutedEventArgs e)
        {
            menuClose();
            Window_Loaded(sender, null);
        }

        private void settings_Btn_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new Settings();
            menuClose();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                this.Dispatcher.Invoke(async () =>
                {
                    //users loading
                    usersPanel.Items.Clear();

                    GLOBAL_USERS = Backend.getUsers();
                    foreach (var user in GLOBAL_USERS)
                    {
                        await Task.Run(() =>
                        {
                            this.Dispatcher.Invoke(() =>
                            {
                                var pri = new Private();
                                pri.username.Text = user.firstname + " " + user.lastname;
                                pri.friend_name.Text = user.friend_name;
                                pri.friend_message.Text = user.friend_message;
                                pri.updated_at.Text = user.updated_at.ToString();
                                usersPanel.Items.Add(pri);
                            });

                        });
                    }
                });                     
            });
            thread.Start();
            
        }

        public void menuClose()
        {
            //
            var boshlash = new Thickness(0, 0, 0, 0);
            var tugatish = new Thickness(-280, 0, 0, 0);
            var da = new ThicknessAnimation();
            da.From = boshlash;
            da.To = tugatish;
            da.Duration = TimeSpan.FromMilliseconds(200);
            MenuGrid.BeginAnimation(MarginProperty, da);
            //
            CloseMenu_Border.Visibility = Visibility.Collapsed;
        }

        private async void searchTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = searchTxt.Text.ToLower();
            var users = GLOBAL_USERS;
            usersPanel.Items.Clear();
            var all = GLOBAL_USERS.Where(user => user.firstname.ToLower().Contains(text) || user.lastname.ToLower().Contains(text) || 
            user.friend_name.ToLower().Contains(text) || user.friend_message.ToLower().Contains(text));
            foreach(var user in all)
            {
                await Task.Run(() =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        var pri = new Private();
                        pri.username.Text = user.firstname + " " + user.lastname;
                        pri.friend_name.Text = user.friend_name;
                        pri.friend_message.Text = user.friend_message;
                        pri.updated_at.Text = user.updated_at.ToString();
                        usersPanel.Items.Add(pri);
                    });
                });
            }   
        }
    }
}

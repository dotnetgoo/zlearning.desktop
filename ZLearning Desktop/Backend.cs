using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows;
using ZLearning_Desktop.Models;

namespace ZLearning_Desktop
{
    class Backend
    {
        public static string API = "http://zlearning.uz/api/";
        public static string API_GET_USERS = API + "getusers";
        public static List<User> getUsers()
        {
            WebClient laravel = new WebClient();
            var response = laravel.DownloadString(API_GET_USERS);
            var users = JsonConvert.DeserializeObject<List<User>>(response);
            return users;
        }
    }
}

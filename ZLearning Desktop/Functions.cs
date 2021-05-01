using System;
using System.Collections.Generic;
using System.Text;

namespace ZLearning_Desktop
{
    class Functions
    {
        public static string getImageOfUser()
        {
            Dictionary<int, string> urls = new Dictionary<int, string>();
            urls.Add(1, "Images/1.jpg");
            urls.Add(2, "Images/2.jpg");
            urls.Add(3, "Images/3.jpg");
            urls.Add(4, "Images/4.jpg");
            urls.Add(5, "Images/5.jpg");
            urls.Add(6, "Images/6.jpg");
            urls.Add(7, "Images/7.jpg");
            var random = new Random();
            int son = random.Next(1, 8);
            return urls[son];
        }
    }
}

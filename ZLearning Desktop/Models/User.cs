using System;
using System.Collections.Generic;
using System.Text;

namespace ZLearning_Desktop.Models
{
    class User
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string friend_name { get; set; }
        public string friend_message { get; set; }
        
        public DateTime created_at = new DateTime();

        public DateTime updated_at = new DateTime();
    }
}

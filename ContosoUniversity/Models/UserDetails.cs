﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class UserDetails
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
    }
}
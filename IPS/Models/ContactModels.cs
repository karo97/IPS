﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPS.Models
{
    public class ContactModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
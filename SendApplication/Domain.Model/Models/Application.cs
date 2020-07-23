﻿using Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string Iin { get; set; }
        public int Score { get; set; }
        public Profile MainProfile { get; set; }
        public Profile SecondProfile { get; set; }
        public College College { get; set; }
    }
}

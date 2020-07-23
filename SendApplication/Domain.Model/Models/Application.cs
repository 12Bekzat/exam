using Domain.Model.Enums;
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
        Profile MainProfile { get; set; }
        Profile SecondProfile { get; set; }
        College College { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

using Domain.Model.Enums;

namespace Edu.Application.DTO
{
    public class ApplicationDto
    {
        public int Id { get; set; }
        public string Iin { get; set; }
        public int Score { get; set; }
        public Profile MainProfile { get; set; }
        public Profile SecondProfile { get; set; }
        public College College { get; set; }
    }
}

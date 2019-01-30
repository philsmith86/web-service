﻿using System;
using System.Collections.Generic;

namespace WebService.Models
{
    public partial class Employees
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }

        public Companies Company { get; set; }
    }
}

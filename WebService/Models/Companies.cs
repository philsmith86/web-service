using System;
using System.Collections.Generic;

namespace WebService.Models
{
    public partial class Companies
    {
        public Companies()
        {
            Employees = new HashSet<Employees>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }

        public ICollection<Employees> Employees { get; set; }
    }
}

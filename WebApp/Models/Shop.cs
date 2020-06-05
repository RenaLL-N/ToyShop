using System;
using System.Collections.Generic;

namespace WebApp
{
    public partial class Shop
    {
        public Shop()
        {
            Employee = new HashSet<Employee>();
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}

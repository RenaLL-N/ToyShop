using System;
using System.Collections.Generic;

namespace WebApp
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ShopId { get; set; }
        public int? Payment { get; set; }

        public virtual Shop Shop { get; set; }
    }
}

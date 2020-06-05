using System;
using System.Collections.Generic;

namespace WebApp
{
    public partial class Offer
    {
        public Offer()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public int? ToyId { get; set; }
        public int? ManufacturerId { get; set; }
        public int? Price { get; set; }

        public virtual Manufacturers Manufacturer { get; set; }
        public virtual Toys Toy { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}

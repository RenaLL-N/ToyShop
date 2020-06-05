using System;
using System.Collections.Generic;

namespace WebApp
{
    public partial class Toys
    {
        public Toys()
        {
            Offer = new HashSet<Offer>();
        }

        public int ToyId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Offer> Offer { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WebApp
{
    public partial class Orders
    {
        public int Id { get; set; }
        public int? ShopId { get; set; }
        public int? OfferId { get; set; }
        public int? Amount { get; set; }

        public virtual Offer Offer { get; set; }
        public virtual Shop Shop { get; set; }
    }
}

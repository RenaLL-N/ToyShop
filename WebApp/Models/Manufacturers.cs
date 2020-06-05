using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp
{
    public partial class Manufacturers
    {
        public Manufacturers()
        {
            Offer = new HashSet<Offer>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Заповніть поле")]
        public string Name { get; set; }

        public virtual ICollection<Offer> Offer { get; set; }
    }
}

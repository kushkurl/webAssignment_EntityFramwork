using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace EntityFrameworkEX.Models
{
    public class Product
    {
        [Required]
        public Decimal Price { get; set; }
        [Key]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }


    }
}

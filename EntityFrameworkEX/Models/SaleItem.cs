using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkEX.Models
{
    public class SaleItem
    {
        [Required]
        public Decimal Price { get; set; }
        [Required]
        [Key]
        public string SalesName { get; set; }
        
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public ICollection<Product> ProductName { get; set; }
    }
}

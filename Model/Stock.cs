using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSystemBackend.Model
{
    public class Stock
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Type { get; set; } // 0 => sale 1 => purchase;

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Totalprice { get; set; }

        public int Productid { get; set; }

        public DateTime Treansactiondate { get; set;}
    }
}

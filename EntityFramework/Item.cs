using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Item: Base
    {
        public Guid ID { get; set; }
        public string? ItemName { get; set; }
        public string? ItemCode { get; set; }
        public string? Location { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? SalePrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PurchasePrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscountPrice { get; set;}
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CGST { get; set;}
        [Column(TypeName = "decimal(18,2)")]
        public decimal? SGST { get; set;}
        [ForeignKey("Users")]
        public Guid? UserID { get; set; }
    }
}

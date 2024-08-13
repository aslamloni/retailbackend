using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class ItemPurchaseDetails : Base
    {
        public Guid ID { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? SalePrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PurchasePrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscountPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CGST { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? SGST { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountedPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SGSTPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CGSTPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        [ForeignKey("Bills")]
        public Guid BillID { get; set; }

        [ForeignKey("Item")]
        public Guid ItemID { get; set; }
        [ForeignKey("Users")]
        public Guid UserId { get; set; }
    }
}

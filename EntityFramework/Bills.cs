using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Bills: Base
    {
        public Guid ID { get; set; }        
        public int BillType { get; set; }
        public string? Name { get; set; }
        public string? ContactNo { get; set; }
        public string? Address { get; set; }
        public string? PaymentMode { get; set;}
        public string? PaymentStatus { get; set; }
        [ForeignKey("Item")]
        public Guid ItemID { get; set; }
        [ForeignKey("Users")]
        public Guid UserId { get; set; }
        public IEnumerable<ItemPurchaseDetails>? PurchaseDetails { get; set;}
    }
}

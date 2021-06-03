using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelpersDemo.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        //[Required]
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName= "decimal(8,2)")]
        public decimal Cost { get; set; }
        public decimal? BillAmount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? NetBillAmount { get; set; }
        public bool IsPartOfDeal { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }   //relationship = One To One  1 product = 1 category
        public string PaymentType { get; set; }
    }
}

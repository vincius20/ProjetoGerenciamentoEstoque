using Services.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Domain model for Sales
    /// </summary>
    public class SalesRecord
    {
        [Key]
        public Guid SalesId { get; set; }

        [DataType(DataType.DateTime)]   
        public DateTime? Date { get; set; }
        public double? Amount { get; set; }
        public List<Product>? Products { get; set; }
        public Guid SellerId { get; set; }
        public SalesStatus SalesStatus  { get; set; }
        public Seller Seller { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// Domain model for product
    /// </summary>
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        [StringLength(100)]
        public string? ProductName { get; set; }

        [Range(0,int.MaxValue)]
        public int? Stock {  get; set; }
        
        [Range(0.0,double.MaxValue)]
        public double? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}

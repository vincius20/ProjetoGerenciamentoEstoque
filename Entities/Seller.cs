using Entities.Enums;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Domain model for Seller
    /// </summary>
    public class Seller
    {
        [Key]
        public Guid SellerId { get; set; }

        [StringLength(100)]
        public string? SellerName { get; set; }

        [StringLength(255)]
        public string? Email { get; set; }

        [StringLength(15)]
        public string? PhoneNumber { get; set; }
        public DateOnly? DateOfBirth { get; set; }

        [Range(0, double.MaxValue)]
        public double? Salary { get; set; }
        public List<SalesRecord>? Sales { get; set; }

        [Required]
        public Status? Status { get; set; }
    }
}

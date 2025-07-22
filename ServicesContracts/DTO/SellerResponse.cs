using Entities.Enums;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace ServicesContracts.DTO
{
    public class SellerResponse
    {
        public Guid SellerId { get; set; }
        public string? SellerName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public double? Salary { get; set; }
        public List<SalesRecordResponse>? Sales { get; set; }
        public Status? Status { get; set; }
    }


    public static class SellerExtensions
    {
        public static SellerResponse ToSellerResponse(this Seller seller)
        {
            var sales = seller.Sales.ToList();
            return new SellerResponse()
            {
                SellerId = seller.SellerId,
                SellerName = seller.SellerName,
                Email = seller.Email,
                PhoneNumber = seller.PhoneNumber,
                DateOfBirth = seller.DateOfBirth,
                Salary = seller.Salary,
                Sales = sales.Select(sale => sale.ToSalesResponse()).ToList(),
                Status = seller.Status
            };
        }
    }
}

using Entities;
using Services.Enums;

namespace ServicesContracts.DTO
{
    public class SalesRecordResponse
    {
        public Guid SalesId { get; set; }
        public DateTime? Date { get; set; }
        public double? Amount { get; set; }
        public List<ProductResponse>? Products { get; set; }
        public Guid SellerId { get; set; }
        //Criar metodo ToSellerResponse
        public SellerResponse? Seller { get; set; }
        public SalesStatus SalesStatus { get; set; }
    }

    public static class SalesExtensions
    {
        public static SalesRecordResponse ToSalesResponse(this SalesRecord salesRecord)
        {
            var products = salesRecord.Products.ToList();
            return new SalesRecordResponse()
            {
                SalesId = salesRecord.SalesId,
                Date = salesRecord.Date,
                Amount = salesRecord.Amount,
                Products = products.Select(product => product.ToProductResponse()).ToList(),
                SellerId = salesRecord.SellerId,
                Seller = salesRecord.Seller.ToSellerResponse(),
                SalesStatus = salesRecord.SalesStatus
            };
        }
    }
}

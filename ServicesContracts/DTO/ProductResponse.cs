using Entities;

namespace ServicesContracts.DTO
{
    public class ProductResponse
    {
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? Stock { get; set; }
        public double? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? CategoryId { get; set; }
    }

    public static class ProductExtensions
    {
        public static  ProductResponse ToProductResponse(this Product product)
        {
            return new ProductResponse()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Stock = product?.Stock,
                Price = product!.Price,
                CreatedDate = product?.CreatedDate,
                CategoryId = product!.CategoryId,
            };
        }
    }
}

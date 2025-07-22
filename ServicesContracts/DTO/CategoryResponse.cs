using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DTO
{
    /// <summary>
    /// DTO class that is used as return type for most of CategoriesService methods
    /// </summary>
    public class CategoryResponse
    {
        public Guid CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public List<ProductResponse>? Products { get; set; }
    }


    public static class CategoryExtensions
    {
        /// <summary>
        /// Method that converts Category to CategoryResponse
        /// </summary>
        /// <param name="category">The category which is going to be converted</param>
        /// <returns>The CategoryResponse object</returns>
        public static CategoryResponse ToCategoryResponse(this Category category)
        {
            var products = category.Products?.ToList();
            return new CategoryResponse()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Products = products?.Select(product => product.ToProductResponse()).ToList()
            };
        }
    }
}

using ServicesContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts
{
    /// <summary>
    /// Bussiness logic for Products
    /// </summary>
    public interface IProductsService
    {
        /// <summary>
        /// Adds a product object to the list of Products
        /// </summary>
        /// <param name="productAddRequest">Product object to add</param>
        /// <returns>Product object response after adding it</returns>
        Task<ProductResponse> AddProduct(ProductAddRequest? productAddRequest);

        /// <summary>
        /// Get all products from the list of Products
        /// </summary>
        /// <returns>List of all products response object</returns>
        Task<List<ProductResponse>?> GetAllProducts();

        /// <summary>
        /// Get a product object from the id
        /// </summary>
        /// <param name="productId">The id of the required product</param>
        /// <returns>The product response object</returns>
        Task<ProductResponse?> GetProductById(Guid? productId);

        /// <summary>
        /// Deletes the product
        /// </summary>
        /// <param name="productId">The id of the product which is going to be deleted<</param>
        /// <returns>True if was excluded, False if it was not excluded</returns>
        Task<bool> DeleteProduct(Guid? productId);
    }
}

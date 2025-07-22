using ServicesContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts
{
    public interface ISellersService
    {
        /// <summary>
        /// Adds a seller object to the list of Sellers
        /// </summary>
        /// <param name="sellerAddRequest">Seller object to add</param>
        /// <returns>Seller object response after adding it</returns>
        Task<SellerResponse> AddSeller(SellerAddRequest? sellerAddRequest);

        /// <summary>
        /// Get all sellers from the list of Seller
        /// </summary>
        /// <returns>List of all seller response object</returns>
        Task<List<SellerResponse>> GetAllSellers();

        /// <summary>
        /// Get a seller object from the id
        /// </summary>
        /// <param name="sellerId">The id of the required seller</param>
        /// <returns>The seller response object</returns>
        Task<SellerResponse?> GetSellerById(Guid? sellerId);

        /// <summary>
        /// Deletes the seller
        /// </summary>
        /// <param name="sellerId">The id of the seller which is going to be deleted<</param>
        /// <returns>True if was excluded, False if it was not excluded</returns>
        Task<bool> DeleteSeller(Guid? sellerId);
    }
}

using ServicesContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts
{
    public interface ISalesRecordsService
    {
        /// <summary>
        /// Adds a product object to the list of SalesRecord
        /// </summary>
        /// <param name="salesRecordAddRequest">SalesRecord object to add</param>
        /// <returns>Sales object response after adding it</returns>
        Task<SalesRecordResponse> AddSalesRecord(SalesRecordAddRequest? salesRecordAddRequest);

        /// <summary>
        /// Get all sales from the list of SalesRecord
        /// </summary>
        /// <returns>List of all sales response object</returns>
        Task<List<SalesRecordResponse>> GetAllSales();

        /// <summary>
        /// Get a sales object from the id
        /// </summary>
        /// <param name="salesId">The id of the required sales</param>
        /// <returns>The sales response object</returns>
        Task<SalesRecordResponse?> GetSalesById(Guid? salesId);

        /// <summary>
        /// Deletes the sale
        /// </summary>
        /// <param name="salesId">The id of the sale which is going to be deleted<</param>
        /// <returns>True if was excluded, False if it was not excluded</returns>
        Task<bool> DeleteSales(Guid? salesId);
    }
}

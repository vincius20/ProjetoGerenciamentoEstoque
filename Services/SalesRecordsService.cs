using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Helper;
using ServicesContracts;
using ServicesContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SalesRecordsService : ISalesRecordsService
    {
        private readonly StockDbContext _dbContext;
        private readonly IProductsService _productsService;

        public SalesRecordsService(StockDbContext stockDbContext, IProductsService productsService)
        {
            _dbContext = stockDbContext;
            _productsService = productsService;
        }
        public async Task<SalesRecordResponse> AddSalesRecord(SalesRecordAddRequest? salesRecordAddRequest)
        {
            if(salesRecordAddRequest == null)
            {
                throw new ArgumentNullException(nameof(salesRecordAddRequest));
            }

            ValidationHelper.ModelValidation(salesRecordAddRequest);

            SalesRecord salesRecord = salesRecordAddRequest.ToSalesRecord();

            salesRecord.SalesId = Guid.NewGuid();
            var products = _dbContext.Products.ToList();

            foreach (Guid productId in salesRecordAddRequest.Products!)
            {
                foreach(Product productFromDb in products)
                {
                    if(productFromDb.ProductId == productId)
                    {
                        _dbContext.Products.Attach(productFromDb);

                        salesRecord.Products.Add(productFromDb);
                    }
                }
            }

            _dbContext.SalesRecords.Add(salesRecord);
            await _dbContext.SaveChangesAsync();
            return salesRecord.ToSalesResponse();
        }

        public async Task<bool> DeleteSales(Guid? salesId)
        {
            if(salesId == null)
            {
                throw new ArgumentNullException(nameof(salesId));
            }

            SalesRecord? salesRecord = await _dbContext.SalesRecords.FirstOrDefaultAsync(sale => sale.SalesId == salesId);

            if(salesRecord == null)
            {
                return false;
            }

            _dbContext.SalesRecords.Remove(
                _dbContext.SalesRecords.FirstOrDefault(sale => sale.SalesId == salesId)!);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<SalesRecordResponse>> GetAllSales()
        {
            var salesRecord =  await _dbContext.SalesRecords.Include("Products").ToListAsync();
            return salesRecord.Select(sale => sale.ToSalesResponse()).ToList();
        }

        public async Task<SalesRecordResponse?> GetSalesById(Guid? salesId)
        {
            if(salesId == null)
            {
                throw new ArgumentNullException(nameof(salesId));
            }

            SalesRecord? sales = await _dbContext.SalesRecords.Include("Products").FirstOrDefaultAsync(sale => sale.SalesId == salesId);

            if(sales == null)
            {
                return null;
            }

            return sales.ToSalesResponse();
        }
    }
}

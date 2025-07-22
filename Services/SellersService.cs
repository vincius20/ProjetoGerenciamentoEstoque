using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Helper;
using ServicesContracts;
using ServicesContracts.DTO;

namespace Services
{
    public class SellersService : ISellersService
    {
        private readonly StockDbContext _dbContext;
        private readonly ISalesRecordsService _salesRecordsService;
        public SellersService(StockDbContext stockDbContext, ISalesRecordsService salesRecordsService)
        {
            _dbContext = stockDbContext;
            _salesRecordsService = salesRecordsService;
        }

        public SellersService(StockDbContext stockDbContext)
        {
            _dbContext = stockDbContext;
        }
        public async Task<SellerResponse> AddSeller(SellerAddRequest? sellerAddRequest)
        {
            if(sellerAddRequest == null)
            {
                throw new ArgumentNullException(nameof(sellerAddRequest));
            }

            ValidationHelper.ModelValidation(sellerAddRequest);

            Seller seller = sellerAddRequest.ToSeller();
            seller.SellerId = Guid.NewGuid();

            _dbContext.Sellers.Add(seller);
            await _dbContext.SaveChangesAsync();

            return seller.ToSellerResponse();
        }

        public async Task<bool> DeleteSeller(Guid? sellerId)
        {
            if(sellerId == null)
            {
                return false;
            }

            Seller? seller = await _dbContext.Sellers.FirstOrDefaultAsync(seller => seller.SellerId == sellerId);

            if(seller == null)
            {
                return false;
            }

            _dbContext.Sellers.Remove(
                _dbContext.Sellers.FirstOrDefault(seller => seller.SellerId == sellerId)!);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<SellerResponse>> GetAllSellers()
        {
            var sellers = await _dbContext.Sellers.Include("Sales").ToListAsync();

            return sellers.Select(seller => seller.ToSellerResponse()).ToList();
        }

        public async Task<SellerResponse?> GetSellerById(Guid? sellerId)
        {
            if(sellerId == null)
            {
                return null;
            }

            Seller? seller = await _dbContext.Sellers.Include("Sales").FirstOrDefaultAsync(seller => seller.SellerId == sellerId);

            if(seller == null)
            {
                return null;
            }

            return seller.ToSellerResponse();
        }
    }
}

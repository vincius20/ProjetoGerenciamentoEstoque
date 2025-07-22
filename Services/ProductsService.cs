using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
    public class ProductsService : IProductsService
    {
        private readonly StockDbContext _dbContext;
        private readonly ICategoriesService _categoriesService;

        public ProductsService(StockDbContext stockDbContext, ICategoriesService categoriesService)
        {
            _dbContext = stockDbContext;
            _categoriesService = categoriesService;
        }

        public async Task<ProductResponse> AddProduct(ProductAddRequest? productAddRequest)
        {
            if(productAddRequest == null)
            {
                throw new ArgumentException(nameof(productAddRequest));
            }

            ValidationHelper.ModelValidation(productAddRequest);

            Product product = productAddRequest.ToProduct();

            product.ProductId = Guid.NewGuid();
            product.CreatedDate = DateTime.Now;

            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            return product.ToProductResponse();
        }

        public async Task<bool> DeleteProduct(Guid? productId)
        {
            if(productId == null)
            {
                throw new ArgumentNullException(nameof(productId));
            }

            Product? product = await _dbContext.Products.FirstOrDefaultAsync(prod => prod.ProductId == productId);

            if(product == null)
            {
                return false;
            }

            _dbContext.Products.Remove(
                _dbContext.Products.First(prod => prod.ProductId == productId)
                );

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<ProductResponse>?> GetAllProducts()
        {
            var products = await _dbContext.Products.ToListAsync();

            return products?.Select(prod => prod.ToProductResponse()).ToList();
        }

        public async Task<ProductResponse?> GetProductById(Guid? productId)
        {
            if(productId == null)
            {
                return null;
            }

            Product? product = await _dbContext.Products.FirstOrDefaultAsync(prod => prod.ProductId == productId);

            if (product == null)
            {
                return null;
            }

            return product.ToProductResponse();
        }
    }
}

using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DTO
{
    public class ProductAddRequest
    {
        [Required(ErrorMessage = "O produto deve ter um nome")]
        [StringLength(100)]
        public string? ProductName { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O estoque não pode conter um numero negativo de produtos")]
        public int? Stock { get; set; }

        [Required(ErrorMessage = "Todo produto deve ter um preço")]
        [Range(0.0, double.MaxValue, ErrorMessage = "O valor de um produto não pode ser negativo")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "Todo produto deve pertencer a alguma categoria")]
        public Guid? CategoryId { get; set; }


        public Product ToProduct()
        {
            return new Product()
            {
                ProductName = ProductName,
                Stock = Stock,
                Price = Price,
                CategoryId = CategoryId
            };
        }
    }
}

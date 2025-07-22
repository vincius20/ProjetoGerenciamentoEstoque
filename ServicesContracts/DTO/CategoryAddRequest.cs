using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts.DTO
{
    /// <summary>
    /// DTO class for adding a new category
    /// </summary>
    public class CategoryAddRequest
    {
        public string? CategoryName { get; set; }

        public Category ToCategory()
        {
            return new Category()
            {
                CategoryName = CategoryName
            };
        }
    }
}

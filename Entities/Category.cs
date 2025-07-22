﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Domain model for Categories
    /// </summary>
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; } 

        [StringLength(40)]
        public string? CategoryName { get; set; }
        public List<Product>? Products { get; set; }
    }
}

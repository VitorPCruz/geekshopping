﻿using GeekShopping.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace GeekShopping.ProductAPI.Model
{
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(1, 1000000)]
        public decimal Price { get; set; }

        [StringLength(280)]
        public string Description { get; set; }
        
        [StringLength(50, MinimumLength = 3)]
        public string CategoryName { get; set; }

        [StringLength(300)]
        public string ImageUrl { get; set; }
    }
}

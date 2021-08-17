using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProductsAndCategories.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least two characters long.")]
        public string Name { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Description must be at least two characters long.")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Association> Associations { get; set; }
    }
}
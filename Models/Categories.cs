using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAndCategories.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        
        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least two characters long.")]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Association> Associations { get; set; }
    }
}
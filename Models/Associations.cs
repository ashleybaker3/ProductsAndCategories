using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAndCategories.Models
{
    public class Association
    {
        public int AssociationId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
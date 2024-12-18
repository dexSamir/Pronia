using System;
using ProniaProject.Models.Base;
using ProniaProject.Utilities.Helpers.Enums;

namespace ProniaProject.Models
{
	public class Product : BaseEntity
	{
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public decimal SellPrice { get; set; }
		public decimal CostPrice { get; set; }
		public int Quantity { get; set; }
		public int? CategoryId { get; set; }
		public Category? Category { get; set; }
		public string CoverImage { get; set; } = null!;
		public int Discount { get; set; }
		public ICollection<ProductImage> Images { get; set; } = new HashSet<ProductImage>();
		public ICollection<Comment> Comments { get; set; } = null!; 
		public ICollection<Rating> Ratings { get; set; } = new HashSet<Rating>();
		public ICollection<ProductTag> Tags { get; set; } = new HashSet<ProductTag>();
		public ICollection<ProductColor> Colors = new HashSet<ProductColor>();
		public ICollection<ProductSize> Sizes = new HashSet<ProductSize>();
    }
}


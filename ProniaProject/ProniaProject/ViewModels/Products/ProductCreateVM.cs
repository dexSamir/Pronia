using System;
using System.ComponentModel.DataAnnotations;

namespace ProniaProject.ViewModels.Products
{
	public class ProductCreateVM
	{
		[MaxLength(64, ErrorMessage = "Name must be less than 64 charachters!"), Required(ErrorMessage = "Name is Required!")]
		public string Name { get; set; } = null!;

		[MaxLength(256, ErrorMessage = "Description must be less than 256 charachters!"), Required(ErrorMessage = "Description is required")]
		public string Description { get; set; } = null!;

		[Range(0.01, double.MaxValue, ErrorMessage ="Sell Price must be greater than 0!")]
		public decimal SellPrice { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Cost Price must be greater than 0!")]
        public decimal CostPrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive number!")]
        public int Quantity { get; set; }

        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100!")]
        public int Discount { get; set; }

        [Required(ErrorMessage = "Cover image is required!")]
        public IFormFile CoverFile { get; set; } = null!;

		public IEnumerable<IFormFile> OtherImages { get; set; } = null!;

        [Required(ErrorMessage = "Category is required!")]
        public int CategoryId { get; set; }

		public IEnumerable<int> TagIds { get; set; } = new HashSet<int>(); 
		public IEnumerable<int> ColorIds { get; set; } = new HashSet<int>();
		public IEnumerable<int> SizeIds { get; set; } = new HashSet<int>();
    }
}
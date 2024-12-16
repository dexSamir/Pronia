using System;
using ProniaProject.Models.Base;

namespace ProniaProject.Models
{
	public class ProductImage : BaseEntity 
	{
		public string FileUrl { get; set; } = null!;
		public int? ProductId { get; set; }
		public Product? Product { get; set; }

	}
}


using System;
using ProniaProject.Models.Base;

namespace ProniaProject.Models
{
	public class Category : BaseEntity
	{
		public string Name { get; set; } = null!;
		public ICollection<Product> Products { get; set; } = new HashSet<Product>(); 
	}
}


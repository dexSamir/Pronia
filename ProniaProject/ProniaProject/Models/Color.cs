using System;
using ProniaProject.Models.Base;

namespace ProniaProject.Models
{
	public class Color : BaseEntity
	{
		public string Name { get; set; } = null!;
		public ICollection<ProductColor> colors = new HashSet<ProductColor>(); 
 	}
}


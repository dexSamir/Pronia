using System;
using ProniaProject.Models.Base;

namespace ProniaProject.Models
{
	public class Tag : BaseEntity
	{
		public string Name { get; set; } = null!;
		public ICollection<ProductTag> Tags { get; set; } = new HashSet<ProductTag>(); 
	}
}


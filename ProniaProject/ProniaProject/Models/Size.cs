using System;
using ProniaProject.Models.Base;
using ProniaProject.Utilities.Helpers.Enums;

namespace ProniaProject.Models
{
	public class Size: BaseEntity
	{
		public ESize SizeName { get; set; }
		public ICollection<ProductSize> Sizes { get; set; } = new HashSet<ProductSize>(); 
	}
}


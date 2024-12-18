using System;
using ProniaProject.Models.Base;
using ProniaProject.Utilities.Helpers.Enums;

namespace ProniaProject.Models
{
	public class Color : BaseEntity
	{
		public EColor ColorName { get; set; } 
		public ICollection<ProductColor> colors = new HashSet<ProductColor>(); 
 	}
}


using System;
using System.ComponentModel.DataAnnotations;

namespace ProniaProject.ViewModels.Category
{
	public class CategoryCreateVM
	{
		[MaxLength(64, ErrorMessage = "Name must be less than 64 charachters!"), Required(ErrorMessage = "Name is required!")]
		public string Name { get; set; } = null!;
	}
}


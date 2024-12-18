using System;
using System.ComponentModel.DataAnnotations;

namespace ProniaProject.ViewModels.Tag
{
	public class TagCreateVM
	{
		[MaxLength(32, ErrorMessage = "Name length must be less than 32 charachters"), Required(ErrorMessage = "Name is Required")]
		public string Name { get; set; } = null!;

	}
}


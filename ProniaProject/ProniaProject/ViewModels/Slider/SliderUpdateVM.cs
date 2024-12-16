using System;
using System.ComponentModel.DataAnnotations;

namespace ProniaProject.ViewModels.Slider
{
	public class SliderUpdateVM
	{
		[MaxLength(64, ErrorMessage = "Title length must be less than 64 charachters!"), Required(ErrorMessage = "Title is required")]
		public string Title { get; set; } = null!;
		[MaxLength(128, ErrorMessage = "Subtitle length must be less than 128 charachters"), Required(ErrorMessage = "Subtitle is Required")]
		public string Subtitle { get; set; } = null!;
		public string? Offer { get; set; }
		public string ImageUrl { get; set; } = null!;
		public IFormFile? File { get; set; }
	}
}


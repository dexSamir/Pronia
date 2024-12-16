using System;
using System.ComponentModel.DataAnnotations;

namespace ProniaProject.ViewModels.Slider
{
	public class SliderCreateVM
	{
		public int Id { get; set; }
		[MaxLength(32, ErrorMessage = "Title length must be less than 32 charachters"), Required(ErrorMessage ="Title is required")]
		public string Title { get; set; } = null!;
		[MaxLength(64 , ErrorMessage ="Subtitle length must be less than 64 charachters"), Required(ErrorMessage ="Subtitle is required")]
		public string Subtitle { get; set; } = null!;
		public string? Offer { get; set; }
		public string ImageUrl { get; set; } = null!;
		public IFormFile File { get; set; } = null!; 
	}
}


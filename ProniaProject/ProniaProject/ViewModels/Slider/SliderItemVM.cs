using System;
namespace ProniaProject.ViewModels.Slider
{
	public class SliderItemVM
	{
		public string Title { get; set; } = null!;
		public string Subtitle { get; set; } = null!;
		public string? Offer { get; set; }
		public string ImageUrl { get; set; } = null!;
		public DateTime CreatedTime { get; set; } 
		public IFormFile File { get; set; } = null!;
		 
	}
}


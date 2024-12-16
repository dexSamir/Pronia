using System;
using System.ComponentModel.DataAnnotations;

namespace ProniaProject.Models
{
	public class Rating 
	{
		public int Id { get; set; }
		[Range(1,5)]
		public int RatingCount { get; set; } 

		public int ProductId { get; set; }
		public Product Product { get; set; } = null!;

		public int UserId { get; set; }
		public User User { get; set; } = null!; 
	}
}


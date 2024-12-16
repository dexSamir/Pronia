using System;
using ProniaProject.Models.Base;

namespace ProniaProject.Models
{
	public class Comment 
	{
		public int Id { get; set; }
		public string Content { get; set; } = null!;

		public int ProductId { get; set; }
		public Product Product { get; set; } = null!;

		public int UserId { get; set; }
		public User User { get; set; } = null!;
		public bool IsEdited { get; set; }
		public DateTime CreatedTime { get; set; } = DateTime.UtcNow;

		public ICollection<CommentLike> Likes { get; set; } = new HashSet<CommentLike>(); 
	}
}


using System;
using Microsoft.AspNetCore.Identity;

namespace ProniaProject.Models
{
	public class User : IdentityUser
	{
		public string Name { get; set; } = null!; 
		public string Surname { get; set; } = null!;
		public int Age { get; set; }
		public string? ProfileImageUrl { get; set; }

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
		public ICollection<CommentLike> LikedComments { get; set; } = new HashSet<CommentLike>();
		public ICollection<Rating> Ratings { get; set; } = new HashSet<Rating>();
    }
}


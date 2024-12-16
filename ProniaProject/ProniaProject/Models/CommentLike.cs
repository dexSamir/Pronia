﻿using System;
namespace ProniaProject.Models
{
	public class CommentLike
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public User User { get; set; } = null!;

		public int CommentId { get; set; }
		public Comment Comment { get; set; } = null!;
	}
}


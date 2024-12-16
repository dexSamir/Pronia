using System;
namespace ProniaProject.Models.Base
{
	public class BaseEntity
	{
		public int Id{ get; set; }
		public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
		public bool IsDeleted { get; set; }

	}
}


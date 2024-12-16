using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProniaProject.Models;

namespace ProniaProject.DAL
{
	public class AppDbContext : IdentityDbContext<User>
	{
		public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
		public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }
    }
}


using System;
using Microsoft.EntityFrameworkCore;
namespace FinalProject.Models
{
	public class CopyrightFreeMusicDBContext : DbContext
	{
		protected readonly IConfiguration Configuration;

		public CopyrightFreeMusicDBContext(DbContextOptions<CopyrightFreeMusicDBContext> options, IConfiguration configuration)
			: base(options)
        {
			Configuration = configuration;
        }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
			var connectionString = Configuration.GetConnectionString("CopyrightFreeMusic");
			options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

		public DbSet<Musics> Musics { get; set; } = null!;
		public DbSet<Artists> Artists { get; set; } = null!;
		public DbSet<Genres> Genres { get; set; } = null!;
	}
}


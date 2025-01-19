using Blazzzer.ApiService.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazzzer.ApiService.Database
{
	public class JobContext : DbContext
	{
		public DbSet<Job> Jobs { get; set; }

		public JobContext(DbContextOptions<JobContext> options) : base(options)
		{ }
	}
}

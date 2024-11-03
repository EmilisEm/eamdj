using EAMDJ.Model;
using Microsoft.EntityFrameworkCore;

namespace EAMDJ.Context
{
	public class ServiceAppContext: DbContext
	{
		public DbSet<Business> Business {  get; set; }
		public ServiceAppContext(DbContextOptions<ServiceAppContext> options) : base(options) { }
	}
}

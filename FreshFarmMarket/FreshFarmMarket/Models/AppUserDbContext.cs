using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FreshFarmMarket.Models
{
    public class AppUserDbContext:IdentityDbContext<AppUser>
    {
        private readonly IConfiguration _configuration;
        //public AppUserDbContext(DbContextOptions<AppUserDbContext> options):base(options){}

        public AppUserDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("ASConnectionString");optionsBuilder.UseSqlServer(connectionString);
        }

    }
}

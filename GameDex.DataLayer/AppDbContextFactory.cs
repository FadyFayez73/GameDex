using GameDex.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDex.DataLayer
{
    public class AppDbContextFactory : IDbContextFactory<AppDbContext>
    {
        private readonly IConfiguration _configuration;
        public AppDbContextFactory(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public AppDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>();
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

            return new AppDbContext(options.Options);
        }
    }
}

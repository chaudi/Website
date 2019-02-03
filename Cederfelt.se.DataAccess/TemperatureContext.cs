using Cederfelt.se.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Cederfelt.se.DataAccess
{
    public class TemperatureContext : DbContext
    {
        public TemperatureContext(DbContextOptions<TemperatureContext> options) : base(options) { }

        public DbSet<Temperature> Temperatures { get; set; }
    }
}

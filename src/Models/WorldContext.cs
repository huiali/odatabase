using Microsoft.EntityFrameworkCore;

namespace ODataBase
{
    public partial class WorldContext : DbContext
    {
        public WorldContext(DbContextOptions<WorldContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
    }
}

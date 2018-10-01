using Microsoft.EntityFrameworkCore;

namespace ODataBase
{
    public partial class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Test> Test { get; set; }
    }
}

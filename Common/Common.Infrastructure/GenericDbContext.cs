using Microsoft.EntityFrameworkCore;

namespace Common.Infrastructure
{
    public class GenericDbContext : DbContext
    {
        public GenericDbContext(DbContextOptions<GenericDbContext> options)
          : base(options)
        {

        }

        protected GenericDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}

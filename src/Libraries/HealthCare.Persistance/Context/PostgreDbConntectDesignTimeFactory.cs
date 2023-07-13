using Microsoft.EntityFrameworkCore.Design;

namespace HealthCare.Persistance.Context
{
    public class PostgreDbConntectDesignTimeFactory : IDesignTimeDbContextFactory<PostgreDbContext>
    {
        public PostgreDbContext CreateDbContext(string[] args)
        {
            var context = new PostgreDbContext();

            return context;
        }
    }
}

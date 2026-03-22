using Microsoft.EntityFrameworkCore;

namespace HogRider.Backend.Data
{
    public class TestDbContextFactory
    {
        public static AppDbContext Create()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("Filename=:memory:")
                .Options;

            var context = new AppDbContext(options);

            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            return context;
        }
    }
}
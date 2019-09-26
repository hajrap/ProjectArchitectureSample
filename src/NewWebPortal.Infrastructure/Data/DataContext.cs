using Microsoft.EntityFrameworkCore;
using NewWebPortal.ApplicationCore.Entities;

namespace NewWebPortal.Infrastructure.Data
{
    public class DataContext  :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sample>();
        }

    }
}

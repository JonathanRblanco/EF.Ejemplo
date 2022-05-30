using EF.Domian.Contracts;
using EF.Domian.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace EF.Infraestructure.Context
{
    public class EFContext : DbContext, IUnitOfWork
    {
        public DbSet<Todo> Todos { get; set; }
        public EFContext(DbContextOptions<EFContext> options) : base(options) { }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }

    public class EFContextDesignFactory : IDesignTimeDbContextFactory<EFContext>
    {
        public EFContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFContext>()
                .UseSqlServer("server=localhost;user=sa;pwd=.Prod1234;database=TodoDB;");

            return new EFContext(optionsBuilder.Options);
        }
    }
}

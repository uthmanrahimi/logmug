using Logmug.SqlServerProvider.Entities;

using Microsoft.EntityFrameworkCore;

namespace Logmug.SqlServerProvider.Persistence
{
    public class SqlServerDataContext : DbContext
    {
        public DbSet<RequestLogEntity> RequestLogs { get; set; }

        private readonly string _connectipnString;
        private readonly string _tableName;


        public SqlServerDataContext(string connectionString, string tableName)
        {
            _connectipnString = connectionString;
            _tableName = tableName;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RequestLogEntity>().ToTable(_tableName)
                                                   .HasKey(x => x.Id);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectipnString);
        }
    }
}

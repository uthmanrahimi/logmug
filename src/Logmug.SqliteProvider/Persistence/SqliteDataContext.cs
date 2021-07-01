using Logmug.SqliteProvider.Entities;

using Microsoft.EntityFrameworkCore;

namespace Logmug.SqliteProvider.Persistence
{
    public class SqliteDataContext : DbContext
    {
        private string _connectionString;
        private string _tableName;

        public DbSet<RequestLogEntity> Requests { get; set; }

        public SqliteDataContext(string connectionString,string tableName)
        {
            _connectionString = connectionString;
            _tableName = tableName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RequestLogEntity>().ToTable(_tableName)
                .HasKey(e => e.Id);

        }
    }
}

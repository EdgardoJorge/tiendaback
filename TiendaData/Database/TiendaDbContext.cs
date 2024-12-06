using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TiendaData.Database.Tables;

namespace TiendaData.Database
{
    public class TiendaDbContext : DbContext
    {
        public TiendaDbContext(DbContextOptions<TiendaDbContext> opts) : base(opts) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<categoria>()
                .HasMany<Productos>()
                .WithOne()
                .HasForeignKey(p => p.id_categoria)
                .IsRequired();
        }
        public DbSet<categoria> categorias { get; set; }
        public DbSet<Productos> productos { get; set; }
    }
}

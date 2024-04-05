using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using asignacionKensysBackend.Models;
namespace asignacionKensysBackend.Services
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
		{

		}
		public DbSet<TipoPermiso> TipoPermisos { get; set; }
		public DbSet<Permiso> Permisos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Permiso>().HasOne(x => x.TipoPermiso).WithMany(x => x.Permisos).HasForeignKey(x=>x.TipoPermisoId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}


using DataLayer.Entites.Account;
using DataLayer.Entites.Products;
using DataLayer.Entites.Sliders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Context
{
 public class AngularEshopDbContext:DbContext
  {
    public AngularEshopDbContext(DbContextOptions<AngularEshopDbContext> options):base(options)
    {
        
    }

    #region Db Sets

    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Slider> Sliders { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<ProductCategory> ProductCategories { get; set; }

    public DbSet<ProductGallery> ProductGalleries { get; set; }

    public DbSet<ProductSelectedCategory> ProductSelectedCategories { get; set; }

    public DbSet<ProductVisit> ProductVisits { get; set; }
    #endregion

    #region disable cascading delete in database

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<UserRole>().HasKey(c => new { c.RoleId, c.UserId });
     // modelBuilder.Entity<ProductCategory>().HasKey(c => new {c.})
      var cascades = modelBuilder.Model.GetEntityTypes()
          .SelectMany(t => t.GetForeignKeys())
          .Where(fk => fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

      foreach (var fk in cascades)
      {
        fk.DeleteBehavior = DeleteBehavior.Restrict;
      }

      base.OnModelCreating(modelBuilder);
    }

    #endregion
  }
}

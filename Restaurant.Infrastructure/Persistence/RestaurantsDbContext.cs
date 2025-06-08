using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
using Restaurants.Domain.Entities;



namespace Restaurants.Infrastructure.Persistence;

public class RestaurantsDbContext:IdentityDbContext<UserIdentity>
{
    public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options)
        : base(options)
    {
    }


    internal  DbSet<Restaurant> Restaurants { get; set; }
    internal DbSet<Dish> dishes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Restaurant>()
            .OwnsOne(r => r.Address);
        modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.Dishes)
            .WithOne()
            .HasForeignKey(d=>d.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}

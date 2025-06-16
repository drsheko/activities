using System;
using Microsoft.EntityFrameworkCore;
using Domain;
namespace Persistence
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
       public DbSet<Activity> MyProperty { get; set; }
    }
}
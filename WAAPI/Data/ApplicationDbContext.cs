using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WAAPI.Models;

namespace WAAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        public DbSet<Product> Products {get;set;}
        public DbSet<Order> Orders {get;set;}
        public DbSet<Team> Team {get;set;}
    }
}
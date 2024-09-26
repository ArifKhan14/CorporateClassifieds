using Microsoft.EntityFrameworkCore;
using OffersMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffersMicroservice.DBContexts
{
    public class OfferContext :DbContext
    {
        public OfferContext(DbContextOptions<OfferContext> options) : base(options)
        {
        }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Electronics",
                    CategoryDescription = "Electronic Items",
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Furniture",
                    CategoryDescription = "Furniture Items",
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Automobiles",
                    CategoryDescription = "Automobiles ",
                }

            );
        }
    }
}

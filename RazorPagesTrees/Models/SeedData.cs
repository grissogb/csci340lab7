using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesTrees.Data;

namespace RazorPagesTrees.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesTreesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesTreesContext>>()))
            {
                // Look for any trees.
                if (context.Tree.Any())
                {
                    return;   // DB has been seeded
                }

                context.Tree.AddRange(
                    new Tree
                    {
                        Name = "Johnny",
                        PlantingDate = DateTime.Parse("1989-2-12"),
                        Age = 32,
                        Species = "Birch",
                        Height = 7.99M,
                        Circumference = 2M
                    },

                    new Tree
                    {
                        Name = "Orange",
                        PlantingDate = DateTime.Parse("1990-4-02"),
                        Age = 31,
                        Species = "Oak",
                        Height = 8.34M,
                        Circumference = 2.2M
                    },

                    new Tree
                    {
                        Name = "50 thousand",
                        PlantingDate = DateTime.Parse("2002-12-19"),
                        Age = 20,
                        Species = "Pine",
                        Height = 12.13M,
                        Circumference = 3.25M
                    },

                    new Tree
                    {
                        Name = "Chocolate",
                        PlantingDate = DateTime.Parse("2012-6-07"),
                        Age = 09,
                        Species = "Pecan",
                        Height = 4M,
                        Circumference = 1.36M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

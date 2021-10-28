using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesTrees.Models;

namespace RazorPagesTrees.Data
{
    public class RazorPagesTreesContext : DbContext
    {
        public RazorPagesTreesContext (DbContextOptions<RazorPagesTreesContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesTrees.Models.Tree> Tree { get; set; }
    }
}

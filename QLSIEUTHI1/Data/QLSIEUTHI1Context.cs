using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLSIEUTHI1.Models;

namespace QLSIEUTHI1.Data
{
    public class QLSIEUTHI1Context : DbContext
    {
        public QLSIEUTHI1Context (DbContextOptions<QLSIEUTHI1Context> options)
            : base(options)
        {
        }

        public DbSet<QLSIEUTHI1.Models.Category> Category { get; set; } = default!;

        public DbSet<QLSIEUTHI1.Models.Product>? Product { get; set; }

        public DbSet<QLSIEUTHI1.Models.User>? User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FE_CURD.Models;

namespace FE_CURD.Data
{
    public class FE_CURDContext : DbContext
    {
        public FE_CURDContext (DbContextOptions<FE_CURDContext> options)
            : base(options)
        {
        }

        public DbSet<FE_CURD.Models.Movie> Movie { get; set; } = default!;
    }
}

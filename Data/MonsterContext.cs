using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using csci340lab8.Models;

namespace csci340lab8.Data
{
    public class MonsterContext : DbContext
    {
        public MonsterContext (DbContextOptions<MonsterContext> options)
            : base(options)
        {
        }

        public DbSet<csci340lab8.Models.Monster> Monster { get; set; } = default!;
    }
}

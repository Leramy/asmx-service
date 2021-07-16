using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Models
{
    public class HockeyPlayerContext : DbContext
    {
        public DbSet<Lab11.Models.HockeyPlayer> hockeyPlayer { get; set; }
        public HockeyPlayerContext(DbContextOptions<HockeyPlayerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

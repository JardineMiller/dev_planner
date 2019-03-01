using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dev_planner_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace dev_planner_backend.Contexts
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}

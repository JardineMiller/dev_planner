using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using dev_planner_backend.Contexts;
using dev_planner_backend.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using NLog;

namespace dev_planner_backend
{
    public class DatabaseSeeder : ISeeder
    {
        private readonly ILogger<DatabaseSeeder> logger;
        private readonly ApplicationDbContext cnt;
        
        public DatabaseSeeder(ILogger<DatabaseSeeder> logger, ApplicationDbContext cnt)
        {
            this.logger = logger;
            this.cnt = cnt;
        }
        
        public void SeedAll()
        {
            var timer = new Stopwatch();
            
            logger.LogInformation("Starting seed...");
            
            seedPeople();
            seedStates();
            seedItems();
            
            logger.LogInformation($"Seeding of database complete. It took {timer.ElapsedMilliseconds} ms");
        }

        private void seedPeople()
        {
            if (!cnt.People.Any())
            {
                var people = new List<Person>()
                {
                    new Person() {Name = "Jardine", Email = "jardine@emailprovider.com"},
                    new Person() {Name = "Julia", Email = "julia@emailprovider.com"},
                    new Person() {Name = "Matt", Email = "matt@emailprovider.com"},
                    new Person() {Name = "Alison", Email = "alison@emailprovider.com"},
                };

                cnt.People.AddRange(people);
                cnt.SaveChanges();
            }
        }

        private void seedStates()
        {
            if (!cnt.States.Any())
            {
                var states = new List<State>()
                {
                    new State() {Name = "To do"},
                    new State() {Name = "In progress"},
                    new State() {Name = "Testing"},
                    new State() {Name = "Completed"},
                };

                cnt.States.AddRange(states);
                cnt.SaveChanges();
            }
        }

        private void seedItems()
        {
            if (!cnt.Items.Any())
            {
                var items = new List<Item>()
                {
                    new Item() {Name = "Finish Dev Planner App", StateId = 2, PersonId = 1},
                    new Item() {Name = "Seed Database", StateId = 2, PersonId = 1},
                    new Item() {Name = "Work out what to do next", StateId = 1, PersonId = 1},
                    new Item() {Name = "Eat loads of food", StateId = 4, PersonId = 1},
                    new Item() {Name = "Kick ass at UCD", StateId = 4, PersonId = 2},
                };

                cnt.Items.AddRange(items);
                cnt.SaveChanges();
            }
        }
    }
}
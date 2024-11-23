using Microsoft.EntityFrameworkCore;
using Rpages.Models;
using System.Collections.Generic;

namespace Rpages.Data
{
    public class ClientContext : DbContext
    {
       
            public ClientContext(DbContextOptions<ClientContext> options)
                : base(options)
            {

            }

            public DbSet<Client> Clients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, Name = "John Doe", Email = "john@example.com",Address ="Oxferd, USA", PhoneNumber="03030303035" },
                new Client { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Address = "Oxferd, UK", PhoneNumber = "034534242423" }
            );
        }

    }
}

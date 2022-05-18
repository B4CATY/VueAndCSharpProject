using CSharpBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CSharpBackEnd.Data
{
    public class ParcerContext : DbContext
    {
        public ParcerContext(DbContextOptions<ParcerContext> options) : base(options) => Database.EnsureCreated();

        public DbSet<Link> Links { get; set; }
        public DbSet<ParcedLink> ParcedLinks { get; set; }


    }
}


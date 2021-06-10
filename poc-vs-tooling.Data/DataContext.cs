using Microsoft.EntityFrameworkCore;
using poc_vs_tooling.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace poc_vs_tooling.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<Person> Persons { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    Database.EnsureCreated();
        //}

    }
}

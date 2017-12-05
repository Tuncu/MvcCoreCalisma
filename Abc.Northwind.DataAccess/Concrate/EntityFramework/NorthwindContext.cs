using Abc.Northwind.Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Northwind.DataAccess.Concrate.EntityFramework
{
    public class NorthwindContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.;database=NORTHWND;uid=sa;pwd=1");
        }
    }
}

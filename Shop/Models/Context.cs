using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Shop.Models
{
    public class Context: DbContext
    {
        public Context() : base("Shop")
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Kategoria> Kategorie { get; set; }
        public DbSet<News> News { get; set; }
    }
}
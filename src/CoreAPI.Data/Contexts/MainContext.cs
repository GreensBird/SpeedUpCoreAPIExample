using CoreAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAPI.Data.Contexts
{
    public class MainContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Price> Prices { get; set; }

        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }
    }
}

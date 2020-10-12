using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CockroachDbLib.Models
{
    public class CockroachDbContext : DbContext
    {
        public CockroachDbContext(DbContextOptions<CockroachDbContext> options) : base(options)
        {
        }

        public DbSet<Account> accounts { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace helloWorld.Models
{
    public class PGDbContext: DbContext
    {
        public PGDbContext() : base(nameOrConnectionString: "DefaultConnectionString") { }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

    }
}
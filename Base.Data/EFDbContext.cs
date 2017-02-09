using Base.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data {

    public class EFDbContext : DbContext, IContext {

        public EFDbContext()
            : base() 
        {
            this.Database.Initialize(true);
        }

        public DbSet<User> Users { get; set; }
    }
}

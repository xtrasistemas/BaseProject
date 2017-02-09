using Base.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data {
    public interface IContext {
        int SaveChanges();

        DbEntityEntry Entry(object entity);

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Database Database { get; }

        #region Entities

        DbSet<User> Users{ get; set; }

        #endregion
    }
}

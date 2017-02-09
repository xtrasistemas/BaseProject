using Base.Models;
using Base.Models.Entities;
using Base.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data {
    public class RepositoryBase<T> : IRepository<T>
        where T : EntityBase {

        private EFDbContext context = new EFDbContext();

        public RepositoryBase() {
        }

        public virtual List<User> GetAll() {
            var users = new List<User>();
            var user1 = new User();
            user1.Id = 1;
            user1.UserName = "Seba";
            user1.Password = "seba1234";
            user1.FirstName = "Sebastian";
            user1.LastName = "Bianchini";
            user1.Email = "sebastian.bianchini@hotmail.com";

            users.Add(user1);

            var user2 = new User();
            user2.Id = 2;
            user2.UserName = "Emi";
            user2.Password = "emi1234";
            user2.FirstName = "Emiliano";
            user2.LastName = "Bianchini";
            user2.Email = "emiliano.bianchini@hotmail.com";
            users.Add(user2);

            return users;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = this.context.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Save(T entity)
        {
            try
            {

                if (this.EntityIsNew(entity))
                {
                    this.Insert(entity);
                }
                else
                {
                    this.Update(entity);
                }
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                //TODO:
            }
        }

        protected virtual void Insert(T entity)
        {
            this.context.Set<T>().Add(entity);
        }

        protected virtual void Update(T entity)
        {
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Delete(Int64 key)
        {
            try
            {
                var entity = this.context.Set<T>().Find(key);
                this.context.Set<T>().Remove(entity);

                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                //TODO:
            }
        }
        private Boolean EntityIsNew(T entity)
        {
            string keyName = GetPropertyNameKey();
            return entity.GetType().GetProperty(keyName).GetValue(entity, null).ToString() == "0";
        }

        private String GetPropertyNameKey()
        {
            System.Data.Entity.Core.Objects.ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
            System.Data.Entity.Core.Objects.ObjectSet<T> set = objectContext.CreateObjectSet<T>();
            string keyNames = set.EntitySet.ElementType.KeyMembers.Select(k => k.Name).FirstOrDefault();
            return keyNames;
        }
    }
}
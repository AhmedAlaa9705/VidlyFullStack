using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Classes;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private MyContext db;
        public Repository()
        {
            db = new MyContext();
        }
        public Repository(MyContext context)
        {
            db = context;
        }
        public void Delete(int id)
        {
            var t= db.Set<T>().Find(id);
            db.Set<T>().Remove(t);
        }

        public T Get(int id)
        {
            return db.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
           return  db.Set<T>().ToList();
            
        }

        public IEnumerable<T> GetAllWithInvlude(string str)
        {
            return db.Set<T>().Include(str).ToList();
        }

        public T GetExpre(Expression<Func<T, bool>> par)
        {
            return db.Set<T>().Where(par).SingleOrDefault();
        }

        public T GetInclude(Expression<Func<T,bool>>expression,string str)
        {
            return db.Set<T>().Include(str).Where(expression).SingleOrDefault();
        }

        public void Insert(T t)
        {
            db.Set<T>().Add(t);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T t)
        {
             db.Set<T>().Attach(t);
            db.Entry(t).State = EntityState.Modified;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRepository<T>where T:class
    {
       IEnumerable< T> GetAll();
        IEnumerable<T> GetAllWithInvlude(string str);
        T Get(int id);
        T GetInclude(Expression<Func<T,bool>>par,string str);
        T GetExpre(Expression<Func<T,bool>>par);
        void Insert(T t);
        void Update(T t);
        void Delete(int id);
        void Save();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogPro.BLL.RepositoryPattern.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        bool Any(Expression<Func<T, bool>> exp);
        T Default(Expression<Func<T, bool>> exp);
        List<T> GetByFilter(Expression<Func<T, bool>> exp);
    }
}

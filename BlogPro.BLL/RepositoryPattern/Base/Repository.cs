using BlogPro.BLL.RepositoryPattern.Interfaces;
using BlogPro.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogPro.BLL.RepositoryPattern.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        MyDbContext _db;
        protected DbSet<T> table;
        public Repository(MyDbContext db)
        {
            _db = db;
            table = db.Set<T>();
        }

		public Repository()
		{
		}

		private void Save()
        {
            _db.SaveChanges();
        }
        public void Add(T item)
        {
            table.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            T item = GetById(id);
            table.Remove(item);
            Save();
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public void Update(T item)
        {
            table.Update(item);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return table.Any(exp);
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> exp)
        {
            return table.Where(exp).ToList();
        }

		public T Default(Expression<Func<T, bool>> exp)
		{
			return table.FirstOrDefault(exp);
		}
	}
}

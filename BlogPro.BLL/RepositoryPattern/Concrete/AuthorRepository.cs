using BlogPro.BLL.RepositoryPattern.Base;
using BlogPro.BLL.RepositoryPattern.Interfaces;
using BlogPro.DAL.Context;
using BlogPro.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPro.BLL.RepositoryPattern.Concrete
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
		MyDbContext _db;
        public AuthorRepository(MyDbContext db):base(db)
        {
			_db = db;
        }

		public void ChangeToAdmin(int id)
		{
			Author item = GetById(id);
			item.Role = "Admin";
			table.Update(item);
			_db.SaveChanges();
		}

		public void ChangeToUser(int id)
		{
			Author item = GetById(id);
			item.Role = "User";
			table.Update(item);
			_db.SaveChanges();
		}

		public IEnumerable<Author> GetAuthors()
        {
            return table.ToList();
        }

		public Author GetByAuthorMail(string mail)
		{
            return table.Where(x => x.AuthorMail == mail).FirstOrDefault();
		}
	}
}

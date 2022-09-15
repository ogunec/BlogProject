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
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		readonly MyDbContext _db;
		public CategoryRepository(MyDbContext db):base(db)
		{
			_db = db;
		}

		public void ConfirmCategory(int id)
		{
			Category item = GetById(id);
			item.Status = true;
			table.Update(item);
			_db.SaveChanges();
		}

		public List<Category> GetCategories()
		{
			return table.ToList();
		}

		public void SpecialDelete(int id)
		{
			Category item = GetById(id);
			item.Status = false;
			table.Update(item);
			_db.SaveChanges();
		}
	}
}

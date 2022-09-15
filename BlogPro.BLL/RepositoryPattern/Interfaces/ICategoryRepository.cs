using BlogPro.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPro.BLL.RepositoryPattern.Interfaces
{
	public interface ICategoryRepository : IRepository<Category>
	{
		List<Category> GetCategories();
		void SpecialDelete(int id);
		void ConfirmCategory(int id);
	}
}

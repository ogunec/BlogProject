using BlogPro.BLL.RepositoryPattern.Base;
using BlogPro.BLL.RepositoryPattern.Interfaces;
using BlogPro.DAL.Context;
using BlogPro.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPro.BLL.RepositoryPattern.Concrete
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        readonly MyDbContext _db;
        public BlogRepository(MyDbContext db) : base(db)
        {
            _db = db;
        }

		public void AddBlog(Blog blog)
		{
            table.Add(blog);
            _db.SaveChanges();

		}

		public Blog GetBlog1()
		{
            return table.Include(x => x.Category).Include(x => x.Author).OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 1).FirstOrDefault();
        }
        public Blog GetBlog2()
        {
            return table.Include(x => x.Category).Include(x => x.Author).OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 2).FirstOrDefault();
        }
        public Blog GetBlog3()
        {
            return table.Include(x => x.Category).Include(x => x.Author).OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 3).FirstOrDefault();
        }
        public Blog GetBlog4()
        {
            return table.Include(x => x.Category).Include(x => x.Author).OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 4).FirstOrDefault();
        }
        public Blog GetBlog5()
        {
            return table.Include(x => x.Category).Include(x => x.Author).OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 5).FirstOrDefault();
        }

        public IEnumerable<Blog> GetBlogList()
        {
            return table.Include(x => x.Category).Include(x => x.Author).ToList();
        }

        public List<Blog> GetSelectedBlog()
        {
            return table.Include(x => x.Category).Include(x => x.Author).ToList();
        }
        
    }
}


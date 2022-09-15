using BlogPro.BLL.RepositoryPattern.Base;
using BlogPro.BLL.RepositoryPattern.Interfaces;
using BlogPro.DAL.Context;
using BlogPro.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace BlogPro.BLL.RepositoryPattern.Concrete
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        MyDbContext _db;
        public CommentRepository(MyDbContext db):base(db)
        {
            _db = db;
        }
        
        public List<Comment> AllComments()
        {
            return table.Include(x => x.Blog).ToList();
        }

		public IEnumerable<Comment> GetBlogidByComment(int id)
		{
            return table.Where(x => x.CommentID == id).ToList();
		}

		public List<Comment> GetCommentsById(int id)
        {
            return table.Where(x => x.BlogID == id).Where(x => x.Status != false).ToList();
        }
        public void SpecialDelete(int id)
        {
            Comment item = GetById(id);
            item.Status = false;
            table.Update(item);
            _db.SaveChanges();
        }
        public List<Comment> GetActiveComments()
        {
            return table.Include(x => x.Blog).Where(x => x.Status != false).ToList();
        }

		public List<Comment> GetPassiveComments()
		{
            return table.Include(x => x.Blog).Where(x => x.Status == false).ToList();
		}

		public void ConfirmMessage(int id)
		{
            Comment item = GetById(id);
            item.Status = true;
            table.Update(item);
            _db.SaveChanges();
		}
	}
}

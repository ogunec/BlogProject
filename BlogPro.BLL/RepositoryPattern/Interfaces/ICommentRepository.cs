using BlogPro.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPro.BLL.RepositoryPattern.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        List<Comment> AllComments();
        List<Comment> GetCommentsById(int id);
        IEnumerable<Comment> GetBlogidByComment(int id);
        void SpecialDelete(int id);
		List<Comment> GetActiveComments();
        List<Comment> GetPassiveComments();
        void ConfirmMessage(int id);
    }
}

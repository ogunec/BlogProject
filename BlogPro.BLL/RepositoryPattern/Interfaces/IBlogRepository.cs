using BlogPro.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPro.BLL.RepositoryPattern.Interfaces
{
    public interface IBlogRepository : IRepository<Blog>
    {
        IEnumerable<Blog> GetBlogList();
        List<Blog> GetSelectedBlog();
        void AddBlog(Blog blog);
        Blog GetBlog1();
        Blog GetBlog2();
        Blog GetBlog3();
        Blog GetBlog4();
        Blog GetBlog5();
    }

}

using BlogPro.MODEL.Entities;
using System.Collections.Generic;

namespace BlogPro.BLL.RepositoryPattern.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        IEnumerable<Author> GetAuthors();
        Author GetByAuthorMail(string mail);
        void ChangeToUser(int id);
        void ChangeToAdmin(int id);
    }
}

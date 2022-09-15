using BlogPro.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPro.BLL.RepositoryPattern.Interfaces
{
    public interface IContactRepository : IRepository<Contact>
    {
        void AddContact(Contact contact);
        List<Contact> GetMessages();
    }
}

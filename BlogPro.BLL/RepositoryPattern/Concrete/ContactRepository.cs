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
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(MyDbContext db):base(db)
        {

        }
        public void AddContact(Contact contact)
        {
            table.Add(contact);
        }

		public List<Contact> GetMessages()
		{
			return table.ToList();
		}
	}
}

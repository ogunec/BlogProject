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
    public class SubscribeMailRepository : Repository<SubscribeMail>, ISubscribeMailRepository
    {
        MyDbContext _db;
        public SubscribeMailRepository(MyDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        void ISubscribeMailRepository.AddMails(SubscribeMail p)
        {
            table.Add(p);
        }
    }
}

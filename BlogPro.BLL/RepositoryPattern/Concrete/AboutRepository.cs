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
    public class AboutRepository : Repository<About>, IAboutRepository
    {
        public AboutRepository(MyDbContext db) : base(db)
        {
        }

        public IEnumerable<About> GetAboutList()
        {
            return table.ToList();
        }
    }
}

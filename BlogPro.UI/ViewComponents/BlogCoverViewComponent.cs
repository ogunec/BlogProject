using BlogPro.BLL.RepositoryPattern.Interfaces;
using BlogPro.MODEL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPro.MODEL.ViewComponents
{
    public class BlogCoverViewComponent : ViewComponent
    {
        IBlogRepository _repoBlog;
        public BlogCoverViewComponent(IBlogRepository repoBlog)
        {
            _repoBlog = repoBlog;
        }
        public IViewComponentResult Invoke()
        {
            
            return View();
        }
    }
}

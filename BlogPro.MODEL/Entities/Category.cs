using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPro.MODEL.Entities
{
    public class Category
    {
		public Category()
		{
            Status = true;
		}
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
		public bool Status { get; set; }

		//Relational Property
		public virtual List<Blog> Blogs { get; set; }
    }
}

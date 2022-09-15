using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPro.MODEL.Entities
{
    public class Author
    {
		public Author()
		{
			Status = true;
		}
        [Key]
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImage { get; set; }
        public string AuthorDetail { get; set; }
		public string AuthorTitle { get; set; }
		public string AboutShort { get; set; }
		public string AuthorMail { get; set; }
		public string Password { get; set; }
		public string PhoneNumber { get; set; }
		public bool Status { get; set; }
		public string Role { get; set; }


		//Relational Property
		public virtual List<Blog> Blogs { get; set; }
    }
}

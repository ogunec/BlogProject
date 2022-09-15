using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPro.MODEL.Entities
{
    public class Comment
    {
		public Comment()
		{
            Status = true;
		}
        [Key]
        public int CommentID { get; set; }
        public string CommentText { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public DateTime CommentDate { get; set; }
		public bool Status { get; set; }

		//Relational Property
		public int BlogID { get; set; }
        public virtual Blog Blog { get; set; }
    }
}

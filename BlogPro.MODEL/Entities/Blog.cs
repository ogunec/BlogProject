using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogPro.MODEL.Entities
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }      
        public string BlogTitle { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogDate { get; set; }
        public string BlogContent { get; set; }

        //Relational Property
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}

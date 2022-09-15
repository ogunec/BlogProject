using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPro.MODEL.Entities
{
    public class Contact
    {
		public Contact()
		{
            MessageDate = DateTime.Now;
		}
        [Key]
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
		public DateTime MessageDate { get; set; }
	}
}

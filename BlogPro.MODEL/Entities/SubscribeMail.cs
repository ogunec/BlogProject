using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPro.MODEL.Entities
{
    public class SubscribeMail
    {
        [Key]
        public int MailID { get; set; }
        [MaxLength(50)]
        public string Mail { get; set; }
    }
}

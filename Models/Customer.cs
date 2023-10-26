using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestinGList.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Tasks = new HashSet<Task>();
        }

        [Key]      
        public int PersonId { get; set; }

        public string First { get; set; }
        public string Last { get; set; }

       public virtual ICollection<Task> Tasks { get; set; }

      
    }
}

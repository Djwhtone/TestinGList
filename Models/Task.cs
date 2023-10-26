using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestinGList.Models
{
    public partial class Task
    {
        [Key]
        public int TaskId { get; set; }
        public string Description { get; set; }

       [ForeignKey(nameof(Customer))]
        public int PersonId { get; set; }
        public virtual Customer Customer { get; set; }
        
    }
}

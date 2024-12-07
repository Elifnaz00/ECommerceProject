using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Entity.Entities
{
    public class Contact: BaseEntity
    {
       
        public string? Location { get; set; }
        public string? OpenHours { get; set; }
        public string? TelephoneNumber { get; set; }
        public string? Email { get; set; }
        
    }
}

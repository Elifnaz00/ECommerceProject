using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Entity.Entities
{
    public class WhyUs : BaseEntity
    {
        
        public string? AboutTitle { get; set; }
        public string? AboutDescription{ get; set; } 

        [StringLength(500)]
        public string? AboutContent1 { get; set; } 
        
      
        

     
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Entity.Entities
{
    public class Order : BaseEntity
    {
        public int Piece {  get; set; }
        public string? Addres { get; set; }

        public virtual ICollection<Product>? Products { get; set; }  
    }
}

using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DTO.DTOs.ProductDTOs
{
    public class GetProductDetailDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? ProductCode { get; set; }



        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; }


    }
}

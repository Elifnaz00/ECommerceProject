﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.CQRS.Products.Queries.Response
{
    public class GetProductByCategoryQueryResponse
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public long? Price { get; set; }
        public string? ImageUrl { get; set; }
    }
}
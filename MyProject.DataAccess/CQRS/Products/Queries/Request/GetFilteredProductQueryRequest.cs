using MediatR;
using MyProject.DataAccess.CQRS.Products.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.CQRS.Products.Queries.Request
{
    public class GetFilteredProductQueryRequest: IRequest<IList<GetFilteredProductQueryResponse>>
    {
        public string? category {  get; set; }
        public string? size {  get; set; }
        public string? color {  get; set; }
        public string? price {  get; set; }
    }
}

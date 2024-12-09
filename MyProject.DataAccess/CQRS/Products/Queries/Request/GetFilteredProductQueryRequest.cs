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
        public string? Category {  get; set; }
        public string? Size {  get; set; }
        public string? Color {  get; set; }
        public long? Price {  get; set; }
    }
}

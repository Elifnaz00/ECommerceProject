using MediatR;
using MyProject.DataAccess.CQRS.Abouts.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.CQRS.Abouts.Queries.Request
{
    public class GetAboutQueryRequest: IRequest<IList<GetAboutQueryResponse>>
    {
    }
}

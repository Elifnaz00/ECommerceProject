using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.CQRS.Products.Queries.Request;
using MyProject.DataAccess.CQRS.Products.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.CQRS.Products.Handlers.QueryHandlers
{
    public class GetFilteredProductQueryHandler : IRequestHandler<GetFilteredProductQueryRequest, IList<GetFilteredProductQueryResponse>>
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetFilteredProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetFilteredProductQueryResponse>> Handle(GetFilteredProductQueryRequest request, CancellationToken cancellationToken)
        {
            var value= _productRepository.GetFilteredProduct(request);
            var value2 = await value.ToListAsync();
            var value3 = _mapper.Map<IList<GetFilteredProductQueryResponse>>(value2);
            return value3;
        }
    }
}

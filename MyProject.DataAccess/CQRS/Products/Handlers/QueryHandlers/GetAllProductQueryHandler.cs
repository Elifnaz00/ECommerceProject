﻿using AutoMapper;
using MediatR;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.CQRS.Products.Queries.Request;
using MyProject.DataAccess.CQRS.Products.Queries.Response;
using MyProject.DTO.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.CQRS.Products.Handlers.QueryHandlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, IList<GetAllProductQueryResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var value = await _productRepository.GetAllAsync();
            var resultDto = _mapper.Map<IList<GetAllProductQueryResponse>>(value);
            return resultDto;
        }
    }
}

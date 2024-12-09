﻿using AutoMapper;
using MediatR;
using MyProject.DataAccess.CQRS.Categories.Queries.Request;
using MyProject.DataAccess.CQRS.Categories.Queries.Response;
using MyProject.DataAccess.Repositories.Abstract;
using MyProject.DTO.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.CQRS.Categories.Handlers.QueryHandlers
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, IList<GetAllCategoriesQueryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var value = await _categoryRepository.GetAllAsync();
            var categoryDto = _mapper.Map<IList<GetAllCategoriesQueryResponse>>(value);
            return categoryDto;
        }
    }
}

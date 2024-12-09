using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.CQRS.Products.Queries.Response;
using MyProject.DTO.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.CQRS.Products.Queries.Request
{
    public class GetProductDetailQueryRequest : IRequest<GetProductDetailQueryResponse>
    {
        public Guid Id { get; set; }
    }


}

﻿using AutoMapper;
using MediatR;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.Concrate;
using MyProject.DataAccess.CQRS.Products.Queries.Response;
using MyProject.DTO.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.CQRS.Products.Queries.Request
{
    public class GetAllProductQueryRequest : IRequest<IList<GetAllProductQueryResponse>>
    {



    }


}
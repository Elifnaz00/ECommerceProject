using AutoMapper;
using MyProject.DataAccess.CQRS.Abouts.Queries.Response;
using MyProject.DataAccess.CQRS.Categories.Queries.Response;
using MyProject.DataAccess.CQRS.Contacts.Commands.Request;
using MyProject.DataAccess.CQRS.Orders.Commands.Request;
using MyProject.DataAccess.CQRS.Products.Queries.Response;
using MyProject.DTO.DTOs.EntranceDTOs;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Entrance, CreateEntranceDTO>().ReverseMap();
            CreateMap<Entrance, ListEntranceDTO>().ReverseMap();
            CreateMap<Entrance, EntranceDetailsDTO>().ReverseMap();
            CreateMap<Entrance, UpdateEntranceDTO>().ReverseMap();

            CreateMap<Order, CreateOrderCommandRequest>().ReverseMap();
            CreateMap<Category, GetAllCategoriesQueryResponse>().ReverseMap();
            CreateMap<Product, GetAllProductQueryResponse>().ReverseMap();
            CreateMap<Product, GetProductByCategoryQueryResponse>().ReverseMap();
            CreateMap<Product, GetProductDetailQueryResponse>().ReverseMap();
            CreateMap<Product, GetNewProductsQueryResponse>().ReverseMap();
            CreateMap<Product, GetFilteredProductQueryResponse>().ReverseMap();
            CreateMap<WhyUs, GetAboutQueryResponse>().ReverseMap();
            CreateMap<Contact, ContactUsCommandRequest>().ReverseMap();




        }
    }
}

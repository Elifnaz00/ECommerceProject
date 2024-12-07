using AutoMapper;
using MyProject.DataAccess.CQRS.Categories.Queries.Response;
using MyProject.DataAccess.CQRS.Orders.Commands.Request;
using MyProject.DataAccess.CQRS.Products.Queries.Response;
using MyProject.DTO.DTOs.CategoryDTOs;
using MyProject.DTO.DTOs.EntranceDTOs;
using MyProject.DTO.DTOs.OrderDTOs;
using MyProject.DTO.DTOs.ProductDTOs;
using MyProject.Entity.Entities;

namespace MyProject.Api.Mapping
{
    public class MapProfile: Profile
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
           


        }
    }
}

using AutoMapper;
using MyProject.Entity.Entities;
using MyProject.WebUI.Models.CategoryModel;
using MyProject.WebUI.Models.EntranceModel;
using MyProject.WebUI.Models.OrderModel;
using MyProject.WebUI.Models.ProductModel;

namespace MyProject.WebUI.Mapping
{
    public class Map: Profile
    {
        public Map() {
            CreateMap<Entrance, CreateEntranceViewModel>().ReverseMap();
            CreateMap<Category, CategoryListViewModel>().ReverseMap();
            CreateMap<Product, ProductListVewModel>().ReverseMap();
            CreateMap<Product, ProductByCategoryViewModel>().ReverseMap();
            CreateMap<Product, ProductDetailViewModel>().ReverseMap();
            CreateMap<Product, ProductNewViewModel>().ReverseMap();
           

            
           
            CreateMap<Order, AddToShoppingCardViewModel>().ReverseMap();
        }    

    }
}

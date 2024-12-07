using AutoMapper;
using MediatR;
using MyProject.DataAccess.Abstract;
using MyProject.Entity.Entities;



namespace MyProject.DataAccess.CQRS.Orders.Commands.Request
{
    public class CreateOrderCommandRequest : IRequest<bool>
    {
        public int Piece { get; set; }

        public List<CreateOrderCommandRequest>? createOrderQueryRequests { get; set; }


    }
}

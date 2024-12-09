using AutoMapper;
using MediatR;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.CQRS.Orders.Commands.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.CQRS.Orders.Handlers
{
    public class CreateOrderCommandRequestHandler : IRequestHandler<CreateOrderCommandRequest, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandRequestHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var mapOrderRequest = _mapper.Map<Entity.Entities.Order>(request);
            return await _orderRepository.AddAsync(mapOrderRequest);

        }
    }
}

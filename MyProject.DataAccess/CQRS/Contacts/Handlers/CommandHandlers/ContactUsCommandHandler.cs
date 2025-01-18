using AutoMapper;
using MediatR;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.CQRS.Contacts.Commands.Request;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.CQRS.Contacts.Handlers.CommandHandlers
{
    public class ContactUsCommandHandler : IRequestHandler<ContactUsCommandRequest, bool>
    {

        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactUsCommandHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(ContactUsCommandRequest request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Contact>(request);
            var response = await _contactRepository.AddAsync(value);
            return response;
        }
    }
}

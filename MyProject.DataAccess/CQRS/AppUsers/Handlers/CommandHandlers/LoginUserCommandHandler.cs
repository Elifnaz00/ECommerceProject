using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MyProject.DataAccess.CQRS.AppUsers.Commands.Request;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.CQRS.AppUsers.Handlers.CommandHandlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, string>
    {
         
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public LoginUserCommandHandler(SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<string> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
        
            var result = await _signInManager.PasswordSignInAsync(request.EMail, request.Password, true, lockoutOnFailure: true);
            
            return result.Succeeded ? "Giriş Başarılı" : "Giriş Başarısız";
        }
    }
}

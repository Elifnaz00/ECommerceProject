using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.CQRS.AppUsers.Commands.Request
{
    public class LoginUserCommandRequest : IRequest<string>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool RememberMe  { get; set; }
    }
}

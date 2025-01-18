using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.CQRS.AppUsers.Commands.Response
{
    public class CreateUserCommandResponse
    {
        public bool Succeeded{ get; set; }   

        public string Message { get; set; }

    }
}

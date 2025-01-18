using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.CQRS.Contacts.Commands.Request
{
    public class ContactUsCommandRequest : IRequest<bool>
    {
       
        public string ContentMessage { get; set; }
        public string SenderName { get; set; }


        public string SenderMail { get; set; }


        public string? Subject { get; set; }
    }
}

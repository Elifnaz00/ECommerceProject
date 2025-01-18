using MediatR;
using MyProject.DataAccess.CQRS.AppUsers.Commands.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.CQRS.AppUsers.Commands.Request
{
    public class CreateUserCommandRequest: IRequest<CreateUserCommandResponse>
    {
        [Display(Name = "Ad-Soyad")]
        public string? NameSurname { get; set; }


        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        public string UserName { get; set; }



        [Required(ErrorMessage = "E-posta gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }


        [Display(Name = "Şifre")]
        public string Password { get; set; }

    }
}

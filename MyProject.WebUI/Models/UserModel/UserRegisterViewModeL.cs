using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyProject.WebUI.Models.UserModel
{
    public class UserRegisterViewModeL
    {
        [DisplayName("NameSurname")]
        public string? NameSurname { get; set; }


        [DisplayName("UserName")]
        [Required(ErrorMessage ="Lütfen kullanıcı adını boş geçmeyiniz..")]
        public string? UserName { get; set; }



        [DisplayName("Email")]
        [Required(ErrorMessage ="Lütfen emaili boş geçmeyiniz...")]
        [EmailAddress(ErrorMessage ="Lütfen email formatında bir değer giriniz...")]
        public string? Email { get; set; }


        [DisplayName("Password")]
        [Required(ErrorMessage ="Lütfen şifreyi boş geçmeyiniz...")]
        [DataType(DataType.Password, ErrorMessage = "Lütfen şifreyi tüm kuralları göz önüne alarak giriniz...")]
        public string? Password { get; set; }

    }
}

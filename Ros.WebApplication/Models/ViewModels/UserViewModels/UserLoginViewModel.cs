using System.ComponentModel.DataAnnotations;

namespace Ros.WebApplication.Models.ViewModels.UserViewModels
{
    public class UserLoginViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
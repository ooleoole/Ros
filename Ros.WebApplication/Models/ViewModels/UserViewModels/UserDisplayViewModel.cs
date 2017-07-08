using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ros.WebApplication.Models.ViewModels.UserViewModels
{
    public class UserDisplayViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Email")]
        public string Login { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
    }
}
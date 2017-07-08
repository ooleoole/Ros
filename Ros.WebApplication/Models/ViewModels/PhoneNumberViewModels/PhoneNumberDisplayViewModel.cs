using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ros.WebApplication.Models.ViewModels.PhoneNumberViewModels
{
    public class PhoneNumberDisplayViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Value { get; set; }

        //[DisplayName("Phone Type")]
        //public string Type { get; set; }

        //public int ClubId { get; set; } //FK
    }
}
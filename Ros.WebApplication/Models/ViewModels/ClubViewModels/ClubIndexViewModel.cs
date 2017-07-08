using Ros.WebApplication.Models.ViewModels.AddressViewModels;
using Ros.WebApplication.Models.ViewModels.PhoneNumberViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ros.WebApplication.Models.ViewModels.ClubViewModels
{
    public class ClubIndexViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Club Name")]
        public string Name { get; set; }

        [DisplayName("Club Logo")]
        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }

        [DisplayName("Club HomePage")]
        //[DataType(DataType.Url)]
        public string HomePage { get; set; }

        [DisplayName("Club Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        //[DisplayName("Phone Number")]
        //[DataType(DataType.PhoneNumber)]
        //public string Value { get; set; }

        //TODO fixa emails med

        [Required]
        [DisplayName("Country")]
        public string Country { get; set; }

        [Required]
        [DisplayName("City")]
        public string City { get; set; }

        [Required]
        [DisplayName("Street")]
        public string Street { get; set; }

        [Required]
        [DisplayName("Postal Code (Zip Code)")]
        [DataType(DataType.PostalCode)]
        public string ZipdCode { get; set; }

        //public string Type { get; set; }

        [DisplayName("Box Number")]
        public int? BoxNo { get; set; }

        public AddressDisplayViewModel Address { get; set; }

        //public PhoneNumberDisplayViewModel PhoneNumber { get; set; }
    }
}
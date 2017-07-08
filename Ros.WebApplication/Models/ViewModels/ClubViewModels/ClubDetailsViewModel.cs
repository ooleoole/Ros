using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ros.WebApplication.Models.ViewModels.ClubViewModels
{
    public class ClubDetailsViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Club Name")]
        public string Name { get; set; }

        [DisplayName("Club Logo")]
        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }

        [DisplayName("Club HomePage")]
        [DataType(DataType.Url)]
        public string HomePage { get; set; }

        [DisplayName("Club Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        //public DateTime RegistrationDate { get; set; }
        //public int AddressId { get; set; }
        //public bool Active { get; set; }
        //public string sa_Info { get; set; }

        //public IAddress Address { get; set; }

        [DisplayName("Country")]
        public string Country { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("Street")]
        public string Street { get; set; }

        [DisplayName("Postal Code (Zip Code)")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [DisplayName("Box Number")]
        public int BoxNo { get; set; }
    }
}
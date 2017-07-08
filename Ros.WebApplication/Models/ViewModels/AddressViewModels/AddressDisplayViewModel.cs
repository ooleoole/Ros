using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ros.WebApplication.Models.ViewModels.AddressViewModels
{
    public class AddressDisplayViewModel
    {
        [Key]
        public int Id { get; set; }

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
        public int? BoxNo { get; set; }
    }
}
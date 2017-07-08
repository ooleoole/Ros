using Ros.WebApplication.Models.ViewModels.AddressViewModels;
using Ros.WebApplication.Models.ViewModels.ClubViewModels;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ros.WebApplication.Models.ViewModels.RegattaViewModels
{
    public class RegattaEditViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Regatta Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [DisplayName("Fee")]
        public int Fee { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        //public int ClubId { get; set; }
        //public int AddressId { get; set; }
        //public bool Active { get; set; }
        //public string sa_Info { get; set; }
        //public IAddress Address { get; set; }
        //public IClub Address { get; set; }

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
        public string ZipCode { get; set; }

        public AddressDisplayViewModel Address { get; set; }
        public ClubDisplayViewModel Club { get; set; }
    }
}
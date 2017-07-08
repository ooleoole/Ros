using Ros.WebApplication.Models.ViewModels.AddressViewModels;
using Ros.WebApplication.Models.ViewModels.ClubViewModels;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ros.WebApplication.Models.ViewModels.RegattaViewModels
{
    public class RegattaDetailsViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Regatta Name")]
        public string Name { get; set; }

        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

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

        [DisplayName("Country")]
        public string Country { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("Street")]
        public string Street { get; set; }

        [DisplayName("Postal Code (Zip Code)")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        public AddressDisplayViewModel Address { get; set; }
        public ClubDisplayViewModel Club { get; set; }
    }
}
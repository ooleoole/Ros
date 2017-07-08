using System;
using Ros.WebApplication.Models.ViewModels.BoatViewModels;
using Ros.WebApplication.Models.ViewModels.ClubViewModels;
using Ros.WebApplication.Models.ViewModels.RegattaViewModels;
using Ros.WebApplication.Models.ViewModels.UserViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ros.WebApplication.Models.ViewModels.EntryViewModels
{
    public class EntryIndexViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Entry Number")]
        public int EntryNo { get; set; }
        
        [DisplayName("Entry Name")]
        public string EntryName { get; set; }

        [DisplayName("Registration Date")]
        public string RegistrationDate { get; set; }

        [DisplayName("Paid Amount")]
        public int PaidAmount { get; set; }

        //public int BoatId { get; set; }
        //public int ResponsibleUserId { get; set; }
        //public int ClubRepresentationId { get; set; }
        //public bool Active { get; set; } = true;
        //public string sa_Info { get; set; }

        [DisplayName("Sail Number")]
        public int SailNo { get; set; }

        [DisplayName("Boat Name")]
        public string BoatName { get; set; }

        [DisplayName("Club Name")]
        public string ClubName { get; set; }

        [DisplayName("Regatta Name")]
        public string RegattaName { get; set; }

        [DisplayName("Regatta Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("Regatta End Date")]
        public DateTime EndDate { get; set; }

        [DisplayName("Regatta Fee")]
        public int Fee { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        public string Login { get; set; }

        public BoatDisplayViewModel Boat { get; set; }
        public ClubDisplayViewModel Club { get; set; }
        public RegattaDisplayViewModel Regatta { get; set; }
        public UserDisplayViewModel User { get; set; }
    }
}
using Ros.WebApplication.Models.ViewModels.BoatViewModels;
using Ros.WebApplication.Models.ViewModels.ClubViewModels;
using Ros.WebApplication.Models.ViewModels.RegattaViewModels;
using Ros.WebApplication.Models.ViewModels.UserViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ros.WebApplication.Models.ViewModels.EntryViewModels
{
    public class EntryCreateViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Entry Number")]
        public int EntryNo { get; set; }

        [Required]
        [DisplayName("Entry Name")]
        public string EntryName { get; set; }

        //[DisplayName("Registration Date")]
        //public string RegistrationDate { get; set; }

        //[DisplayName("Paid Amount")]
        //public int PaidAmount { get; set; }

        public int BoatId { get; set; }
        //public int ResponsibleUserId { get; set; }
        public int? ClubRepresentationId { get; set; }
        public int RegattaId { get; set; }

        //public bool Active { get; set; } = true;
        //public string sa_Info { get; set; }

        //public BoatDisplayViewModel Boat { get; set; }
        //public ClubDisplayViewModel Club { get; set; }
        //public UserDisplayViewModel User { get; set; }

        //public RegattaDisplayViewModel Regatta { get; set; }
        // Regatta???
    }
}
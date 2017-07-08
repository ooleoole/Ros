using Ros.WebApplication.Models.ViewModels.RegattaViewModels;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ros.WebApplication.Models.ViewModels.SocialEventViewModels
{
    public class SocialEventIndexViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Location")]
        public string Location { get; set; }

        [DisplayName("Fee")]
        public int Fee { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("StartDate")]
        public DateTime StartDate { get; set; }

        [DisplayName("EndDate")]
        public DateTime EndDate { get; set; }

        [DisplayName("MaxParticipants")]
        public int MaxParticipants { get; set; }

        //public int RegattaId { get; set; }
        //public bool Active { get; set; }
        //public string sa_Info { get; set; }
        //public IRegatta Regatta { get; set; }

        [DisplayName("Regatta Name")]
        public string RegattaName { get; set; }

        [DisplayName("Regatta Start Date")]
        public DateTime RegattaStartDate { get; set; }

        [DisplayName("Regatta End Date")]
        public DateTime RegattaEndDate { get; set; }

        [DisplayName("Regatta Fee")]
        public int RegattaFee { get; set; }

        [DisplayName("Regatta Description")]
        public string RegattaDescription { get; set; }

        public RegattaDisplayViewModel Regatta { get; set; }
    }
}
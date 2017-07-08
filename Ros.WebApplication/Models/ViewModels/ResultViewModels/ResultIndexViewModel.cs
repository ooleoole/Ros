using Ros.WebApplication.Models.ViewModels.EntryViewModels;
using Ros.WebApplication.Models.ViewModels.RaceEventModels;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ros.WebApplication.Models.ViewModels.ResultViewModels
{
    public class ResultIndexViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Rank")]
        public int? Rank { get; set; }

        [DisplayName("Points")]
        public int? Points { get; set; }

        [DisplayName("Time")]
        public int? Time { get; set; }

        [DisplayName("Distance")]
        public int? Distance { get; set; }

        [DisplayName("CalculatedTime")]
        public int? CalculatedTime { get; set; }

        [DisplayName("CalculatedDistance")]
        public int? CalculatedDistance { get; set; }

        [DisplayName("Remark")]
        public string Remark { get; set; }

        //public int EntryId { get; set; }
        //public int RaceEventId { get; set; }
        //public bool Active { get; set; } = true;
        //public string sa_Info { get; set; }

        [DisplayName("Entry Number")]
        public int EntryNo { get; set; }

        [DisplayName("Entry Name")]
        public string EntryName { get; set; }

        [DisplayName("Race Name")]
        public string Name { get; set; }

        [DisplayName("Race Location")]
        public string Location { get; set; }

        [DisplayName("Race StartDate")]
        public DateTime StartDate { get; set; }

        [DisplayName("Race Class")]
        public string Class { get; set; }

        [DisplayName("Race Type")]
        public string Type { get; set; }

        public EntryDisplayViewModel Entry { get; set; }
        public RaceEventDisplayViewModel RaceEvent { get; set; }
    }
}
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ros.WebApplication.Models.ViewModels.RaceEventModels
{
    public class RaceEventDisplayViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Location")]
        public string Location { get; set; }

        [DisplayName("StartDate")]
        public DateTime StartDate { get; set; }

        [DisplayName("Race Class")]
        public string Class { get; set; }

        [DisplayName("Race Type")]
        public string Type { get; set; }
    }
}
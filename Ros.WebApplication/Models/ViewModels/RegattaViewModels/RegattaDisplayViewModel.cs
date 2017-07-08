using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ros.WebApplication.Models.ViewModels.RegattaViewModels
{
    public class RegattaDisplayViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Regatta Name")]
        public string Name { get; set; }

        [DisplayName("Regatta Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("Regatta End Date")]
        public DateTime EndDate { get; set; }

        [DisplayName("Regatta Fee")]
        public int Fee { get; set; }

        [DisplayName("Regatta Description")]
        public string Description { get; set; }
    }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ros.WebApplication.Models.ViewModels.BoatViewModels
{
    public class BoatRegistrationViewModel
    {
        [Required]
        [DisplayName("Sail Number")]
        public int SailNo { get; set; }

        [Required]
        [DisplayName("Boat Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Boat Type")]
        public string Type { get; set; }

        [Required]
        [DisplayName("Boat Handicap")]
        public string Handicap { get; set; }
    }
}
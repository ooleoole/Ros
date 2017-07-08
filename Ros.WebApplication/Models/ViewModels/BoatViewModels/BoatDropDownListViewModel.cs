using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ros.WebApplication.Models.ViewModels.BoatViewModels
{
    public class BoatDropDownListViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Sail Number")]
        public int SailNo { get; set; }

        [DisplayName("Boat Name")]
        public string Name { get; set; }

        [DisplayName("Boats")]
        public string FullBoatName
        {
            get
            {
                return $"{Name} {SailNo}";
            }
        }

        //[DisplayName("Boat Type")]
        //public string Type { get; set; }

        //[DisplayName("Boat Handicap")]
        //public string Handicap { get; set; }
    }
}
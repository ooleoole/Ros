using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ros.WebApplication.Models.ViewModels.ClubViewModels
{
    public class ClubDisplayViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Club Name")]
        public string Name { get; set; }

        [DisplayName("Club Logo")]
        public string Logo { get; set; }

        [DisplayName("Club HomePage")]
        public string HomePage { get; set; }

        [DisplayName("Club Description")]
        public string Description { get; set; }
    }
}
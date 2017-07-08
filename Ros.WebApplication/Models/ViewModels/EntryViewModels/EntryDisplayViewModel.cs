using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ros.WebApplication.Models.ViewModels.EntryViewModels
{
    public class EntryDisplayViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Entry Number")]
        public int EntryNo { get; set; }

        [DisplayName("Entry Name")]
        public string EntryName { get; set; }
    }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ros.WebApplication.Models.ViewModels.EmailViewModels
{
    public class EmailDisplayViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Value { get; set; }

        //public string Type { get; set; }
        //public bool Active { get; set; }
        //public string sa_Info { get; set; }
    }
}
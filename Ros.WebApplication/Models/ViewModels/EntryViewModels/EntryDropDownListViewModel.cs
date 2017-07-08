using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ros.WebApplication.Models.ViewModels.EntryViewModels
{
    public class EntryDropDownListViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Entry Number")]
        public int EntryNo { get; set; }

        [DisplayName("Entry Name")]
        public string EntryName { get; set; }

        [DisplayName("Entry")]
        public string FullEntryName
        {
            get
            {
                return $"{EntryName} {EntryNo}";
            }
        }
    }
}
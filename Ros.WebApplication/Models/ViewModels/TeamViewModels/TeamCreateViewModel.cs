﻿using Ros.WebApplication.Models.ViewModels.EntryViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ros.WebApplication.Models.ViewModels.TeamViewModels
{
    public class TeamCreateViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Team Number")]
        public int TeamNo { get; set; }

        [DisplayName("Team Name")]
        public string TeamName { get; set; }

        public int EntryId { get; set; }
        //public bool Active { get; set; } = true;
        //public string sa_Info { get; set; }

        [DisplayName("Entry Number")]
        public int EntryNo { get; set; }

        [DisplayName("Entry Name")]
        public string EntryName { get; set; }

        public EntryDisplayViewModel Entry { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Domain.Entities;
using System.ComponentModel;

namespace Ros.WebApplication.Models.ViewModels.TeamViewModels
{
    public class AddUserToTeamViewModel
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        [DisplayName("Users")]
        public string FullUserName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public IEnumerable<UserDTO> UserList { get; set; }

        //public DisplayUserListViewModel UserList { get; set; }


    }
}
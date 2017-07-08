using Domain.Interfaces.Entities;
using Ros.Mapping.DomainModels;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ros.WebApplication.Models.ViewModels.UserViewModels
{
    public class UserDeleteViewModel : IUser, IAddress, IPhoneNumber
    {
        public UserDeleteViewModel()
        {
            //Gör det själv edit. :)
        }

        public UserDeleteViewModel(IUser user)
        {
            Id = user.Id;
            AddressId = user.Address.Id;
            PhoneNumberId = user.PhoneNumber.Id;
            Login = user.Login;
            Password = user.Password;
            FirstName = user.FirstName;
            LastName = user.LastName;
            ICE_Name = user.ICE_Name;
            ICE_PhoneNumber = user.ICE_PhoneNumber;
            PhoneNumber = user.PhoneNumber;
            Address.Country = user.Address.Country;
            Address.City = user.Address.City;
            Address.Street = user.Address.Street;
            Address.ZipCode = user.Address.ZipCode;
            Address.BoxNo = user.Address.BoxNo;
            Active = user.Active;
            Address.Active = user.Address.Active;
            PhoneNumber.Active = user.PhoneNumber.Active;
            sa_Info = user.sa_Info;
            Address.sa_Info = user.Address.sa_Info;
            PhoneNumber.sa_Info = user.PhoneNumber.sa_Info;
        }

        public int Id { get; set; }

        [DisplayName("Login (Email)")]
        public string Login { get; set; }

        [Display(Name = "New password")]
        public string Password { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("ICE Name")]
        public string ICE_Name { get; set; }

        [DisplayName("ICE Phone Number")]
        public string ICE_PhoneNumber { get; set; }

        [DisplayName("Phone Number")]
        public string Value { get; set; }

        [DisplayName("Country")]
        public string Country { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("Street")]
        public string Street { get; set; }

        [DisplayName("Postal Code (Zip Code)")]
        public string ZipCode { get; set; }

        [DisplayName("Box Number")]
        public int? BoxNo { get; set; }

        public int AddressId { get; set; }
        public int PhoneNumberId { get; set; }

        public IAddress Address { get; set; } = (IAddress)Activator.CreateInstance(typeof(AddressModel));
        public IPhoneNumber PhoneNumber { get; set; } = (IPhoneNumber)Activator.CreateInstance(typeof(PhoneNumberModel));
        public bool Active { get; set; }
        public string sa_Info { get; set; }
        public string Type { get; set; }
    }
}
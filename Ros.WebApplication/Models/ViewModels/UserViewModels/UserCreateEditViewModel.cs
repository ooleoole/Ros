using Domain.Interfaces.Entities;
using Ros.Mapping.DomainModels;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ros.WebApplication.Models.ViewModels.UserViewModels
{
    public class UserCreateEditViewModel : IUser, IAddress, IPhoneNumber
    {
        public UserCreateEditViewModel()
        {
            //Gör det själv edit. :)
        }

        public UserCreateEditViewModel(IUser user)
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
            //Address.Id = AddressId
            //PhoneNumber.Id = PhoneNumberId;
            Address.Id = AddressId;
            PhoneNumber.Id = PhoneNumberId;
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

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Login (Email)")]
        public string Login { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm new password")]
        //[Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("ICE Name")]
        public string ICE_Name { get; set; }

        [DisplayName("ICE Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string ICE_PhoneNumber { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Value { get; set; }

        [Required]
        [DisplayName("Country")]
        public string Country { get; set; }

        [Required]
        [DisplayName("City")]
        public string City { get; set; }

        [Required]
        [DisplayName("Street")]
        public string Street { get; set; }

        [Required]
        [DisplayName("Postal Code (Zip Code)")]
        [DataType(DataType.PostalCode)]
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
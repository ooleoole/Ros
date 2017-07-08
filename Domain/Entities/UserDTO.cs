using Domain.Interfaces.Entities;
using Domain.Utilities;
using System;

namespace Domain.Entities
{
    public class UserDTO : IEntityDTO, IDboInfo
    {
        public int Id { get; private set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => GetFullName();
        public string ICE_Name { get; set; }
        public string ICE_PhoneNumber { get; set; }
        public int PhoneNumberId { get; set; }
        public int AddressId { get; set; }
        public bool Active { get; set; }
        public string sa_Info { get; set; }
        public AddressDTO Address { get; private set; }
        public PhoneNumberDTO PhoneNumber { get; private set; }
        public IPermissions Permissions => new Permissions(this);

        public UserDTO(string login, string password, string firstName, string lastName, int phoneNumberId, int addressId, string ice_Name = null, string ice_PhoneNumber = null, string sa_Info = null)
        {
            ValidateInParameters(login, password, firstName, lastName, phoneNumberId, addressId, ice_Name, ice_PhoneNumber);

            Id = 0;
            Login = login;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            ICE_Name = ice_Name;
            ICE_PhoneNumber = ice_PhoneNumber;
            PhoneNumberId = phoneNumberId;
            AddressId = addressId;

            Active = true;
            this.sa_Info = sa_Info;
        }

        public UserDTO(IUser user)
        {
            if (user.Id < 0)
                throw new ArgumentOutOfRangeException($"{nameof(user.Id)} cannot be less than 0.");
            AddressDTO address = new AddressDTO(user.Address);
            PhoneNumberDTO phoneNumber = new PhoneNumberDTO(user.PhoneNumber);
            ValidateInParameters(user.Login, user.Password, user.FirstName, user.LastName, user.PhoneNumber.Id, user.Address.Id, user.ICE_Name, user.ICE_PhoneNumber);

            Id = user.Id;
            Login = user.Login;
            Password = user.Password;
            FirstName = user.FirstName;
            LastName = user.LastName;
            ICE_Name = user.ICE_Name;
            ICE_PhoneNumber = user.ICE_PhoneNumber;
            PhoneNumberId = user.PhoneNumber.Id;
            AddressId = user.Address.Id;
            Address = address;
            PhoneNumber = phoneNumber;

            Active = user.Active;
            sa_Info = user.sa_Info;
        }

        private void ValidateInParameters(string login, string password, string firstName, string lastName, int phoneNumberId, int addressId, string ice_Name, string ice_PhoneNumber)
        {
            // TODO: Implement validation!
        }

        public string GetFullName(bool firstNameFirst = true)
        {
            return firstNameFirst ? $"{FirstName} {LastName}" : $"{LastName} {FirstName}";
        }
    }
}
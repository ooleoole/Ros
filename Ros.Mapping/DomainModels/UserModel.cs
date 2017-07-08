using Domain.Interfaces.Entities;

namespace Ros.Mapping.DomainModels
{
    public class UserModel : IUser, Interfaces.IEntityModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ICE_Name { get; set; }
        public string ICE_PhoneNumber { get; set; }
        public bool Active { get; set; } = true;
        public string sa_Info { get; set; }
        public IAddress Address { get; set; }
        public IPhoneNumber PhoneNumber { get; set; }
    }
}
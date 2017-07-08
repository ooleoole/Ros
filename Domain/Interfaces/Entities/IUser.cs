namespace Domain.Interfaces.Entities
{
    public interface IUser : IDboInfo
    {
        int Id { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string ICE_Name { get; set; }
        string ICE_PhoneNumber { get; set; }
        IAddress Address { get; set; }
        IPhoneNumber PhoneNumber { get; set; }
    }
}
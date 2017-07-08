namespace Domain.Interfaces
{
    public interface IRoleJunction
    {
        int UserId { get; set; }
        int UserRoleId { get; set; }
        int? PhoneNumberId { get; set; }
        int? EmailId { get; set; }
    }
}
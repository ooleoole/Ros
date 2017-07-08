namespace Domain.Interfaces.Entities
{
    public interface IUserRoleDTO
    {
        int Id { get; }
        string Type { get; set; }
        bool Active { get; set; }
        string sa_Info { get; set; }
    }
}
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPermissionTarget
    {
        int Id { get; }

        void CheckPermission(UserDTO caller);
    }
}
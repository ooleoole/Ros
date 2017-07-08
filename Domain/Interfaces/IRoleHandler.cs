using Domain.Entities;
using Domain.Enums;

namespace Domain.Utilities.RoleHandlers
{
    public interface IRoleHandler
    {
        void AddRoleRelation(UserDTO caller, UserDTO user, Role role);

        void AddRoleRelation(UserDTO caller, UserDTO user, EmailDTO email, Role role);

        void AddRoleRelation(UserDTO caller, UserDTO user, PhoneNumberDTO phoneNumber, Role role);

        void AddRoleRelation(UserDTO caller, UserDTO user, PhoneNumberDTO phoneNumber, EmailDTO email, Role role);

        void RemoveRoleRelation(UserDTO caller, UserDTO user, Role role);
    }
}
using Domain.Entities;
using Domain.Entities.Junctions;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Services.Locator;
using System.Linq;

namespace Domain.Utilities.RoleHandlers
{
    public class RegattaRoleHandler : RoleHandler
    {
        private readonly RegattaDTO _regatta;

        public RegattaRoleHandler(RegattaDTO regatta) : base(regatta)
        {
            _regatta = regatta;
        }

        internal override IRoleJunction CreateRoleRelation(UserDTO user, Role role)
        {
            return new Regattas_Users_UserRoles_JunctionsDTO
            {
                RegattaId = _regatta.Id,
                UserId = user.Id,
                UserRoleId = (int)role,
            };
        }

        internal override IRoleJunction CreateRoleRelation(UserDTO user, EmailDTO email, Role role)
        {
            return new Regattas_Users_UserRoles_JunctionsDTO
            {
                RegattaId = _regatta.Id,
                UserId = user.Id,
                UserRoleId = (int)role,
                EmailId = email.Id
            };
        }

        internal override IRoleJunction CreateRoleRelation(UserDTO user, PhoneNumberDTO phoneNumber, Role role)
        {
            return new Regattas_Users_UserRoles_JunctionsDTO
            {
                RegattaId = _regatta.Id,
                UserId = user.Id,
                UserRoleId = (int)role,
                PhoneNumberId = phoneNumber.Id,
            };
        }

        internal override IRoleJunction CreateRoleRelation(UserDTO user, PhoneNumberDTO phoneNumber, EmailDTO email, Role role)
        {
            return new Regattas_Users_UserRoles_JunctionsDTO
            {
                RegattaId = _regatta.Id,
                UserId = user.Id,
                UserRoleId = (int)role,
                PhoneNumberId = phoneNumber.Id,
                EmailId = email.Id
            };
        }

        internal override IRoleJunction GetRoleRelation(UserDTO user, Role role)
        {
            NullCheck.ThrowArgumentNullEx(user, role);
            return ServiceLocator.RegattasUsersUserRolesJunctionsService
                .FindBy(uRJunc => uRJunc.UserId == user.Id && uRJunc.UserRoleId == (int)role)
                .First();
        }

        internal override void RemoveRoleRelationFromDb(IRoleJunction relation)
        {
            ServiceLocator.RegattasUsersUserRolesJunctionsService.Delete((Regattas_Users_UserRoles_JunctionsDTO)relation);
        }

        internal override void AddRoleRelationToDb(IRoleJunction relation)
        {
            ServiceLocator.RegattasUsersUserRolesJunctionsService.Add((Regattas_Users_UserRoles_JunctionsDTO)relation);
        }
    }
}
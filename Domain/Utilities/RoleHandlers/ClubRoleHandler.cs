using Domain.Entities;
using Domain.Entities.Junctions;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Services.Locator;
using System.Linq;

namespace Domain.Utilities.RoleHandlers
{
    public class ClubRoleHandler : RoleHandler
    {
        private readonly ClubDTO _club;

        public ClubRoleHandler(ClubDTO club) : base(club)
        {
            _club = club;
        }

        internal override IRoleJunction CreateRoleRelation(UserDTO user, Role role)
        {
            return new Clubs_Users_UserRoles_JunctionsDTO
            {
                ClubId = _club.Id,
                UserId = user.Id,
                UserRoleId = (int)role,
            };
        }

        internal override IRoleJunction CreateRoleRelation(UserDTO user, EmailDTO email, Role role)
        {
            return new Clubs_Users_UserRoles_JunctionsDTO
            {
                ClubId = _club.Id,
                UserId = user.Id,
                UserRoleId = (int)role,
                EmailId = email.Id
            };
        }

        internal override IRoleJunction CreateRoleRelation(UserDTO user, PhoneNumberDTO phoneNumber, Role role)
        {
            return new Clubs_Users_UserRoles_JunctionsDTO
            {
                ClubId = _club.Id,
                UserId = user.Id,
                UserRoleId = (int)role,
                PhoneNumberId = phoneNumber.Id
            };
        }

        internal override IRoleJunction CreateRoleRelation(UserDTO user, PhoneNumberDTO phoneNumber, EmailDTO email, Role role)
        {
            return new Clubs_Users_UserRoles_JunctionsDTO
            {
                ClubId = _club.Id,
                UserId = user.Id,
                UserRoleId = (int)role,
                PhoneNumberId = phoneNumber.Id,
                EmailId = email.Id
            };
        }

        internal override IRoleJunction GetRoleRelation(UserDTO user, Role role)
        {
            NullCheck.ThrowArgumentNullEx(user, role);
            return ServiceLocator.ClubsUsersUserRolesJunctionsService
                .FindBy(uCJunc => uCJunc.UserId == user.Id && uCJunc.UserRoleId == (int)role)
                .First();
        }

        internal override void RemoveRoleRelationFromDb(IRoleJunction relation)
        {
            ServiceLocator.ClubsUsersUserRolesJunctionsService.Delete((Clubs_Users_UserRoles_JunctionsDTO)relation);
        }

        internal override void AddRoleRelationToDb(IRoleJunction relation)
        {
            ServiceLocator.ClubsUsersUserRolesJunctionsService.Add((Clubs_Users_UserRoles_JunctionsDTO)relation);
        }
    }
}
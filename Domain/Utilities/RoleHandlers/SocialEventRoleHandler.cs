using Domain.Entities;
using Domain.Entities.Junctions;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Services.Locator;
using System.Linq;

namespace Domain.Utilities.RoleHandlers
{
    public class SocialEventRoleHandler : RoleHandler
    {
        private readonly SocialEventDTO _socialEvent;

        public SocialEventRoleHandler(SocialEventDTO socialEvent) : base(socialEvent)
        {
            _socialEvent = socialEvent;
        }

        internal override IRoleJunction CreateRoleRelation(UserDTO user, Role role)
        {
            return new SocialEvents_Users_UserRoles_JunctionsDTO()
            {
                SocialEventId = _socialEvent.Id,
                UserId = user.Id,
                UserRoleId = (int)role,
            };
        }

        internal override IRoleJunction CreateRoleRelation(UserDTO user, EmailDTO email, Role role)
        {
            return new SocialEvents_Users_UserRoles_JunctionsDTO()
            {
                SocialEventId = _socialEvent.Id,
                UserId = user.Id,
                UserRoleId = (int)role,
            };
        }

        internal override IRoleJunction CreateRoleRelation(UserDTO user, PhoneNumberDTO phoneNumber, Role role)
        {
            return new SocialEvents_Users_UserRoles_JunctionsDTO()
            {
                SocialEventId = _socialEvent.Id,
                UserId = user.Id,
                UserRoleId = (int)role,
                PhoneNumberId = phoneNumber.Id
            };
        }

        internal override IRoleJunction CreateRoleRelation(UserDTO user, PhoneNumberDTO phoneNumber, EmailDTO email, Role role)
        {
            return new SocialEvents_Users_UserRoles_JunctionsDTO()
            {
                SocialEventId = _socialEvent.Id,
                UserId = user.Id,
                UserRoleId = (int)role,
                PhoneNumberId = phoneNumber.Id,
                EmailId = email.Id
            };
        }

        internal override IRoleJunction GetRoleRelation(UserDTO user, Role role)
        {
            NullCheck.ThrowArgumentNullEx(user, role);
            return ServiceLocator.SocialEventsUsersUserRolesJunctionsService
                .FindBy(uSeJunc => uSeJunc.UserId == user.Id && uSeJunc.UserRoleId == (int)role)
                .First();
        }

        internal override void RemoveRoleRelationFromDb(IRoleJunction relation)
        {
            ServiceLocator.SocialEventsUsersUserRolesJunctionsService.Delete((SocialEvents_Users_UserRoles_JunctionsDTO)relation);
        }

        internal override void AddRoleRelationToDb(IRoleJunction relation)
        {
            ServiceLocator.SocialEventsUsersUserRolesJunctionsService.Add((SocialEvents_Users_UserRoles_JunctionsDTO)relation);
        }
    }
}
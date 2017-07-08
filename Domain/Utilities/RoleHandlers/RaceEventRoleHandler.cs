using Domain.Entities;
using Domain.Entities.Junctions;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Services.Locator;
using System.Linq;

namespace Domain.Utilities.RoleHandlers
{
    public class RaceEventRoleHandler : RoleHandler
    {
        private readonly RaceEventDTO _raceEvent;

        public RaceEventRoleHandler(RaceEventDTO raceEvent) : base(raceEvent)
        {
            _raceEvent = raceEvent;
        }

        internal override IRoleJunction CreateRoleRelation(UserDTO user, Role role)
        {
            return new RaceEvents_Users_UserRoles_JunctionsDTO
            {
                RaceEventId = _raceEvent.Id,
                UserId = user.Id,
                UserRoleId = (int)role,
            };
        }

        internal override IRoleJunction CreateRoleRelation(UserDTO user, EmailDTO email, Role role)
        {
            return new RaceEvents_Users_UserRoles_JunctionsDTO
            {
                RaceEventId = _raceEvent.Id,
                UserId = user.Id,
                UserRoleId = (int)role,

                EmailId = email.Id
            };
        }

        internal override IRoleJunction CreateRoleRelation(UserDTO user, PhoneNumberDTO phoneNumber, Role role)
        {
            return new RaceEvents_Users_UserRoles_JunctionsDTO
            {
                RaceEventId = _raceEvent.Id,
                UserId = user.Id,
                UserRoleId = (int)role,
                PhoneNumberId = phoneNumber.Id,
            };
        }

        internal override IRoleJunction CreateRoleRelation(UserDTO user, PhoneNumberDTO phoneNumber, EmailDTO email, Role role)
        {
            return new RaceEvents_Users_UserRoles_JunctionsDTO
            {
                RaceEventId = _raceEvent.Id,
                UserId = user.Id,
                UserRoleId = (int)role,
                PhoneNumberId = phoneNumber.Id,
                EmailId = email.Id
            };
        }

        internal override IRoleJunction GetRoleRelation(UserDTO user, Role role)
        {
            NullCheck.ThrowArgumentNullEx(user, role);
            return ServiceLocator.RaceEventsUsersUserRolesJunctionsService
                .FindBy(uReJunc => uReJunc.UserId == user.Id && uReJunc.UserRoleId == (int)role)
                .First();
        }

        internal override void RemoveRoleRelationFromDb(IRoleJunction relation)
        {
            ServiceLocator.RaceEventsUsersUserRolesJunctionsService.Delete((RaceEvents_Users_UserRoles_JunctionsDTO)relation);
        }

        internal override void AddRoleRelationToDb(IRoleJunction relation)
        {
            ServiceLocator.RaceEventsUsersUserRolesJunctionsService.Add((RaceEvents_Users_UserRoles_JunctionsDTO)relation);
        }
    }
}
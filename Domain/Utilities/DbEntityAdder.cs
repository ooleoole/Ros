using Domain.Entities;
using Domain.Services.Locator;
using System.Linq;

namespace Domain.Utilities
{
    internal static class DbEntityAdder
    {
        public static UserDTO AddUserToDb(UserDTO user)
        {
            NullCheck.ThrowArgumentNullEx(user);
            ServiceLocator.UserService.InternalService.Add(user);
            var addedUser = ServiceLocator.UserService.EagerDisconnectedService.FindBy(u => u.Login == user.Login)
                .First();
            return addedUser;
        }

        public static PhoneNumberDTO AddPhoneNumberToDb(PhoneNumberDTO phoneNumber)
        {
            NullCheck.ThrowArgumentNullEx(phoneNumber);
            ServiceLocator.PhoneNumberService.InternalService.Add(phoneNumber);
            var addedPhoneNumber = ServiceLocator.PhoneNumberService.EagerDisconnectedService.FindBy(p => p.Value == phoneNumber.Value)
                .First();
            return addedPhoneNumber;
        }

        public static EmailDTO AddEmailToDb(EmailDTO email)
        {
            NullCheck.ThrowArgumentNullEx(email);
            ServiceLocator.EmailService.InternalService.Add(email);
            var addedEmail = ServiceLocator.EmailService.EagerDisconnectedService.FindBy(e => e.Value == email.Value)
                .First();
            return addedEmail;
        }

        public static TeamDTO AddTeamToDb(TeamDTO team)
        {
            NullCheck.ThrowArgumentNullEx(team);
            ServiceLocator.TeamService.InternalService.Add(team);
            var addedTeam = ServiceLocator.TeamService.EagerDisconnectedService.FindBy(e => e.TeamName == team.TeamName)
                .First();
            return addedTeam;
        }
    }
}
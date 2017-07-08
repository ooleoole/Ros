using Domain.Entities;
using Domain.Services.Locator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Domain.Utilities
{
    internal static class DbEntityExistensChecker
    {
        public static UserDTO TryGetExistingUserFromDb(UserDTO user)
        {
            var foundUser = ServiceLocator.UserService.EagerDisconnectedService.FindBy(u => u.Login == user.Login).FirstOrDefault();
            if (CheckEquality(user, foundUser, "Permissions", "Active", "Id"))
                return foundUser;

            throw new ArgumentException($"A user with the same login: {user.Login}, but with conflicting values already exsist in the database");
        }

        public static PhoneNumberDTO TryGetExistingPhoneNumberFromDb(PhoneNumberDTO phoneNumber)
        {
            var foundPhoneNumber = ServiceLocator.PhoneNumberService.EagerDisconnectedService.FindBy(p => p.Value == phoneNumber.Value).FirstOrDefault();
            CheckIfNumberExistButWithDiffrentType(phoneNumber, foundPhoneNumber);
            return foundPhoneNumber;
        }

        public static EmailDTO TryGetExistingEmailFromDb(EmailDTO email)
        {
            var foundEmail = ServiceLocator.EmailService.EagerDisconnectedService.FindBy(e => e.Value == email.Value).FirstOrDefault();
            CheckIfEmailExistButWithDiffrentType(email, foundEmail);
            return foundEmail;
        }

        public static TeamDTO TryGetExistingTeamFromDb(TeamDTO team)
        {
            var foundTeam = ServiceLocator.TeamService.EagerDisconnectedService.FindBy(t => t.TeamNo == team.TeamNo).FirstOrDefault();
            if (CheckEquality(team, foundTeam, "Active", "Id"))
                return foundTeam;

            throw new ArgumentException($"A team with the same TeamNo: {team.TeamNo}, but with conflicting values already exsist in the database");
        }

        public static ClubDTO TryGetExistingClubFromDb(ClubDTO club)
        {
            var foundClub = ServiceLocator.ClubService.EagerDisconnectedService.FindBy(t => t.Name == club.Name).FirstOrDefault();
            if (CheckEquality(club, foundClub, "RoleHandler", "RegistrationDate", "Active", "Id"))
                return foundClub;

            throw new ArgumentException($"A club with the same Name: {club.Name}, but with conflicting values already exsist in the database");
        }

        private static bool CheckEquality(object obj1, object obj2, params string[] propertyToExlude)
        {
            var props1 = GetPropertyInfos(obj1);
            var props2 = GetPropertyInfos(obj2);

            if (propertyToExlude.Length != 0)
                ExcludePropertyFromPropertyInfos(new[] { props1, props2 }, propertyToExlude);

            return CheckPropsForEquality(obj1, obj2, props1, props2);
        }

        private static bool CheckPropsForEquality(object obj1, object obj2, List<PropertyInfo> props1, List<PropertyInfo> props2)
        {
            for (var i = 0; i < props1.Count; i++)
            {
                var prop1Value = props1[i].GetValue(obj1);
                var prop2Value = props2[i].GetValue(obj2);
                if (!Equals(prop1Value, prop2Value))
                    return false;
            }
            return true;
        }

        private static void ExcludePropertyFromPropertyInfos(IEnumerable<List<PropertyInfo>> propertysInfos, string[] propertyToExclude)
        {
            foreach (var propertyInfo in propertysInfos)
            {
                foreach (var prop in propertyToExclude)
                    propertyInfo.RemoveAll(p => p.Name == prop);
            }
        }

        private static List<PropertyInfo> GetPropertyInfos(object obj)
        {
            return obj.GetType().GetProperties().OrderByDescending(p => p.Name).ToList();
        }

        private static void CheckIfNumberExistButWithDiffrentType(PhoneNumberDTO phoneNumber, PhoneNumberDTO foundPhoneNumber)
        {
            if (foundPhoneNumber != null && !string.Equals(phoneNumber.Type, foundPhoneNumber.Type,
                    StringComparison.CurrentCultureIgnoreCase))
                throw new ArgumentException(
                    $"Phonenumber: {phoneNumber.Value} already exist in the database as Type: {foundPhoneNumber.Type}" +
                    $"To add Phonenumber: {phoneNumber.Value} as Type: {phoneNumber.Type}. Delete {foundPhoneNumber.Value} Id: {foundPhoneNumber.Id} first");
        }

        private static void CheckIfEmailExistButWithDiffrentType(EmailDTO email, EmailDTO foundEmail)
        {
            if (foundEmail != null && !string.Equals(email.Type, foundEmail.Type,
                    StringComparison.CurrentCultureIgnoreCase))
                throw new ArgumentException(
                    $"Email: {email.Value} already exist in the database as a {foundEmail.Type} email");
        }
    }
}
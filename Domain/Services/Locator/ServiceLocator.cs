using Domain.Services.AddressServices;
using Domain.Services.AggregatRoots.ClubServices;
using Domain.Services.AggregatRoots.EntryServices;
using Domain.Services.AggregatRoots.RaceEventServices;
using Domain.Services.AggregatRoots.RegattaServices;
using Domain.Services.AggregatRoots.SocialEventServices;
using Domain.Services.AggregatRoots.TeamServices;
using Domain.Services.AggregatRoots.UserServices;
using Domain.Services.BoatServices;
using Domain.Services.EmailServices;
using Domain.Services.Junctions.Clubs_Users_UserRoles_JunctionsService;
using Domain.Services.Junctions.ClubsEmails;
using Domain.Services.Junctions.ClubsPhoneNumbers;
using Domain.Services.Junctions.RaceEvents_Users_UserRoles_JunctionsServices;
using Domain.Services.Junctions.Regattas_Users_UserRoles_JunctionsService;
using Domain.Services.Junctions.RegisteredUserSocialEventServices;
using Domain.Services.Junctions.TeamsRaceEvents;
using Domain.Services.Junctions.TeamsRegisteredUsers;
using Domain.Services.PhoneNumberServices;
using Domain.Services.RegisteredUserServices;
using Domain.Services.ResultServices;
using Domain.Services.UserRoleServices;

namespace Domain.Services.Locator
{
    public static class ServiceLocator
    {
        public static AddressService AddressService { get; }
        public static BoatService BoatService { get; }
        public static ClubService ClubService { get; }
        public static EntryService EntryService { get; }
        public static RaceEventService RaceEventService { get; }
        public static RegattaService RegattaService { get; }
        public static SocialEventService SocialEventService { get; }
        public static TeamService TeamService { get; }
        public static UserService UserService { get; }
        public static EmailService EmailService { get; }
        public static PhoneNumberService PhoneNumberService { get; }
        public static ResultService ResultService { get; }

        internal static RegisteredUserService RegisteredUserService { get; }
        internal static UserRoleService UserRoleService { get; }
        internal static SocialEvents_Users_UserRoles_JunctionsService SocialEventsUsersUserRolesJunctionsService { get; }
        internal static RaceEvents_Users_UserRoles_JunctionsService RaceEventsUsersUserRolesJunctionsService { get; }

        internal static Clubs_Users_UserRoles_JunctionsService ClubsUsersUserRolesJunctionsService
        {
            get;
        }

        internal static Regattas_Users_UserRoles_JunctionsService RegattasUsersUserRolesJunctionsService
        {
            get;
        }

        internal static RegisteredUser_SocialEventService RegisteredUserSocialEventService { get; }
        internal static Team_RaceEventService TeamRaceEventService { get; }
        internal static Team_RegisteredUserService TeamRegisteredUserService { get; }
        internal static ClubsEmailsService ClubsEmailsService { get; }
        internal static ClubsPhoneNumbersService ClubsPhoneNumbersService { get; }

        static ServiceLocator()
        {
            AddressService = new AddressService();
            BoatService = new BoatService();
            ClubService = new ClubService();
            UserService = new UserService();
            EntryService = new EntryService();
            RaceEventService = new RaceEventService();
            RegattaService = new RegattaService();
            SocialEventService = new SocialEventService();
            TeamService = new TeamService();
            EmailService = new EmailService();
            PhoneNumberService = new PhoneNumberService();
            RegisteredUserService = new RegisteredUserService();
            ResultService = new ResultService();
            UserRoleService = new UserRoleService();
            ClubsUsersUserRolesJunctionsService = new Clubs_Users_UserRoles_JunctionsService();
            RegattasUsersUserRolesJunctionsService = new Regattas_Users_UserRoles_JunctionsService();
            RegisteredUserSocialEventService = new RegisteredUser_SocialEventService();
            TeamRaceEventService = new Team_RaceEventService();
            TeamRegisteredUserService = new Team_RegisteredUserService();
            BoatService = new BoatService();
            SocialEventsUsersUserRolesJunctionsService = new SocialEvents_Users_UserRoles_JunctionsService();
            RaceEventsUsersUserRolesJunctionsService = new RaceEvents_Users_UserRoles_JunctionsService();
            ClubsEmailsService = new ClubsEmailsService();
            ClubsPhoneNumbersService = new ClubsPhoneNumbersService();
        }
    }
}
using AutoMapper;
using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Entities.Junctions;

namespace Domain.Mappings.Profiles
{
    public static class MapperProfiles
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Address, AddressDTO>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<Boat, BoatDTO>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<Club, ClubDTO>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<Email, EmailDTO>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<Entry, EntryDTO>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<PhoneNumber, PhoneNumberDTO>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<RaceEvent, RaceEventDTO>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<Regatta, RegattaDTO>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<Result, ResultDTO>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<SocialEvent, SocialEventDTO>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<Team, TeamDTO>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<User, UserDTO>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<UserRole, UserRoleDTO>().MaxDepth(0).ReverseMap();

                cfg.CreateMap<Clubs_Users_UserRoles_Junctions, Clubs_Users_UserRoles_JunctionsDTO>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<Regattas_Users_UserRoles_Junctions, Regattas_Users_UserRoles_JunctionsDTO>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<RegisteredUser, RegisteredUserDTO>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<RegisteredUsers_SocialEvents, RegisteredUsers_SocialEventsDTO>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<Teams_RaceEvents, Teams_RaceEventsDTO>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<Teams_RegisteredUsers, Teams_RegisteredUsersDTO>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<Clubs_PhoneNumbers, Clubs_PhoneNumbersDTO>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<Clubs_Emails, Clubs_EmailsDTO>().MaxDepth(0).ReverseMap();

                cfg.CreateMap<AddressDTO, Address>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<BoatDTO, Boat>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<ClubDTO, Club>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<EmailDTO, Email>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<EntryDTO, Entry>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<PhoneNumberDTO, PhoneNumber>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<RaceEventDTO, RaceEvent>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<RegattaDTO, Regatta>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<ResultDTO, Result>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<SocialEventDTO, SocialEvent>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<TeamDTO, Team>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<UserDTO, User>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<UserRoleDTO, UserRole>().MaxDepth(0).ReverseMap();

                cfg.CreateMap<SocialEvents_Users_UserRoles_Junctions, SocialEvents_Users_UserRoles_JunctionsDTO>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<RaceEvents_Users_UserRoles_Junctions, RaceEvents_Users_UserRoles_JunctionsDTO>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<Clubs_Users_UserRoles_JunctionsDTO, Clubs_Users_UserRoles_Junctions>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<RegisteredUserDTO, RegisteredUser>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<RegisteredUsers_SocialEventsDTO, RegisteredUsers_SocialEvents>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<Teams_RaceEventsDTO, Teams_RaceEvents>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<Teams_RegisteredUsersDTO, Teams_RegisteredUsers>().MaxDepth(0).ReverseMap();
            });
            return config;
        }
    }
}
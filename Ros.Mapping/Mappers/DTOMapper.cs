using Domain.Entities;
using Domain.Interfaces.Entities;

namespace Ros.Mapping.Mappers
{
    public static class DTOMapper
    {
        public static AddressDTO MappFrom(IAddress address)
        {
            return new AddressDTO(address);
        }

        public static BoatDTO MappFrom(IBoat boat)
        {
            return new BoatDTO(boat);
        }

        public static ClubDTO MappFrom(IClub club)
        {
            return new ClubDTO(club);
        }

        public static EmailDTO MappFrom(IEmail email)
        {
            return new EmailDTO(email);
        }

        public static EntryDTO MappFrom(IEntry entry)
        {
            return new EntryDTO(entry);
        }

        public static PhoneNumberDTO MappFrom(IPhoneNumber phoneNumber)
        {
            return new PhoneNumberDTO(phoneNumber);
        }

        public static RaceEventDTO MappFrom(IRaceEvent raceEvent)
        {
            return new RaceEventDTO(raceEvent);
        }

        public static RegattaDTO MappFrom(IRegatta regatta)
        {
            return new RegattaDTO(regatta);
        }

        public static ResultDTO MappFrom(IResult result)
        {
            return new ResultDTO(result);
        }

        public static SocialEventDTO MappFrom(ISocialEvent socialEvent)
        {
            return new SocialEventDTO(socialEvent);
        }

        public static TeamDTO MappFrom(ITeam team)
        {
            return new TeamDTO(team);
        }

        public static UserDTO MappFrom(IUser user)
        {
            return new UserDTO(user);
        }
    }
}
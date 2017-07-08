using Domain.Entities;
using Domain.Interfaces.Entities;
using Ros.Mapping.DomainModels;
using Ros.Mapping.Interfaces;

namespace Ros.Mapping.Mappers
{
    public static class ModelMapper
    {
        public static IAddress MappFrom(AddressDTO address)
        {
            AddressModel addressModel = new AddressModel();
            SetCommonDboProperties(addressModel, address);
            addressModel.Country = address.Country;
            addressModel.City = address.City;
            addressModel.Street = address.Street;
            addressModel.ZipCode = address.ZipCode;
            addressModel.BoxNo = address.BoxNo;
            addressModel.Type = address.Type;
            return addressModel;
        }

        public static IBoat MappFrom(BoatDTO boat)
        {
            BoatModel boatModel = new BoatModel();
            SetCommonDboProperties(boatModel, boat);
            boatModel.SailNo = boat.SailNo;
            boatModel.Name = boat.Name;
            boatModel.Type = boat.Type;
            boatModel.Handicap = boat.Handicap;
            return boatModel;
        }

        public static IClub MappFrom(ClubDTO club)
        {
            ClubModel clubModel = new ClubModel();
            SetCommonDboProperties(clubModel, club);
            clubModel.Name = club.Name;
            clubModel.RegistrationDate = club.RegistrationDate;
            clubModel.Logo = club.Logo;
            clubModel.HomePage = club.HomePage;
            clubModel.Description = club.Description;
            clubModel.Address = MappFrom(club.Address);
            return clubModel;
        }

        public static IEmail MappFrom(EmailDTO email)
        {
            EmailModel emailModel = new EmailModel();
            SetCommonDboProperties(emailModel, email);
            emailModel.Value = email.Value;
            emailModel.Type = email.Type;
            return emailModel;
        }

        public static IEntry MappFrom(EntryDTO entry)
        {
            EntryModel entryModel = new EntryModel();
            SetCommonDboProperties(entryModel, entry);
            entryModel.EntryNo = entry.EntryNo;
            entryModel.EntryName = entry.EntryName;
            entryModel.RegistrationDate = entry.RegistrationDate;
            entryModel.PaidAmount = entry.PaidAmount;
            entryModel.Boat = MappFrom(entry.Boat);
            entryModel.Club = MappFrom(entry.Club);
            entryModel.User = MappFrom(entry.User);
            return entryModel;
        }

        public static IPhoneNumber MappFrom(PhoneNumberDTO phoneNumber)
        {
            PhoneNumberModel phoneNumberModel = new PhoneNumberModel();
            SetCommonDboProperties(phoneNumberModel, phoneNumber);
            phoneNumberModel.Value = phoneNumber.Value;
            phoneNumberModel.Type = phoneNumber.Type;
            return phoneNumberModel;
        }

        public static IRaceEvent MappFrom(RaceEventDTO raceEvent)
        {
            RaceEventModel raceEventModel = new RaceEventModel();
            SetCommonDboProperties(raceEventModel, raceEvent);
            raceEventModel.Name = raceEvent.Name;
            raceEventModel.Location = raceEvent.Location;
            raceEventModel.Fee = raceEvent.Fee;
            raceEventModel.Description = raceEvent.Description;
            raceEventModel.StartDate = raceEvent.StartDate;
            raceEventModel.EndDate = raceEvent.EndDate;
            raceEventModel.MaxParticipants = raceEvent.MaxParticipants;
            raceEventModel.Class = raceEvent.Class;
            raceEventModel.Type = raceEvent.Type;
            raceEventModel.Regatta = MappFrom(raceEvent.Regatta);
            return raceEventModel;
        }

        public static IRegatta MappFrom(RegattaDTO regatta)
        {
            RegattaModel regattaModel = new RegattaModel();
            SetCommonDboProperties(regattaModel, regatta);
            regattaModel.Name = regatta.Name;
            regattaModel.StartDate = regatta.StartDate;
            regattaModel.EndDate = regatta.EndDate;
            regattaModel.Fee = regatta.Fee;
            regattaModel.Description = regatta.Description;
            regattaModel.Address = MappFrom(regatta.Address);
            regattaModel.Club = MappFrom(regatta.Club);
            return regattaModel;
        }

        public static IResult MappFrom(ResultDTO result)
        {
            ResultModel resultModel = new ResultModel();
            SetCommonDboProperties(resultModel, result);
            resultModel.Rank = result.Rank;
            resultModel.Points = result.Points;
            resultModel.Time = result.Time;
            resultModel.Distance = result.Distance;
            resultModel.CalculatedTime = result.CalculatedTime;
            resultModel.CalculatedDistance = result.CalculatedDistance;
            resultModel.Remark = result.Remark;
            resultModel.Entry = MappFrom(result.Entry);
            resultModel.RaceEvent = MappFrom(result.RaceEvent);
            return resultModel;
        }

        public static ISocialEvent MappFrom(SocialEventDTO socialEvent)
        {
            SocialEventModel socialEventModel = new SocialEventModel();
            SetCommonDboProperties(socialEventModel, socialEvent);
            socialEventModel.Name = socialEvent.Name;
            socialEventModel.Location = socialEvent.Location;
            socialEventModel.Fee = socialEvent.Fee;
            socialEventModel.Description = socialEvent.Description;
            socialEventModel.StartDate = socialEvent.StartDate;
            socialEventModel.EndDate = socialEvent.EndDate;
            socialEventModel.MaxParticipants = socialEvent.MaxParticipants;
            socialEventModel.Regatta = MappFrom(socialEvent.Regatta);
            return socialEventModel;
        }

        public static ITeam MappFrom(TeamDTO team)
        {
            TeamModel teamModel = new TeamModel();
            SetCommonDboProperties(teamModel, team);
            teamModel.TeamNo = team.TeamNo;
            teamModel.TeamName = team.TeamName;
            teamModel.Entry = MappFrom(team.Entry);
            return teamModel;
        }

        public static IUser MappFrom(UserDTO user)
        {
            UserModel userModel = new UserModel();
            SetCommonDboProperties(userModel, user);
            userModel.Login = user.Login;
            userModel.Password = user.Password;
            userModel.FirstName = user.FirstName;
            userModel.LastName = user.LastName;
            userModel.ICE_Name = user.ICE_Name;
            userModel.ICE_PhoneNumber = user.ICE_PhoneNumber;
            userModel.Address = MappFrom(user.Address);
            userModel.PhoneNumber = MappFrom(user.PhoneNumber);
            return userModel;
        }

        private static void SetCommonDboProperties<TModel, TDTO>(TModel model, TDTO dto)
            where TModel : class, IDboInfo, IEntityModel
            where TDTO : class, IDboInfo, IEntityDTO
        {
            model.Id = dto.Id;
            model.Active = dto.Active;
            model.sa_Info = dto.sa_Info;
        }
    }
}
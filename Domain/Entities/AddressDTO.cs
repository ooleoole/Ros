using Domain.Interfaces.Entities;
using Domain.Utilities;
using System;
using System.Linq;

namespace Domain.Entities
{
    public sealed class AddressDTO : IEntityDTO, IDboInfo, IEquatable<AddressDTO>
    {
        public static readonly int CountryMinLength = 4;
        public static readonly int CountryMaxLength = 32;
        public static readonly int CityMinLength = 1;
        public static readonly int CityMaxLength = 15;
        public static readonly int StreetMinLength = 5;
        public static readonly int StreetMaxLength = 35;
        public static readonly int ZipCodeLength = 5;
        public static readonly int TypeMinLength = 3;
        public static readonly int TypeMaxLength = 10;
        public static readonly int BoxNoMinValue = 1;
        public static readonly int BoxNoMaxValue = 10000;

        public int Id { get; private set; }
        public string Country { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string ZipCode { get; private set; }
        public int? BoxNo { get; private set; }
        public string Type { get; private set; }
        public bool Active { get; set; }
        public string sa_Info { get; set; }

        public AddressDTO(string country, string city, string street, string zipCode, string type, int? boxNo = null, string sa_Info = null)
        {
            ValidateInParameters(country, city, street, zipCode, type, boxNo);

            Id = 0;
            Country = country;
            City = city;
            Street = street;
            ZipCode = zipCode;
            BoxNo = boxNo;
            Type = type;
            Active = true;
            this.sa_Info = sa_Info;
        }

        public AddressDTO(IAddress address)
        {
            if (address.Id < 0)
                throw new ArgumentOutOfRangeException($"{nameof(address.Id)} cannot be less than 0.");
            ValidateInParameters(address.Country, address.City, address.Street, address.ZipCode, address.Type, address.BoxNo);

            Id = address.Id;
            Country = address.Country;
            City = address.City;
            Street = address.Street;
            ZipCode = address.ZipCode;
            BoxNo = address.BoxNo;
            Type = address.Type;
            Active = address.Active;
            sa_Info = address.sa_Info;
        }

        private void ValidateInParameters(string country, string city, string street, string zipCode, string type, int? boxNo)
        {
            ValidateCountry(country);

            ValidateCity(city);

            ValidateStreet(street);

            ValidateZipCode(zipCode);

            ValidateType(type);

            ValidateBoxNo(boxNo);
        }

        private void ValidateCountry(string country)
        {
            NullCheck.ThrowArgumentNullEx(country);
            if (country.Any(char.IsDigit))
                throw new ArgumentException($"{nameof(country)} cannot contain digits.");
            if (CountryMinLength > country.Length || country.Length > CountryMaxLength)
                throw new ArgumentException($"{nameof(country)} must have a length between {CountryMinLength} and {CountryMaxLength}.");
            if (CountryStartsWithWhiteSpace())
                throw new ArgumentException($"{nameof(country)} cannot start with a white-space character.");
            if (CountryEndsWithWhiteSpace())
                throw new ArgumentException($"{nameof(country)} cannot end with a white-space character.");
            if (CountryStartsLowerCase())
                throw new ArgumentException($"{nameof(country)} cannot start with a lower case.");
            if (CountryEndsWithUpperCase())
                throw new ArgumentException($"{nameof(country)} cannot end with a upper case.");
            if (CountryContainsIllegalCharacters())
                throw new ArgumentException($"{nameof(country)} can only contain letters and white-space characters.");

            bool CountryStartsWithWhiteSpace() => country[0] == ' ';
            bool CountryEndsWithWhiteSpace() => country[country.Length - 1] == ' ';
            bool CountryStartsLowerCase() => char.IsLower(country[0]);
            bool CountryEndsWithUpperCase() => char.IsUpper(country[country.Length - 1]);
            bool CountryContainsIllegalCharacters() => country.Any(character =>
                                                               !char.IsLetter(character) &&
                                                               character != ' ');
        }

        private void ValidateCity(string city)
        {
            NullCheck.ThrowArgumentNullEx(city);
            if (city.Any(char.IsDigit))
                throw new ArgumentException($"{nameof(city)} cannot contain digits.");
            if (CityMinLength > city.Length || city.Length > CityMaxLength)
                throw new ArgumentException($"{nameof(city)} must have a length between {CityMinLength} and {CityMaxLength}.");
            if (CityStartsWithWhiteSpace())
                throw new ArgumentException($"{nameof(city)} cannot start with a white-space character.");
            if (CityEndsWithWhiteSpace())
                throw new ArgumentException($"{nameof(city)} cannot end with a white-space character.");
            if (CityStartsLowerCase())
                throw new ArgumentException($"{nameof(city)} cannot start with a lower case.");
            if (CityEndsWithUpperCase())
                throw new ArgumentException($"{nameof(city)} cannot end with a upper case.");
            if (CityContainsIllegalCharacters())
                throw new ArgumentException($"{nameof(city)} can only contain letters and white-space characters.");

            bool CityStartsWithWhiteSpace() => city[0] == ' ';
            bool CityEndsWithWhiteSpace() => city[city.Length - 1] == ' ';
            bool CityStartsLowerCase() => char.IsLower(city[0]);
            bool CityEndsWithUpperCase() => city.Length > 1 && char.IsUpper(city[city.Length - 1]);
            bool CityContainsIllegalCharacters() => city.Any(character =>
                                                               !char.IsLetter(character) &&
                                                               character != ' ');
        }

        private void ValidateStreet(string street)
        {
            NullCheck.ThrowArgumentNullEx(street);
            if (StreetMinLength > street.Length || street.Length > StreetMaxLength)
                throw new ArgumentException($"{nameof(street)} must have a length between {StreetMinLength} and {StreetMaxLength}.");
            if (StreetStartsWithWhiteSpace())
                throw new ArgumentException($"{nameof(street)} cannot start with a white-space character.");
            if (StreetEndsWithWhiteSpace())
                throw new ArgumentException($"{nameof(street)} cannot end with a white-space character.");
            if (StreetStartsWithDigit())
                throw new ArgumentException($"{nameof(street)} cannot start with a digit.");
            if (StreetDoesNotContainAnyWhiteSpace())
                throw new ArgumentException($"{nameof(street)} does not contain any white-space characters.");
            if (StreetContainsIllegalCharacters())
                throw new ArgumentException($"{nameof(street)} can only contain letters, digits and white-space characters.");

            bool StreetStartsWithWhiteSpace() => street[0] == ' ';
            bool StreetEndsWithWhiteSpace() => street[street.Length - 1] == ' ';
            bool StreetStartsWithDigit() => char.IsDigit(street[0]);
            bool StreetDoesNotContainAnyWhiteSpace() => street.All(character => character != ' ');
            bool StreetContainsIllegalCharacters() => street.Any(character =>
                                                               !char.IsLetter(character) &&
                                                               !char.IsDigit(character) &&
                                                               character != ' ');
        }

        private void ValidateZipCode(string zipCode)
        {
            NullCheck.ThrowArgumentNullEx(zipCode);
            if (zipCode.Length != ZipCodeLength)
                throw new ArgumentException($"{nameof(zipCode)} must have a length of {ZipCodeLength}.");
            if (zipCode.Any(character => !char.IsDigit(character)))
                throw new ArgumentException($"{nameof(zipCode)} can only contain digits.");
        }

        private void ValidateType(string type)
        {
            NullCheck.ThrowArgumentNullEx(type);
            if (TypeMinLength > type.Length || type.Length > TypeMaxLength)
                throw new ArgumentException($"{nameof(type)} must have a length between {TypeMinLength} and {TypeMaxLength}.");
            if (TypeStartsWithWhiteSpace())
                throw new ArgumentException($"{nameof(type)} cannot start with a white-space character.");
            if (TypeEndsWithWhiteSpace())
                throw new ArgumentException($"{nameof(type)} cannot end with a white-space character.");
            if (TypeStartsWithDigit())
                throw new ArgumentException($"{nameof(type)} cannot start with a digit.");
            if (TypeContainsIllegalCharacters())
                throw new ArgumentException($"{nameof(type)} can only contain letters, digits and white-space characters.");

            bool TypeStartsWithWhiteSpace() => type[0] == ' ';
            bool TypeEndsWithWhiteSpace() => type[type.Length - 1] == ' ';
            bool TypeStartsWithDigit() => char.IsDigit(type[0]);
            bool TypeContainsIllegalCharacters() => type.Any(typeCharacter =>
                                                             !char.IsLetter(typeCharacter) &&
                                                             !char.IsDigit(typeCharacter) &&
                                                             typeCharacter != ' ');
        }

        private void ValidateBoxNo(int? boxNo)
        {
            if (boxNo.HasValue)
            {
                if (BoxNoMinValue > boxNo || boxNo > BoxNoMaxValue)
                    throw new ArgumentOutOfRangeException($"{nameof(boxNo)} must be between {BoxNoMinValue} and {BoxNoMaxValue}.");
            }
        }

        public override bool Equals(object obj)
        {
            try
            {
                return Equals((AddressDTO)obj);
            }
            catch
            {
                return false;
            }
        }

        public bool Equals(AddressDTO other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Country, other.Country) && string.Equals(City, other.City) && string.Equals(Street, other.Street) && string.Equals(ZipCode, other.ZipCode) && BoxNo == other.BoxNo && string.Equals(Type, other.Type);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Country?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (City?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (Street?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (ZipCode?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ BoxNo.GetHashCode();
                hashCode = (hashCode * 397) ^ (Type?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(AddressDTO left, AddressDTO right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AddressDTO left, AddressDTO right)
        {
            return !Equals(left, right);
        }
    }
}
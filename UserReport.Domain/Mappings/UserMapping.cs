namespace UserReport.Domain.Mappings;

using UserReport.Domain.DTOs;

public static class UserMapping
{
    public static User ToEntity(this UserDto user) =>
        new()
        {
            UserId = Guid.NewGuid(),
            Gender = user.Gender,
            Name = new Name
            {
                Title = user.Name.Title,
                First = user.Name.First,
                Last = user.Name.Last
            },
            Location = new Location
            {
                Street = new Street
                {
                    Number = user.Location.Street.Number,
                    Name = user.Location.Street.Name,
                },
                City = user.Location.City,
                State = user.Location.State,
                Country = user.Location.Country,
                Postcode = user.Location.Postcode,
                Coordinates = new Coordinates
                {
                    Latitude = user.Location.Coordinates.Latitude,
                    Longitude = user.Location.Coordinates.Longitude,
                },
                Timezone = new Timezone
                {
                    Offset = user.Location.TimeZone.Offset,
                    Description = user.Location.TimeZone.Description
                }
            },
            Email = user.Email,
            Login = new Login
            {
                Uuid = user.Login.Uuid,
                Username = user.Login.Username,
                Password = user.Login.Password,
                Salt = user.Login.Salt,
                Md5 = user.Login.Md5,
                Sha1 = user.Login.Sha1,
                Sha256 = user.Login.Sha256
            },
            Dob = new DateOfBirth { Date = user.Dob.Date, Age = user.Dob.Age },
            Registered = new Registered { Date = user.Registered.Date, Age = user.Registered.Age },
            Phone = user.Phone,
            Cell = user.Cell,
            Id = new Identification { Name = user.Id.Name, Value = user.Id.Value },
            Picture = new Picture
            {
                Large = user.Picture.Large,
                Medium = user.Picture.Medium,
                Thumbnail = user.Picture.Thumbnail
            },
            Nat = user.Nat
        };

    public static UserDto ToDto(this User user) =>
        new(
            Gender: user.Gender,
            Name: new NameDto(Title: user.Name.Title, First: user.Name.First, Last: user.Name.Last),
            Location: new LocationDto(
                Street: new StreetDto(
                    Number: user.Location.Street.Number,
                    Name: user.Location.Street.Name
                ),
                City: user.Location.City,
                State: user.Location.State,
                Country: user.Location.Country,
                Postcode: user.Location.Postcode,
                Coordinates: new CoordinatesDto(
                    Latitude: user.Location.Coordinates.Latitude,
                    Longitude: user.Location.Coordinates.Longitude
                ),
                TimeZone: new TimezoneDto(
                    Offset: user.Location.Timezone.Offset,
                    Description: user.Location.Timezone.Description
                )
            ),
            Email: user.Email,
            Login: new LoginDto(
                Uuid: user.Login.Uuid,
                Username: user.Login.Username,
                Password: user.Login.Password,
                Salt: user.Login.Salt,
                Md5: user.Login.Md5,
                Sha1: user.Login.Sha1,
                Sha256: user.Login.Sha256
            ),
            Dob: new DateOfBirthDto(Date: user.Dob.Date, Age: user.Dob.Age),
            Registered: new RegisteredDto(Date: user.Registered.Date, Age: user.Registered.Age),
            Phone: user.Phone,
            Cell: user.Cell,
            Id: new IdentificationDto(Name: user.Id.Name, Value: user.Id.Value),
            Picture: new PictureDto(
                Large: user.Picture.Large,
                Medium: user.Picture.Medium,
                Thumbnail: user.Picture.Thumbnail
            ),
            Nat: user.Nat
        );
}

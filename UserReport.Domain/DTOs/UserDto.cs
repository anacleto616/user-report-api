namespace UserReport.Domain.DTOs;

using System.ComponentModel.DataAnnotations;

public record NameDto(string Title, string First, string Last);

public record StreetDto(int Number, string Name);

public record CoordinatesDto(string Latitude, string Longitude);

public record TimezoneDto(string Offset, string Description);

public record LocationDto(
    StreetDto Street,
    string City,
    string State,
    string Country,
    string Postcode,
    CoordinatesDto Coordinates,
    TimezoneDto TimeZone
);

public record LoginDto(
    string Uuid,
    string Username,
    string Password,
    string Salt,
    string Md5,
    string Sha1,
    string Sha256
);

public record DateOfBirthDto(DateTime Date, int Age);

public record RegisteredDto(DateTime Date, int Age);

public record IdentificationDto(string Name, string Value);

public record PictureDto(string Large, string Medium, string Thumbnail);

public record UserDto(
    [Required] string Gender,
    [Required] NameDto Name,
    [Required] LocationDto Location,
    [Required] string Email,
    [Required] LoginDto Login,
    [Required] DateOfBirthDto Dob,
    [Required] RegisteredDto Registered,
    [Required] string Phone,
    [Required] string Cell,
    [Required] IdentificationDto Id,
    [Required] PictureDto Picture,
    [Required] string Nat
);

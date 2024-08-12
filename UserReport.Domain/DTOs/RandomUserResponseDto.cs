namespace UserReport.Domain.DTOs;

public record RandomUserResponseDto(List<UserDto> Results, InfoDto Info);

public record InfoDto(string Seed, int Results, int Page, string Version);

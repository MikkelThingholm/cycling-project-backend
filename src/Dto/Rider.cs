namespace App.Dto;

public record RiderResponse(
    int Id,
    string FirstName,
    string LastName,
    string Slug,
    DateOnly BirthDate,
    NationResponse Nation,
    List<RiderTeamDto> Teams
);

public record RiderTeamDto(
    string TeamName,
    int TeamOrganizationId,
    short TeamYear,
    DateOnly JoinDate,
    DateOnly LeaveDate
);


public record RiderSimpleResponse(
    int Id,
    string FirstName,
    string LastName,
    string Slug,
    DateOnly BirthDate,
    int NationId
);

public record RiderCreateRequest(
    string FirstName,
    string LastName,
    string Slug,
    int NationId,
    DateOnly BirthDate
);

public record RiderUpdateRequest(
    string FirstName,
    string LastName,
    string Slug,
    int NationId,
    DateOnly BirthDate
);
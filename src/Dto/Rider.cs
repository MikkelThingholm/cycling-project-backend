namespace App.Dto;

public record RiderResponse(
    int Id,
    string FirstName,
    string LastName,
    DateOnly BirthDate,
    NationResponse Nation,
    List<RiderTeamResponse> RiderTeams
);

public record RiderSimpleResponse(
    int Id,
    string FirstName,
    string LastName,
    DateOnly BirthDate,
    int NationId
);

public record RiderCreateRequest(
    string FirstName,
    string LastName,
    int NationId,
    DateOnly BirthDate
);

public record RiderUpdateRequest(
    string FirstName,
    string LastName,
    int NationId,
    DateOnly BirthDate
);
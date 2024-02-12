
namespace App.Dto;

public record RiderResponse(
    int Id,
    string FirstName,
    string LastName,
    string Nation,
    DateOnly BirthDate
);

public record RiderCreateRequest(
    string FirstName,
    string LastName,
    string Nation,
    DateOnly BirthDate
);

public record RiderUpdateRequest(
    string FirstName,
    string LastName,
    string Nation,
    DateOnly BirthDate
);
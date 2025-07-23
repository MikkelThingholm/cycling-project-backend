namespace App.Dto;

public record RaceEditionResponse(
    int Id,
    string Name,
    short Year,
    DateOnly StartDate,
    DateOnly EndDate,
    RaceSimpleResponse Race,
    ICollection<StageSimpleResponse> Stages
);

public record RaceEditionSimpleResponse(
    int Id,
    string Name,
    short Year,
    DateOnly StartDate,
    DateOnly EndDate,
    int RaceId
);


public record RaceEditionCreateRequest(
    string Name,
    short Year,
    DateOnly StartDate,
    DateOnly EndDate,
    int RaceId
);

public record RaceEditionUpdateRequest(
    string Name,
    short Year,
    DateOnly StartDate,
    DateOnly EndDate,
    int RaceId
);

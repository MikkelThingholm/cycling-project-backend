namespace App.Dto;

public record RaceResponse(
    int Id,
    string Name,
    NationResponse Nation,
    ICollection<RaceEditionResponse> RaceEditions
);

public record RaceSimpleResponse(
    int Id,
    string Name,
    int NationId
);


public record RaceCreateRequest(
    string Name,
    int NationId
);

public record RaceUpdateRequest(
    string Name,
    int NationId
);

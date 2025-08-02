namespace App.Dto;

public record RaceResponse(
    int Id,
    string Name,
    string Slug,
    NationResponse Nation,
    List<RaceEditionResponse> RaceEditions
);

public record RaceSimpleResponse(
    int Id,
    string Name,
    string Slug,
    int NationId
);

public record RaceCreateRequest(
    string Name,
    string Slug,
    int NationId
);

public record RaceUpdateRequest(
    string Name,
    string Slug,
    int NationId
);

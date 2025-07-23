namespace App.Dto;

public record StageResultStatusCodeResponse(
    int Id,
    string Name,
    string NameAbbreviation
);

public record StageResultStatusCodeCreateRequest(
    string Name,
    string NameAbbreviation
);

public record StageResultStatusCodeUpdateRequest(
    string Name,
    string NameAbbreviation
);

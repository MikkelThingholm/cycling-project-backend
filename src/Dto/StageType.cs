namespace App.Dto;

public record StageTypeResponse(
    int Id,
    string Name
);

public record StageTypeCreateRequest(
    string Name
);

public record StageTypeUpdateRequest(
    string Name
);
namespace App.Dto;

public record MountainResponse(
    int Id,
    string Name
);

public record MountainCreateRequest(
    string Name
);

public record MountainUpdateRequest(
    string Name
);

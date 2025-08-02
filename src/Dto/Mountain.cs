namespace App.Dto;

public record MountainResponse(
    int Id,
    string Name,
    string Slug
);

public record MountainCreateRequest(
    string Name,
    string Slug
);

public record MountainUpdateRequest(
    string Name,
    string Slug
);

namespace App.Dto;

public record NationResponse(
    int Id,
    string Name,
    bool StillExists
);

public record NationCreateRequest(
    string Name,
    bool StillExists
);

public record NationPutRequest(
    string Name,
    bool StillExists
);

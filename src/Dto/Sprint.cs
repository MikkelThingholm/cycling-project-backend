namespace App.Dto;

//TODO: Add Stage and sprint Results
public record SprintResponse(
    int Id,
    string Name,
    int DistanceFromStartMeters,
    bool IsFinish,
    ICollection<SprintResultResponse> SprintResults,
    StageSimpleResponse Stage
);

public record SprintSimpleResponse(
    int Id,
    string Name,
    int DistanceFromStartMeters,
    bool IsFinish,
    int StageId
);

public record SprintCreateRequest(
    string Name,
    int DistanceFromStartMeters,
    bool IsFinish,
    int StageId
);

public record SprintUpdateRequest(
    string Name,
    int DistanceFromStartMeters,
    bool IsFinish,
    int StageId
);

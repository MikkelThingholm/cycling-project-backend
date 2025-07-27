namespace App.Dto;

public record StageResponse(
    int Id,
    short StageNumber,
    string StartLocation,
    string FinishLocation,
    DateOnly Date,
    int DistanceMeters,
    RaceEditionSimpleResponse RaceEdition,
    StageTypeResponse StageType,
    List<SprintSimpleResponse> Sprints,
    List<MountainClimbSimpleResponse> MountainClimbs,
    List<StageTeamResultSimpleResponse> StageTeamResults,
    List<StageRiderResultSimpleResponse> StageRiderResults
);

public record StageSimpleResponse(
    int Id,
    short StageNumber,
    string StartLocation,
    string FinishLocation,
    DateOnly Date,
    int DistanceMeters,
    int RaceEditionId,
    int StageTypeId
);

public record StageCreateRequest(
    short StageNumber,
    string StartLocation,
    string FinishLocation,
    DateOnly Date,
    int DistanceMeters,
    int RaceEditionId,
    int StageTypeId
);

public record StageUpdateRequest(
    short StageNumber,
    string StartLocation,
    string FinishLocation,
    DateOnly Date,
    int DistanceMeters,
    int RaceEditionId,
    int StageTypeId
);
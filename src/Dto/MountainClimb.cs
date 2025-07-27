namespace App.Dto;

public record MountainClimbResponse(
    int Id,
    int ClimbLengthMeter,
    float AverageSlope,
    int DistanceFromStartMeters,
    bool IsFinish,
    MountainResponse Mountain,
    StageSimpleResponse Stage
);

public record MountainClimbSimpleResponse(
    int Id,
    int ClimbLengthMeter,
    float AverageSlope,
    int DistanceFromStartMeters,
    bool IsFinish,
    int MountainId,
    int StageId
);

public record MountainClimbCreateRequest(
    int MountainId,
    int StageId,
    int ClimbLengthMeter,
    float AverageSlope,
    int DistanceFromStartMeters,
    bool IsFinish
);

public record MountainClimbUpdateRequest(
    int MountainId,
    int StageId,
    int ClimbLengthMeter,
    float AverageSlope,
    int DistanceFromStartMeters,
    bool IsFinish
);

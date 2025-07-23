namespace App.Dto;

public record MountainClimbResultResponse(
    int Id,
    short Placement,
    short MountainPoints,
    short BonusSeconds,
    MountainClimbResponse MountainClimb
);

public record MountainClimbResultSimpleResponse(
    int Id,
    short Placement,
    short MountainPoints,
    short BonusSeconds,
    int MountainClimbId
);

public record MountainClimbResultCreateRequest(
    short Placement,
    short MountainPoints,
    short BonusSeconds,
    int MountainClimbId
);

public record MountainClimbResultUpdateRequest(
    short Placement,
    short MountainPoints,
    short BonusSeconds,
    int MountainClimbId
);

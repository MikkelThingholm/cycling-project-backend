namespace App.Dto;

public record StageRiderStandingResponse(
    int Id,
    short Placement,
    int TimeMilliseconds,
    short TimePenaltySeconds,
    short BonusSeconds,
    short SprintPoints,
    short SprintPointsPenalty,
    short MountainPoints,
    short MountainPointsPenalty,
    StageSimpleResponse Stage,
    RaceRiderParticipationResponse RaceRiderParticipation
);

public record StageRiderStandingSimpleResponse(
    int Id,
    short Placement,
    int TimeMilliseconds,
    short TimePenaltySeconds,
    short BonusSeconds,
    short SprintPoints,
    short SprintPointsPenalty,
    short MountainPoints,
    short MountainPointsPenalty,
    int StageId,
    int RaceRiderParticipationId
);

public record StageRiderStandingCreateRequest(
    short Placement,
    int TimeMilliseconds,
    short TimePenaltySeconds,
    short BonusSeconds,
    short SprintPoints,
    short SprintPointsPenalty,
    short MountainPoints,
    short MountainPointsPenalty,
    int StageId,
    int RaceRiderParticipationId
);

public record StageRiderStandingUpdateRequest(
    short Placement,
    int TimeMilliseconds,
    short TimePenaltySeconds,
    short BonusSeconds,
    short SprintPoints,
    short SprintPointsPenalty,
    short MountainPoints,
    short MountainPointsPenalty,
    int StageId,
    int RaceRiderParticipationId
);

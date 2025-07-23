namespace App.Dto;

public record SprintResultResponse(
    int Id,
    short Placement,
    short Points,
    short BonusSeconds,
    SprintSimpleResponse Sprint,
    RaceRiderParticipationResponse RaceRiderParticipation
);

public record SprintResultSimpleResponse(
    int Id,
    short Placement,
    short Points,
    short BonusSeconds,
    int SprintId,
    int RaceRiderParticipationId
);

public record SprintResultCreateRequest(
    short Placement,
    short Points,
    short BonusSeconds,
    int SprintId,
    int RaceRiderParticipationId
);

public record SprintResultUpdateRequest(
    short Placement,
    short Points,
    short BonusSeconds,
    int SprintId,
    int RaceRiderParticipationId
);
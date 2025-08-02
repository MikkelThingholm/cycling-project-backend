namespace App.Dto;

public record StageRiderResultResponse(
    int Id,
    short Placement,
    int FinishTimeMilliseconds,
    StageSimpleResponse Stage,
    RaceRiderParticipationResponse RaceRiderParticipation
);

public record StageRiderResultSimpleResponse(
    int Id,
    short Placement,
    int FinishTimeMilliseconds,
    int StageId,
    int RaceRiderParticipationId

);

public record StageRiderResultCreateRequest(
    short Placement,
    int FinishTimeMilliseconds,
    int StageId,
    int RaceRiderParticipationId
);

public record StageRiderResultUpdateRequest(
    short Placement,
    int FinishTimeMilliseconds,
    int StageId,
    int RaceRiderParticipationId
);
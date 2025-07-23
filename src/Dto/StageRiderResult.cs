namespace App.Dto;

public record StageRiderResultResponse(
    int Id,
    short Placement,
    int FinishTimeMilliseconds,
    StageSimpleResponse Stage,
    RaceRiderParticipationResponse RaceRiderParticipation,
    StageResultStatusCodeResponse StageResultStatusCode
);

public record StageRiderResultSimpleResponse(
    int Id,
    short Placement,
    int FinishTimeMilliseconds,
    int StageId,
    int RaceRiderParticipationId,
    int StageFinishStatusCodeId
);

public record StageRiderResultCreateRequest(
    short Placement,
    int FinishTimeMilliseconds,
    int StageId,
    int RaceRiderParticipationId,
    int StageFinishStatusCodeId
);

public record StageRiderResultUpdateRequest(
    short Placement,
    int FinishTimeMilliseconds,
    int StageId,
    int RaceRiderParticipationId,
    int StageFinishStatusCodeId
);
namespace App.Dto;

public record StageDidNotStartResponse(
    int Id,
    StageSimpleResponse Stage,
    RaceRiderParticipationResponse RaceRiderParticipation
);

public record StageDidNotStartSimpleResponse(
    int Id,
    int StageId,
    int RaceRiderParticipationId
);

public record StageDidNotStartCreateRequest(
    int StageId,
    int RaceRiderParticipationId
);

public record StageDidNotStartUpdateRequest(
    int StageId,
    int RaceRiderParticipationId
);

using App.EntityModels;

namespace App.Dto;

public record StageNonFinishResponse(
    int Id,
    StageSimpleResponse Stage,
    RaceRiderParticipationResponse RaceRiderParticipation,
    NonFinishStatus Status
);

public record StageNonFinishSimpleResponse(
    int Id,
    int StageId,
    int RaceRiderParticipationId,
    NonFinishStatus Status
);

public record StageNonFinishCreateRequest(
    int StageId,
    int RaceRiderParticipationId,
    NonFinishStatus Status
);

public record StageNonFinishUpdateRequest(
    int StageId,
    int RaceRiderParticipationId,
    NonFinishStatus Status
);

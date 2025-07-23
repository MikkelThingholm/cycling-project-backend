namespace App.Dto;

public record StageCombatativeAwardResponse(
    int Id,
    StageSimpleResponse Stage,
    RaceRiderParticipationResponse RaceRiderParticipation
);

public record StageCombatativeAwardSimpleResponse(
    int Id,
    int StageId,
    int RaceRiderParticipationId
);

public record StageCombatativeAwardCreateRequest(
    int StageId,
    int RaceRiderParticipationId
);

public record StageCombatativeAwardUpdateRequest(
    int StageId,
    int RaceRiderParticipationId
);

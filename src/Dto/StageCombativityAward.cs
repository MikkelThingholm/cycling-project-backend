namespace App.Dto;

public record StageCombativityAwardResponse(
    int Id,
    StageSimpleResponse Stage,
    RaceRiderParticipationResponse RaceRiderParticipation
);

public record StageCombativityAwardSimpleResponse(
    int Id,
    int StageId,
    int RaceRiderParticipationId
);

public record StageCombativityAwardCreateRequest(
    int StageId,
    int RaceRiderParticipationId
);

public record StageCombativityAwardUpdateRequest(
    int StageId,
    int RaceRiderParticipationId
);

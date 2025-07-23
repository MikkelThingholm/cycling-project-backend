namespace App.Dto;

public record StageTeamResultResponse(
    int Id,
    int Placement,
    int FinishTimeMilliseconds,
    StageSimpleResponse Stage,
    RaceTeamParticipationSimpleResponse RaceTeamParticipation
);

public record StageTeamResultSimpleResponse(
    int Id,
    int Placement,
    int FinishTimeMilliseconds,
    int StageId,
    int RaceTeamParticipationId
);

public record StageTeamResultCreateRequest(
    int Placement,
    int FinishTimeMilliseconds,
    int StageId,
    int RaceTeamParticipationId
);

public record StageTeamResultUpdateRequest(
    int Placement,
    int FinishTimeMilliseconds,
    int StageId,
    int RaceTeamParticipationId
);
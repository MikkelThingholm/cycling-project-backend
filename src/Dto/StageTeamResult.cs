namespace App.Dto;

public record StageTeamResultResponse(
    int Id,
    short Placement,
    int FinishTimeMilliseconds,
    StageSimpleResponse Stage,
    RaceTeamParticipationSimpleResponse RaceTeamParticipation
);

public record StageTeamResultSimpleResponse(
    int Id,
    short Placement,
    int FinishTimeMilliseconds,
    int StageId,
    int RaceTeamParticipationId
);

public record StageTeamResultCreateRequest(
    short Placement,
    int FinishTimeMilliseconds,
    int StageId,
    int RaceTeamParticipationId
);

public record StageTeamResultUpdateRequest(
    short Placement,
    int FinishTimeMilliseconds,
    int StageId,
    int RaceTeamParticipationId
);
namespace App.Dto;

public record StageTeamStandingResponse(
    int Id,
    int Placement,
    int TimeMilliseconds,
    short TimePenaltySeconds,
    short BonusSeconds,
    StageSimpleResponse Stage,
    RaceTeamParticipationSimpleResponse RaceTeamParticipation
);

public record StageTeamStandingSimpleResponse(
    int Id,
    int Placement,
    int TimeMilliseconds,
    short TimePenaltySeconds,
    short BonusSeconds,
    int StageId,
    int RaceTeamParticipationId
);

public record StageTeamStandingCreateRequest(
    int Placement,
    int TimeMilliseconds,
    short TimePenaltySeconds,
    short BonusSeconds,
    int StageId,
    int RaceTeamParticipationId
);

public record StageTeamStandingUpdateRequest(
    int Placement,
    int TimeMilliseconds,
    short TimePenaltySeconds,
    short BonusSeconds,
    int StageId,
    int RaceTeamParticipationId
);
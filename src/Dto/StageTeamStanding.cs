namespace App.Dto;

public record StageTeamStandingResponse(
    int Id,
    short Placement,
    int TimeMilliseconds,
    short TimePenaltySeconds,
    short BonusSeconds,
    StageSimpleResponse Stage,
    RaceTeamParticipationSimpleResponse RaceTeamParticipation
);

public record StageTeamStandingSimpleResponse(
    int Id,
    short Placement,
    int TimeMilliseconds,
    short TimePenaltySeconds,
    short BonusSeconds,
    int StageId,
    int RaceTeamParticipationId
);

public record StageTeamStandingCreateRequest(
    short Placement,
    int TimeMilliseconds,
    short TimePenaltySeconds,
    short BonusSeconds,
    int StageId,
    int RaceTeamParticipationId
);

public record StageTeamStandingUpdateRequest(
    short Placement,
    int TimeMilliseconds,
    short TimePenaltySeconds,
    short BonusSeconds,
    int StageId,
    int RaceTeamParticipationId
);
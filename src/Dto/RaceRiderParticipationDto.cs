namespace App.Dto;

public record RaceRiderParticipationResponse(
    int Id,
    RaceTeamParticipationSimpleResponse RaceTeamParticipation,
    RiderSimpleResponse Rider
);

public record RaceRiderParticipationSimpleResponse(
    int Id,
    int RaceTeamParticipationId,
    int RiderId
);

public record RaceRiderParticipationCreateRequest(
    int RaceTeamParticipationId,
    int RiderId
);

public record RaceRiderParticipationUpdateRequest(
    int RaceTeamParticipationId,
    int RiderId
);

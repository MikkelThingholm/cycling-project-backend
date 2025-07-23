namespace App.Dto;

public record RaceTeamParticipationResponse(
    int Id,
    RaceTeamParticipationSimpleResponse RaceTeamParticipation,
    RaceEditionSimpleResponse RaceEdition,
    ICollection<RaceRiderParticipationSimpleResponse> RaceRiderParticipations
);

public record RaceTeamParticipationSimpleResponse(
    int Id,
    int RaceEditionId,
    int TeamId,
    ICollection<RaceRiderParticipationSimpleResponse> RaceRiderParticipations
);

public record RaceTeamParticipationCreateRequest(
    int RaceEditionId,
    int TeamId
);

public record RaceTeamParticipationUpdateRequest(
    int RaceEditionId,
    int TeamId
);

namespace App.Dto;

public record RaceTeamParticipationResponse(
    int Id,
    TeamResponse Team,
    RaceEditionSimpleResponse RaceEdition,
    List<RaceRiderParticipationSimpleResponse> RaceRiderParticipations
);

public record RaceTeamParticipationSimpleResponse(
    int Id,
    int RaceEditionId,
    int TeamId,
    List<RaceRiderParticipationSimpleResponse> RaceRiderParticipations
);

public record RaceTeamParticipationCreateRequest(
    int TeamId
);

public record RaceTeamParticipationUpdateRequest(
    int RaceEditionId,
    int TeamId
);

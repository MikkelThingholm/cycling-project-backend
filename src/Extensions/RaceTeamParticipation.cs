using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class RaceTeamParticipationDtoExtension
{
    public static RaceTeamParticipationResponse ToResponseDto(this RaceTeamParticipation raceTeamParticipation)
    {
        return new RaceTeamParticipationResponse(
            Id: raceTeamParticipation.Id,
            Team: raceTeamParticipation.Team.ToResponseDto(),
            RaceEdition: raceTeamParticipation.RaceEdition.ToSimpleResponseDto(),
            RaceRiderParticipations: [.. raceTeamParticipation.RaceRiderParticipations.Select(r => r.ToSimpleResponseDto())]
        );
    }

    public static RaceTeamParticipationSimpleResponse ToSimpleResponseDto(this RaceTeamParticipation raceTeamParticipation)
    {
        return new RaceTeamParticipationSimpleResponse(
            Id: raceTeamParticipation.Id,
            RaceEditionId: raceTeamParticipation.RaceEditionId,
            TeamId: raceTeamParticipation.TeamId,
            RaceRiderParticipations: [.. raceTeamParticipation.RaceRiderParticipations.Select(r => r.ToSimpleResponseDto())]
        );
    }

    public static RaceTeamParticipation ToEntity(this RaceTeamParticipationCreateRequest request)
    {
        return new RaceTeamParticipation()
        {
            RaceEditionId = request.RaceEditionId,
            TeamId = request.TeamId
        };
    }

    public static void UpdateFromDto(this RaceTeamParticipation raceTeamParticipationEntity, RaceTeamParticipationUpdateRequest raceTeamParticipationUpdateRequest)
    {
        raceTeamParticipationEntity.RaceEditionId = raceTeamParticipationUpdateRequest.RaceEditionId;
        raceTeamParticipationEntity.TeamId = raceTeamParticipationUpdateRequest.TeamId;
    }

}
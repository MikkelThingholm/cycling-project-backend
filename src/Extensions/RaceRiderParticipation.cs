using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class RaceRiderParticipationDtoExtension
{
    public static RaceRiderParticipationResponse ToResponseDto(this RaceRiderParticipation raceRiderParticipation)
    {
        return new RaceRiderParticipationResponse(
            Id: raceRiderParticipation.Id,
            RaceTeamParticipation: raceRiderParticipation.RaceTeamParticipation.ToSimpleResponseDto(),
            Rider: raceRiderParticipation.Rider.ToSimpleResponseDto()
        );
    }
    public static RaceRiderParticipationSimpleResponse ToSimpleResponseDto(this RaceRiderParticipation raceRiderParticipation)
    {
        return new RaceRiderParticipationSimpleResponse(
            Id: raceRiderParticipation.Id,
            RaceTeamParticipationId: raceRiderParticipation.RaceTeamParticipationId,
            RiderId: raceRiderParticipation.RiderId
        );
    }
    /*
    public static RaceRiderParticipation ToEntity(this RaceRiderParticipationCreateRequest raceRiderParticipationCreateRequest)
    {
        return new RaceRiderParticipation()
        {
            RaceTeamParticipationId = raceRiderParticipationCreateRequest.RaceTeamParticipationId,
            RiderId = raceRiderParticipationCreateRequest.RiderId
        };
    }
    
    public static void UpdateFromDto(this RaceRiderParticipation raceRiderParticipationEntity, RaceRiderParticipationUpdateRequest raceRiderParticipationUpdateRequest)
    {
        raceRiderParticipationEntity.RaceTeamParticipationId = raceRiderParticipationUpdateRequest.RaceTeamParticipationId;
        raceRiderParticipationEntity.RiderId = raceRiderParticipationUpdateRequest.RiderId;
    }
    */
}
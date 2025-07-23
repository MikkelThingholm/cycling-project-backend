using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class RaceEditionDtoExtension
{
    public static RaceEditionResponse ToResponseDto(this RaceEdition raceEdition)
    {
        return new RaceEditionResponse(
            Id: raceEdition.Id,
            Name: raceEdition.Name,
            Year: raceEdition.Year,
            StartDate: raceEdition.StartDate,
            EndDate: raceEdition.EndDate,
            Race: raceEdition.Race.ToSimpleResponseDto(),
            Stages: null
        );
    }
    public static RaceEditionSimpleResponse ToSimpleResponseDto(this RaceEdition raceEdition)
    {
        return new RaceEditionSimpleResponse(
            Id: raceEdition.Id,
            Name: raceEdition.Name,
            Year: raceEdition.Year,
            StartDate: raceEdition.StartDate,
            EndDate: raceEdition.EndDate,
            RaceId: raceEdition.RaceId
        );
    }

    public static RaceEdition ToEntity(this RaceEditionCreateRequest raceEditionCreateRequest)
    {
        return new RaceEdition()
        {
            Name = raceEditionCreateRequest.Name,
            Year = raceEditionCreateRequest.Year,
            StartDate = raceEditionCreateRequest.StartDate,
            EndDate = raceEditionCreateRequest.EndDate,
            RaceId = raceEditionCreateRequest.RaceId
        };
    }


    public static void UpdateFromDto(this RaceEdition raceEditionEntity, RaceEditionUpdateRequest raceEditionUpdateRequest)
    {
        raceEditionEntity.Name = raceEditionUpdateRequest.Name;
        raceEditionEntity.Year = raceEditionUpdateRequest.Year;
        raceEditionEntity.StartDate = raceEditionUpdateRequest.StartDate;
        raceEditionEntity.EndDate = raceEditionUpdateRequest.EndDate;
        raceEditionEntity.RaceId = raceEditionUpdateRequest.RaceId;
    }
}
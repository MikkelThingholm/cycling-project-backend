using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class RaceDtoExtension
{
    public static RaceResponse ToResponseDto(this Race race)
    {
        return new RaceResponse(
            Id: race.Id,
            Name: race.Name,
            Nation: race.Nation.ToResponse(),
            RaceEditions: null!
        );
    }

    public static RaceSimpleResponse ToSimpleResponseDto(this Race race)
    {
        return new RaceSimpleResponse(
            Id: race.Id,
            Name: race.Name,
            NationId: race.NationId
        );
    }

    public static Race ToEntity(this RaceCreateRequest raceCreateRequest)
    {
        return new Race()
        {
            Name = raceCreateRequest.Name,
            NationId = raceCreateRequest.NationId
        };
    }

    public static Race ToEntity(this RaceUpdateRequest raceupdateRequest, int id)
    {
        return new Race()
        {
            Id = id,
            Name = raceupdateRequest.Name,
            NationId = raceupdateRequest.NationId
        };
    }
}
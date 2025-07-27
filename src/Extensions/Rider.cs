using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class RiderDtoExtensions
{
    public static RiderResponse ToResponseDto(this Rider riderEntity)
    {

        RiderResponse riderResponse = new(
            Id: riderEntity.Id,
            FirstName: riderEntity.FirstName,
            LastName: riderEntity.LastName,
            BirthDate: riderEntity.BirthDate,
            Nation: riderEntity.Nation.ToResponseDto(),
            RiderTeams: [.. riderEntity.RiderTeams.Select(rt => rt.ToResponseDto())]
        );
        return riderResponse;
    }

    public static RiderSimpleResponse ToSimpleResponseDto(this Rider riderEntity)
    {
        return new RiderSimpleResponse(
            Id: riderEntity.Id,
            FirstName: riderEntity.FirstName,
            LastName: riderEntity.LastName,
            BirthDate: riderEntity.BirthDate,
            NationId: riderEntity.NationId
        );
    }


    public static Rider ToEntity(this RiderCreateRequest riderCreateRequest)
    {
        return new Rider()
        {
            FirstName = riderCreateRequest.FirstName,
            LastName = riderCreateRequest.LastName,
            NationId = riderCreateRequest.NationId,
            BirthDate = riderCreateRequest.BirthDate
        };
    }

    public static void UpdateFromDto(this Rider riderEntity, RiderUpdateRequest riderUpdateRequest)
    {
        riderEntity.FirstName = riderUpdateRequest.FirstName;
        riderEntity.LastName = riderUpdateRequest.LastName;
        riderEntity.NationId = riderUpdateRequest.NationId;
        riderEntity.BirthDate = riderUpdateRequest.BirthDate;
    }

}


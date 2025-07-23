
using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class DtoExtensions
{
    public static RiderResponse ToResponseDto(this Rider riderEntity)
    {

        RiderResponse riderResponse = new(
            Id: riderEntity.Id,
            FirstName: riderEntity.FirstName,
            LastName: riderEntity.LastName,
            BirthDate: riderEntity.BirthDate,
            Nation: null!,
            RiderTeam: null!
        );
        return riderResponse;
    }

    public static RiderSimpleResponse ToCreateResponseDto(this Rider riderEntity)
    {
        return new RiderSimpleResponse(
            Id: riderEntity.Id,
            FirstName: riderEntity.FirstName,
            LastName: riderEntity.LastName,
            BirthDate: riderEntity.BirthDate,
            NationId: riderEntity.NationId
        );
    }

    public static RiderSimpleResponse ToUpdateResponseDto(this Rider riderEntity)
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

    public static Rider ToEntity(this RiderUpdateRequest riderUpdateRequest, int id)
    {
        return new Rider()
        {
            Id = id,
            FirstName = riderUpdateRequest.FirstName,
            LastName = riderUpdateRequest.LastName,
            NationId = riderUpdateRequest.NationId,
            BirthDate = riderUpdateRequest.BirthDate
        };
    }

}


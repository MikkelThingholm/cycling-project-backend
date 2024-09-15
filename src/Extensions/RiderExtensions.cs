
using App.Dto;
using App.EntityModels;

namespace App.Extenstions;

public static class DtoExtensions
{
    public static RiderResponse ToDto(this Rider riderEntiy)
    {
        NationResponse? riderNation = null;
        if (riderEntiy.Nation is not null)
        {
            riderNation = riderEntiy.Nation.ToDto() ;
        }
        RiderResponse riderResponse = new(
            Id: riderEntiy.Id,
            FirstName: riderEntiy.FirstName,
            LastName: riderEntiy.LastName,
            BirthDate: riderEntiy.BirthDate,
            Nation: riderNation
        );
        return riderResponse;
    }

    public static RiderCreateResponse ToDtoCreate(this Rider riderEntity)
    {
        return new RiderCreateResponse(
            Id: riderEntity.Id,
            FirstName: riderEntity.FirstName,
            LastName: riderEntity.LastName,
            BirthDate: riderEntity.BirthDate,
            NationId: riderEntity.NationId
        );
    }

    public static RiderUpdateResponse ToDtoUpdate(this Rider riderEntity)
    {
        return new RiderUpdateResponse(
            Id: riderEntity.Id,
            FirstName: riderEntity.FirstName,
            LastName: riderEntity.LastName,
            BirthDate: riderEntity.BirthDate,
            NationId: riderEntity.NationId
        );
    }

    public static Rider ToEntity(this RiderCreateRequest riderCreateRequest)
    {
        return new Rider(){
            FirstName = riderCreateRequest.FirstName,
            LastName = riderCreateRequest.LastName,
            NationId = riderCreateRequest.NationId,
            BirthDate = riderCreateRequest.BirthDate
        };
    }
    
    public static Rider ToEntity(this RiderUpdateRequest riderUpdateRequest, int id)
    {
        return new Rider(){
            Id = id,
            FirstName = riderUpdateRequest.FirstName,
            LastName = riderUpdateRequest.LastName,
            NationId = riderUpdateRequest.NationId,
            BirthDate = riderUpdateRequest.BirthDate
        };
    }
    
}


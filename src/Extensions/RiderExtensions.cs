
using App.Dto;
using App.EntityModels;

namespace App.Extenstions;

public static class DtoExtensions
{
    public static RiderResponse ToDto(this Rider rider){
        NationResponse? riderNation = null;
        if (rider.Nation is not null)
        {
            riderNation = rider.Nation.ToDto() ;
        }
        RiderResponse riderResponse = new(
            Id: rider.Id,
            FirstName: rider.FirstName,
            LastName: rider.LastName,
            BirthDate: rider.BirthDate,
            Nation: riderNation
        );
        return riderResponse;
    }



    public static Rider ToEntity(this RiderCreateRequest riderCreateRequest){
        return new Rider(){
            FirstName = riderCreateRequest.FirstName,
            LastName = riderCreateRequest.LastName,
            NationId = riderCreateRequest.NationId,
            BirthDate = riderCreateRequest.BirthDate
        };
    }

    public static Rider ToEntity(this RiderUpdateRequest riderUpdateRequest){
        return new Rider(){
            FirstName = riderUpdateRequest.FirstName,
            LastName = riderUpdateRequest.LastName,
            BirthDate = riderUpdateRequest.BirthDate
        };
    }
}


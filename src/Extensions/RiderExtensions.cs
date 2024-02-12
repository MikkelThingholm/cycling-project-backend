
using App.Dto;
using App.EntityModels;

namespace App.Extenstions;

public static class EntityExtensions
{


    public static RiderResponse ToDto(this Rider rider){
        return new RiderResponse(
            Id: rider.Id,
            FirstName: rider.FirstName,
            LastName: rider.LastName,
            Nation: rider.Nation,
            BirthDate: rider.BirthDate
        );
    }



    public static Rider ToEntity(this RiderCreateRequest riderCreateRequest){
        return new Rider(){
            FirstName = riderCreateRequest.FirstName,
            LastName = riderCreateRequest.LastName,
            Nation = riderCreateRequest.Nation,
            BirthDate = riderCreateRequest.BirthDate
        };
    }

    public static Rider ToEntity(this RiderUpdateRequest riderUpdateRequest){
        return new Rider(){
            FirstName = riderUpdateRequest.FirstName,
            LastName = riderUpdateRequest.LastName,
            Nation = riderUpdateRequest.Nation,
            BirthDate = riderUpdateRequest.BirthDate
        };
    }
}
using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class NationDtoExtensions
{
    public static NationResponse ToResponseDto(this Nation nation)
    {
        return new NationResponse(
            Id: nation.Id,
            Name: nation.Name,
            StillExists: nation.StillExists
        );
    }

    public static Nation ToEntity(this NationCreateRequest nation)
    {
        return new Nation()
        {
            Name = nation.Name,
            StillExists = nation.StillExists
        };
    }

    public static void UpdateFromDto(this Nation nationEntity, NationUpdateRequest nationUpdateRequest)
    {
        nationEntity.Name = nationUpdateRequest.Name;
        nationEntity.StillExists = nationUpdateRequest.StillExists;
    }

}


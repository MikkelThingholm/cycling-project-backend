using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class NationDtoExtensions
{
    public static NationResponse ToResponse(this Nation nation)
    {
        return new NationResponse(
            Id: nation.Id,
            Name: nation.Name,
            StillExists: nation.StillExists
        );
    }

    public static Nation ToNation(this NationCreateRequest nation)
    {
        return new Nation()
        {
            Name = nation.Name,
            StillExists = nation.StillExists
        };
    }

    public static Nation ToNation(this NationUpdateRequest nation, int id)
    {
        return new Nation()
        {
            Id = id,
            Name = nation.Name,
            StillExists = nation.StillExists
        };
    }

}


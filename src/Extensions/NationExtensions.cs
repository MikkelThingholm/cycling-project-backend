
using App.Dto;
using App.EntityModels;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace App.Extenstions;

public static class NationDtoExtensions
{
    public static NationResponse ToDto(this Nation nation)
    {
        return new NationResponse(
            Id: nation.Id,
            Name: nation.Name,
            StillExists: nation.StillExists
        );
    }

    public static Nation ToEntity(this NationCreateRequest nation)
    {
        return new Nation(){
            Name = nation.Name,
            StillExists= nation.StillExists
        };
    }

}


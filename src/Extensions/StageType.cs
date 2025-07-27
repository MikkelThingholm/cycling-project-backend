using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class StageTypeDtoExtensions
{
    public static StageTypeResponse ToResponseDto(this StageType stageType)
    {
        return new StageTypeResponse(
            Id: stageType.Id,
            Name: stageType.Name
        );
    }

}
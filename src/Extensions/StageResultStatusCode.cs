using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class StageResultStatusCodeDtoExtensions
{
    public static StageResultStatusCodeResponse ToResponseDto(this StageResultStatusCode stageResultStatusCode)
    {
        return new StageResultStatusCodeResponse(
            Id: stageResultStatusCode.Id,
            Name: stageResultStatusCode.Name,
            NameAbbreviation: stageResultStatusCode.NameAbbreviation
        );
    }
}
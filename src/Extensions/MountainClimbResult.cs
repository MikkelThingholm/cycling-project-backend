using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class MountainClimbResultDtoExtension
{
    public static MountainClimbResultResponse ToResponseDto(this MountainClimbResult mountainClimbResult)
    {
        return new MountainClimbResultResponse(
            Id: mountainClimbResult.Id,
            Placement: mountainClimbResult.Placement,
            MountainPoints: mountainClimbResult.MountainPoints,
            BonusSeconds: mountainClimbResult.BonusSeconds,
            MountainClimb: mountainClimbResult.MountainClimb.ToResponseDto()
        );
    }

    public static MountainClimbResultSimpleResponse ToSimpleResponseDto(this MountainClimbResult mountainClimbResult)
    {
        return new MountainClimbResultSimpleResponse(
            Id: mountainClimbResult.Id,
            Placement: mountainClimbResult.Placement,
            MountainPoints: mountainClimbResult.MountainPoints,
            BonusSeconds: mountainClimbResult.BonusSeconds,
            MountainClimbId: mountainClimbResult.MountainClimbId
        );
    }

    public static MountainClimbResult ToEntity(this MountainClimbResultCreateRequest mountainClimbResultCreateRequest)
    {
        return new MountainClimbResult()
        {
            Placement = mountainClimbResultCreateRequest.Placement,
            MountainPoints = mountainClimbResultCreateRequest.MountainPoints,
            BonusSeconds = mountainClimbResultCreateRequest.BonusSeconds,
            MountainClimbId = mountainClimbResultCreateRequest.MountainClimbId
        };
    }

}
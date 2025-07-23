using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class MountainClimbDtoExtension
{
    public static MountainClimbResponse ToResponseDto(this MountainClimb mountainClimb)
    {
        return new MountainClimbResponse(
            Id: mountainClimb.Id,
            ClimbLengthMeter: mountainClimb.ClimbLengthMeter,
            AverageSlope: mountainClimb.AverageSlope,
            DistanceFromStartMeter: mountainClimb.DistanceFromStartMeters,
            IsFinish: mountainClimb.IsFinish,
            Mountain: mountainClimb.Mountain.ToResponseDto(),
            Stage: null
        );
    }
    public static MountainClimbSimpleResponse ToSimpleResponseDto(this MountainClimb mountainClimb)
    {
        return new MountainClimbSimpleResponse(
            Id: mountainClimb.Id,
            ClimbLengthMeter: mountainClimb.ClimbLengthMeter,
            AverageSlope: mountainClimb.AverageSlope,
            DistanceFromStartMeter: mountainClimb.DistanceFromStartMeters,
            IsFinish: mountainClimb.IsFinish,
            MountainId: mountainClimb.MountainId,
            StageId: mountainClimb.StageId
        );
    }

    public static MountainClimb ToEntity(this MountainClimbCreateRequest mountainClimbCreateRequest)
    {
        return new MountainClimb()
        {
            MountainId = mountainClimbCreateRequest.MountainId,
            StageId = mountainClimbCreateRequest.StageId,
            ClimbLengthMeter = mountainClimbCreateRequest.ClimbLengthMeter,
            AverageSlope = mountainClimbCreateRequest.AverageSlope,
            DistanceFromStartMeters = mountainClimbCreateRequest.DistanceFromStartMeter,
            IsFinish = mountainClimbCreateRequest.IsFinish
        };
    }

    public static MountainClimb ToEntity(this MountainClimbUpdateRequest mountainClimbUpdateRequest, int id)
    {
        return new MountainClimb()
        {
            Id = id,
            MountainId = mountainClimbUpdateRequest.MountainId,
            StageId = mountainClimbUpdateRequest.StageId,
            ClimbLengthMeter = mountainClimbUpdateRequest.ClimbLengthMeter,
            AverageSlope = mountainClimbUpdateRequest.AverageSlope,
            DistanceFromStartMeters = mountainClimbUpdateRequest.DistanceFromStartMeter,
            IsFinish = mountainClimbUpdateRequest.IsFinish
        };
    }
}
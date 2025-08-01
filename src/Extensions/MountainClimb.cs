using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class MountainClimbDtoExtension
{
    public static MountainClimbResponse ToResponseDto(this MountainClimb mountainClimb)
    {
        return new MountainClimbResponse(
            Id: mountainClimb.Id,
            ClimbLengthMeter: mountainClimb.ClimbLengthMeters,
            AverageSlope: mountainClimb.AverageSlope,
            DistanceFromStartMeters: mountainClimb.DistanceFromStartMeter,
            IsFinish: mountainClimb.IsFinish,
            Mountain: mountainClimb.Mountain.ToResponseDto(),
            Stage: mountainClimb.Stage.ToSimpleResponseDto()
        );
    }
    public static MountainClimbSimpleResponse ToSimpleResponseDto(this MountainClimb mountainClimb)
    {
        return new MountainClimbSimpleResponse(
            Id: mountainClimb.Id,
            ClimbLengthMeter: mountainClimb.ClimbLengthMeters,
            AverageSlope: mountainClimb.AverageSlope,
            DistanceFromStartMeters: mountainClimb.DistanceFromStartMeter,
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
            ClimbLengthMeters = mountainClimbCreateRequest.ClimbLengthMeter,
            AverageSlope = mountainClimbCreateRequest.AverageSlope,
            DistanceFromStartMeter = mountainClimbCreateRequest.DistanceFromStartMeters,
            IsFinish = mountainClimbCreateRequest.IsFinish
        };
    }

    public static void UpdateFromDto(this MountainClimb mountainClimbEntity, MountainClimbUpdateRequest mountainClimbUpdateRequest)
    {
        mountainClimbEntity.MountainId = mountainClimbUpdateRequest.MountainId;
        mountainClimbEntity.StageId = mountainClimbUpdateRequest.StageId;
        mountainClimbEntity.ClimbLengthMeters = mountainClimbUpdateRequest.ClimbLengthMeter;
        mountainClimbEntity.AverageSlope = mountainClimbUpdateRequest.AverageSlope;
        mountainClimbEntity.DistanceFromStartMeter = mountainClimbUpdateRequest.DistanceFromStartMeters;
        mountainClimbEntity.IsFinish = mountainClimbUpdateRequest.IsFinish;
    }

}
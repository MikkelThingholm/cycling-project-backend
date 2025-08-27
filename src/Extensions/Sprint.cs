using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class SprintDtoExtensions
{
    public static SprintResponse ToResponseDto(this Sprint sprintEntity)
    {
        return new SprintResponse(
            Id: sprintEntity.Id,
            Name: sprintEntity.Name,
            DistanceFromStartMeters: sprintEntity.DistanceFromStartMeters,
            IsFinish: sprintEntity.IsFinish,
            Stage: sprintEntity.Stage.ToSimpleResponseDto(),
            SprintResults: [.. sprintEntity.SprintResults.Select(sr => sr.ToResponseDto())]
        );
    }

    public static SprintSimpleResponse ToSimpleResponseDto(this Sprint sprintEntity)
    {
        return new SprintSimpleResponse(
            Id: sprintEntity.Id,
            Name: sprintEntity.Name,
            DistanceFromStartMeters: sprintEntity.DistanceFromStartMeters,
            IsFinish: sprintEntity.IsFinish,
            StageId: sprintEntity.StageId
        );
    }

    public static Sprint ToEntity(this SprintCreateRequest sprintCreateRequest, int stageId)
    {
        return new Sprint()
        {
            Name = sprintCreateRequest.Name,
            StageId = stageId,
            DistanceFromStartMeters = sprintCreateRequest.DistanceFromStartMeters,
            IsFinish = sprintCreateRequest.IsFinish
        };
    }

    public static void UpdateFromDto(this Sprint sprintEntity, SprintUpdateRequest sprintUpdateRequest)
    {
        sprintEntity.Name = sprintUpdateRequest.Name;
        sprintEntity.StageId = sprintUpdateRequest.StageId;
        sprintEntity.DistanceFromStartMeters = sprintUpdateRequest.DistanceFromStartMeters;
        sprintEntity.IsFinish = sprintUpdateRequest.IsFinish;
    }
}
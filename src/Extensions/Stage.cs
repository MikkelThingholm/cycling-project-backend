using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class StageDtoExtensions
{
    public static StageResponse ToResponseDto(this Stage stage)
    {
        return new StageResponse(
            Id: stage.Id,
            StageNumber: stage.StageNumber,
            StartLocation: stage.StartLocation,
            FinishLocation: stage.FinishLocation,
            Date: stage.Date,
            DistanceMeters: stage.DistanceMeters,
            RaceEdition: stage.RaceEdition.ToSimpleResponseDto(),
            StageType: stage.StageType.ToResponseDto(),
            Sprints: [.. stage.Sprints.Select(s => s.ToSimpleResponseDto())],
            MountainClimbs: [.. stage.MountainClimbs.Select(m => m.ToSimpleResponseDto())],
            StageTeamResults: [.. stage.StageTeamResults.Select(str => str.ToSimpleResponseDto())],
            StageRiderResults: [.. stage.StageRiderResults.Select(srr => srr.ToSimpleResponseDto())]
        );
    }

    public static StageSimpleResponse ToSimpleResponseDto(this Stage stage)
    {
        return new StageSimpleResponse(
            Id: stage.Id,
            StageNumber: stage.StageNumber,
            StartLocation: stage.StartLocation,
            FinishLocation: stage.FinishLocation,
            Date: stage.Date,
            DistanceMeters: stage.DistanceMeters,
            RaceEditionId: stage.RaceEditionId,
            StageTypeId: stage.StageTypeId
        );
    }

    public static Stage ToEntity(this StageCreateRequest stageCreateRequest)
    {
        return new Stage()
        {
            StageNumber = stageCreateRequest.StageNumber,
            StartLocation = stageCreateRequest.StartLocation,
            FinishLocation = stageCreateRequest.FinishLocation,
            Date = stageCreateRequest.Date,
            DistanceMeters = stageCreateRequest.DistanceMeters,
            RaceEditionId = stageCreateRequest.RaceEditionId,
            StageTypeId = stageCreateRequest.StageTypeId
        };
    }

    public static void UpdateFromDto(this Stage stageEntity, StageUpdateRequest stageUpdateRequest)
    {
        stageEntity.StageNumber = stageUpdateRequest.StageNumber;
        stageEntity.StartLocation = stageUpdateRequest.StartLocation;
        stageEntity.FinishLocation = stageUpdateRequest.FinishLocation;
        stageEntity.Date = stageUpdateRequest.Date;
        stageEntity.DistanceMeters = stageUpdateRequest.DistanceMeters;
        stageEntity.RaceEditionId = stageUpdateRequest.RaceEditionId;
        stageEntity.StageTypeId = stageUpdateRequest.StageTypeId;
    }
}
using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class StageNonFinishtDtoExtensions
{
    public static StageNonFinishResponse ToResponseDto(this StageNonFinish stageNonFinish)
    {
        return new StageNonFinishResponse(
            Id: stageNonFinish.Id,
            Stage: stageNonFinish.Stage.ToSimpleResponseDto(),
            RaceRiderParticipation: stageNonFinish.RaceRiderParticipation.ToResponseDto(),
            Status: stageNonFinish.Status
        );
    }

    public static StageNonFinishSimpleResponse ToSimpleResponseDto(this StageNonFinish stageNonFinish)
    {
        return new StageNonFinishSimpleResponse(
            Id: stageNonFinish.Id,
            StageId: stageNonFinish.StageId,
            RaceRiderParticipationId: stageNonFinish.RaceRiderParticipationId,
            Status: stageNonFinish.Status
        );
    }

    public static StageNonFinish ToEntity(this StageNonFinishCreateRequest stageNonFinishCreateRequest)
    {
        return new StageNonFinish()
        {
            StageId = stageNonFinishCreateRequest.StageId,
            RaceRiderParticipationId = stageNonFinishCreateRequest.RaceRiderParticipationId,
            Status = stageNonFinishCreateRequest.Status
        };
    }
    public static void UpdateFromDto(this StageNonFinish stageNonFinishEntity, StageNonFinishUpdateRequest stageNonFinishUpdateRequest)
    {
        stageNonFinishEntity.StageId = stageNonFinishUpdateRequest.StageId;
        stageNonFinishEntity.RaceRiderParticipationId = stageNonFinishUpdateRequest.RaceRiderParticipationId;
        stageNonFinishEntity.Status = stageNonFinishUpdateRequest.Status;
    }
}
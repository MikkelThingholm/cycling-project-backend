using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class StageRiderResultDtoExtensions
{
    public static StageRiderResultResponse ToResponseDto(this StageRiderResult stageRiderResult)
    {
        return new StageRiderResultResponse(
            Id: stageRiderResult.Id,
            Placement: stageRiderResult.Placement,
            FinishTimeMilliseconds: stageRiderResult.FinishTimeMilliseconds,
            Stage: stageRiderResult.Stage.ToSimpleResponseDto(),
            RaceRiderParticipation: stageRiderResult.RaceRiderParticipation.ToResponseDto(),
            StageResultStatusCode: stageRiderResult.StageResultStatusCode.ToResponseDto()
        );
    }

    public static StageRiderResultSimpleResponse ToSimpleResponseDto(this StageRiderResult stageRiderResult)
    {
        return new StageRiderResultSimpleResponse(
            Id: stageRiderResult.Id,
            Placement: stageRiderResult.Placement,
            FinishTimeMilliseconds: stageRiderResult.FinishTimeMilliseconds,
            StageId: stageRiderResult.StageId,
            RaceRiderParticipationId: stageRiderResult.RaceRiderParticipationId,
            StageFinishStatusCodeId: stageRiderResult.StageFinishStatusCodeId
        );
    }

    public static StageRiderResult ToEntity(this StageRiderResultCreateRequest stageRiderResultCreateRequest)
    {
        return new StageRiderResult()
        {
            Placement = stageRiderResultCreateRequest.Placement,
            FinishTimeMilliseconds = stageRiderResultCreateRequest.FinishTimeMilliseconds,
            StageId = stageRiderResultCreateRequest.StageId,
            RaceRiderParticipationId = stageRiderResultCreateRequest.RaceRiderParticipationId,
            StageFinishStatusCodeId = stageRiderResultCreateRequest.StageFinishStatusCodeId
        };
    }

    public static void UpdateFromDto(this StageRiderResult stageRiderResultEntity, StageRiderResultUpdateRequest stageRiderResultUpdateRequest)
    {
        stageRiderResultEntity.Placement = stageRiderResultUpdateRequest.Placement;
        stageRiderResultEntity.FinishTimeMilliseconds = stageRiderResultUpdateRequest.FinishTimeMilliseconds;
        stageRiderResultEntity.StageId = stageRiderResultUpdateRequest.StageId;
        stageRiderResultEntity.RaceRiderParticipationId = stageRiderResultUpdateRequest.RaceRiderParticipationId;
        stageRiderResultEntity.StageFinishStatusCodeId = stageRiderResultUpdateRequest.StageFinishStatusCodeId;
    }
}
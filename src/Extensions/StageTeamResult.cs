using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class StageTeamResultDtoExtensions
{
    public static StageTeamResultResponse ToResponseDto(this StageTeamResult stageTeamResult)
    {
        return new StageTeamResultResponse(
            Id: stageTeamResult.Id,
            Placement: stageTeamResult.Placement,
            FinishTimeMilliseconds: stageTeamResult.FinishTimeMilliseconds,
            Stage: stageTeamResult.Stage.ToSimpleResponseDto(),
            RaceTeamParticipation: stageTeamResult.RaceTeamParticipation.ToSimpleResponseDto()
        );
    }

    public static StageTeamResultSimpleResponse ToSimpleResponseDto(this StageTeamResult stageTeamResult)
    {
        return new StageTeamResultSimpleResponse(
            Id: stageTeamResult.Id,
            Placement: stageTeamResult.Placement,
            FinishTimeMilliseconds: stageTeamResult.FinishTimeMilliseconds,
            StageId: stageTeamResult.StageId,
            RaceTeamParticipationId: stageTeamResult.RaceTeamParticipationId
        );
    }

    public static StageTeamResult ToEntity(this StageTeamResultCreateRequest stageTeamResultCreateRequest)
    {
        return new StageTeamResult()
        {
            Placement = stageTeamResultCreateRequest.Placement,
            FinishTimeMilliseconds = stageTeamResultCreateRequest.FinishTimeMilliseconds,
            StageId = stageTeamResultCreateRequest.StageId,
            RaceTeamParticipationId = stageTeamResultCreateRequest.RaceTeamParticipationId
        };
    }

    public static void UpdateFromDto(this StageTeamResult stageTeamResultEntity, StageTeamResultUpdateRequest stageTeamResultUpdateRequest)
    {
        stageTeamResultEntity.Placement = stageTeamResultUpdateRequest.Placement;
        stageTeamResultEntity.FinishTimeMilliseconds = stageTeamResultUpdateRequest.FinishTimeMilliseconds;
        stageTeamResultEntity.StageId = stageTeamResultUpdateRequest.StageId;
        stageTeamResultEntity.RaceTeamParticipationId = stageTeamResultUpdateRequest.RaceTeamParticipationId;
    }
}
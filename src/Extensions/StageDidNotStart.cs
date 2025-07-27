using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class StageDidNotStartDtoExtensions
{
    public static StageDidNotStartResponse ToResponseDto(this StageDidNotStart stageDidNotStart)
    {
        return new StageDidNotStartResponse(
            Id: stageDidNotStart.Id,
            Stage: stageDidNotStart.Stage.ToSimpleResponseDto(),
            RaceRiderParticipation: stageDidNotStart.RaceRiderParticipation.ToResponseDto()
        );
    }

    public static StageDidNotStartSimpleResponse ToSimpleResponseDto(this StageDidNotStart stageDidNotStart)
    {
        return new StageDidNotStartSimpleResponse(
            Id: stageDidNotStart.Id,
            StageId: stageDidNotStart.StageId,
            RaceRiderParticipationId: stageDidNotStart.RaceRiderParticipationId
        );
    }

    public static StageDidNotStart ToEntity(this StageDidNotStartCreateRequest stageDidNotStartCreateRequest)
    {
        return new StageDidNotStart()
        {
            StageId = stageDidNotStartCreateRequest.StageId,
            RaceRiderParticipationId = stageDidNotStartCreateRequest.RaceRiderParticipationId
        };
    }
    public static void UpdateFromDto(this StageDidNotStart stageDidNotStartEntity, StageDidNotStartUpdateRequest stageDidNotStartUpdateRequest)
    {
        stageDidNotStartEntity.StageId = stageDidNotStartUpdateRequest.StageId;
        stageDidNotStartEntity.RaceRiderParticipationId = stageDidNotStartUpdateRequest.RaceRiderParticipationId;
    }
}
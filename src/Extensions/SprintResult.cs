using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class SprintResultDtoExtensions
{
    public static SprintResultResponse ToResponseDto(this SprintResult sprintResult)
    {
        return new SprintResultResponse(
            Id: sprintResult.Id,
            Placement: sprintResult.Placement,
            Points: sprintResult.Points,
            BonusSeconds: sprintResult.BonusSeconds,
            Sprint: sprintResult.Sprint.ToSimpleResponseDto(),
            RaceRiderParticipation: sprintResult.RaceRiderParticipation.ToResponseDto()
        );
    }

    public static SprintResultSimpleResponse ToSimpleResponseDto(this SprintResult sprintResult)
    {
        return new SprintResultSimpleResponse(
            Id: sprintResult.Id,
            Placement: sprintResult.Placement,
            Points: sprintResult.Points,
            BonusSeconds: sprintResult.BonusSeconds,
            SprintId: sprintResult.SprintId,
            RaceRiderParticipationId: sprintResult.RaceRiderParticipationId
        );
    }

    public static SprintResult ToEntity(this SprintResultCreateRequest sprintResultCreateRequest)
    {
        return new SprintResult()
        {
            Placement = sprintResultCreateRequest.Placement,
            Points = sprintResultCreateRequest.Points,
            BonusSeconds = sprintResultCreateRequest.BonusSeconds,
            SprintId = sprintResultCreateRequest.SprintId,
            RaceRiderParticipationId = sprintResultCreateRequest.RaceRiderParticipationId
        };
    }

    public static void UpdateFromDto(this SprintResult sprintResultEntity, SprintResultUpdateRequest sprintResultUpdateRequest)
    {
        sprintResultEntity.Placement = sprintResultUpdateRequest.Placement;
        sprintResultEntity.Points = sprintResultUpdateRequest.Points;
        sprintResultEntity.BonusSeconds = sprintResultUpdateRequest.BonusSeconds;
        sprintResultEntity.SprintId = sprintResultUpdateRequest.SprintId;
        sprintResultEntity.RaceRiderParticipationId = sprintResultUpdateRequest.RaceRiderParticipationId;
    }
}
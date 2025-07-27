using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class StageRiderStandingDtoExtensions
{
    public static StageRiderStandingResponse ToResponseDto(this StageRiderStanding stageRiderStanding)
    {
        return new StageRiderStandingResponse(
            Id: stageRiderStanding.Id,
            Placement: stageRiderStanding.Placement,
            TimeMilliseconds: stageRiderStanding.TimeMilliseconds,
            TimePenaltySeconds: stageRiderStanding.TimePenaltySeconds,
            BonusSeconds: stageRiderStanding.BonusSeconds,
            SprintPoints: stageRiderStanding.SprintPoints,
            SprintPointsPenalty: stageRiderStanding.SprintPointsPenalty,
            MountainPoints: stageRiderStanding.MountainPoints,
            MountainPointsPenalty: stageRiderStanding.MountainPointsPenalty,
            Stage: stageRiderStanding.Stage.ToSimpleResponseDto(),
            RaceRiderParticipation: stageRiderStanding.RaceRiderParticipation.ToResponseDto()
        );
    }

    public static StageRiderStandingSimpleResponse ToSimpleResponseDto(this StageRiderStanding stageRiderStanding)
    {
        return new StageRiderStandingSimpleResponse(
            Id: stageRiderStanding.Id,
            Placement: stageRiderStanding.Placement,
            TimeMilliseconds: stageRiderStanding.TimeMilliseconds,
            TimePenaltySeconds: stageRiderStanding.TimePenaltySeconds,
            BonusSeconds: stageRiderStanding.BonusSeconds,
            SprintPoints: stageRiderStanding.SprintPoints,
            SprintPointsPenalty: stageRiderStanding.SprintPointsPenalty,
            MountainPoints: stageRiderStanding.MountainPoints,
            MountainPointsPenalty: stageRiderStanding.MountainPointsPenalty,
            StageId: stageRiderStanding.StageId,
            RaceRiderParticipationId: stageRiderStanding.RaceRiderParticipationId
        );
    }

    public static StageRiderStanding ToEntity(this StageRiderStandingCreateRequest stageRiderStandingCreateRequest)
    {
        return new StageRiderStanding()
        {
            Placement = stageRiderStandingCreateRequest.Placement,
            TimeMilliseconds = stageRiderStandingCreateRequest.TimeMilliseconds,
            TimePenaltySeconds = stageRiderStandingCreateRequest.TimePenaltySeconds,
            BonusSeconds = stageRiderStandingCreateRequest.BonusSeconds,
            SprintPoints = stageRiderStandingCreateRequest.SprintPoints,
            SprintPointsPenalty = stageRiderStandingCreateRequest.SprintPointsPenalty,
            MountainPoints = stageRiderStandingCreateRequest.MountainPoints,
            MountainPointsPenalty = stageRiderStandingCreateRequest.MountainPointsPenalty,
            StageId = stageRiderStandingCreateRequest.StageId,
            RaceRiderParticipationId = stageRiderStandingCreateRequest.RaceRiderParticipationId
        };
    }

    public static void UpdateFromDto(this StageRiderStanding stageRiderStandingEntity, StageRiderStandingUpdateRequest stageRiderStandingUpdateRequest)
    {
        stageRiderStandingEntity.Placement = stageRiderStandingUpdateRequest.Placement;
        stageRiderStandingEntity.TimeMilliseconds = stageRiderStandingUpdateRequest.TimeMilliseconds;
        stageRiderStandingEntity.TimePenaltySeconds = stageRiderStandingUpdateRequest.TimePenaltySeconds;
        stageRiderStandingEntity.BonusSeconds = stageRiderStandingUpdateRequest.BonusSeconds;
        stageRiderStandingEntity.SprintPoints = stageRiderStandingUpdateRequest.SprintPoints;
        stageRiderStandingEntity.SprintPointsPenalty = stageRiderStandingUpdateRequest.SprintPointsPenalty;
        stageRiderStandingEntity.MountainPoints = stageRiderStandingUpdateRequest.MountainPoints;
        stageRiderStandingEntity.MountainPointsPenalty = stageRiderStandingUpdateRequest.MountainPointsPenalty;
        stageRiderStandingEntity.StageId = stageRiderStandingUpdateRequest.StageId;
        stageRiderStandingEntity.RaceRiderParticipationId = stageRiderStandingUpdateRequest.RaceRiderParticipationId;
    }
}
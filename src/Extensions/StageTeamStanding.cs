using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class StageTeamStandingDtoExtensions
{
    public static StageTeamStandingResponse ToResponseDto(this StageTeamStanding stageTeamStanding)
    {
        return new StageTeamStandingResponse(
            Id: stageTeamStanding.Id,
            Placement: stageTeamStanding.Placement,
            TimeMilliseconds: stageTeamStanding.TimeMilliseconds,
            TimePenaltySeconds: stageTeamStanding.TimePenaltySeconds,
            BonusSeconds: stageTeamStanding.BonusSeconds,
            Stage: stageTeamStanding.Stage.ToSimpleResponseDto(),
            RaceTeamParticipation: stageTeamStanding.RaceTeamParticipation.ToSimpleResponseDto()
        );
    }

    public static StageTeamStandingSimpleResponse ToSimpleResponseDto(this StageTeamStanding stageTeamStanding)
    {
        return new StageTeamStandingSimpleResponse(
            Id: stageTeamStanding.Id,
            Placement: stageTeamStanding.Placement,
            TimeMilliseconds: stageTeamStanding.TimeMilliseconds,
            TimePenaltySeconds: stageTeamStanding.TimePenaltySeconds,
            BonusSeconds: stageTeamStanding.BonusSeconds,
            StageId: stageTeamStanding.StageId,
            RaceTeamParticipationId: stageTeamStanding.RaceTeamParticipationId
        );
    }
}
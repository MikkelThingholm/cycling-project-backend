using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class StageCombativityAwardDtoExtensions
{
    public static StageCombativityAwardResponse ToResponseDto(this StageCombativityAward stageCombativityAward)
    {
        return new StageCombativityAwardResponse(
            Id: stageCombativityAward.Id,
            Stage: stageCombativityAward.Stage.ToSimpleResponseDto(),
            RaceRiderParticipation: stageCombativityAward.RaceRiderParticipation.ToResponseDto()
        );
    }

    public static StageCombativityAwardSimpleResponse ToSimpleResponseDto(this StageCombativityAward stageCombativityAward)
    {
        return new StageCombativityAwardSimpleResponse(
            Id: stageCombativityAward.Id,
            StageId: stageCombativityAward.StageId,
            RaceRiderParticipationId: stageCombativityAward.RaceRiderParticipationId
        );
    }

    public static StageCombativityAward ToEntity(this StageCombativityAwardCreateRequest stageCombativityAwardCreateRequest)
    {
        return new StageCombativityAward()
        {
            StageId = stageCombativityAwardCreateRequest.StageId,
            RaceRiderParticipationId = stageCombativityAwardCreateRequest.RaceRiderParticipationId
        };
    }

    public static void UpdateFromDto(this StageCombativityAward stageCombativityAwardEntity, StageCombativityAwardUpdateRequest stageCombativityAwardUpdateRequest)
    {
        stageCombativityAwardEntity.StageId = stageCombativityAwardUpdateRequest.StageId;
        stageCombativityAwardEntity.RaceRiderParticipationId = stageCombativityAwardUpdateRequest.RaceRiderParticipationId;
    }
}
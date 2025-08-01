using App.Dto;
using App.EntityModels;

namespace App.Services.Interfaces;

public interface IRaceSetupService
{
    Task<RaceEditionSimpleResponse> CreateRaceEdition(RaceEditionCreateRequest raceEditionCreateRequest);
    Task<RaceEditionSimpleResponse> UpdateRaceEdition(int id, RaceEditionUpdateRequest raceEditionUpdateRequest);
    Task DeleteRaceEditionById(int id);

    Task<StageSimpleResponse> CreateStage(StageCreateRequest stageCreateRequest);
    Task<StageSimpleResponse> UpdateStage(int raceEditionId, int stageNum, StageUpdateRequest stageUpdateRequest);
    Task DeleteStageById(int raceEditionId, int stageNum);

    Task<MountainClimbSimpleResponse> CreateMountainClimb(MountainClimbCreateRequest mountainClimbCreateRequest);
    Task<MountainClimbSimpleResponse> UpdateMountainClimb(int mountainClimbId, MountainClimbUpdateRequest mountainClimbUpdateRequest);
    Task DeleteMountainClimbById(int id);

    Task<SprintSimpleResponse> CreateSprint(SprintCreateRequest sprintCreateRequest);
    Task<SprintSimpleResponse> UpdateSprint(int id, SprintUpdateRequest sprintUpdateRequest);
    Task DeleteSprintById(int id);
}
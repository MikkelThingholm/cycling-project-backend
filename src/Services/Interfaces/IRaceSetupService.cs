using App.Dto;
using App.EntityModels;

namespace App.Services.Interfaces;

public interface IRaceSetupService
{
    Task<RaceSimpleResponse> CreateRace(RaceCreateRequest raceCreateRequest);
    Task<RaceSimpleResponse> UpdateRace(int raceId, RaceUpdateRequest raceUpdateRequest);
    Task DeleteRace(int raceId);

    Task<RaceEditionSimpleResponse> CreateRaceEdition(int raceId, RaceEditionCreateRequest raceEditionCreateRequest);
    Task<RaceEditionSimpleResponse> UpdateRaceEdition(int raceEditionId, RaceEditionUpdateRequest raceEditionUpdateRequest);
    Task DeleteRaceEdition(int raceEditionId);

    Task<StageSimpleResponse> CreateStage(int raceEditionId, StageCreateRequest stageCreateRequest);
    Task<StageSimpleResponse> UpdateStage(int stageId, StageUpdateRequest stageUpdateRequest);
    Task DeleteStage(int stageId);

    Task<MountainClimbSimpleResponse> CreateMountainClimb(int stageId, MountainClimbCreateRequest mountainClimbCreateRequest);
    Task<MountainClimbSimpleResponse> UpdateMountainClimb(int mountainClimbId, MountainClimbUpdateRequest mountainClimbUpdateRequest);
    Task DeleteMountainClimb(int mountainClimbId);

    Task<SprintSimpleResponse> CreateSprint(int stageId, SprintCreateRequest sprintCreateRequest);
    Task<SprintSimpleResponse> UpdateSprint(int sprintId, SprintUpdateRequest sprintUpdateRequest);
    Task DeleteSprint(int sprintId);
}
using App.Dto;
using App.EntityModels;

namespace App.Services.Interfaces;

public interface IRaceSetupService
{
    Task<RaceSimpleResponse> CreateRace(RaceCreateRequest raceCreateRequest);
    Task<RaceSimpleResponse> UpdateRace(string slug, RaceUpdateRequest raceUpdateRequest);
    Task DeleteRace(string slug);

    Task<RaceEditionSimpleResponse> CreateRaceEdition(RaceEditionCreateRequest raceEditionCreateRequest);
    Task<RaceEditionSimpleResponse> UpdateRaceEdition(string raceEditionSlug, RaceEditionUpdateRequest raceEditionUpdateRequest);
    Task DeleteRaceEdition(string raceEditionSlug);

    Task<StageSimpleResponse> CreateStage(StageCreateRequest stageCreateRequest);
    Task<StageSimpleResponse> UpdateStage(string stageSlug, StageUpdateRequest stageUpdateRequest);
    Task DeleteStage(string stageSlug);

    Task<MountainClimbSimpleResponse> CreateMountainClimb(string stageSlug, MountainClimbCreateRequest mountainClimbCreateRequest);
    Task<MountainClimbSimpleResponse> UpdateMountainClimb(string stageSlug, int mountainClimbNumber, MountainClimbUpdateRequest mountainClimbUpdateRequest);
    Task DeleteMountainClimb(string stageSlug, int mountainClimbNumber);

    Task<SprintSimpleResponse> CreateSprint(SprintCreateRequest sprintCreateRequest);
    Task<SprintSimpleResponse> UpdateSprint(string stageSlug, int sprintNumber, SprintUpdateRequest sprintUpdateRequest);
    Task DeleteSprint(string stageSlug, int sprintNumber);
}
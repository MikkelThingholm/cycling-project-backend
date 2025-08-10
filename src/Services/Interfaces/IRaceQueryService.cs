using App.EntityModels;

namespace App.Services.Interfaces;

public interface IRaceQueryService
{
    Task<Race> GetRaceById(int raceId);
    Task<Race> GetRaceBySlug(string raceSlug);

    Task<RaceEdition> GetRaceEditionById(int raceEditionId);
    Task<RaceEdition> GetRaceEditionBySlug(string raceEditionSlug);

    Task<Stage> GetStageById(int stageId);
    Task<Stage> GetStageBySlug(string stageSlug);

    Task<MountainClimb> GetMountainClimbById(int mountainClimbId);
    Task<MountainClimb> GetMountainClimbBySlug(string stageSlug, int mountainClimbNumber);

    Task<Sprint> GetSprintById(int sprintId);
    Task<Sprint> GetSprintBySlug(string stageSlug, int springNumber);
}
using App.Dto;

namespace App.Services.Interfaces;

public interface IRaceEntryService
{
    Task TeamRaceEntry(int teamId, int raceEditionId);
    Task DeleteTeamRaceEntry(int teamId, int raceEditionId);

    Task RiderRaceEntry(int riderId, int raceEditionId);
    Task DeleteRiderRaceEntry(int riderId, int raceEditionId);
}
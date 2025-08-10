using App.Data;
using App.Dto;
using App.EntityModels;
using App.Exceptions;
using App.Extensions;
using Microsoft.EntityFrameworkCore;
using App.Services.Interfaces;

namespace App.Services;

public class RaceSetupService(ILogger<RaceSetupService> logger, AppDbContext db, IRaceQueryService raceQueryService) : IRaceSetupService
{
    private readonly ILogger<RaceSetupService> _logger = logger;
    private readonly AppDbContext _db = db;
    private readonly IRaceQueryService _raceQueryService = raceQueryService;

    // Races

    public async Task<RaceSimpleResponse> CreateRace(RaceCreateRequest raceCreateRequest)
    {
        var race = raceCreateRequest.ToEntity();
        await _db.Races.AddAsync(race);
        await _db.SaveChangesAsync();
        return race.ToSimpleResponseDto();
    }

    public async Task<RaceSimpleResponse> UpdateRace(string raceSlug, RaceUpdateRequest raceUpdateRequest)
    {
        var race = await _raceQueryService.GetRaceBySlug(raceSlug);

        race.UpdateFromDto(raceUpdateRequest);
        await _db.SaveChangesAsync();
        return race.ToSimpleResponseDto();
    }

    public async Task DeleteRace(string raceSlug)
    {
        var race = await _raceQueryService.GetRaceBySlug(raceSlug);
        _db.Races.Remove(race);
        await _db.SaveChangesAsync();
    }

    // RaceEditions

    private static void ValidateRaceEditionDates(short raceEditionYear, DateOnly startDate, DateOnly endDate)
    {
        if (raceEditionYear != startDate.Year || raceEditionYear != endDate.Year)
        {
            throw new BusinessRuleViolationException($"Race edition start and end dates {startDate} - {endDate} must be in the race edition year {raceEditionYear}");
        }
    }

    public async Task<RaceEditionSimpleResponse> CreateRaceEdition(RaceEditionCreateRequest raceEditionCreateRequest)
    {
        var raceEdition = raceEditionCreateRequest.ToEntity();

        ValidateRaceEditionDates(raceEdition.Year, raceEdition.StartDate, raceEdition.EndDate);

        _db.RaceEditions.Add(raceEdition);
        await _db.SaveChangesAsync();
        return raceEdition.ToSimpleResponseDto();
    }


    public async Task<RaceEditionSimpleResponse> UpdateRaceEdition(string raceEditionSlug, RaceEditionUpdateRequest raceEditionUpdateRequest)
    {
        var raceEdition = await _raceQueryService.GetRaceEditionBySlug(raceEditionSlug);

        ValidateRaceEditionDates(raceEditionUpdateRequest.Year, raceEditionUpdateRequest.StartDate, raceEditionUpdateRequest.EndDate);

        if (!raceEdition.Stages.All(s => raceEditionUpdateRequest.StartDate <= s.Date && s.Date <= raceEditionUpdateRequest.EndDate))
        {
            throw new BusinessRuleViolationException($"Stage dates must be within {raceEditionUpdateRequest.StartDate} - {raceEditionUpdateRequest.EndDate}");
        }

        raceEdition.UpdateFromDto(raceEditionUpdateRequest);
        await _db.SaveChangesAsync();

        return raceEdition.ToSimpleResponseDto();
    }

    public async Task DeleteRaceEdition(string slug)
    {
        var raceEdition = await _raceQueryService.GetRaceEditionBySlug(slug);

        _db.RaceEditions.Remove(raceEdition);
        await _db.SaveChangesAsync();
    }


    // Stages

    public async Task<StageSimpleResponse> CreateStage(StageCreateRequest stageCreateRequest)
    {
        var stage = stageCreateRequest.ToEntity();

        var raceEdition = await _db.RaceEditions.FindAsync(stage.RaceEditionId)
            ?? throw new EntityNotFoundException(nameof(RaceEdition), stage.RaceEditionId);

        if (!(raceEdition.StartDate <= stage.Date && stage.Date <= raceEdition.EndDate))
        {
            throw new BusinessRuleViolationException($"Stage date {stage.Date} must be within Race Edition dates {raceEdition.StartDate} - {raceEdition.EndDate}");
        }

        _db.Stages.Add(stage);
        await _db.SaveChangesAsync();
        return stage.ToSimpleResponseDto();
    }


    public async Task<StageSimpleResponse> UpdateStage(string stageSlug, StageUpdateRequest stageUpdateRequest)
    {
        var stage = await _raceQueryService.GetStageBySlug(stageSlug);

        if (!(stage.RaceEdition.StartDate <= stageUpdateRequest.Date && stageUpdateRequest.Date <= stage.RaceEdition.EndDate))
        {
            throw new BusinessRuleViolationException($"Stage date {stageUpdateRequest.Date} must be within Race Edition dates {stage.RaceEdition.StartDate} - {stage.RaceEdition.EndDate}");
        }

        if (!stage.Sprints.All(s => s.DistanceFromStartMeters <= stageUpdateRequest.DistanceMeters))
        {
            throw new BusinessRuleViolationException($"Stage distance {stageUpdateRequest.DistanceMeters} must be greater than all Sprints");
        }
        if (!stage.MountainClimbs.All(mc => mc.DistanceFromStartMeters <= stageUpdateRequest.DistanceMeters))
        {
            throw new BusinessRuleViolationException($"Stage distance {stageUpdateRequest.DistanceMeters} must be greater than all Mountain Climbs");
        }


        stage.UpdateFromDto(stageUpdateRequest);
        await _db.SaveChangesAsync();
        return stage.ToSimpleResponseDto();
    }

    public async Task DeleteStage(string stageSlug)
    {

        var stage = await _raceQueryService.GetStageBySlug(stageSlug);
        _db.Stages.Remove(stage);
        await _db.SaveChangesAsync();
    }


    // MountainClimbs

    public async Task<MountainClimbSimpleResponse> CreateMountainClimb(string stageSlug, MountainClimbCreateRequest mountainClimbCreateRequest)
    {
        var mountainClimb = mountainClimbCreateRequest.ToEntity();

        var stage = await _raceQueryService.GetStageBySlug(stageSlug);

        mountainClimb.StageId = stage.Id;

        if (!(0 < mountainClimb.DistanceFromStartMeters && mountainClimb.DistanceFromStartMeters <= stage.DistanceMeters))
        {
            throw new BusinessRuleViolationException($"Mountain climb distance {mountainClimb.DistanceFromStartMeters} must be between 0 and stage distance {stage.DistanceMeters}");
        }

        _db.MountainClimbs.Add(mountainClimb);
        await _db.SaveChangesAsync();
        return mountainClimb.ToSimpleResponseDto();
    }


    public async Task<MountainClimbSimpleResponse> UpdateMountainClimb(string stageSlug, int mountainClimbNumber, MountainClimbUpdateRequest mountainClimbUpdateRequest)
    {
        var mountainClimb = await _raceQueryService.GetMountainClimbBySlug(stageSlug, mountainClimbNumber);

        if (!(0 < mountainClimbUpdateRequest.DistanceFromStartMeters && mountainClimbUpdateRequest.DistanceFromStartMeters <= mountainClimb.Stage.DistanceMeters))
        {
            throw new BusinessRuleViolationException($"Mountain climb distance {mountainClimbUpdateRequest.DistanceFromStartMeters} must be between 0 and stage distance {mountainClimb.Stage.DistanceMeters}");
        }

        mountainClimb.UpdateFromDto(mountainClimbUpdateRequest);
        await _db.SaveChangesAsync();
        return mountainClimb.ToSimpleResponseDto();
    }

    public async Task DeleteMountainClimb(string stageSlug, int mountainClimbNumber)
    {
        var mountainClimb = await _raceQueryService.GetMountainClimbBySlug(stageSlug, mountainClimbNumber);
        _db.MountainClimbs.Remove(mountainClimb);
        await _db.SaveChangesAsync();
    }

    // Sprints

    public async Task<SprintSimpleResponse> CreateSprint(SprintCreateRequest sprintCreateRequest)
    {
        var sprint = sprintCreateRequest.ToEntity();

        var stage = await _db.Stages.FindAsync(sprint.StageId)
            ?? throw new EntityNotFoundException(nameof(Stage), sprint.StageId);

        if (!(0 < sprint.DistanceFromStartMeters && sprint.DistanceFromStartMeters <= stage.DistanceMeters))
        {
            throw new BusinessRuleViolationException($"Sprint distance {sprint.DistanceFromStartMeters} must be between 0 and stage distance {stage.DistanceMeters}");
        }

        await _db.Sprints.AddAsync(sprint);
        await _db.SaveChangesAsync();
        return sprint.ToSimpleResponseDto();
    }


    public async Task<SprintSimpleResponse> UpdateSprint(string stageSlug, int sprintNumber, SprintUpdateRequest sprintUpdateRequest)
    {
        var sprint = await _raceQueryService.GetSprintBySlug(stageSlug, sprintNumber);
        if (!(0 < sprintUpdateRequest.DistanceFromStartMeters && sprintUpdateRequest.DistanceFromStartMeters <= sprint.Stage.DistanceMeters))
        {
            throw new BusinessRuleViolationException($"Sprint distance {sprintUpdateRequest.DistanceFromStartMeters} must be between 0 and stage distance {sprint.Stage.DistanceMeters}");
        }

        sprint.UpdateFromDto(sprintUpdateRequest);
        await _db.SaveChangesAsync();
        return sprint.ToSimpleResponseDto();
    }

    public async Task DeleteSprint(string stageSlug, int sprintNumber)
    {
        var sprint = await _raceQueryService.GetSprintBySlug(stageSlug, sprintNumber);
        _db.Sprints.Remove(sprint);
        await _db.SaveChangesAsync();
    }


}
using App.Data;
using App.Dto;
using App.EntityModels;
using App.Exceptions;
using App.Extensions;
using Microsoft.EntityFrameworkCore;

namespace App.Services;

public class RaceEditionManagementService(ILogger<RaceEditionManagementService> logger, AppDbContext db)
{
    private readonly ILogger<RaceEditionManagementService> _logger = logger;
    private readonly AppDbContext _db = db;

    // RaceEditions

    public async Task<RaceEditionSimpleResponse> CreateRaceEdition(RaceEditionCreateRequest raceEditionCreateRequest)
    {
        var raceEdition = raceEditionCreateRequest.ToEntity();
        _db.RaceEditions.Add(raceEdition);
        await _db.SaveChangesAsync();
        return raceEdition.ToSimpleResponseDto();
    }

    public async Task<RaceEditionResponse> GetRaceEditionById(int raceEditionId)
    {
        var raceEdition = await _db.RaceEditions.FindAsync(raceEditionId)
            ?? throw new EntityNotFoundException(nameof(RaceEdition), raceEditionId);

        return raceEdition.ToResponseDto();
    }

    public async Task<RaceEditionSimpleResponse> UpdateRaceEdition(int raceEditionId, RaceEditionUpdateRequest raceEditionUpdateRequest)
    {
        var raceEdition = await _db.RaceEditions.Include(re => re.Stages)
                                .SingleOrDefaultAsync(re => re.Id == raceEditionId)
                                ?? throw new EntityNotFoundException(nameof(RaceEdition), raceEditionId);

        if (!raceEdition.Stages.All(s => raceEditionUpdateRequest.StartDate <= s.Date && s.Date <= raceEditionUpdateRequest.EndDate))
        {
            throw new BusinessRuleViolationException($"Stage dates must be within {raceEditionUpdateRequest.StartDate} - {raceEditionUpdateRequest.EndDate}");
        }

        raceEdition.UpdateFromDto(raceEditionUpdateRequest);
        await _db.SaveChangesAsync();

        return raceEdition.ToSimpleResponseDto();
    }

    public async Task DeleteRaceEdition(int raceEditionId)
    {
        var raceEdition = await _db.RaceEditions.FindAsync(raceEditionId)
            ?? throw new EntityNotFoundException(nameof(RaceEdition), raceEditionId);

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

    public async Task<StageSimpleResponse> UpdateStage(int id, StageUpdateRequest stageUpdateRequest)
    {
        var stage = await _db.Stages.Include(s => s.RaceEdition)
                            .Include(s => s.Sprints)
                            .Include(s => s.MountainClimbs)
                            .SingleOrDefaultAsync(s => s.Id == id)
                            ?? throw new EntityNotFoundException(nameof(Stage), id);

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

    public async Task DeleteStage(int stageId)
    {
        var stage = await _db.Stages.FindAsync(stageId) ?? throw new EntityNotFoundException(nameof(Stage), stageId);
        _db.Stages.Remove(stage);
        await _db.SaveChangesAsync();
    }


    // MountainClimbs

    public async Task<MountainClimbSimpleResponse> CreateMountainClimb(MountainClimbCreateRequest mountainClimbCreateRequest)
    {
        var mountainClimb = mountainClimbCreateRequest.ToEntity();

        var stage = await _db.Stages.FindAsync(mountainClimb.StageId)
            ?? throw new EntityNotFoundException(nameof(Stage), mountainClimb.StageId);

        if (!(0 < mountainClimb.DistanceFromStartMeters && mountainClimb.DistanceFromStartMeters <= stage.DistanceMeters))
        {
            throw new BusinessRuleViolationException($"Mountain climb distance {mountainClimb.DistanceFromStartMeters} must be between 0 and stage distance {stage.DistanceMeters}");
        }

        _db.MountainClimbs.Add(mountainClimb);
        await _db.SaveChangesAsync();
        return mountainClimb.ToSimpleResponseDto();
    }

    public async Task<MountainClimbSimpleResponse> UpdateMountainClimb(int id, MountainClimbUpdateRequest mountainClimbUpdateRequest)
    {
        var mountainClimb = await _db.MountainClimbs.Include(mc => mc.Stage).SingleOrDefaultAsync(mc => mc.Id == id)
            ?? throw new EntityNotFoundException(nameof(MountainClimb), id);

        if (!(0 < mountainClimbUpdateRequest.DistanceFromStartMeters && mountainClimbUpdateRequest.DistanceFromStartMeters <= mountainClimb.Stage.DistanceMeters))
        {
            throw new BusinessRuleViolationException($"Mountain climb distance {mountainClimbUpdateRequest.DistanceFromStartMeters} must be between 0 and stage distance {mountainClimb.Stage.DistanceMeters}");
        }

        mountainClimb.UpdateFromDto(mountainClimbUpdateRequest);
        await _db.SaveChangesAsync();
        return mountainClimb.ToSimpleResponseDto();
    }

    public async Task DeleteMountainClimb(int id)
    {
        var mountainClimb = await _db.MountainClimbs.FindAsync(id) ?? throw new EntityNotFoundException(nameof(MountainClimb), id);
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

    public async Task<SprintSimpleResponse> UpdateSprint(int id, SprintUpdateRequest sprintUpdateRequest)
    {
        var sprint = await _db.Sprints.Include(s => s.Stage).SingleOrDefaultAsync(s => s.Id == id)
                                      ?? throw new EntityNotFoundException(nameof(Sprint), id);

        if (!(0 < sprintUpdateRequest.DistanceFromStartMeters && sprintUpdateRequest.DistanceFromStartMeters <= sprint.Stage.DistanceMeters))
        {
            throw new BusinessRuleViolationException($"Sprint distance {sprintUpdateRequest.DistanceFromStartMeters} must be between 0 and stage distance {sprint.Stage.DistanceMeters}");
        }

        sprint.UpdateFromDto(sprintUpdateRequest);
        await _db.SaveChangesAsync();
        return sprint.ToSimpleResponseDto();
    }

    public async Task DeleteSprint(int id)
    {
        var sprint = await _db.Sprints.FindAsync(id) ?? throw new EntityNotFoundException(nameof(Sprint), id);
        _db.Sprints.Remove(sprint);
        await _db.SaveChangesAsync();
    }


}
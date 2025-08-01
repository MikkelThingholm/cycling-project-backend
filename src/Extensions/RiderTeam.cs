using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class RiderTeamDtoExtensions
{
    public static RiderTeamResponse ToResponseDto(this RiderTeam riderTeamEntity)
    {
        return new RiderTeamResponse(
            Id: riderTeamEntity.Id,
            JoinDate: riderTeamEntity.JoinDate,
            LeaveDate: riderTeamEntity.LeaveDate,
            Rider: riderTeamEntity.Rider.ToSimpleResponseDto(),
            Team: riderTeamEntity.Team.ToSimpleResponseDto()
        );
    }

    public static RiderTeamSimpleResponse ToSimpleResponseDto(this RiderTeam riderTeamEntity)
    {
        return new RiderTeamSimpleResponse(
            Id: riderTeamEntity.Id,
            JoinDate: riderTeamEntity.JoinDate,
            LeaveDate: riderTeamEntity.LeaveDate,
            RiderId: riderTeamEntity.RiderId,
            TeamId: riderTeamEntity.TeamId
        );
    }
    public static RiderTeam ToEntity(this RiderTeamCreateRequest riderTeamCreateRequest, int riderId, int teamId)
    {
        return new RiderTeam()
        {
            JoinDate = riderTeamCreateRequest.JoinDate,
            LeaveDate = riderTeamCreateRequest.LeaveDate,
            RiderId = riderId,
            TeamId = teamId
        };
    }

    public static void UpdateFromDto(this RiderTeam riderTeamEntity, RiderTeamUpdateRequest riderTeamUpdateRequest)
    {
        riderTeamEntity.JoinDate = riderTeamUpdateRequest.JoinDate;
        riderTeamEntity.LeaveDate = riderTeamUpdateRequest.LeaveDate;
    }

}
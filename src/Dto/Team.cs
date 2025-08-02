namespace App.Dto;

public record TeamResponse(
    int Id,
    string Name,
    short Year,
    string Slug,
    List<RiderTeamResponse> RiderTeams,
    TeamOrganizationResponse TeamOrganization
);

public record TeamSimpleResponse(
    int Id,
    string Name,
    short Year,
    string Slug,
    int TeamOrganizationId
);

public record TeamCreateRequest(
    string Name,
    short Year,
    string Slug,
    int TeamOrganizationId
);


public record TeamUpdateRequest(
    string Name,
    string Slug,
    int TeamOrganizationId
);
namespace App.Dto;

public record TeamOrganizationResponse(
    int Id,
    List<TeamResponse> Teams
);

public record TeamOrganizationSimpleResponse(
    int Id
);

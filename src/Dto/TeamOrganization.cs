namespace App.Dto;

public record TeamOrganizationResponse(
    int Id,
    ICollection<TeamResponse> Teams
);
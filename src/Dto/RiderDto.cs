
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using App.EntityModels;

namespace App.Dto;

public record RiderResponse(
    int Id,
    string FirstName,
    string LastName,
    DateOnly BirthDate,
    NationResponse? Nation
);
/*
public record RiderCreateRequest(
    string FirstName,
    string LastName,
    int NationId,
    DateOnly BirthDate
);
*/

public record RiderCreateRequest{

    [Required]
    public required string FirstName { get; set;}
    
    [Required]
    public required string LastName { get; set; }

    [Required]
    public required int NationId { get; set; }

    [Required]
    public required DateOnly BirthDate { get; set; }
}

public record RiderUpdateRequest(
    string FirstName,
    string LastName,
    DateOnly BirthDate
);
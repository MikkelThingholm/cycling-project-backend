
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


public record RiderCreateRequest{
    public required string FirstName { get; set;}
    public required string LastName { get; set; }
    public required int NationId { get; set; }
    public required DateOnly BirthDate { get; set; }
}

public record RiderCreateResponse(
    int Id,
    string FirstName,
    string LastName,
    int NationId,
    DateOnly BirthDate
);


public record RiderUpdateRequest(
    string FirstName,
    string LastName,
    int NationId,
    DateOnly BirthDate
);
public record RiderUpdateResponse(
    int Id,
    string FirstName,
    string LastName,
    int NationId,
    DateOnly BirthDate
);
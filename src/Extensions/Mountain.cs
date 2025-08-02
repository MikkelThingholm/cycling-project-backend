using App.Dto;
using App.EntityModels;

namespace App.Extensions;

public static class MountainDtoExtension
{
    public static MountainResponse ToResponseDto(this Mountain mountain)
    {
        return new MountainResponse(
            Id: mountain.Id,
            Name: mountain.Name,
            Slug: mountain.Slug
        );
    }

    public static Mountain ToEntity(this MountainCreateRequest mountainCreateRequest)
    {
        return new Mountain()
        {
            Name = mountainCreateRequest.Name,
            Slug = mountainCreateRequest.Slug
        };
    }

    public static void UpdateFromDto(this Mountain mountainEntity, MountainUpdateRequest mountainUpdateRequest)
    {
        mountainEntity.Name = mountainUpdateRequest.Name;
        mountainEntity.Slug = mountainUpdateRequest.Slug;
    }
}
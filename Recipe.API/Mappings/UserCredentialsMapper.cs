using Recipe.API.DTOs.UserCredentialsDTOs;
using Recipe.API.Helpers;
using Recipe.Repository.Entities;

namespace Recipe.API.Mappings;

public class UserCredentialsMapper : IBaseMapper<UserCredentials, UserCredentialsReadDto, UserCredentialsCreateDto, UserCredentialsUpdateDto>
{
    public UserCredentials ToEntity(UserCredentialsCreateDto dto)
    {
        AuthHelpers.CreatePasswordHash(dto.Password, out var passwordHash, out var passwordSalt);
        return new UserCredentials
        {
            Email = dto.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
    }

    public UserCredentials ToEntity(UserCredentialsUpdateDto dto, UserCredentials entity)
    {
        AuthHelpers.CreatePasswordHash(dto.NewPassword, out var passwordHash, out var passwordSalt);
        
        entity.Email = dto.Email;
        entity.PasswordHash = passwordHash;
        entity.PasswordSalt = passwordSalt;

        return entity;
    }

    public UserCredentialsReadDto ToDto(UserCredentials entity)
    {
        return new UserCredentialsReadDto
        {
            Email = entity.Email
        };
    }
}
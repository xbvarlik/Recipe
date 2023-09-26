using Recipe.API.DTOs.UserCredentialsDTOs;
using Recipe.API.Helpers;
using Recipe.Repository.Entities;

namespace Recipe.API.Mappings;

public class UserCredentialsMapper : IBaseMapper<UserCredentials, UserCredentialsReadDto, UserCredentialsCreateDto, UserCredentialsUpdateDto>
{
    public UserCredentials ToEntity(UserCredentialsCreateDto dto)
    {
        throw new NotImplementedException();
    }
    
    public UserCredentials ToEntity(string email, byte[] passwordHash, byte[] passwordSalt)
    {
        return new UserCredentials
        {
            Email = email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
    }

    public UserCredentials ToEntity(UserCredentialsUpdateDto dto, UserCredentials entity)
    {
        throw new NotImplementedException();
    }
    
    public UserCredentials ToEntity(string email, byte[] passwordHash, byte[] passwordSalt, UserCredentials entity)
    {
        entity.Email = email;
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
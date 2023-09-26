using Recipe.API.DTOs.UserCredentialsDTOs;
using Recipe.API.Mappings;
using Recipe.Repository;
using Recipe.Repository.Entities;

namespace Recipe.API.Services;

public class UserCredentialsService : GenericService<UserCredentials, UserCredentialsReadDto, UserCredentialsCreateDto, UserCredentialsUpdateDto>
{
    public UserCredentialsService(AppDbContext context, IBaseMapper<UserCredentials, UserCredentialsReadDto, UserCredentialsCreateDto, UserCredentialsUpdateDto> mapper) : base(context, mapper)
    {
    }
}
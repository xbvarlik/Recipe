using Recipe.API.DTOs.UserDTOs;
using Recipe.API.Mappings;
using Recipe.Repository;
using Recipe.Repository.Entities;

namespace Recipe.API.Services;

public class UserService : GenericService<User, UserReadDto, UserCreateDto, UserUpdateDto>
{
    public UserService(AppDbContext context, IBaseMapper<User, UserReadDto, UserCreateDto, UserUpdateDto> mapper) : base(context, mapper)
    {
    }
}
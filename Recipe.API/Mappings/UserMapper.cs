using Recipe.API.DTOs.UserDTOs;
using Recipe.Repository.Entities;

namespace Recipe.API.Mappings;

public class UserMapper : IBaseMapper<User, UserReadDto, UserCreateDto, UserUpdateDto>
{
    public User ToEntity(UserCreateDto dto)
    {
        return new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Password = dto.Password,
            Age = dto.Age,
            Gender = dto.Gender
        };
    }

    public User ToEntity(UserUpdateDto dto, User entity)
    {
        entity.FirstName = dto.FirstName ?? entity.FirstName;
        entity.LastName = dto.LastName ?? entity.LastName;
        entity.Email = dto.Email ?? entity.Email;
        entity.Password = dto.Password ?? entity.Password;
        entity.Age = dto.Age ?? entity.Age;
        entity.Gender = dto.Gender ?? entity.Gender;

        return entity;
    }

    public UserReadDto ToDto(User entity)
    {
        return new UserReadDto
        {
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            Password = entity.Password,
            Age = entity.Age,
            Gender = entity.Gender,
            FavoriteRecipes = entity.FavoriteRecipes?.Select(x => 
                new FavoriteRecipesMapper().ToDto(x)).ToList(),
            RecipePointsAndComments = entity.RecipePointsAndComments?.Select(x =>
                new RecipePointsAndCommentsMapper().ToDto(x)).ToList(),
            Recipes = entity.Recipes?.Select(x => new RecipeMapper().ToDto(x)).ToList()
        };
    }
}
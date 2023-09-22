namespace Recipe.API.Mappings;

public interface IBaseMapper<TEntity, TReadDto, TCreateDto, TUpdateDto> 
    where TEntity : class 
    where TReadDto : class 
    where TCreateDto : class 
    where TUpdateDto : class
{
    TEntity ToEntity(TCreateDto dto);
    TEntity ToEntity(TUpdateDto dto, TEntity entity);
    TReadDto ToDto(TEntity entity);
}
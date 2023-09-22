using Recipe.API.DTOs.StepDTOs;
using Recipe.API.Mappings;
using Recipe.Repository;
using Recipe.Repository.Entities;

namespace Recipe.API.Services;

public class StepService : GenericService<Step, StepReadDto, StepCreateDto, StepUpdateDto>
{
    public StepService(AppDbContext context, IBaseMapper<Step, StepReadDto, StepCreateDto, StepUpdateDto> mapper) : base(context, mapper)
    {
    }
}
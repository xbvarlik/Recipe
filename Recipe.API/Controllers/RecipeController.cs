using Microsoft.AspNetCore.Mvc;
using Recipe.API.DTOs.CommunicationDTOs;
using Recipe.API.DTOs.RecipeDTOs;
using Recipe.API.Mappings;
using Recipe.API.Services;

namespace Recipe.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipeController : BaseController
{
    private readonly RecipeMapper _mapper;
    private readonly RecipeService _service;

    public RecipeController(RecipeMapper mapper, RecipeService service)
    {
        _mapper = mapper;
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] string? filter = null)
    {
        var entities = await _service.GetAllAsync(filter);
        var dtos = entities.Select(x => _mapper.ToDto(x));
        var responseDto = ResponseDto<IEnumerable<RecipeReadDto>>.Success(200, dtos);
        
        return CreateActionResult(responseDto);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        var dto = _mapper.ToDto(entity);
        var responseDto = ResponseDto<RecipeReadDto>.Success(200, dto);
        
        return CreateActionResult(responseDto);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] RecipeCreateDto dto)
    {
        var createdEntity = await _service.CreateAsync(dto);
        var responseDto = ResponseDto<RecipeReadDto>.Success(201, createdEntity);
        
        return CreateActionResult(responseDto);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] RecipeUpdateDto dto)
    {
        await _service.UpdateAsync(id, dto);
        var responseDto = ResponseDto<NoContentDto>.Success(204);
        
        return CreateActionResult(responseDto);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _service.DeleteAsync(id);
        var responseDto = ResponseDto<NoContentDto>.Success(204);
        
        return CreateActionResult(responseDto);
    }
    
}
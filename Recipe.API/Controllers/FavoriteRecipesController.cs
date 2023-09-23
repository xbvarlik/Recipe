using Microsoft.AspNetCore.Mvc;
using Recipe.API.DTOs.CommunicationDTOs;
using Recipe.API.DTOs.FavoriteRecipesDTOs;
using Recipe.API.Mappings;
using Recipe.API.Services;

namespace Recipe.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoriteRecipesController : BaseController
{
    private readonly FavoriteRecipesMapper _mapper;
    private readonly FavoriteRecipesService _service;

    public FavoriteRecipesController(FavoriteRecipesMapper mapper, FavoriteRecipesService service)
    {
        _mapper = mapper;
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var entities = await _service.GetAllAsync();
        var dtos = entities.Select(x => _mapper.ToDto(x));
        var responseDto = ResponseDto<IEnumerable<FavoriteRecipesReadDto>>.Success(200, dtos);
        
        return CreateActionResult(responseDto);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        var dto = _mapper.ToDto(entity);
        var responseDto = ResponseDto<FavoriteRecipesReadDto>.Success(200, dto);
        
        return CreateActionResult(responseDto);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] FavoriteRecipesCreateDto dto)
    {
        var createdEntity = await _service.CreateAsync(dto);
        var responseDto = ResponseDto<FavoriteRecipesReadDto>.Success(201, createdEntity);
        
        return CreateActionResult(responseDto);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] FavoriteRecipesUpdateDto dto)
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
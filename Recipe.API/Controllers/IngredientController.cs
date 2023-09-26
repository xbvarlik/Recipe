using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe.API.DTOs.CommunicationDTOs;
using Recipe.API.DTOs.IngredientDTOs;
using Recipe.API.Mappings;
using Recipe.API.Services;
using Recipe.Repository.Entities;

namespace Recipe.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class IngredientsController : BaseController
{
    private readonly IngredientMapper _mapper;
    private readonly IngredientService _service;

    public IngredientsController(IngredientService service, IngredientMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var entities = await _service.GetAllAsync();
        var dtos = entities.Select(x => _mapper.ToDto(x));
        var responseDto = ResponseDto<IEnumerable<IngredientReadDto>>.Success(200, dtos);
        
        return CreateActionResult(responseDto);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        var dto = _mapper.ToDto(entity);
        var responseDto = ResponseDto<IngredientReadDto>.Success(200, dto);
        
        return CreateActionResult(responseDto);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] IngredientCreateDto dto)
    {
        var createdEntity = await _service.CreateAsync(dto);
        var responseDto = ResponseDto<IngredientReadDto>.Success(201, createdEntity);
        
        return CreateActionResult(responseDto);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] IngredientUpdateDto dto)
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
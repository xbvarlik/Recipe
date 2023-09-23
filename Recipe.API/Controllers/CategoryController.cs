using Microsoft.AspNetCore.Mvc;
using Recipe.API.DTOs.CategoryDTOs;
using Recipe.API.DTOs.CommunicationDTOs;
using Recipe.API.Mappings;
using Recipe.API.Services;

namespace Recipe.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : BaseController
{
    private readonly CategoryMapper _mapper;
    private readonly CategoryService _service;

    public CategoryController(CategoryMapper mapper, CategoryService service)
    {
        _mapper = mapper;
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] string filter)
    {
        var entities = await _service.GetAllAsync(filter);
        var dtos = entities.Select(x => _mapper.ToDto(x));
        var responseDto = ResponseDto<IEnumerable<CategoryReadDto>>.Success(200, dtos);
        
        return CreateActionResult(responseDto);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        var dto = _mapper.ToDto(entity);
        var responseDto = ResponseDto<CategoryReadDto>.Success(200, dto);
        
        return CreateActionResult(responseDto);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CategoryCreateDto dto)
    {
        var createdEntity = await _service.CreateAsync(dto);
        var responseDto = ResponseDto<CategoryReadDto>.Success(201, createdEntity);
        
        return CreateActionResult(responseDto);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] CategoryUpdateDto dto)
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
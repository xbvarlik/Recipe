using Microsoft.AspNetCore.Mvc;
using Recipe.API.DTOs.CommunicationDTOs;
using Recipe.API.DTOs.StepDTOs;
using Recipe.API.Mappings;
using Recipe.API.Services;

namespace Recipe.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StepsController : BaseController
{
    private readonly StepService _service;
    private readonly StepMapper _mapper;

    public StepsController(StepService service, StepMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] string? filter = null)
    {
        var entities = await _service.GetAllAsync(filter);
        var dtos = entities.Select(x => _mapper.ToDto(x));
        var response = ResponseDto<IEnumerable<StepReadDto>>.Success(200, dtos);
        
        return CreateActionResult(response);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        var dto = _mapper.ToDto(entity);
        var response = ResponseDto<StepReadDto>.Success(200, dto);
        
        return CreateActionResult(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] StepCreateDto dto)
    {
        var createdEntity = await _service.CreateAsync(dto);
        var response = ResponseDto<StepReadDto>.Success(201, createdEntity);
        
        return CreateActionResult(response);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] StepUpdateDto dto)
    {
        await _service.UpdateAsync(id, dto);
        var response = ResponseDto<NoContentDto>.Success(204);
        
        return CreateActionResult(response);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _service.DeleteAsync(id);
        var response = ResponseDto<NoContentDto>.Success(204);
        
        return CreateActionResult(response);
    }
}
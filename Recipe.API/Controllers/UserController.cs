using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipe.API.DTOs.CommunicationDTOs;
using Recipe.API.DTOs.UserDTOs;
using Recipe.API.Mappings;
using Recipe.API.Services;

namespace Recipe.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : BaseController
{
    private readonly UserMapper _mapper;
    private readonly UserService _service;
    
    public UserController(UserMapper mapper, UserService service)
    {
        _mapper = mapper;
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] string? filter = null)
    {
        var entities = await _service.GetAllAsync(filter);
        var dtos = entities.Select(x => _mapper.ToDto(x));
        var responseDto = ResponseDto<IEnumerable<UserReadDto>>.Success(200, dtos);
        
        return CreateActionResult(responseDto);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        var dto = _mapper.ToDto(entity);
        var responseDto = ResponseDto<UserReadDto>.Success(200, dto);
        
        return CreateActionResult(responseDto);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] UserCreateDto dto)
    {
        var createdEntity = await _service.CreateAsync(dto);
        var responseDto = ResponseDto<UserReadDto>.Success(201, createdEntity);
        
        return CreateActionResult(responseDto);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UserUpdateDto dto)
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


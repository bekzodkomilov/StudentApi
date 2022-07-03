using Microsoft.AspNetCore.Mvc;
using StudentApi.Entities;
using StudentApi.Models;
using StudentApi.Services;

namespace StudentApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly ILogger<StudentController> _logger;
    private readonly StudentService _service;

    public StudentController(ILogger<StudentController> logger, StudentService service)
    {
        _logger = logger;
        _service = service;
    }
    [HttpPost("/addcar")]
    public async Task<IActionResult> AddStudent([FromForm]StudentModel newModel)
    {
        var student = new Student(){
            Id = Guid.NewGuid(),
            Name = newModel.Name,
            LastName = newModel.LastName,
            Age = newModel.Age
        };
        var result = await _service.InsertAsync(student);
        var error = !result.IsSuccess;
        var message = result.e is null ? "Success" : result.e.Message;
        return Ok(new {error, message, student});
    }
    [HttpGet("getstudentbyid{id}")]
    public async Task<IActionResult> GetStudentById(Guid id)
    {
        var res = await _service.GetByIdAsync(id);
        return Ok(res);
    }
    [HttpGet("getallstudent")]
    public async Task<IActionResult> GetAllStudent()
    {
        var res = await _service.GetAllAsync();
        return Ok(res);
    }
    [HttpPut("updatestudentbyid/{id}")]
    public async Task<IActionResult> UpdateStudentById([FromForm]StudentModel model, Guid id)
    {
        var res = await _service.GetByIdAsync(id);
        res.LastName = model.LastName;
        res.Name = model.Name;
        res.Age = model.Age;
        var result = await _service.UpdateAsync(res);
        var error = !result.IsSuccess;
        var message = result.e is null ? "Success"  : result.e.Message;
        return Ok(new {error,message});
    }
    [HttpDelete("deletestudentbyid")]
    public async Task<IActionResult> DeleteStudentById(Guid id)
    {
        var res = await _service.DeleteAsync(id);
        return Ok(res);
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentCRUD.Models.Entities;
using StudentCRUD.Models.ViewModels;
using StudentCRUD.Repository.Interface;

namespace StudentCRUD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentAPIController : ControllerBase
{
    private readonly IStudentRepository _repo;
    private readonly IMapper _mapper;

    public StudentAPIController(IStudentRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await _repo.GetAll();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var student = await _repo.GetById(id);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> Create(StudentCreateVM studentVM)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var student = _mapper.Map<Student>(studentVM);
        await _repo.Create(student);
        return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, StudentUpdateVM studentVM)
    {
        if (id != studentVM.Id)
        {
            return BadRequest();
        }
        var student = _mapper.Map<Student>(studentVM);
        await _repo.Update(student);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _repo.GetById(id);
        if (student == null)
        {
            return NotFound();
        }
        await _repo.Delete(id);
        return Ok();
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentCRUD.Models.Entities;
using StudentCRUD.Models.ViewModels;
using StudentCRUD.Repository.Interface;

namespace StudentCRUD.Controllers;

public class StudentController : Controller
{
    private readonly IStudentRepository _repo;
    private readonly IMapper _mapper;

    public StudentController(IStudentRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var students = await _repo.GetAll();
        return View(students);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var student = await _repo.GetById(id);
        return View(student);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(StudentCreateVM student)
    {
        if (ModelState.IsValid)
        {
            var entity = _mapper.Map<Student>(student);
            await _repo.Create(entity);
            return RedirectToAction("Index");
        }

        return View(student);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var student = await _repo.GetById(id);
        if (student == null)
        {
            return NotFound();
        }
        var vm = _mapper.Map<StudentUpdateVM>(student);
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Update(StudentUpdateVM student)
    {
        if (ModelState.IsValid)
        {
            var entity = _mapper.Map<Student>(student);
            await _repo.Update(entity);
            return RedirectToAction("Index");
        }

        return View(student);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _repo.GetById(id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }
    
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var student = await _repo.GetById(id);
        if (student == null)
        {
            return NotFound();
        }
        await _repo.Delete(id);
        return RedirectToAction("Index");
    }
}
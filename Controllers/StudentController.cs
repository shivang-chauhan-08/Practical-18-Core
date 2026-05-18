using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentCRUD.Models.Entities;
using StudentCRUD.Models.ViewModels;
using StudentCRUD.Repository.Interface;

namespace StudentCRUD.Controllers;

public class StudentController : Controller
{
    private readonly IStudentRepository _repo;

    public StudentController(IStudentRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var students = await _repo.GetAll();
        return View(students);
    }

    [HttpGet]
    public async Task<Student> Details(int id)
    {
        var student = _repo.GetById(id);
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
            _repo.Create(student);
            return RedirectToAction("Index");
        }

        return View(student);
    }
}
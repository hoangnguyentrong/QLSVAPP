using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;

namespace StudentApp.Controllers;

public class StudentController(IStudentService studentService, 
IDepartmentService departmentService) : Controller
{
   private readonly IStudentService _studentService = studentService;
  private readonly IDepartmentService _departmentService = departmentService;
    public IActionResult Index()
    {
        ViewBag.Department = _departmentService.GetDepartments();
        return View(_studentService.GetStudents());
    }
  public IActionResult Create(){
    var departments = _departmentService.GetDepartments();
    return View(departments);
  }
  public IActionResult Update(int id){
    var student = _studentService.GetStudentById(id);
    ViewBag.Departments = _departmentService.GetDepartments();
    return View(student);
  }
   public IActionResult Delete(int id){
    _studentService.DeleteStudent(id);
 return View("Index", _studentService.GetStudents());
  }
  public IActionResult Save(Student student){
  
    if(student.Id == 0){
      _studentService.CreateStudent(student);
    }
    else{
      _studentService.UpdateStudent(student);
    }
    return View("Index", _studentService.GetStudents());
  }

   

    
}

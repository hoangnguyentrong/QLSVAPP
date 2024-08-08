using Microsoft.EntityFrameworkCore;

namespace StudentApp.Models;

    public interface IStudentService //xem như bánh xe trong dependency injection
    {
      List<Student> GetStudents();
      Student? GetStudentById(int id);
      void CreateStudent(Student student);
      void UpdateStudent(Student student);
      void DeleteStudent(int id);

    }
public class StudentService(DataContext dataContext) : IStudentService
{
    private readonly DataContext _dataContext = dataContext;
  
    void IStudentService.CreateStudent(Student student)
    {
       _dataContext.Students.Add(student);
       _dataContext.SaveChanges();
    }

    void IStudentService.DeleteStudent(int id)
    {
     var student = _dataContext.Students.FirstOrDefault(x => x.Id == id); 
     if(student is null) return;
     _dataContext.Students.Remove(student);
     _dataContext.SaveChanges(); 
    }

    Student? IStudentService.GetStudentById(int id)
    {
        return _dataContext.Students.FirstOrDefault(x => x.Id == id); 
    }

    List<Student> IStudentService.GetStudents()
    {
        return _dataContext.Students.Include(s => s.Department).ToList();
    }

    void IStudentService.UpdateStudent(Student student)
    {
        var updateStudent = _dataContext.Students.FirstOrDefault(x => x.Id == student.Id);
        if(updateStudent is null) return;
        updateStudent.Code = student.Code;
        updateStudent.Name = student.Name;
        updateStudent.Birthday = student.Birthday;
        updateStudent.Address = student.Address;
        updateStudent.Department = student.Department;
        _dataContext.SaveChanges();
    }
}
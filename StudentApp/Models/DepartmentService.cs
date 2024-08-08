namespace StudentApp.Models;

    public interface IDepartmentService //xem như bánh xe trong dependency injection
    {
      List<Department> GetDepartments();

    }
    public class DepartmentService(DataContext dataContext) : IDepartmentService 
    {
         private readonly DataContext _dataContext = dataContext;

    List<Department> IDepartmentService.GetDepartments()
    {
        return _dataContext.Departments.ToList();
    }
}
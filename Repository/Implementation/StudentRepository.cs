using StudentCRUD.Models.Context;
using StudentCRUD.Models.Entities;

namespace StudentCRUD.Repository.Interface;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(ApplicationDBContext context) : base(context)
    {
        
    }
}
namespace Students.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Students.Models;
    using Students.Models.Criteria;

    public interface IStudentService
    {
        Task<ActionResult<IEnumerable<Student>>> GetStudents();
        Task<ActionResult<Student>> GetStudent(int id);
        Task<ActionResult<Student>> PutStudent(int id, StudentCriteria criteria);
        Task<ActionResult<Student>> PostStudent(StudentCriteria criteria);
        Task<bool> DeleteStudent(int id);
    }
}

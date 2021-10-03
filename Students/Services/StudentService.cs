namespace Students.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    
    using Microsoft.AspNetCore.Mvc;
    
    using Models;
    using Models.Criteria;
    using Students.Data.WebAPIInMemoryDB.Models;

    public class StudentService : IStudentService
    {
        private readonly StudentDBContext _context;

        public StudentService(StudentDBContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
 
            return student;
        }

        public async Task<ActionResult<Student>> PutStudent(int id, StudentCriteria criteria)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return null;
            }

            student.Name = criteria.Name;
            student.BirthOfDate = criteria.BirthOfDate;
            student.Gender = criteria.Gender;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }

            return student;
        }

        public async Task<ActionResult<Student>> PostStudent(StudentCriteria criteria)
        {
            var maxId = _context.Students.Max(s => s.Id);

            maxId++;

            Student student = new Student(
                id: maxId,
                name: criteria.Name,
                gender: criteria.Gender,
                birthOfDate: criteria.BirthOfDate
            );
           
            _context.Students.Add(student);
         
            await _context.SaveChangesAsync();
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }

            return student;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);

                if (student == null)
                {
                    return false;
                }

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}

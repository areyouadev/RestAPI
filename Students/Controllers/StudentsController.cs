namespace Students.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    
    using Microsoft.AspNetCore.Mvc;
    
    using Models;
    using Services;
    using Models.Criteria;
   
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        #region Fields

        private readonly IStudentService _studentService;

        #endregion Fields

        #region Constructor

        public StudentsController(IStudentService _studentService)
        {
            this._studentService = _studentService;
        }

        #endregion Constructor

        #region  Methods

        /// <summary>
        /// GET: api/Students
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _studentService.GetStudents();
        }
        
        /// <summary>
        ///  GET: api/Students/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {

            var student = await _studentService.GetStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        /// <summary>
        ///  PUT: api/Students/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="criteria"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, StudentCriteria criteria)
        {
            try
            {
                var student = await _studentService.PutStudent(id, criteria);

                if (student == null)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
           
        }

        /// <summary>
        /// POST: api/Students
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(StudentCriteria criteria)
        {
            try
            {
                var student = await _studentService.PostStudent(criteria);

                if (student == null)
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
          
        }
        
        /// <summary>
        /// DELETE: api/Students/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var student = await _studentService.DeleteStudent(id);

                if (student ==false)
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

      

        #endregion Methods
    }
}

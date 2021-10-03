using Microsoft.VisualStudio.TestTools.UnitTesting;
using Students.Controllers;
using Students.Services;
using Xunit;

namespace StudentTests
{
    [TestClass]
    public class StudentTests
    {
        private readonly IStudentService _studentService;

        public StudentTests(IStudentService _studentService)
        {
            this._studentService = _studentService;
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(true,true);
        }


        [Theory]
        public void TestMethod2()
        {
            StudentsController stdController = new StudentsController(this._studentService);

            var result = stdController.GetStudents();
            
            Assert.IsNotNull(result);
        }
    }
}

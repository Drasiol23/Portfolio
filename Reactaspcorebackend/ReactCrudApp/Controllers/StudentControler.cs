using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactCrudApp.Models;
using System.Collections;

namespace ReactCrudApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly StudentDbContext _studentDbContext;


        public StudentController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetStudent")]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentDbContext.Students.ToListAsync();
        }
        [HttpPost]
        [Route("AddStudent")]
        public async Task<Student>AddStudent(Student objectStudent)
        {
            _studentDbContext.Students.Add(objectStudent);
            await _studentDbContext.SaveChangesAsync();
            return objectStudent;
        }


        [HttpPatch]
        [Route("UpdateStudent/{id}")]
        public async Task<Student>UpdateStudent(Student objectStudent)
        {
            _studentDbContext.Entry(objectStudent).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
            return objectStudent;
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]

        public bool DeleteStudent(int id)
        {
            bool a = false;
            var student = _studentDbContext.Students.Find(id);

            if(student != null)
            {
                a = true;
                _studentDbContext.Entry(student).State = EntityState.Deleted;
                _studentDbContext.SaveChanges();
            }
            else
            {
                a = false;
            }
            return a;
        }
    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using SchoolManagement.API.Data;
using SchoolManagement.API.Models;
using SchoolManagement.API.DataTransferObjects;
using SchoolManagament.API.Security;
using System.Threading.Tasks;

namespace SchoolManagement.API.Controllers{
    [Authorize(2)]
    [ApiController]
    [Route("student")]
    public class StudentController:ControllerBase {
        //private readonly StudentRepo _repository;

        public StudentController()
        {

        }
        [HttpGet]
        [Route("lessons")]
        public ActionResult<IEnumerable<Student>> Get()
        {

            return NotFound();


        }
        [HttpGet]
        [Route("lesson/{id}")]
        public ActionResult<IEnumerable<TeacherDTO>> GetLessonById(int id)
        {
            return NotFound();

        }
        [HttpPost]
        [Route("lesson/{id}")]
        public ActionResult<IEnumerable<TeacherDTO>> SignupLesson(int id)
        {
            return NotFound();
        }
        [HttpDelete]
        [Route("lesson/{id}")]
        public ActionResult<IEnumerable<TeacherDTO>> SignoutLesson(int id)
        {
            return NotFound();
        }
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using SchoolManagement.API.Data;
using SchoolManagement.API.Models;
using SchoolManagement.API.DataTransferObjects;
using SchoolManagement.API.Profiles;
using System.Threading.Tasks;
using System;
using SchoolManagament.API.Security;
using SchoolManagement.API.Security;

namespace SchoolManagement.API.Controllers{
    [Authorize(5)]
    [ApiController]
    [Route("admin")]
    public class AdminController:ControllerBase {

        private readonly IRepo<User> _repository;
        private readonly IRepo<Role> _rrepository;
        private readonly IRepo<Teacher> trepository;
        private readonly IRepo<Student> srepository;
        private readonly IRepo<Lesson> lrepository;
        private IMapper _mapper;

         public AdminController(IRepo<Lesson> _lrepository,IRepo<Student> _srepository,IRepo<User> repository,IRepo<Role> rrepository,IRepo<Teacher> _trepository,IMapper mapper)
        {
            _repository = repository;
            _rrepository=rrepository;
            _mapper = mapper;
            trepository = _trepository;
            srepository = _srepository;
            lrepository = _lrepository;
        }
        [HttpGet]
        [Route("users")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _repository.GetAll().Result;
            if(users!=null){
                return  Ok(users); }
            return NoContent();

        }
        /*                 [HttpGet]
                [Route("users")]
                public ActionResult<IEnumerable<UserDTO>> GetAllUsers()
                {
                    var users = _repository.GetAll();
                    if(users!=null){
                        return Ok(_mapper.Map<IEnumerable<UserDTO>>(users)); }
                    return NotFound();
                } */
        [HttpGet]
        [Route("roles")]
        public async Task<List<Role>> GetAllRoles()
        {
            var roles = _rrepository.GetAll();
            if(roles!=null){
                return await roles;}
            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("user/{id}")]
        public async Task<User> GetLesson(int id)
        { 
            var user = _repository.GetById(id);
            if(user!=null){
                return  await user;//Ok(_mapper.Map<UserDTO>(users));
                } 
            throw new NotImplementedException();
            //return await Task<IActionResult>.CompletedTask.GetAwaiter();

        }
        //[HttpPost]
        //[Route("role")]
        //public void CreateRole(Role roleCreate)
        //{
        //    _rrepository.Add(roleCreate);
        //    _rrepository.SaveChanges();
        //}
        [HttpPost]
        [Route("user")]
        public void CreateUser(UserCreateDTO userCreateDTO){
            var user = _mapper.Map<User>(userCreateDTO);
            _repository.Add(user);
            _repository.SaveChanges();
        }
        [HttpDelete]
        [Route("user/{id}")]
        public ActionResult<IEnumerable<UserDTO>> DeleteUser(int id)
        { 
/*             var user = _repository.GetById(id);
            if(user!=null){
                _repository.Delete(user);
                return  Ok(_mapper.Map<IEnumerable<UserDTO>>(user)); } */
            return NotFound();

        }
        [HttpGet("teachers")]
        public async Task<List<Teacher>> GetTeachers(){
            var teacher = trepository.GetAll();
            if(teacher!=null){
                return await teacher;}
            throw new NotImplementedException();

        }
        [HttpGet("teacher/{id}")]
        public async Task<Teacher> GetTeacherById(int id){
            var teacher = trepository.GetById(id);
            if(teacher!=null){
                return await teacher;}
            throw new NotImplementedException();

        }
        [HttpPost]
        [Route("teacher")]
        public void AddTeacher(TeacherCreateDTO teacherCreateDTO)
        {
            var teacher = _mapper.Map<Teacher>(teacherCreateDTO);
            trepository.Add(teacher);
            trepository.SaveChanges();

        }
        [HttpDelete]
        [Route("teacher/{id}")]
        public ActionResult<IEnumerable<TeacherDTO>> DeleteTeacher(int id)
        { 
/*             var teacher = trepository.GetById(id);
            if(teacher!=null){
                trepository.Delete(teacher);
                return  Ok(_mapper.Map<IEnumerable<TeacherDTO>>(teacher)); } */
            return NotFound();

        }
        [HttpGet]
        [Route("students")]
        public async Task<List<Student>> GetStudents(int id)
        {
            var students = srepository.GetAll();
            if (students != null)
            {
                return await students;
            }
            throw new NotImplementedException();

        }
        [HttpGet("student/{id}")]
        public async Task <Student> GetStudent(int id){
            var student = srepository.GetById(id);
            if (student != null)
            {
                return await student;
            }
            throw new NotImplementedException();

        }
        [HttpPost]
        [Route("student")]
        public void AddStudent(Student studentDTO)
        {
            var student = _mapper.Map<Student>(studentDTO);
            srepository.Add(student);
            srepository.SaveChanges();

        }
        [HttpDelete]
        [Route("student/{id}")]
        public ActionResult<IEnumerable<TeacherDTO>> DeleteStudent(int id)
        { 
            return Ok();

        }

        [HttpGet]
        [Route("lessons")]
        public async Task<List<Lesson>> GetLessons()
        {
            var lessons = lrepository.GetAll();
            if (lessons != null)
            {
                return await lessons;
            }
            throw new NotImplementedException();

        }

        [HttpGet]
        [Route("lesson/{id}")]
        public async Task<Lesson> GetLessonById(int id)
        {
            var lesson = lrepository.GetById(id);
            if (lesson != null)
            {
                return await lesson;
            }
            throw new NotImplementedException();

        }
 
        [HttpPost]
        [Route("lesson")]
        public void AddLesson(LessonDTO lessonDTO)
        {
            var lesson = _mapper.Map<Lesson>(lessonDTO);
            lrepository.Add(lesson);
            lrepository.SaveChanges();

        }
   
        [HttpDelete]
        [Route("lesson/{id}")]
        public ActionResult<IEnumerable<TeacherDTO>> DeleteLesson(int id)
        { 
            return Ok();

        }
        
    }
}
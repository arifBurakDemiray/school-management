using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using SchoolManagement.API.Data;
using SchoolManagement.API.Models;
using SchoolManagement.API.DataTransferObjects;
using SchoolManagament.API.Security;
using SchoolManagement.API.Security;

namespace SchoolManagement.API.Controllers{
    [Authorize(4)]
    [ApiController]
    [Route("management")]
    public class SchoolManagerController:ControllerBase {
        private readonly IRepo<User> _repository;

        private readonly IMapper _mapper;

        public SchoolManagerController(IRepo<User> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        [HttpGet]
        [Route("teachers")]
        public ActionResult<IEnumerable<TeacherDTO>> GetAllTeachers()
        {
            //var teachers = _repository.GetAllObjects();
            //return  Ok(_mapper.Map<IEnumerable<TeacherDTO>>(teachers)); 
            return NotFound();

        }
        [HttpGet("teacher/{id}")]
        public ActionResult <TeacherDTO> GetTeacherById(int id){
/*             var teacher = _repository.GetObjectById(id);
            if(teacher!=null){
                return Ok(_mapper.Map<TeacherDTO>(teacher));} */
            return NotFound();

        }
        [HttpPost]
        [Route("teacher")]
        public ActionResult<TeacherDTO> CreateCommand(TeacherCreateDTO teacherCreateDTO){
            /*             var teacher = _mapper.Map<Teacher>(teacherCreateDTO);
                        _repository.CreateObject(teacher);
                        _repository.SaveChanges();
                        var commandReadDto = _mapper.Map<TeacherDTO>(teacher); */
            return NotFound();
            // return CreatedAtRoute(nameof(GetCommandById),new {ID= TeacherDTO.Id},commandReadDto);
        }
        [HttpDelete]
        [Route("teacher/{id}")]
        public ActionResult<IEnumerable<TeacherDTO>> DeleteTeacher(int id)
        {
            return NotFound();

        }
        [HttpGet]
        [Route("students")]
        public ActionResult<IEnumerable<TeacherDTO>> GetStudents(int id)
        {
            return NotFound();

        }
        [HttpGet("student/{id}")]
        public ActionResult <TeacherDTO> GetStudent(int id){
            /*             var teacher = _repository.GetObjectById(id);
                        if(teacher!=null){
                            return Ok(_mapper.Map<TeacherDTO>(teacher));} */
            return NotFound();

        }
        [HttpPost]
        [Route("student")]
        public ActionResult<IEnumerable<TeacherDTO>> AddStudent(int id)
        {
            return NotFound();

        }
        [HttpDelete]
        [Route("student/{id}")]
        public ActionResult<IEnumerable<TeacherDTO>> DeleteStudent(int id)
        {
            return NotFound();

        }
        
    }
}
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
    [Authorize(3)]
    [ApiController]
    [Route("teacher")]
    public class TeacherController:ControllerBase {

        private readonly IRepo<User> _repository;
        private readonly IMapper _mapper;

         public TeacherController(IRepo<User> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("lessons")]
        public ActionResult<IEnumerable<TeacherDTO>> GetLessons(int id)
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
        [Route("lesson")]
        public ActionResult<IEnumerable<TeacherDTO>> AddLesson(int id)
        { 
            return NotFound();

        }
        [HttpDelete]
        [Route("lesson/{id}")]
        public ActionResult<IEnumerable<TeacherDTO>> DeleteLesson(int id)
        { 
            return NotFound();

        }
    }
}
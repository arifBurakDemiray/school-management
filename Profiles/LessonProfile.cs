using System.Threading.Tasks;
using AutoMapper;
using SchoolManagement.API.DataTransferObjects;
using SchoolManagement.API.Models;

namespace SchoolManagement.API.Profiles {
    public class TeacherProfile:Profile{
        public TeacherProfile()
        {
            CreateMap<AbstractEntity, UserDTO>().Include<User,UserDTO>();
            CreateMap<User, UserDTO>();
            //CreateMap<Teacher, TeacherDTO>();
            //CreateMap<TeacherCreateDTO, Teacher>();
            //CreateMap<User, UserDTO>();
            //CreateMap<UserCreateDTO, User>();
            //CreateMap<StudentDTO, Student>();
            //CreateMap<Student, StudentDTO>();
            //CreateMap<Lesson,LessonDTO>();
            //CreateMap<LessonDTO, Lesson>();
        }
    }
}
using System.Collections.Generic;

namespace SchoolManagement.API.DataTransferObjects{
    public class TeacherLessonDTO{
        public int LessonId {get;set;}
        public int TeacherId {get;set;}
        public List<LessonDTO> LessonsOfTeacher { get; set; }
    }
}
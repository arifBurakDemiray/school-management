using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.API.DataTransferObjects {
    public class LessonDTO {

        public string Name { get; set; }
        
        public string Subject { get; set; }

        public int TeacherId { get; set; }

        }
    }

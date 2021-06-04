using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.API.Models {
    public class Lesson : AbstractEntity {

        public string Name { get; set; }
        
        public string Subject { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public Lesson() { }
        public Lesson(int teacherId, string name, string subject) {
            TeacherId = teacherId;
            Name = name;
            Subject = subject; 
        }
    }
}
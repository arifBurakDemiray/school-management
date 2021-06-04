using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.API.Models {
    public class Teacher : AbstractEntity {
        
        [ForeignKey("School")]
        public int SchoolId { get; set; }
        public School School { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public Teacher() { }
        public Teacher(int schoolId, int userId) {
            SchoolId = schoolId;
            UserId = userId;
        }
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.API.Models
{
    public class Student : AbstractEntity
    {
        public string StudentNo { get; set; }

        [ForeignKey("School")]
        public int SchoolId { get; set; }
        public School School { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }


        public Student() { }
        public Student(string stdNo, int schoolId, int userId)
        {
            StudentNo = stdNo;
            SchoolId = schoolId;
            UserId = userId;

        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;


namespace SchoolManagement.API.Models
{
    public class SchoolManager : AbstractEntity
    {
        [ForeignKey("School")]
        public int SchoolId { get; set; }
        public School School { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public SchoolManager() { }
        public SchoolManager(int schoolId, int userId)
        {
            SchoolId = schoolId;
            UserId = userId;
        }
    }
}
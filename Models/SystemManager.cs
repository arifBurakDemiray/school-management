using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.API.Models{
    public class SystemManager:AbstractEntity{
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public SystemManager() { }
        public SystemManager(int userId) {
            UserId = userId;
        }
    }

}
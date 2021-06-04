using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.API.DataTransferObjects
{
    public class TeacherCreateDTO
    {
        public int UserId { get; set; }
        public int SchoolId { get; set; }



    }
}



                    
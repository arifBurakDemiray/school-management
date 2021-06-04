
using System.Collections.Generic;

namespace SchoolManagement.API.DataTransferObjects {
    public class SchoolDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<TeacherDTO> Teachers { get; set; }
    }
}

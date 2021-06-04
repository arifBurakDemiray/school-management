using SchoolManagement.API.DataTransferObjects;

namespace SchoolManagement.API.Models {
    public class School : AbstractEntity {
        public string Name { get; set; }

        public string Address { get; set; }


        public School() { }
        public School(SchoolDTO dto) {
            Id = dto.Id;
            Name = dto.Name;
        }
    }
}
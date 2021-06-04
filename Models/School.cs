using SchoolManagement.API.DataTransferObjects;

namespace SchoolManagement.API.Models {
    public class School : AbstractEntity {
        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
        
        public string WebSite { get; set; }

        public string Email { get; set; }

        public School() { }
        public School(SchoolDTO dto) {
            Id = dto.Id;
            Name = dto.Name;
            PhoneNumber = dto.PhoneNumber;
            WebSite = dto.Website;
        }
    }
}
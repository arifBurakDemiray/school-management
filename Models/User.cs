
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Identity;
using SchoolManagement.API.DataTransferObjects;

namespace SchoolManagement.API.Models {
    public class User : AbstractEntity {
     
        [MaxLength(450)]
        public string Username { get; set; }
        [IgnoreDataMember]
        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        
        [MaxLength(450)]
        public string SSN { get; set; }
        
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public User() { }
        public User(UserDTO userDTO) {
            Username = userDTO.Username;
            Password = userDTO.Password;
            Name = userDTO.Name;
            Surname = userDTO.Surname;
            PhoneNumber = userDTO.PhoneNumber;
            SSN = userDTO.SSN;
        }
    }
}


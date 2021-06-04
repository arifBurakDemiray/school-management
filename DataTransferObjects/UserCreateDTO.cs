


namespace SchoolManagement.API.DataTransferObjects {

    public class UserCreateDTO {

        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int RoleId { get; set; }

    }
}

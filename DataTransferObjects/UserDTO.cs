


namespace SchoolManagement.API.DataTransferObjects {

    public abstract class UserDTO {

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }
        public string Email { get; set; }
    }
}

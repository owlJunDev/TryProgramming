namespace BEnd.DTO
{
    public class UserDTO {
        public string username { get; set; }
        public string pass { get; set; }

        public UserDTO() {}

        public UserDTO(string username, string pass)
        {
            this.username = username;
            this.pass = pass;
        }
    }    
}
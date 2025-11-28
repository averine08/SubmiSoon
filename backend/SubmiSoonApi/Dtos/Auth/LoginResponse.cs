using SubmiSoonApi.Models;

namespace SubmiSoonApi.Dtos.Auth
{
    public class LoginResponse
    {
        public int Id {get; set;}
        public string Email { get; set;} = "";
        public string Name { get; set; } = "";
        public string Role {get; set;} = "";
    }
}
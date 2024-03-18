namespace MagicVilla_API.Models.Dto
{
    public class RegisterationRequestDTO
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }       // We should to get the user's Role too in the registeration
    }
}

// We don't define any class which is "RegisterationResponseDTO"! We just say 200 OK
// But if you would to personalize the Registeration Response, you can also define that class!


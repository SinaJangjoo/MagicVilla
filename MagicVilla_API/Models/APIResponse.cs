using System.Net;

namespace MagicVilla_API.Models
{
    public class APIResponse
    {

        // To handle Nullable ErrorMessages!
        // because inside "UserController" when we register and login successfully
        // the status code will 200Ok and the error message will be null! because of that we create a ctor
        public APIResponse()
        {
            ErrorMessages = new List<string>(); 

        }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
    }
}

using System.Net;

namespace MagicVilla_Web.Models
{
    public class APIResponse
    {
        public HttpStatusCode statusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMasseges { get; set; }
        public object Result { get; set; }
    }
}

using System.Net;

namespace MagicVillaAPI.Models
{
	public class APIResponse
	{
		public APIResponse()
		{
			ErrorMasseges = new List<string>();
		}
		public HttpStatusCode statusCode { get; set; }
		public bool IsSuccess { get; set; } = false;
		public List<string> ErrorMasseges { get; set; }
		public object Result { get; set; }
	}
}

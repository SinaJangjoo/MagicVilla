using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Web.Models.Dto
{
	public class LoginRequestDTO
	{
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }
	}
}

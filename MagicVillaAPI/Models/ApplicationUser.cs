using Microsoft.AspNetCore.Identity;

namespace MagicVillaAPI.Models
{
	public class ApplicationUser:IdentityUser
	{
        public string Name { get; set; }
    }
}

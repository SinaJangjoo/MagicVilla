using MagicVillaAPI.Models;
using MagicVillaAPI.Models.Dto;

namespace MagicVillaAPI.Repository.IRepository
{
	public interface IUserRepository
	{
		bool IsUserUnique(string username);
		Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO);
		Task<LocalUser> RegisterAsync(RegisterRequestDTO registerRequestDTO);
	}
}

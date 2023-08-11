using MagicVilla_Web.Models.Dto;

namespace MagicVilla_Web.Services.IServices
{
	public interface IAuthService
	{
		Task<T> RegisterAsync<T>(RegisterRequestDTO requestDTO);
		Task<T> LoginAsync<T>(LoginRequestDTO requestDTO);
	}
}

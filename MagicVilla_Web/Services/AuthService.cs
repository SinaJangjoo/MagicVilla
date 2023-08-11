using Humanizer;
using MagicVilla_Utilities;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
	public class AuthService : BaseService, IAuthService
	{
		private readonly IHttpClientFactory httpClient;
		private string villaUrl;

		public AuthService(IHttpClientFactory _httpClient, IConfiguration configuration) : base(_httpClient)
		{
			httpClient = _httpClient;
			villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
		}

		public Task<T> LoginAsync<T>(LoginRequestDTO obj)
		{
			return SendAsync<T>(new APIRequest
			{
				ApiType = SD.ApiType.POST,
				Data = obj,
				Url = villaUrl + "/api/UserAuth/loginAsync",
			});
		}

		public Task<T> RegisterAsync<T>(RegisterRequestDTO obj)
		{
			return SendAsync<T>(new APIRequest
			{
				ApiType = SD.ApiType.POST,
				Data = obj,
				Url = villaUrl + "/api/UserAuth/registerAsync",
			});
		}
	}
}

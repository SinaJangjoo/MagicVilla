using MagicVillaAPI.Models;
using MagicVillaAPI.Models.Dto;
using MagicVillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace MagicVillaAPI.Controllers
{
	[Route("api/UserAuth")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserRepository userRepository;
		private APIResponse response;
		public UsersController(IUserRepository _userRepository)
		{
			userRepository = _userRepository;
			response= new APIResponse();
		}
		[HttpPost("registerAsync")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequestDTO registerDTO)
		{
			if (ModelState.IsValid)
			{
				if (!userRepository.IsUserUnique(registerDTO.Username))
				{
					response.IsSuccess = false;
					response.statusCode = HttpStatusCode.BadRequest;
					response.ErrorMasseges.Add("This username already exists");
					return BadRequest(response);
				};
				var user = await userRepository.RegisterAsync(registerDTO);
				if (user == null)
				{
					response.IsSuccess = false;
					response.statusCode = HttpStatusCode.BadRequest;
					response.ErrorMasseges.Add("Error occured during register");
					return BadRequest(response);
				}
				response.IsSuccess = true;
				response.statusCode = HttpStatusCode.OK;
				return Ok(response);
			}
			else
			{
				response.IsSuccess = false;
				response.statusCode = HttpStatusCode.BadRequest;
				response.Result = ModelState;
				return BadRequest(response);
			}
		}
		[HttpPost("loginAsync")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDTO loginRequestDTO)
		{
			var model= await userRepository.LoginAsync(loginRequestDTO);
			if (model.User == null ||string.IsNullOrEmpty( model.Token))
			{
				response.IsSuccess = false;
				response.statusCode = HttpStatusCode.BadRequest;
				response.ErrorMasseges.Add("Username or password is incorrect.");
				return BadRequest(response);
			}
			response.IsSuccess = true;
			response.statusCode = HttpStatusCode.OK;
			response.Result = model;
			return Ok(response);
		}
	}
}

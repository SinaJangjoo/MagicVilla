using AutoMapper;
using MagicVillaAPI.Data;
using MagicVillaAPI.Models;
using MagicVillaAPI.Models.Dto;
using MagicVillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MagicVillaAPI.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly MagicVillaDB magicVillaDB;
		//private readonly Mapper mapper;
		private string secretKey;

		public UserRepository(MagicVillaDB _magicVillaDB, IConfiguration configuration)
		{
			magicVillaDB = _magicVillaDB;
			//mapper = _mapper;
			secretKey = configuration.GetValue<string>("APISettings:secretkey");
		}

		public bool IsUserUnique(string username)
		{
			bool User = true;
			return User = magicVillaDB.LocalUsers.Any(x => x.Username.ToLower() == username.ToLower()) ? false : true;

		}

		public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO)
		{
			var user = await magicVillaDB.LocalUsers.FirstOrDefaultAsync(x => x.Username.ToLower() == loginRequestDTO.Username.ToLower() && x.Password == loginRequestDTO.Password);
			if (user == null)
			{
				LoginResponseDTO dto = new LoginResponseDTO
				{
					Token = "",
					User = null
				};
				return dto;
			}

			//if user was found generate JWT token
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(secretKey);

			var tokenDiscriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name,user.Id.ToString()),
					new Claim(ClaimTypes.Role,user.Role)
				}),
				Expires = DateTime.Now.AddDays(7),
				SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDiscriptor);
			LoginResponseDTO loginResponseDTO = new LoginResponseDTO
			{
				Token = tokenHandler.WriteToken(token),
				User = user,
			};
			return loginResponseDTO;

		}

		public async Task<LocalUser> RegisterAsync(RegisterRequestDTO registerRequestDTO)
		{
			LocalUser user = new LocalUser()
			{
				Name = registerRequestDTO.Name,
				Username=registerRequestDTO.Username,
				Password = registerRequestDTO.Password,
				Role = registerRequestDTO.Role,
			};
			//user = mapper.Map<LocalUser>(registerRequestDTO);
			await magicVillaDB.LocalUsers.AddAsync(user);
			await magicVillaDB.SaveChangesAsync();
			user.Password = "";
			return user;
		}

        
    }
}

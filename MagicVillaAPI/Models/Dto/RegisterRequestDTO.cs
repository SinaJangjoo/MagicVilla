﻿using System.ComponentModel.DataAnnotations;

namespace MagicVillaAPI.Models.Dto
{
	public class RegisterRequestDTO
	{
		public string Name { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public string Role { get; set; }
	}
}

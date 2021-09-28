﻿using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.AuthenticationDTOs
{
    public class LoginRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

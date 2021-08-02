﻿using System.Text.Json;

namespace Application.DTOs
{
    class ErrorDetailsDTO
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

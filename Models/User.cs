using System;
using Microsoft.AspNetCore.Mvc;

namespace UserFormApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public byte[]? Image { get; set; }
    }
}

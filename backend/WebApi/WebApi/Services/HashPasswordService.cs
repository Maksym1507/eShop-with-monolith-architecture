﻿using System.Security.Cryptography;
using System.Text;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class HashPasswordService
    {
        public static string HashPassword(string password)
        {
            var asByteArray = Encoding.Default.GetBytes(password);
            var hashedPasswrod = SHA256.Create().ComputeHash(asByteArray);
            return Convert.ToBase64String(hashedPasswrod);
        }
    }
}

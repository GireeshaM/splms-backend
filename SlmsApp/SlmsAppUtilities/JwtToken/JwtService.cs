using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppUtilities.JwtToken
{
    public class JwtService : IJwtService
    {
        private readonly string _secretKey;
        private readonly SlmsAppContext _context; // DbContext for querying the database

        // Injecting DbContext into JwtService
        public JwtService(string secretKey, SlmsAppContext context)
        {
            _secretKey = secretKey;
            _context = context;  // Store the DbContext for querying the database
        }

        public string GenerateToken(User user)
        {
            // Fetch the role name from the Roles table using RolesId
            // In JwtService.cs

            var roleName = GetRoleNameById(user.RolesId);

            // Set up the claims for the JWT token
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim("RolesId", user.RolesId.ToString()), // Include RolesId as a claim
                new Claim(ClaimTypes.Role, roleName), // Include Role name as a claim
                new Claim(ClaimTypes.Email,user.Email)
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "your-app",
                audience: "your-app",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // Method to fetch the role name based on RolesId
        private string GetRoleNameById(int roleId)
        {
            var role = _context.Roles.SingleOrDefault(r => r.RolesId == roleId);
            return role?.Name ?? "DefaultRole";  // Return the role name, or a default role if not found
        }
    }
}

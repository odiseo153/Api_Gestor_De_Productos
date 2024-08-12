using Gestor_Productos.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Gestor_Productos.Infraestructure.Repository
{
    public class JWTServices : DelegatingHandler
    {
        public static string key = "Odiseo esta probando Odiseo esta probando Odiseo esta probando Odiseo esta probando Odiseo esta probando Odiseo esta probando Odiseo esta probando Odiseo esta probando Odiseo esta probando Odiseo esta probando";

        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary> 
        /// Constructor for <see cref="JwtServices"/>.
        /// </summary>
        /// <param name="jwtSettings">The JWT settings injected via options.</param>
        /// <param name="httpContextAccessor">The HTTP context accessor for retrieving tokens.</param>
        public JWTServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }

        public async Task<string> GetSecurityToken(Users user)
        {
            // Retrieve user claims and roles
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Name),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id)
            };

            // Create symmetric security key and signing credentials
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            // Create JWT security token with issuer, audience, claims, expiration, and signing credentials
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: signingCredentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(jwtSecurityToken);

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenString);


            // Return the token string to the client
            return tokenString;
        }
          

        /// <summary>
        /// Retrieves the ID of the authenticated user from the JWT token.
        /// </summary>
        /// <returns>The ID of the authenticated user.</returns>
        public string GetIdUser()
        {
            try
            {
                // Retrieve authorization header and extract JWT token
                string authorization = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                string tokenRequest = authorization.Replace("Bearer", "").Trim();
                JwtSecurityToken jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(tokenRequest);

                // Retrieve and return the 'uid' claim value from the JWT token
                Claim idUser = jwtToken.Claims.FirstOrDefault(x => x.Type == "uid");
                return idUser?.Value ?? throw new ApplicationException("User ID claim not found in token.");
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Generates a refresh token.
        /// </summary>
        /// <returns>The generated refresh token.</returns>
        public IActionResult GenerateRefreshToken()
        {
            return new JsonResult(new
            {
                Token = RandomTokenString(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow
            });
        }

        /// <summary>
        /// Generates a random token string using cryptographic RNG.
        /// </summary>
        /// <returns>The generated random token string.</returns>
        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);

            return BitConverter.ToString(randomBytes).Replace("-", "");
        }

    }
}


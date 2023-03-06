using CloneIntime.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CloneIntime.Services
{
    public class SupportService
    {

        private readonly Context _context;

        public SupportService (Context context)
        {
            _context = context;
        }   

        private ClaimsIdentity GetIdentity(string email, string id)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, email),
                new Claim(JwtRegisteredClaimNames.NameId, id),
            };
            ClaimsIdentity claimidentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
            ClaimTypes.NameIdentifier);
            return claimidentity;
        }

        public JwtSecurityToken GenerateJWT(string email, string id)
        {
            var now = DateTime.UtcNow;
            var identity = GetIdentity(email, id);
            var jwt = new JwtSecurityToken(
                issuer: JWTConfiguration.Issuer,
                audience: JWTConfiguration.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.AddMinutes(JWTConfiguration.Lifetime),
                signingCredentials: new SigningCredentials(JWTConfiguration.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return jwt;
        }

        /*private void ValidateData(List<UserEntity> users, UserRegisterModel model)
        {
            if (users == null)
                throw new UserNotFoundException();

            foreach (var user in users)
            {
                if (user.EmailAddress == model.Email)
                    throw new EmailAlreadyInBaseException();

                if (user.FullName == model.FullName)
                    throw new NickNameAlreadyInBaseException();

                if (user.PhoneNumber == model.PhoneNumber)
                    throw new PhoneAlreadyInBaseException();
           }*/
        //}
    }
}

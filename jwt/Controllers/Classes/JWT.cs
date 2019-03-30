using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace jwt.Controllers.Classes
{
    public class JWT
    {
        public static string Issuer = "http://localhost:44345";
        public static string Audience = "http://localhost:44345";

        public static byte[] GetEncoding
        {
            get
            {
                return Encoding.UTF8.GetBytes("TW9zaGVFcmV6UHJpdmF0ZUtleQ==");
            }
        }

        public static SymmetricSecurityKey GetSecretKey
        {
            get
            {
                return new SymmetricSecurityKey(GetEncoding);
            }
        }

        public static SigningCredentials GetSigninCredentials {
            get
            {
                return new SigningCredentials(GetSecretKey, SecurityAlgorithms.HmacSha256Signature);
            }
        } 

        public static JwtSecurityToken GetJwtSecurityToken(string id_user, string username, string GUID, string MongoDocumentID)
        {
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, id_user),
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.SerialNumber, GUID),
                    new Claim(ClaimTypes.Hash, MongoDocumentID)
                },
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: GetSigninCredentials
                );
            return jwtSecurityToken;
        }

        public static string GetToken(string id_user, string username, string GUID, string MongoDocumentID)
        {
            JwtSecurityToken token = GetJwtSecurityToken(id_user, username, GUID, MongoDocumentID);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using vrbit.wsapi.ticket.Data.ConvertersImpl;
using vrbit.wsapi.ticket.Data.VO;
using vrbit.wsapi.ticket.Model;
using vrbit.wsapi.ticket.Repository;
using vrbit.wsapi.ticket.Security.Configuration;

namespace vrbit.wsapi.ticket.Business.Implementations
{
    public class LoginBusinessImpl : ILoginBusiness
    {

        private IUserRepository _userRepository;
        private SigningConfiguration _signingConfiguration;
        private TokenConfiguration _tokenConfiguration;

        public LoginBusinessImpl(IUserRepository userRepository, SigningConfiguration signingConfiguration, TokenConfiguration tokenConfiguration) 
        {
            _userRepository = userRepository;
            _signingConfiguration = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
        }

        public object FindByLogin(User user)
        {
            bool credentialsIsValid = false;

            if(user != null && !string.IsNullOrWhiteSpace(user.Login))
            {
                var baseUser = _userRepository.FindByLogin(user.Login);
                credentialsIsValid = (baseUser != null && user.Login == baseUser.Login && user.AccessKey == baseUser.AccessKey);
            }

            if (credentialsIsValid)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Login, "Login"),
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Login)
                    }
                    );

                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expirationDate, handler);

                return SucessObject(createDate, expirationDate, token);
            }
            else
            {
                return ExceptionObject();
            }
                                
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object ExceptionObject()
        {
            return new
            {
                authenticated = false,
                message = "Failed to authenticate"
            };
        }

        private object SucessObject(DateTime createDate, DateTime expirationDate, string token)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("YYYY-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("YYYY-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };
        }
    }
}

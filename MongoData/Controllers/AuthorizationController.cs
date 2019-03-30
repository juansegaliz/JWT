using MongoData.Models.DAL;
using MongoData.Models.DTO;
using MongoData.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoData.Controllers
{
    public class AuthorizationController
    {
        private readonly IAuthorizationRepository authorizationRepository; 

        public AuthorizationController()
        {
            authorizationRepository = new AuthorizationRepository();
        }

        public string Create(AuthorizationDTO authorization)
        {
            return authorizationRepository.Create(authorization);
        }

        public List<AuthorizationDTO> Read()
        {
            return authorizationRepository.Read();
        }

        public AuthorizationDTO Read(string Id)
        {
            return authorizationRepository.Read(Id);
        }

        public void Update(string Id, AuthorizationDTO authorization)
        {
            authorizationRepository.Update(Id, authorization);
        }

        public void Delete(string Id)
        {
            authorizationRepository.Delete(Id);
        }
    }
}

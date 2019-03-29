using System;
using System.Collections.Generic;
using System.Text;
using MongoData.Models.DTO;


namespace MongoData.Models.Interfaces
{
    public interface IAuthorizationRepository : IDisposable
    {
        void Create(AuthorizationDTO authorization);
        List<AuthorizationDTO> Read();
        void Update(string Id, AuthorizationDTO authorization);
        void Delete(string Id);
    }
}

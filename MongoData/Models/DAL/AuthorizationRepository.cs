using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoData.Models.DBContext;
using MongoData.Models.DTO;
using MongoData.Models.Interfaces;

namespace MongoData.Models.DAL
{
    public class AuthorizationRepository : IAuthorizationRepository, IDisposable
    {
        private MongoDBContext _mongoDBContext;
        private IMongoCollection<AuthorizationDTO> _authorizations;

        public AuthorizationRepository()
        {
            this._mongoDBContext = new MongoDBContext();
            _authorizations = _mongoDBContext.Database.GetCollection<AuthorizationDTO>("authorizations");
        }

        public void Create(AuthorizationDTO authorization)
        {
            _authorizations.InsertOne(authorization);
        }

        public List<AuthorizationDTO> Read()
        {
            return _authorizations.AsQueryable<AuthorizationDTO>().ToList();
        }

        public void Update(string Id, AuthorizationDTO authorization)
        {
            _authorizations.ReplaceOne(Builders<AuthorizationDTO>.Filter.Eq("Id", Id), authorization);
        }

        public void Delete(string Id)
        {
            _authorizations.DeleteOne(Builders<AuthorizationDTO>.Filter.Eq("Id", Id));
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}

using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoData.Models.DBContext;
using MongoData.Models.DTO;
using MongoData.Models.Interfaces;
using MongoDB.Bson;

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

        public string Create(AuthorizationDTO authorization)
        {
            authorization.Id = new ObjectId();
            _authorizations.InsertOne(authorization);
            return authorization.Id.ToString();
        }

        public List<AuthorizationDTO> Read()
        {
            return _authorizations.AsQueryable<AuthorizationDTO>().ToList();
        }

        public AuthorizationDTO Read(string Id)
        {
            return _authorizations.AsQueryable<AuthorizationDTO>().ToList().Where(r => r.Id.Equals(Id)).FirstOrDefault();
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

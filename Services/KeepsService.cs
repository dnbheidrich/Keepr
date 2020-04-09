using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;
        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Keep> Get()
        {
            return _repo.Get();
        }
          internal IEnumerable<Keep> GetUserKeeps(string userId)
        {
            return _repo.GetUserKeeps(userId);
        }
           public Keep GetById(int id, string userId)
        {
            Keep found = _repo.GetById(id, userId);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

          public Keep GetEditById(int id)
        {
            Keep found = _repo.GetEditById(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }
         internal IEnumerable<VaultKeepViewModel> GetKeepByVaultId(int vaultId, string userId)
        {
            return _repo.GetByVaultId(vaultId, userId);
        }

        public Keep Create(Keep newKeep)
        {
            return _repo.Create(newKeep);
        }

     internal Keep Edit(Keep updatedKeep)
        {
            Keep found = GetEditById(updatedKeep.Id);
            if (found.UserId != updatedKeep.UserId)
            {
                throw new Exception("Invalid Request");
            }
            found.Name = updatedKeep.Name;
            found.Description = updatedKeep.Description;
            found.Img = updatedKeep.Img != null ? updatedKeep.Img : found.Img;
            return _repo.Edit(found);
        }

    internal Keep Delete(int id, string userId)
        {
            Keep found = GetEditById(id);
            if (found.UserId != userId)
            {
                throw new Exception("Invalid Request");
            }
            if (_repo.Delete(id))
            {
                return found;
            }
            throw new Exception("Something went terribly wrong");
        }
  }
}
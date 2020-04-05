using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;

        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Vault> Get()
        {
            string sql = "SELECT * FROM vaults";
            return _db.Query<Vault>(sql);
        }
         public Vault GetById(int Id)
        {
            string sql = "SELECT * FROM vaults WHERE id = @Id";
            return _db.QueryFirstOrDefault<Vault>(sql, new { Id });
        }

        

        internal Vault Create(Vault newVault)
        {
             string sql = @"
            INSERT INTO vaults
            (name, description, userId)
            VALUES
            (@Name, @Description, @UserId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newVault);
            newVault.Id = id;
            return newVault;
        }



      internal bool Delete(int Id)
        {
            string sql = "DELETE FROM vaults WHERE id = @Id LIMIT 1";
            int removed = _db.Execute(sql, new { Id });
            return removed == 1;
        }
  }
}
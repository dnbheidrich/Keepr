using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;
        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal VaultKeep Create(VaultKeep newVaultKeep)
        {
            string sql = @"
            INSERT INTO vaultkeeps 
            (keepId, vaultId, userId) 
            VALUES 
            (@KeepId, @VaultId, @UserId);
            SELECT LAST_INSERT_ID()";
            newVaultKeep.Id = _db.ExecuteScalar<int>(sql, newVaultKeep);
            return newVaultKeep;
        }

        internal VaultKeep Get(int Id)
        {
            string sql = "SELECT * FROM vaultkeeps WHERE id = @Id";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new { Id });
        }

        internal bool Delete(int Id)
        {
            string sql = "DELETE FROM vaultkeeps WHERE id = @Id LIMIT 1";
            int removed = _db.Execute(sql, new { Id });
            return removed == 1;
        }
    }
}
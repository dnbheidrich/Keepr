using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Keep> Get()
        {
            string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
            return _db.Query<Keep>(sql);
        }
         internal IEnumerable<Keep> GetUserKeeps(string UserId)
        {
            string sql = "SELECT * FROM keeps WHERE userId = @UserId";
            return _db.Query<Keep>(sql, new { UserId });
        }
         public Keep GetById(int Id)
        {
            string sql = "SELECT * FROM keeps WHERE id = @Id";
            return _db.QueryFirstOrDefault<Keep>(sql, new { Id });
        }

         internal IEnumerable<VaultKeepViewModel> GetByVaultId(int VaultId, string userId)
        {
            string sql = @"
                SELECT 
                k.*,
                vk.id as vaultKeepId
                FROM vaultkeeps vk
                INNER JOIN keeps k ON k.id = vk.keepId 
                WHERE (vaultId = @vaultId AND vk.userId = @userId)";

            return _db.Query<VaultKeepViewModel>(sql, new { VaultId, userId });

        }
        

        internal Keep Create(Keep newKeep)
        {
             string sql = @"
            INSERT INTO keeps
            (name, description, userId, img, isPrivate, views, shares, keeps)
            VALUES
            (@Name, @Description, @UserId, @Img, @IsPrivate, @Views, @Shares, @Keeps);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newKeep);
            newKeep.Id = id;
            return newKeep;
        }

  public Keep Edit(Keep updatedKeep)
        {
            string sql = @"
            UPDATE keeps
            SET
                name = @Name,
                description = @Description,
                img  = @Img
            WHERE id = @Id;
            ";
            _db.Execute(sql, updatedKeep);
            return updatedKeep;
        }

      internal bool Delete(int Id)
        {
            string sql = "DELETE FROM keeps WHERE id = @Id LIMIT 1";
            int removed = _db.Execute(sql, new { Id });
            return removed == 1;
        }
  }
}
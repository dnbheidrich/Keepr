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
         public Keep GetById(int Id)
        {
            string sql = "SELECT * FROM keeps WHERE id = @Id";
            return _db.QueryFirstOrDefault<Keep>(sql, new { Id });
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
            string sql = "DELETE FROM blogs WHERE id = @Id LIMIT 1";
            int removed = _db.Execute(sql, new { Id });
            return removed == 1;
        }
  }
}
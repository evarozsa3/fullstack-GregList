using System;
using System.Data;
using Dapper;
using fullstack_gregslist.Models;

namespace fullstack_gregslist.Repositories
{
  public class CarsRepository
  {
    private readonly IDbConnection _db;

    public CarsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Car Create(Car newCar)
    {
      string sql = @"
        INSERT INTO cars
        (make, model, userId)
        VALUES
        (@Make, @Model, @UserId);
        SELECT LAST_INSERT_ID()";
      newCar.Id = _db.ExecuteScalar<int>(sql, newCar);
      return newCar;
    }
  }
}
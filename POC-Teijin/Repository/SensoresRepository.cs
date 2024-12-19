using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace POC_Teijin.Repository
{
    public class SensoresRepository
    {
        private readonly string _connectionString;


        public SensoresRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Sensores>> GetDataAsync()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                return await connection.QueryAsync<Sensores>("SELECT * FROM dbo.Sensores");
            }
            catch (Exception ex)
            {
                // Handle the exception
                throw;
            }
        }

        public async Task<IEnumerable<Sensores>> SaveDataAsync(Sensores sensorData)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                return await connection.QueryAsync<Sensores>("INSERT INTO dbo.Sensores (Id, Nome, Estado) VALUES ("+sensorData.Id+", '"+sensorData.Nome+"',"+sensorData.Estado+")");
               
            }
            catch (Exception ex)
            {
                // Handle the exception
                throw;
            }
        }
    }
}

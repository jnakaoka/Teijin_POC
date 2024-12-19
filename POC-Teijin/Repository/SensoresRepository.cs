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
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    return await connection.QueryAsync<Sensores>("SELECT * FROM public.\"Sensores\"");
                }
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
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    return await connection.QueryAsync<Sensores>("INSERT INTO public.\"Sensores\" (Id, Nome) VALUES (1, 'John Doe')");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                throw;
            }
        }


        //private readonly MyDbContext _context;

        //public SensoresRepository(MyDbContext context)
        //{
        //    _context = context;
        //}

        ////public List<Sensores> saveAndGetSensoresfromDb() {
        ////    using (var context = new MyDbContext())
        ////    {
        ////        // Create a new instance of MyModel
        ////        var sensoresModel = new Sensores { Name = "John Doe" };

        ////        // Add the instance to the database
        ////        context.Sensores.Add(sensoresModel);
        ////        context.SaveChanges();

        ////        // Retrieve all instances of MyModel from the database
        ////        var myModels = context.Sensores.ToList();
        ////        return myModels;
        ////    }

        ////}

        //public async Task SaveDataAsync(Sensores sensorData)
        //{
        //    try
        //    {
        //        var query = _context.Sensores.Where(s => s.Id == 1);
        //        var result = await query.FirstOrDefaultAsync();
        //        await _context.Sensores.AddAsync(sensorData);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle the exception
        //        throw;
        //    }
        //}

        //public async Task<IEnumerable<Sensores>> GetDataAsync()
        //{
        //    try
        //    {
        //        return await _context.QueryAsync<Sensores>("SELECT * FROM Products");
        //        //return await _context.Sensores.ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle the exception
        //        throw;
        //    }
        //}
    }
}

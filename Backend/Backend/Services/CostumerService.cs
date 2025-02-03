using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Dapper;
using Npgsql;

namespace Backend.Services
{
    public class CostumerService
    {
        private readonly ILogger<CostumerService> _logger;
        private readonly NpgsqlConnection _connection;
        private readonly IMapper _mapper;

        public CostumerService(ILogger<CostumerService> logger, NpgsqlConnection connection, IMapper mapper)
        {
            _logger = logger;
            _connection = connection;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Costumer>> GetAll()
        {
            var sql = "SELECT * FROM Costumers";
            var costumers = await _connection.QueryAsync<Costumer>(sql);
            return costumers;
        }

        public async Task<Costumer> Get(string name)
        {
            var sql = "SELECT * FROM Costumers WHERE Name LIKE @Name";
            var costumer = await _connection.QuerySingleOrDefaultAsync<Costumer>(sql, new { Name = $"%{name}%" });
            return costumer;
        }

        public async Task Post(CostumerDTO costumerDTO)
        {
            var sql = "INSERT INTO Costumers (EMAIL,NAME,PASSWORD) VALUES (@Email,@Name,@Password)";
            await _connection.ExecuteAsync(sql, new { Email = costumerDTO.Email, Name = costumerDTO.Name, Password = costumerDTO.Password });
        }

        public async Task Put(Costumer costumer)
        {
            var sql = "UPDATE Costumers SET Email = @Email, Name = @Name, Password = @Password WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { Id = costumer.Id, Email = costumer.Email, Name = costumer.Name, Password = costumer.Password });
        }

        public async Task Delete(int id)
        {
            var sql = "DELETE FROM Costumers WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { @Id = id });
        }
    }
}

using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VS2019.API.Infrastructure.Interfaces;
using VS2019.API.Models;

namespace VS2019.API.Infrastructure
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventoContext _eventoContext;

        public EventoRepository(EventoContext eventoContext)
        {
            _eventoContext = eventoContext;
        }

        public async Task<IEnumerable<Evento>> GetAllByLimit(int limit)
        {
            var sql = @"SELECT TOP (@Limit) Id, Nome, Participantes
                          FROM dbo.Evento";

            return await _eventoContext.EventoConnection.QueryAsync<Evento>(sql, new { Limit = limit });
        }

        public void Add(Evento evento)
        {
            var sql = @"INSERT INTO dbo.Evento (Id, Nome, Participantes)
                            VALUES (@Id, @Nome, @Palestrantes);";

            _eventoContext.EventoConnection.Execute(sql, new { evento.Id, evento.Nome, evento.Participantes });
        }
    }
}

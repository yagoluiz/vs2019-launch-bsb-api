using System.Collections.Generic;
using System.Threading.Tasks;
using VS2019.API.Infrastructure.Interfaces;
using VS2019.API.Models;
using VS2019.API.Services.Interfaces;

namespace VS2019.API.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<IEnumerable<Evento>> GetAllByLimit(int limit)
        {
            return await _eventoRepository.GetAllByLimit(limit);
        }

        public void Add(Evento evento)
        {
            _eventoRepository.Add(evento);
        }
    }
}

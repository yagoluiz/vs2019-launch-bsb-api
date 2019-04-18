using System.Collections.Generic;
using System.Threading.Tasks;
using VS2019.API.Models;

namespace VS2019.API.Services.Interfaces
{
    public interface IEventoService
    {
        Task<IEnumerable<Evento>> GetAllByLimit(int limit);
        void Add(Evento evento);
    }
}

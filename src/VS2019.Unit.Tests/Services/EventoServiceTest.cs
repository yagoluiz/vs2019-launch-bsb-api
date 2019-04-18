using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using VS2019.API.Infrastructure.Interfaces;
using VS2019.API.Models;
using VS2019.API.Services;
using VS2019.Unit.Tests.Mocks;
using Xunit;

namespace VS2019.Unit.Tests.Services
{
    public class EventoServiceTest
    {
        private readonly Mock<IEventoRepository> _eventoRepositoryMock;

        public EventoServiceTest()
        {
            _eventoRepositoryMock = new Mock<IEventoRepository>();
        }

        [Fact]
        public async Task GetAllByLimit_NotNull()
        {
            int limit = 10;

            _eventoRepositoryMock.Setup(x => x.GetAllByLimit(limit))
                .ReturnsAsync(new EventoMock().GetEventos());

            var eventoService = new EventoService(_eventoRepositoryMock.Object);
            var eventoMethod = await eventoService.GetAllByLimit(limit);

            var eventoResult = Assert.IsAssignableFrom<IEnumerable<Evento>>(eventoMethod);

            Assert.NotNull(eventoResult);
        }
    }
}

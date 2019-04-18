using Bogus;
using System.Collections.Generic;
using VS2019.API.Models;

namespace VS2019.Unit.Tests.Mocks
{
    public class EventoMock
    {
        private Faker _faker;

        public Evento GetEvento()
        {
            _faker = new Faker();

            return new Evento(
                id: _faker.Random.Number(),
                nome: _faker.Name.LastName(Bogus.DataSets.Name.Gender.Male),
                participantes: $"{_faker.Name.LastName(Bogus.DataSets.Name.Gender.Female)}"
            );
        }

        public List<Evento> GetEventos()
        {
            return new List<Evento>
            {
                GetEvento(),
                GetEvento(),
                GetEvento(),
            };
        }
    }
}

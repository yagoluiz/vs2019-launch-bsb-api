namespace VS2019.API.Models
{
    public class Evento
    {
        public Evento(int id, string nome, string participantes)
        {
            Id = id;
            Nome = nome;
            Participantes = participantes;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Participantes { get; private set; }
    }
}

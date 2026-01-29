using GamesOps.Domain.Exceptions;

namespace GamesOps.Domain.Entities
{
    public class Studio
    {
        private Guid _id;
        private string _name;
        private DateTime _createdAt;
        private readonly List<Game> _games = new();

        public Guid Id { get => _id; }
        public string Name { get => _name; }
        public DateTime CreatedAt { get => _createdAt; }
        public IReadOnlyCollection<Game> Games { get => _games.AsReadOnly(); }

        public Studio(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException($"Studio name cannot be empty");
            }

            _id = Guid.NewGuid();
            _name = name.Trim();
            _createdAt = DateTime.UtcNow;
        }

        public void Rename(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException($"Studio name cannot be empty");
            }

            this._name = name.Trim();
        }

        public void AddGame(string name)
        {
            if (_games.Any(g => g.Name == name))
            {
                throw new DomainException("Game name must be unique per studio");
            }                

            var newGame = new Game(_id, name);

            _games.Add(newGame);
        }
    }
}

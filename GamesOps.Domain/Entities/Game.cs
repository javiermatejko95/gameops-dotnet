using GamesOps.Domain.Exceptions;

namespace GamesOps.Domain.Entities
{
    public class Game
    {
        private Guid _id;
        private string _name;
        private DateTime _createdAt;        

        public Guid Id { get => _id; }
        public string Name { get => _name; }
        public DateTime CreatedAt { get => _createdAt; }        

        public Game(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException($"Game name cannot be empty");
            }

            _id = Guid.NewGuid();
            _name = name.Trim();
            _createdAt = DateTime.UtcNow;
        }        
    }
}

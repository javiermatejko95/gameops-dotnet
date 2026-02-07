using GameOps.Domain.Exceptions;

namespace GameOps.Domain.Entities
{
    public class Game
    {
        private Guid _id;
        private string _name;
        private DateTime _createdAt;
        private Guid _studioId;

        public Guid Id { get => _id; }
        public string Name { get => _name; }
        public DateTime CreatedAt { get => _createdAt; }   
        public Guid StudioId {  get => _studioId; }

        public Game(Guid studioId, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException($"Game name cannot be empty");
            }

            _id = Guid.NewGuid();
            _name = name.Trim();
            _createdAt = DateTime.UtcNow;
            _studioId = studioId;
        }
    }
}

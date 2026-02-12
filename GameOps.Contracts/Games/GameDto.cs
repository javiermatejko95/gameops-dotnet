namespace GameOps.Contracts.Games
{
    public class GameDto
    {
        private Guid _id;
        private string _name;
        private DateTime _createdAt;
        private Guid _studioId;

        public Guid Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public DateTime CreatedAt { get => _createdAt; set => _createdAt = value; }
        public Guid StudioId { get => _studioId; set => _studioId = value; }
    }
}

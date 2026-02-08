namespace GameOps.Contracts.Studios
{
    public class StudioDto
    {
        private Guid _id;
        private string _name;
        private DateTime _createdAt;
        public Guid Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public DateTime CreatedAt { get => _createdAt; set => _createdAt = value; }
        //public List<GameDto> Games { get; set; } = new();
    }
}

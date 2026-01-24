using GamesOps.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesOps.Domain.Entities
{
    public class Studio
    {
        private Guid id;
        private string name;
        private DateTime createdAt;

        public Guid Id { get => id; }
        public string Name { get => name; }
        public DateTime CreatedAt { get => createdAt; }

        public Studio(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException($"Studio name cannot be empty");
            }

            id = Guid.NewGuid();
            this.name = name.Trim();
            createdAt = DateTime.UtcNow;
        }

        public void Rename(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException($"Studio name cannot be empty");
            }

            this.name = name.Trim();
        }
    }
}

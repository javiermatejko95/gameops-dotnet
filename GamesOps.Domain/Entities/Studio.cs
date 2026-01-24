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

        public Studio(string studioName)
        {
            if(string.IsNullOrWhiteSpace(studioName))
            {
                throw new DomainException($"Studio name cannot be empty");
            }

            id = Guid.NewGuid();
            name = studioName.Trim();
            createdAt = DateTime.UtcNow;
        }

        public void Rename(string newStudioName)
        {
            if (string.IsNullOrWhiteSpace(newStudioName))
            {
                throw new DomainException($"Studio name cannot be empty");
            }

            name = newStudioName.Trim();
        }
    }
}

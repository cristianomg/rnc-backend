using _4Lab.Core.DomainObjects;
using _4Lab.Core.Enums;
using System;

namespace _4lab.Occurrences.Domain.Models
{
    public class Archive : Entity<Guid>
    {
        public Archive(string key, string fileName, string fileType, EntityArchiveType entityType, string entityId)
        {
            Id = Guid.NewGuid();
            Key = key;
            FileName = fileName;
            FileType = fileType;
            EntityType = entityType;
            EntityId = entityId;
        }
        protected Archive () { }
        public string Key { get; private set; }
        public string FileName { get; private set; }
        public string FileType { get; private set; }
        public EntityArchiveType EntityType { get; private set; }
        public string EntityId { get; private set; }

    }
}

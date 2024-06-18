using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Domain.Models.Base
{
    public abstract class Entity
    {
        public Guid Id { get ; set ; }

        private Guid _createdBy;
        public Guid CreatedBy { get => _createdBy; set => SetProperty(ref _createdBy, value, nameof(CreatedBy)); }

        private DateTime _createdOn;
        public DateTime CreatedOn { get => _createdOn; set => SetProperty(ref _createdOn, value, nameof(CreatedOn)); }

        private Guid _modifiedBy;
        public Guid ModifiedBy { get => _modifiedBy; set => SetProperty(ref _modifiedBy, value, nameof(ModifiedBy)); }

        private DateTime _modifiedOn;
        public DateTime ModifiedOn { get => _modifiedOn; set => SetProperty(ref _modifiedOn, value, nameof(ModifiedOn)); }

        private Guid _ownerId;
        public Guid OwnerId { get => _ownerId; set => SetProperty(ref _ownerId, value, nameof(OwnerId)); }

        public Dictionary<string, object> UpdatedProperties { get; private set; } = new Dictionary<string, object>();

        protected void SetProperty<T>(ref T field, T value, string propertyName)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                if (UpdatedProperties.ContainsKey(propertyName))
                {
                    UpdatedProperties[propertyName] = value;
                }
                else
                {
                    UpdatedProperties.Add(propertyName, value);
                }
            }
        }
    }
}

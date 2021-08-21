using System;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public object this[string propertyName]
        {
            get
            {
                var propertyInfo = GetType().GetProperty(propertyName);
                return propertyInfo.GetValue(this);
            }
            set
            {
                var prop = this.GetType().GetProperty(propertyName);
                prop.SetValue(this, value);
            }
        }
    }
}

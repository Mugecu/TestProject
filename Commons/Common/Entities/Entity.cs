namespace Common.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Guid Id { get; protected internal set; }

        public bool Equals(Entity? obj)
        {
            var entity = obj as Entity;
            if (ReferenceEquals(entity, null)) return false;
            if (ReferenceEquals(this, entity)) return true;
            if (GetType() != entity.GetType()) return false;
            return Id == entity.Id;
        }

        public void GenerateId()
            => Id = Guid.NewGuid();

        public static bool operator ==(Entity x, Entity y)
        {
            if (ReferenceEquals(x, null) && ReferenceEquals(y, null)) return true;
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;
            return x.Equals(y);
        }

        public static bool operator !=(Entity x, Entity y)
            => !(x == y);

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Entity;
            return Equals(other);
        }
    }
}

namespace Homo.DependencyInjection
{
    public class ObjectAccessor<T>
    {
        public T Value { get; set; }

        public ObjectAccessor()
        {
        }

        public ObjectAccessor(T value)
        {
            Value = value;
        }
    }
}

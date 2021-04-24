namespace Andef.DependencyInjection
{
    public class ObjectAccessor<T>
    {
        public ObjectAccessor()
        {

        }

        public ObjectAccessor(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
    }
}

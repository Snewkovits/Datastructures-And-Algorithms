namespace University.Lists.Utils
{
    public class Element<T>
    {
        public T Data;
        public Element<T>? Pointer = null;
    }

    public class MultiElement<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;
        public MultiElement<TKey, TValue>? Pointer;
    }
}

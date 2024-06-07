using University.Lists.Utils;

namespace University.Lists
{
    internal class MultiList<TKey, TValue>
    {
        public MultiElement<TKey, TValue> Head;

        public MultiList()
        {
            Head = new MultiElement<TKey, TValue>();
            Head.Pointer = null;
        }

        public TValue this[TKey key]
        {
            get
            {
                if (Head.Pointer == null)
                    throw new InvalidOperationException("This list is empty.");
                MultiElement<TKey, TValue> element = Head.Pointer;
                while (!element.Key.Equals(key))
                {
                    if (element.Pointer != null)
                        element = element.Pointer;
                    else
                        throw new KeyNotFoundException("Key not fount.");
                }
                return element.Value;
            }
            set
            {
                if (Head.Pointer != null)
                {
                    MultiElement<TKey, TValue> sElement = Head.Pointer;
                    while (sElement.Pointer != null)
                    {
                        if (sElement.Key.Equals(key))
                        {
                            sElement.Value = value;
                            return;
                        }
                        sElement = sElement.Pointer;
                    }
                }

                MultiElement<TKey, TValue> element = new MultiElement<TKey, TValue>();
                element.Value = value;
                element.Key = key;
                GetLast().Pointer = element;
            }
        }

        public int Count
        {
            get
            {
                int index = 0;
                if (Head.Pointer == null)
                    return index;
                MultiElement<TKey, TValue> element = Head.Pointer;
                while (element.Pointer != null)
                {
                    element = element.Pointer;
                    index++;
                }
                return index + 1;
            }
        }

        public void Add(TKey key, TValue value)
        {
            MultiElement<TKey, TValue> element = new MultiElement<TKey, TValue>();
            element.Value = value;
            element.Key = key;
            GetLast().Pointer = element;
        }

        MultiElement<TKey, TValue> GetLast()
        {
            if (Head.Pointer == null)
                return Head;
            MultiElement<TKey, TValue> element = Head.Pointer;
            while (element.Pointer != null)
            {
                element = element.Pointer;
            }
            return element;
        }
    }
}

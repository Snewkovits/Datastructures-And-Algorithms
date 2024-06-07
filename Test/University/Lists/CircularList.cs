using University.Lists.Utils;

namespace University.Lists
{
    class CircularList<T>
    {
        public Element<T> Head;
        public int Count { get
            {
                if (Head.Pointer == null)
                    return 0;
                Element<T> element = Head.Pointer;
                Element<T> firstElement = element;
                int index = 0;
                while (element.Pointer != firstElement)
                {
                    index++;
                    element = element.Pointer;
                }
                return index + 1;
            }
        }

        public T this[int index]
        {
            get
            {
                if (Head.Pointer == null)
                    throw new IndexOutOfRangeException();
                Element<T> element = Head.Pointer;
                for (int i = 0; i < index; i++)
                {
                    element = element.Pointer;
                }
                return element.Data;
            }
            set
            {
                if (Head.Pointer == null)
                    throw new IndexOutOfRangeException();
                Element<T> element = Head.Pointer;
                for (int i = 0; i < index; i++)
                {
                    element = element.Pointer;
                }
                element.Data = value;
            }
        }

        public CircularList() 
        {
            Head = new Element<T>();
            Head.Pointer = null;
        }

        public void Add(T data)
        {
            Element<T> newElement = new Element<T>();
            newElement.Data = data;
            GetLast().Pointer = newElement;
            newElement.Pointer = Head.Pointer;
        }

        public void Remove(int index)
        {
            if (Head.Pointer == null)
                throw new IndexOutOfRangeException();
            Element<T> element = Head.Pointer;
            Element<T> previus = Head;
            for (int i = 0; i < index; i++)
            {
                previus = element;
                element = element.Pointer;
            }
            previus.Pointer = element.Pointer;
        }

        Element<T> GetLast()
        {
            if (Head.Pointer == null)
                return Head;
            Element<T> element = Head.Pointer;
            Element<T> firstElement = element;
            if (firstElement.Pointer == firstElement)
                return firstElement;

            while (firstElement != element.Pointer)
                element = element.Pointer;

            return element;
        }

        public string ToString(string separator)
        {
            string data = string.Empty;
            if (Head.Pointer == null)
                return data;
            Element<T> element = Head.Pointer;
            Element<T> firstElement = element;
            if (firstElement.Pointer == firstElement)
                return $"{firstElement.Data}";
            while (firstElement != element.Pointer)
            {
                data += $"{element.Data}{separator}";
                element = element.Pointer;
            }
            data += $"{element.Data}";
            return data;
        }
    }
}

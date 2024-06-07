using University.Lists.Utils;

namespace University.Lists
{
    internal class ChainedList<T>
    {
        public T this[int index]
        {
            get
            {
                if (index < 0)
                    throw new ArgumentOutOfRangeException("index");
                if (Head.Pointer == null)
                    throw new IndexOutOfRangeException();
                Element<T> element = Head.Pointer;
                for (int i = 0; i < index; i++)
                {
                    if (element.Pointer != null)
                    {
                        element = element.Pointer;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
                return element.Data;
            }
            set
            {
                if (index < 0)
                    throw new ArgumentOutOfRangeException("index");
                if (Head.Pointer == null)
                    throw new IndexOutOfRangeException();
                Element<T> element = Head.Pointer;
                for (int i = 0; i < index; i++)
                {
                    if (element.Pointer != null)
                    {
                        element = element.Pointer;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
                element.Data = value;
            }
        }
        public int Count { get {
                Element<T> element = Head;
                int index = 0;
                while (element.Pointer != null) 
                {
                    index++;
                    element = element.Pointer;
                }
                return index;
            } 
        }
        public Element<T> Head { get; set; }
        public ChainedList()
        {
            Head = new Element<T>();
            Head.Pointer = null;
        }

        public void Remove(int index)
        {
            if (Head.Pointer == null)
                throw new ArgumentOutOfRangeException("index");

            Element<T> element = Head.Pointer;
            Element<T> previus = Head;
            for (int i = 0; i < index; i++)
            {
                if (element.Pointer == null)
                    throw new ArgumentOutOfRangeException("index");

                previus = element;
                element = element.Pointer;
            }
            if (element.Pointer == null)
                throw new ArgumentOutOfRangeException("index");

            element = element.Pointer;
            previus.Pointer = element;
        }

        public void Add(T data)
        {
            Element<T> element = GetLast();
            element.Pointer = new Element<T>();
            element.Pointer.Data = data;
            element.Pointer.Pointer = null;
        }

        Element<T> GetLast()
        {
            Element<T> element = Head;
            while (element.Pointer != null)
                element = element.Pointer;
            return element;
        }

        public string ToString(string separator)
        {
            if (Head.Pointer == null)
                return string.Empty;
            Element<T> element = Head.Pointer;
            string data = string.Empty;
            while (element.Pointer != null)
            {
                data += $"{element.Data}{separator}";
                element = element.Pointer;
            }
            data += element.Data;
            return data;
        }

    }
}

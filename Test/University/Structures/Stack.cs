namespace University.Structures
{
    class Stack<T>
    {
        Node<T> head;
        public Stack()
        {
            head = new Node<T>();
        }

        public bool Empty()
        {
            if (peek().Equals(head))
                return true;
            return false;
        }

        public void Push(T data)
        {
            peek().pointer = new Node<T>() { data = data, pointer = null };
        }

        Node<T> peek()
        {
            if (head.pointer == null)
                return head;
            Node<T> pointer = head.pointer;
            while (pointer != null)
                pointer = pointer.pointer;
            return pointer;
        }

        public string Peek()
        {
            if (head.pointer == null)
                throw new NullReferenceException();
            Node<T> pointer = head.pointer;
            while (pointer != null)
                pointer = pointer.pointer;
            return pointer.data.ToString();
        }

        public int Search(T data)
        {

            int index = -1;
            if (head.pointer == null)
                return index;
            Node<T> pointer = head.pointer;
            while (pointer != null)
            {
                if (pointer.data.Equals(data))
                    break;
                index++;
                pointer = pointer.pointer;
            }
            return index;
        }
    }

    class Node<T>
    {
        public T data;
        public Node<T>? pointer;
    }
}

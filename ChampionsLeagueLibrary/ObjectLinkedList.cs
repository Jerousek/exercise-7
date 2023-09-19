using System.Collections;

namespace ChampionsLeagueLibrary
{
    public class ObjectLinkedList : ICollection, IEnumerable, IList
    {
        private Node? head;

        internal class Node
        {
            public object? Data { get; set; }
            public Node? Next { get; set; }
            public Node? Prev { get; set; }

        }

        public ObjectLinkedList()
        {
            head = null;
            Count = 0;
        }

        public object? this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                {
                    return null;
                }
                else
                {
                    Node? current = head;
                    for (int i = 0; i < index; i++)
                    {
                        current = current.Next;
                    }
                    return current.Data;
                }
            }
            set
            {

                if (index >= Count || index < 0)
                {
                    return;
                }
                else
                {
                    Node current = head;
                    for (int i = 0; i < index; i++)
                    {
                        current = current.Next;
                    }
                    current.Data = value;
                }
            }
        }

        public int Count { get; set; }

        public bool IsSynchronized => false;

        public object SyncRoot => this;

        public bool IsFixedSize => false;

        public bool IsReadOnly => false;

        public int Add(object? value)
        {
            try
            {
                Insert(Count, value);
                return IndexOf(value);
            }
            catch
            {
                return -1;
            }
        }

        public void Clear()
        {
            if (head != null)
            {
                head.Next = null;
                head = null;
                Count = 0;
            }
        }

        public bool Contains(object? value)
        {
            return IndexOf(value) >= 0;
        }

        public void CopyTo(Array array, int index)
        {
            for (int i = index; i < Count + index; i++)
            {
                array.SetValue(this[i - index], i);
            }
        }

        public IEnumerator GetEnumerator()
        {

            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }

        }

        public int IndexOf(object? value)
        {
            Node current = head;
            for (int i = 0; i < Count; i++)
            {
                if (current.Data == value)
                {
                    return i;
                }
                current = current.Next;
            }
            return -1;
        }

        public void Insert(int index, object? value)
        {
            if (index < 0)
            {
                return;
            }
            else if (index > Count)
            {
                return;
            }
            else
            {
                Node current = head;
                Node newNode = new Node();
                newNode.Data = value;

                if (Count == 0)
                {
                    newNode.Prev = null;
                    newNode.Next = null;
                    head = newNode;
                }
                else if (index == 0 && Count != 0)
                {
                    newNode.Next = head;
                    head.Prev = newNode;
                    head = newNode;
                }
                else if (Count == index)
                {
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }
                    current.Next = newNode;
                    newNode.Prev = current;
                }
                else
                {
                    for (int i = 0; i < index; i++)
                    {
                        current = current.Next;
                    }

                    newNode.Prev = current.Prev;
                    newNode.Next = current;
                    current.Prev.Next = newNode;
                    current.Prev = newNode;
                }




                Count++;
            }
        }

        public void Remove(object? value)
        {
            if (IndexOf(value) == -1)
            {
                return;
            }
            else
            {
                Node current = head;

                if (Count == 1)
                {
                    Clear();
                    return;
                }
                else if (IndexOf(value) == 0 && Count > 1)
                {
                    head.Next.Prev = null;
                    head = head.Next;
                    head.Prev = null;
                }
                else if (Count - 1 == IndexOf(value))
                {
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }
                    current.Prev.Next = null;
                    current.Prev = null;
                }
                else
                {
                    for (int i = 0; i < IndexOf(value); i++)
                    {
                        current = current.Next;
                    }
                    current.Next.Prev = current.Prev;
                    current.Prev.Next = current.Next;
                    current.Prev = null;
                    current.Next = null;

                }

                Count--;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0)
            {
                return;
            }
            else if (index >= Count)
            {
                return;
            }
            else
            {
                Node current = head;


                if (Count == 1)
                {
                    Clear();
                    return;
                }
                else if (index == 0 && Count > 1)
                {
                    head.Next.Prev = null;
                    head = head.Next;
                    head.Prev = null;
                }
                else if (Count - 1 == index)
                {
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }
                    current.Prev.Next = null;
                    current.Prev = null;
                }
                else
                {
                    for (int i = 0; i < index; i++)
                    {
                        current = current.Next;
                    }
                    current.Next.Prev = current.Prev;
                    current.Prev.Next = current.Next;
                    current.Prev = null;
                    current.Next = null;

                }

                Count--;
            }
        }
    }
}

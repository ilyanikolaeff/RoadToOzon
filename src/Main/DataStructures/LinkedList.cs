using System.Collections;

namespace Main.DataStructures
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T>? _head;
        private Node<T>? _tail;
        private int _count;

        /// <summary>
        /// Добавление элемента в список
        /// </summary>
        /// <param name="value">Значение элемента</param>
        public void Add(T value)
        {
            // Создаем новый элемент, который будем добавлять
            var node = new Node<T>(value);

            // Если список пустой, то назначаем головному узлу - созданный узел
            if (_head == null)
                _head = node;
            // Иначе присваем следующему элементу конечного
            else
                _tail!.Next = node;

            // Обновляем конечный элемент - он теперь указывает но добавленный узел
            _tail = node;
            _count++;
        }

        /// <summary>
        /// Удаление элемента из списк
        /// </summary>
        /// <param name="value">Удаляемый элемент</param>
        /// <returns>true - элемент удалось найти, false - эдемент не найден</returns>
        public bool Remove(T value)
        {
            Node<T>? current = _head;
            Node<T>? previous = null;

            while (current != null && current.Value != null)
            {
                if (current.Value.Equals(value))
                {
                    // Если узел в середине или конце
                    if (previous != null)
                    {
                        // Меняем ссылку предыдущего узла на следующий текущего
                        // (prev) -> (current) -> (current.Next)
                        //               X
                        previous.Next = current.Next;

                        // Если узел последний, то меняем _tail
                        if (current.Next == null)
                            _tail = previous;
                    }
                    // Удаляется узел в начале
                    else
                    {
                        _head = _head?.Next;

                        if (_head == null)
                            _tail = null;
                    }

                    _count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Количество элементов в списке
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Флаг содержит ли список элементы
        /// </summary>
        public bool IsEmpty => _count == 0;

        /// <summary>
        /// Очистить список
        /// </summary>
        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        /// <summary>
        /// Проверка содержит ли список такой элемент
        /// </summary>
        /// <param name="value">Проверяемое значени</param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            Node<T>? current = _head;
            while (current != null && current.Value != null)
            {
                if (current.Value.Equals(value))
                    return true;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Добавление элемента в начало списка
        /// </summary>
        /// <param name="data"></param>
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = _head;
            _head = node;
            if (_count == 0)
                _tail = _head;
            _count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}

using System;

public class HashTable<TKey, TValue>
{
    private struct Entry
    {
        public bool IsOccupied;
        public TKey Key;
        public TValue Value;
    }

    private readonly Entry[] _entries;
    private readonly int _capacity;

    public HashTable(int capacity)
    {
        _capacity = capacity;
        _entries = new Entry[capacity];
    }

    private int GetIndex(TKey key)
    {
        int hash = Math.Abs(key.GetHashCode());
        int index = hash % _capacity;
        int originalIndex = index;

        while (_entries[index].IsOccupied && !_entries[index].Key.Equals(key))
        {
            index = (index + 1) % _capacity;
            if (index == originalIndex)
                throw new InvalidOperationException("Хеш-таблица переполнена.");
        }

        return index;
    }

    public void Add(TKey key, TValue value)
    {
        int index = GetIndex(key);
        if (_entries[index].IsOccupied)
            throw new ArgumentException("Элемент с таким ключом уже существует.");

        _entries[index] = new Entry { IsOccupied = true, Key = key, Value = value };
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        int index = GetIndex(key);
        if (_entries[index].IsOccupied)
        {
            value = _entries[index].Value;
            return true;
        }

        value = default;
        return false;
    }

    public bool Remove(TKey key)
    {
        int index = GetIndex(key);
        if (!_entries[index].IsOccupied)
            return false;

        _entries[index].IsOccupied = false;
        _entries[index].Key = default;
        _entries[index].Value = default;
        return true;
    }

    public void Display()
    {
        Console.WriteLine("Содержимое хеш-таблицы:");
        for (int i = 0; i < _capacity; i++)
        {
            if (_entries[i].IsOccupied)
                Console.WriteLine($"Индекс: {i}, Ключ: {_entries[i].Key}, Значение: {_entries[i].Value}");
        }
    }
}
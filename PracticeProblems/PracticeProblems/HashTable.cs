using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{
    public abstract class HasHash
    {
        public abstract int GetHashCode();
    }

    public class Elements : HasHash
    {
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }


    public class HashTable<T>
        where T: HasHash
    {
        private Entry[] _table;
        private int _tableSize;

        public class Entry
        {
            private readonly T _value;
            private readonly int _key;

            public Entry(T value)
            {
                _key = value.GetHashCode();
                _value = value;
            }

            public int Key => _key;

            public T Value => _value;
        }

        /// <summary>
        /// Hash table 
        /// </summary>
        /// <param name="tableSize"></param>
        public HashTable(int tableSize = 128)
        {
            _table = new Entry[tableSize];
            _tableSize = tableSize;
        }

        public void Add(T elm)
        {
            var entry = new Entry(elm);
            var key = entry.Key;
            var hash = key % _tableSize;

            //Open adressing 
            while (_table[hash] != null && _table[hash].Key != key)
                hash = key % _tableSize;

            //Key already there
            if (_table[hash].Key == key)
                throw new Exception("Key already there");

            //Add key 
            _table[hash] = entry;
        }

        public bool Contains(T elm)
        {
            var key = elm.GetHashCode();
            var hash = key % _tableSize;
            
            //Conflict resolution scheme 
            while (_table[hash] != null && _table[hash].Key != key)
                hash = key % _tableSize;

            //Return if key not found 
            if (_table[hash] == null) return false;
            return true;
        }

        public void Remove(T elm)
        {
        }
    }
}

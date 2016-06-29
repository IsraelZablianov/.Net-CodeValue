using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    public class MultiDictionary<K, V> : IMultiDictionary<K, V>, IEnumerable<KeyValuePair<K, V>>
    {
        private Dictionary<K, LinkedList<V>> m_Dictionary;
        public MultiDictionary()
        {
            m_Dictionary = new Dictionary<K, LinkedList<V>>();
        }

        public int Count
        {
            get
            {
                List<V> returnedList = new List<V>();
                foreach (var list in m_Dictionary.Values)
                {
                    returnedList.AddRange(list);
                }

                return returnedList.Count;
            }
        }

        public ICollection<K> Keys
        {
            get
            {
                return m_Dictionary.Keys;
            }
        }

        public ICollection<V> Values
        {
            get
            {
                List<V> returnedList = new List<V>();
                foreach (var list in m_Dictionary.Values)
                {
                    returnedList.AddRange(list);
                }

                return returnedList;
            }
        }

        public void Add(K key, V value)
        {
            if(!m_Dictionary.ContainsKey(key))
            {
                LinkedList<V> list = new LinkedList<V>();
                list.AddLast(value);
                m_Dictionary.Add(key, list);
            }
            else
            {
                m_Dictionary[key].AddLast(value);
            }
        }

        public void Clear()
        {
            m_Dictionary.Clear();
        }

        public bool Contains(K key, V value)
        {
            bool contains = false;
            if(m_Dictionary.ContainsKey(key))
            {
                if(m_Dictionary[key].Contains(value))
                {
                    contains = true;
                }
            }

            return contains;
        }

        public bool ContainsKey(K key)
        {
            return m_Dictionary.ContainsKey(key);
        }

        public bool Remove(K key)
        {
            bool success = false;
            if (m_Dictionary.ContainsKey(key))
            {
                success = true;
                m_Dictionary.Remove(key);
                //m_Dictionary[key].Clear();               
            }

            return success;
        }

        public bool Remove(K key, V value)
        {
            bool success = false;
            if(m_Dictionary.ContainsKey(key))
            {
                LinkedList<V> list = m_Dictionary[key];
                if(list.Contains(value))
                {
                    success = true;
                    list.Remove(value);
                }
            }

            return success;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            List<KeyValuePair<K, V>> returnedEnumerator = new List<KeyValuePair<K, V>>();
            foreach (var entry in m_Dictionary)
            {
                foreach (var value in entry.Value)
                {
                    returnedEnumerator.Add(new KeyValuePair<K, V>(entry.Key, value));
                }
            }

            return returnedEnumerator.GetEnumerator();
        }
    }
}

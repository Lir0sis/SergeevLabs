using System;
using System.Collections.Generic;

namespace Hashmap {
	class KeyValue<KeyType, ValueType> {
		public KeyValue(KeyType key, ValueType value) {
			Key = key;
			Value = value;
		}
		public KeyType Key { get; set; }
		public ValueType Value { get; set; }

		public override bool Equals(Object obj) {
			if (obj == null || !(obj is KeyValue<KeyType, ValueType>))
				return false;
			else
				return (Key.Equals( ((KeyValue<KeyType, ValueType>)obj).Key) ) && (Value.Equals(((KeyValue<KeyType, ValueType>)obj).Value));
		}
	}
	class HashmapOpen<KeyType, ValueType> {
		public HashmapOpen(int size = 1024) {
			m_size = size;
			m_buckets = new List<KeyValue<KeyType, ValueType>>[size];
			for (int i = 0; i < size; i++) {
				m_buckets[i] = new List<KeyValue<KeyType, ValueType>>();
			}
		}
		public void Add(KeyType key, ValueType value) {
			var i = GetIndex(key);
			var kv = new KeyValue<KeyType, ValueType>(key, value);
			if (!m_buckets[i].Contains(kv)) m_buckets[i].Add(kv);
		}
		public void Remove(KeyType key) {
			m_buckets[GetIndex(key)].RemoveAll((KeyValue<KeyType, ValueType> kv) => { return key.Equals(kv.Key); });
		}
		public KeyValue<KeyType, ValueType> Find(KeyType key) {
			return m_buckets[GetIndex(key)].Find((KeyValue<KeyType, ValueType> kv) => { return key.Equals(kv.Key); });
		}

		private int GetIndex(KeyType key) {
			return key.GetHashCode() % m_size;
		}

		private List<KeyValue<KeyType, ValueType>>[] m_buckets;
		private int m_size;
	}
	class HashmapClosed<KeyType, ValueType> {
		const int BAD_INDEX = -1;
		public HashmapClosed(int size = 512) {
			m_size = size;
			m_buckets = new KeyValue<KeyType, ValueType>[size];
		}
		public void Add(KeyType key, ValueType value) {
			var i = Probe(key);
			if (i != BAD_INDEX) m_buckets[i] = new KeyValue<KeyType, ValueType>(key, value);
			else {
				Resize(m_size * 2);
				m_buckets[Probe(key)] = new KeyValue<KeyType, ValueType>(key, value);
			}
		}
		public void Remove(KeyType key) {
			var i = Probe(key);
			if (i != BAD_INDEX) m_buckets[i] = null;
		}
		public KeyValue<KeyType, ValueType> Find(KeyType key) {
			var i = Probe(key);
			if (i != BAD_INDEX) return m_buckets[i];
			else return null;
		}
		private int Probe(KeyType key) {
			for (var i = GetRawIndex(key); i < m_size; i++) {
				if (m_buckets[i] == null || key.Equals(m_buckets[i].Key)) return i;
			}
			return BAD_INDEX;
		}
		private int GetRawIndex(KeyType key) {
			return key.GetHashCode() % m_size;
		}
		private void Resize(int size) {
			var map = new HashmapClosed<KeyType, ValueType>(size);
			foreach(var kv in m_buckets) {
				map.Add(kv.Key, kv.Value);
			}
			m_buckets = map.m_buckets;
			m_size = map.m_size;
		}

		private KeyValue<KeyType, ValueType>[] m_buckets;
		private int m_size;
	}
}

using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace BillyNaCl.QQGroupToolkit
{
    internal class OptionArg : IDictionary<string, List<string>>
    {
        Dictionary<string, List<string>> dict = [];

        public List<string> this[string key] { get => ((IDictionary<string, List<string>>)dict)[key]; set => ((IDictionary<string, List<string>>)dict)[key] = value; }

        public ICollection<string> Keys => ((IDictionary<string, List<string>>)dict).Keys;

        public ICollection<List<string>> Values => ((IDictionary<string, List<string>>)dict).Values;

        public int Count => ((ICollection<KeyValuePair<string, List<string>>>)dict).Count;

        public bool IsReadOnly => ((ICollection<KeyValuePair<string, List<string>>>)dict).IsReadOnly;

        public void Add(string key, List<string> value)
        {
            ((IDictionary<string, List<string>>)dict).Add(key, value);
        }

        public void Add(KeyValuePair<string, List<string>> item)
        {
            ((ICollection<KeyValuePair<string, List<string>>>)dict).Add(item);
        }

        public void Clear()
        {
            ((ICollection<KeyValuePair<string, List<string>>>)dict).Clear();
        }

        public bool Contains(KeyValuePair<string, List<string>> item)
        {
            return ((ICollection<KeyValuePair<string, List<string>>>)dict).Contains(item);
        }

        public bool ContainsKey(string key)
        {
            return ((IDictionary<string, List<string>>)dict).ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, List<string>>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<string, List<string>>>)dict).CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<string, List<string>>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, List<string>>>)dict).GetEnumerator();
        }

        public bool Remove(string key)
        {
            return ((IDictionary<string, List<string>>)dict).Remove(key);
        }

        public bool Remove(KeyValuePair<string, List<string>> item)
        {
            return ((ICollection<KeyValuePair<string, List<string>>>)dict).Remove(item);
        }

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out List<string> value)
        {
            return ((IDictionary<string, List<string>>)dict).TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)dict).GetEnumerator();
        }
    }
}

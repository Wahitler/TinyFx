using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.Extensions.EPPlus
{
    public class HeaderMapConfigCollection : IEnumerable<HeaderMapConfig>
    {
        private SortedDictionary<int, HeaderMapConfig> _configs = new SortedDictionary<int, HeaderMapConfig>();
        private Dictionary<string, int> _titles = new Dictionary<string, int>();
        public HeaderMapConfig this[int index] => _configs[index];
        public HeaderMapConfig this[string title]=> _configs[_titles[title]];
        public bool ContainsIndex(int columnIndex) => _configs.ContainsKey(columnIndex);
        public bool ContainsTitle(string title) => _titles.ContainsKey(title);
        public void Add(HeaderMapConfig config)
        {
            _configs.Add(config.ColumnIndex, config);
            if (!string.IsNullOrEmpty(config.Title))
                _titles.Add(config.Title, config.ColumnIndex);
        }
        public int GetIndex(string title) => _titles[title];
        public void Clear()
        {
            _configs.Clear();
            _titles.Clear();
        }
        public IEnumerator<HeaderMapConfig> GetEnumerator()
        {
            foreach (var item in _configs)
                yield return item.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _configs.GetEnumerator();
        }
    }
}

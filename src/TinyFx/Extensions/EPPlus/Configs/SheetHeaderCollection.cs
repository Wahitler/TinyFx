using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.Extensions.EPPlus
{
    /// <summary>
    /// Sheet 中的 Headers 信息, ColumnIndex从1开始
    /// </summary>
    public class SheetHeaderCollection : IEnumerable<(int Index, string Title)>
    {
        private SortedDictionary<int, string> _indexs = new SortedDictionary<int, string>();
        private Dictionary<string, int> _titles = new Dictionary<string, int>();
        public int this[string title] => _titles[title];
        public string this[int index] => _indexs[index];
        public int Count => _indexs.Count;

        public bool Contains(string title) => _titles.ContainsKey(title);
        public bool Contains(int index) => _indexs.ContainsKey(index);
        public void Add(int index, string title)
        {

            _indexs.Add(index, title);
            _titles.Add(title, index);
        }
        public void Remove(int index)
        {
            _titles.Remove(_indexs[index]);
            _indexs.Remove(index);
        }
        public void Remove(string title)
        {
            _indexs.Remove(_titles[title]);
            _titles.Remove(title);
        }
        public void Clear()
        {
            _indexs.Clear();
            _titles.Clear();
        }

        public IEnumerator<(int Index, string Title)> GetEnumerator()
        {
            foreach (var item in _indexs)
                yield return (item.Key, item.Value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _indexs.GetEnumerator();
        }

    }
}

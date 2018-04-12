using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.EntLib.Pinyin
{
    /// <summary>
    /// ����ƴ�������Ϣ�࣬ͨ��PinYinUtil���ȡ
    /// </summary>
    public class WordPinyin : IComparable<WordPinyin>
    {
        private List<PinyinEntity> _pinyins = new List<PinyinEntity>(3); //ƴ����Ϣ����
        private string _hex;    // �ַ������ʮ�����Ʊ�ʾ

        /// <summary>
        /// ��û����ú���
        /// </summary>
        public char Word { get; set; }

        /// <summary>
        /// ���ƴ����Ϣ����
        /// </summary>
        public List<PinyinEntity> Pinyins => _pinyins;

        /// <summary>
        /// ����ַ������ʮ�����Ʊ�ʾ
        /// </summary>
        public string Hex
        {
            get {
                if (string.IsNullOrEmpty(_hex))
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(new char[] { Word });
                    for (int i = 0; i < buffer.Length; i++)
                        _hex += Convert.ToString(buffer[i], 16).ToUpper();
                }
                return _hex;
            }
        }

        /// <summary>
        /// ����Ƿ������
        /// </summary>
        public bool IsMutiPinyin => this._pinyins.Count > 1;
        /// <summary>
        /// ��ú��ֵĶ���������
        /// </summary>
        public int PinyinCount => _pinyins.Count;

        /// <summary>
        /// ��ʾ������Ϣ
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (PinyinEntity info in _pinyins)
            {
                builder.AppendLine(Word + " " + info.ToString());
            }
            return builder.ToString();
        }

        #region IComparable<WordEntity> Members
        /// <summary>
        /// ʵ��IComparable�ӿڣ��ṩ�����ַ������֧��
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(WordPinyin other)
            => Word.CompareTo(other.Word);

        #endregion
    }
}

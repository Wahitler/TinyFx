using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.EntLib.Pinyin
{
    /// <summary>
    /// ƴ����Ϣʵ���࣬����ƴ��������ƴд����������������ƴд
    /// </summary>
    public class PinyinEntity : IComparable<PinyinEntity>
    {
        /// <summary>
        /// ��û�����ƴ��������ƴд��������
        /// </summary>
        public string Pinyin { get; set; }

        /// <summary>
        /// ��û���������
        /// </summary>
        public string Tone { get; set; }
        /// <summary>
        /// ��û�����ƴд
        /// </summary>
        public string Spell { get; set; }

        /// <summary>
        /// Ĭ�Ϲ��캯��
        /// </summary>
        public PinyinEntity()
        { }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="pinyin">ƴ��</param>
        /// <param name="tone">����</param>
        /// <param name="spell">ƴд</param>
        public PinyinEntity(string pinyin, string tone, string spell)
        {
            this.Pinyin = pinyin;
            this.Tone = tone;
            this.Spell = spell;
        }

        /// <summary>
        /// ��дToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("ƴ����{0} ƴд��{1} ������{2}", Pinyin, Spell, Tone);
        }

        #region IComparable<PinyinEntity> Members
        /// <summary>
        /// ʵ��IComparable�ӿڣ��ṩ����ƴд�����֧��
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(PinyinEntity other)
        {
            return string.Compare(this.Spell, other.Spell);
        }

        #endregion
    }
}

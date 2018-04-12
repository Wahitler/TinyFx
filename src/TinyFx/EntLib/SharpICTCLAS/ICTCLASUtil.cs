using SharpICTCLAS;
using System;
using System.Collections.Generic;
using System.Text;
using TinyFx.Configuration;

namespace TinyFx.EntLib.SharpICTCLAS
{
    /// <summary>
    /// ICTCLAS辅助类
    /// </summary>
    public static class ICTCLASUtil
    {
        /// <summary>
        /// 分词
        /// </summary>
        /// <param name="sentence">分词的句子</param>
        /// <param name="nKind">初步切分时分成几种结果</param>
        /// <param name="dictPath">字典所在目录</param>
        /// <returns></returns>
        public static List<WordResult[]> GetSegment(string sentence, int nKind = 1, string dictPath=null)
        {
            var ws = new WordSegment();
            if (string.IsNullOrEmpty(dictPath))
            {
                var config = TinyFxConfigManager.GetConfig<SharpICTCLASConfig>();
                dictPath = config.ResourcePath;
            }
            if (string.IsNullOrEmpty(dictPath))
                throw new ArgumentNullException("dictPath", "未在配置文件中定义字典所在路径,请传入参数。");
            ws.InitWordSegment(dictPath);
            return ws.Segment(sentence, nKind);
        }
    }
}
